using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Player_HP : MonoBehaviour
{
    public PhotonView pv;
    public Slider hpBar;
    public TextMeshProUGUI hpText;
    private CapsuleCollider capsuleCollider;

    const float basicHP = 100;
    float currentHP;
    float maxHP { get { return Player_Info.Instance.additionalHP + basicHP; } }


    private bool isDied = false;


    private void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();

        if (pv && !pv.IsMine)
            return;

        GameManager GM = GameObject.Find("GM").GetComponent<GameManager>();
        hpBar = GM.hpBar;
        hpText = GM.hpText;

        currentHP = maxHP;
        hpBar.value = currentHP / maxHP;
        hpText.text = currentHP.ToString() + "/" + maxHP.ToString();
    }


    public void Hit(int damage, Collider _collider)
    {
        if ((pv != null && !pv.IsMine) || capsuleCollider != _collider)
            return;

        currentHP -= damage;
        UpdateHpBar();
    }



    public void UpdateHpBar()
    {
        if (pv == null || pv.IsMine)
        {
            if (currentHP > maxHP)
                currentHP = maxHP;

            hpBar.value = currentHP / maxHP;
            hpText.text = currentHP.ToString() + "/" + maxHP.ToString();
        }
        if (currentHP <= 0)
        {
            if (isDied == false)
            {
                isDied = true;
                Debug.Log(gameObject.name + " Á×À½");
                if (pv == null)
                    ChangeToRagdollRPC();
                else
                {
                    InDungeonPhotonManager dm = GameObject.Find("GM").GetComponent<InDungeonPhotonManager>();
                    if(dm != null)
                        dm.bossMonster.pv.RPC("DeleteTarget", RpcTarget.All, PhotonNetwork.LocalPlayer);
                    pv.RPC("ChangeToRagdollRPC", RpcTarget.All);
                }
            }
        }
    }

    [PunRPC]
    void ChangeToRagdollRPC()
    {
        GetComponent<ChangeRagdoll>().ChangeToRagdoll();
    }



    public bool GetIsDied()
    {
        return isDied;
    }
}
