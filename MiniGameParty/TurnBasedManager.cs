using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnBasedManager : MonoBehaviourPunCallbacks
{
    protected int totalPlayer = -1;
    public int playerCount = 0;
    public int whoseTurn = -1;
    protected PhotonView pv;
    public Dictionary<int, TurnBasedPlayer> playerDic = new Dictionary<int, TurnBasedPlayer>();
    public List<int> playerList = new List<int>();
    public TurnBasedPlayer myPlayer;
    public bool gameEnd = false;
    protected Camera theCam;

    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip[] audioClips;

    protected virtual void Awake()
    {
        totalPlayer = PhotonNetwork.CurrentRoom.PlayerCount;
        pv = GetComponent<PhotonView>();
        theCam = Camera.main;
        if (PhotonNetwork.IsMasterClient)
            StartCoroutine(CheckAllPlayerLoaded());
    }

    IEnumerator CheckAllPlayerLoaded()
    {
        while (true)
        {
            yield return null;
            if (playerCount == PhotonNetwork.CurrentRoom.PlayerCount)
            {
                Debug.Log("모두 준비됨!");
                pv.RPC("SetPlayerList", RpcTarget.All);
                yield break;
            }
        }
    }

    [PunRPC]
    protected void SetPlayerList()
    {
        playerList.Sort();
        SetInitialOfAllClient();
        if (PhotonNetwork.IsMasterClient)
        {
            SetInitialOfMasterClient();
            int i = 0;
            foreach (var player in playerDic)
            {
                player.Value.pv.RPC("SetInitial", RpcTarget.All, i++);
            }
            TurnToNext();
        }
    }

    public virtual void SetInitialOfAllClient() { }

    public virtual void SetInitialOfMasterClient() { }

    [PunRPC]
    public virtual void TurnToNext() { }

    [PunRPC]
    protected virtual void ShowResult() { }

    // 다른 플레이어가 나감
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (gameEnd)
            return;
        Debug.Log((otherPlayer.ActorNumber) + " 나갔습니다");
        int actorNumOfTurn = playerList[whoseTurn];
        for (int i = 0; i < playerList.Count; i++)
        {
            Debug.Log(i + " : i");
            if (playerList[i] == otherPlayer.ActorNumber)
            {
                Debug.Log((otherPlayer.ActorNumber) + " : If");
                playerList[i] = -1;
                playerDic.Remove(otherPlayer.ActorNumber);
                break;
            }
        }
        playerCount--;
        int alive = 0;
        for(int i =0; i < playerList.Count; i++)
        {
            if (playerList[i] != -1 && !playerDic[playerList[i]].isDied)
                alive++;
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1 || alive <= 1) // 사망까지 추가해야함
        {
            ShowResult();
            return;
        }
        if (PhotonNetwork.IsMasterClient)
        {
            for(int i = 0; i < playerList.Count; i++)
            {
                if (playerList[i] != -1 && playerDic[playerList[i]].isMyTurn)
                    break;
                if(i == playerList.Count - 1)
                {
                    TurnToNext();
                    return;
                }
            }
            if(whoseTurn == -1 || actorNumOfTurn == otherPlayer.ActorNumber)
                TurnToNext();
        }
    }
}
