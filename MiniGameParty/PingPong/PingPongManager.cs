using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PingPongManager : MonoBehaviourPunCallbacks
{
    const int SET_POINT = 15;
    public TextMeshProUGUI scoreText;
    public GameObject resultPanel;
    public GameObject winText;
    public GameObject loseText;
    public GameObject winByLeftText;
    public Camera theCam;

    public PingPongPlayer myPlayer;
    public List<int> playerList = new List<int>();
    public int playerCount = 0;
    public int camp = -1;

    public int homePoint = 0;
    public int awayPoint = 0;

    public bool gameEnd = false;

    private void Awake()
    {

        foreach (var _player in PhotonNetwork.CurrentRoom.Players)
        {
            if(_player.Value.ActorNumber != PhotonNetwork.LocalPlayer.ActorNumber)
            {
                camp = _player.Value.ActorNumber;
                break;
            }
        }

        if(PhotonNetwork.LocalPlayer.ActorNumber < camp)
        {
            PhotonNetwork.Instantiate("PingPongPlayer", 4.5f * Vector3.up, Quaternion.identity, 0, new object[] { -1 });
            camp = 1;
            theCam.transform.rotation =  Quaternion.Euler(0, 0, 180);
        }
        else
        {
            PhotonNetwork.Instantiate("PingPongPlayer", -4.5f * Vector3.up, Quaternion.identity, 0, new object[] { 1 });
            camp = -1;
        }
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
                if (PhotonNetwork.IsMasterClient)
                {
                    PhotonNetwork.Instantiate("PingPongBall", -2 * Vector3.zero, Quaternion.identity);
                    break;
                }
            }
        }
    }

    public bool UpdateScore()
    {
        scoreText.text = "[³ª] " + homePoint.ToString() + " : " + awayPoint + " [»ó´ë]";
        if (homePoint >= SET_POINT || awayPoint >= SET_POINT)
        {
            if (homePoint > awayPoint)
                winText.SetActive(true);
            else
                loseText.SetActive(true);

            resultPanel.SetActive(true);
            return true;
        }
        return false;
    }

    public void DownLeftBtn()
    {
        if (myPlayer == null)
            return;
        myPlayer.isLeftBtnDowning = true;
    }

    public void UpLeftBtn()
    {
        if (myPlayer == null)
            return;
        myPlayer.isLeftBtnDowning = false;
    }

    public void DownRightBtn()
    {
        if (myPlayer == null)
            return;
        myPlayer.isRightBtnDowning = true;
    }

    public void UpRightBtn()
    {
        if (myPlayer == null)
            return;
        myPlayer.isRightBtnDowning = false;
    }

    public void GoToMenu()
    {
        PhotonNetwork.LeaveRoom();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (gameEnd)
            return;
        winByLeftText.SetActive(true);
        resultPanel.SetActive(true);
    }
}
