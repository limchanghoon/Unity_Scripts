using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedPlayer : MonoBehaviour
{
    protected TurnBasedManager GM;
    public PhotonView pv;
    protected Camera theCam;

    public bool isMyTurn = false;
    public bool isDied = false;

    protected virtual void Start()
    {
        pv = GetComponent<PhotonView>();
        theCam = Camera.main;
        if (pv.IsMine)
        {
            GameObject.Find("GM").GetComponent<TurnBasedManager>().myPlayer = this;
            pv.RPC("SaveActorNumbers", RpcTarget.All, PhotonNetwork.LocalPlayer.ActorNumber);
        }
    }

    [PunRPC]
    public void SaveActorNumbers(int index)
    {
        GM = GameObject.Find("GM").GetComponent<TurnBasedManager>();
        GM.playerCount++;
        GM.playerList.Add(index);
        GM.playerDic.Add(index, this);
    }

    [PunRPC]
    public virtual void SetInitial(int idx) { }

    public virtual void StartMyTurn()
    {
        pv.RPC("ChangeIsMyTurn", RpcTarget.All, true);
    }

    [PunRPC]
    public void ChangeIsMyTurn(bool _b)
    {
        isMyTurn = _b;
    }
}
