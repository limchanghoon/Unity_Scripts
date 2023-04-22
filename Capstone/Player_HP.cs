using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_HP : MonoBehaviour
{
    public PhotonView pv;
    public Slider hpBar;

    public float maxHP;
    public float currentHP;

    private void Start()
    {
        currentHP = maxHP;

        if (pv && !pv.IsMine)
            return;

        GameManager GM = GameObject.Find("GM").GetComponent<GameManager>();
        hpBar = GM.hpBar;
        hpBar.value = currentHP / maxHP;

    }

    [ContextMenu("¸ÂÀ½!")]
    public void Hit(int damage)
    {
        if (!pv.IsMine)
            return;
        pv.RPC("Hit_RPC", RpcTarget.All, damage);
    }

    [PunRPC]
    private void Hit_RPC(int damage)
    {
        currentHP -= damage;
        if(pv.IsMine)
            hpBar.value = currentHP / maxHP;
        if (currentHP <= 0)
        {
            Debug.Log(gameObject.name + " Á×À½");
        }
    }
}
