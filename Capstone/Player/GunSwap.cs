using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunSwap : MonoBehaviour
{
    /*
     * 
     *         
     *         else if (Input.GetKeyDown(KeyCode.E))
        {
            if (pv)
                pv.RPC("ChangeCurrentGunType();", RpcTarget.All);
            else
                ChangeCurrentGunType();
        }
     */
    PhotonView pv;
    [SerializeField] FirePosSetting firePosSetting;

    [SerializeField] GameObject[] Magazine_objs;
    [SerializeField] GameObject[] gunObjs;

    Animator animator;

    public GunType currentGunType;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        ChangeCurrentGunType();
    }

    private void OnEnable()
    {
        CFirebase.Instance.gunSwapAction += new Action(ChangeCurrentGunType);
    }

    private void OnDisable()
    {
        CFirebase.Instance.gunSwapAction -= new Action(ChangeCurrentGunType);
    }

    [PunRPC]
    public void ChangeCurrentGunType()
    {
        Debug.Log("ChangeCurrentGunType");
        gunObjs[(int)currentGunType].SetActive(false);
        Magazine_objs[(int)currentGunType].SetActive(false);

        currentGunType = Player_Info.Instance.gunType;

        int curIndex = (int)currentGunType;
        gunObjs[curIndex].SetActive(true);
        Magazine_objs[curIndex].SetActive(true);
        firePosSetting.SetLocalPosition(curIndex);

        switch (currentGunType)
        {
            case GunType.Rifle:
                animator.SetFloat("ShootSpeed", 15f);
                break;
            case GunType.Sniper:
                animator.SetFloat("ShootSpeed", 1f);
                break;
        }
    }
}
