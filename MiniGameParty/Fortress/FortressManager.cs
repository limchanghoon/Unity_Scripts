using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FortressManager : TurnBasedManager
{
    public GameObject btn_canvas;
    public Transform[] spawnPoints;
    public Transform myTurnTextTr;
    public TextMeshProUGUI myTurnText;
    public GameObject resultPanel, winText, loseText;

    protected override void Awake()
    {
        PhotonNetwork.Instantiate("FortressPlayer", Vector3.zero, Quaternion.identity);
        base.Awake();
    }

    [PunRPC]
    public override void TurnToNext()
    {
        if (!PhotonNetwork.IsMasterClient)
            return;
        int count = 0;
        for (int i = 0; i < playerList.Count; i++)
        {
            if (playerList[i] != -1 && !playerDic[playerList[i]].isDied)
                count++;
        }
        if(count <= 1)
        {
            pv.RPC("ShowResult", RpcTarget.All);
            return;
        }

        StartCoroutine(TurnToNextCoroutine());
    }



    IEnumerator TurnToNextCoroutine()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            yield return null;
            int i = 0;
            for (; i < playerList.Count; i++)
            {
                if (playerList[i] != -1 && !((FortressPlayer)playerDic[playerList[i]]).isStop)
                    break;
            }
            if (i == playerList.Count)
                break;
        }
        pv.RPC("SetTurn", RpcTarget.All, GetNextTurn());
    }

    int GetNextTurn()
    {
        int tmp = whoseTurn;
        do
        {
            tmp = (tmp + 1) % playerList.Count;
            if(tmp == whoseTurn)
            {
                Debug.Log("Can not turn to next!");
                break;
            }
        } while (playerList[tmp] == -1 || playerDic[playerList[tmp]].isDied);
        return tmp;
    }

    [PunRPC]
    void SetTurn(int _idx)
    {
        whoseTurn = _idx;
        if (playerDic[playerList[whoseTurn]].pv.IsMine)
        {
            theCam.transform.position = new Vector3(playerDic[playerList[whoseTurn]].transform.position.x, playerDic[playerList[whoseTurn]].transform.position.y, -10);
            StartCoroutine(StartMyTurnCoroutine());
        }
    }

    IEnumerator StartMyTurnCoroutine()
    {
        myTurnTextTr.gameObject.SetActive(true);
        myTurnTextTr.localScale = Vector3.zero;
        float c = 0f;
        while (c<1f)
        {
            c = c + Time.deltaTime > 1f ? 1f : c + Time.deltaTime;
            myTurnTextTr.localScale = new Vector3(c, c, c);
            myTurnText.alpha = 1f - c;
            yield return null;
        }
        myTurnTextTr.gameObject.SetActive(false);
        playerDic[playerList[whoseTurn]].StartMyTurn();
    }

    [PunRPC]
    protected override void ShowResult()
    {
        gameEnd = true;
        resultPanel.SetActive(true);
        if(myPlayer.isDied)
            loseText.SetActive(true);
        else
            winText.SetActive(true);
    }

    public void GoToMenu()
    {
        PlayClip(2);
        PhotonNetwork.LeaveRoom();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
    }

    public void PlayClip(int i)
    {
        audioSource.clip = audioClips[i];
        audioSource.Play();
    }

}
