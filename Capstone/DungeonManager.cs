using System.Collections;
using System.Collections.Generic;
using Photon.Pun;   // 유니티용 포톤 컴포넌트들
using Photon.Realtime;  // 포톤 서비스 관련 라이브러리
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DungeonManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1"; // 게임 버전

    public PhotonView myPhotonView;
    public TextMeshProUGUI connectionInfoText;     // 네트워크 정보를 표시할 텍스트
    public TextMeshProUGUI playerCountInRoomText;   // 룸 접속 버튼오브젝트
    public Button createPartyButton;   // 룸 생성 버튼
    public Button quitPartyButton;   // 룸 생성 버튼
    public Button startButton;   // 게임 시작 버튼
    public GameObject leaveRoomButtonObj;   // 룸 떠나기 버튼오브젝트
    public TextMeshProUGUI playerCountText;
    public TextMeshProUGUI playerNickName;
    public GameObject nickNameInputObj;
    public GameObject nickNameGroup;
    public GameObject nickNameBlock;
    public GameObject roomNameInputObj;

    [Header("LobbyPanel")]
    public GameObject LobbyPanel;
    public InputField RoomInput;
    public Button[] roomCellBtns;
    public Button[] cur_RoomCellBtns;
    public Button PreviousBtn;
    public Button NextBtn;

    List<RoomInfo> myList = new List<RoomInfo>();
    int currentPage = 1, maxPage, multiple;

    // 게임 실행과 동시에 마스터 서버 접속 시도
    void Start()
    {
        // 접속에 필요한 정보(게임 버전) 설정
        PhotonNetwork.GameVersion = gameVersion;
        // 설정한 정보를 가지고 마스터 서버 접속 시도
        PhotonNetwork.ConnectUsingSettings();

        PhotonNetwork.LocalPlayer.NickName = "임시 이름";
        // 룸 생성 버튼을 잠시 비활성화
        createPartyButton.interactable = false;
        quitPartyButton.interactable = false;
        startButton.interactable = false;

        // 접속을 시도 중임을 텍스트로 표시
        connectionInfoText.text = "마스터 서버에 접속중...";
    }

    #region 방리스트 갱신
    // ◀버튼 -2 , ▶버튼 -1 , 셀 숫자
    public void MyListClick(int num)
    {
        if (num == -2) --currentPage;
        else if (num == -1) ++currentPage;
        else 
        {
            if(!PhotonNetwork.InRoom)
                PhotonNetwork.JoinRoom(myList[multiple + num].Name); // 방에서 방 접속하는 경우 고려해야함!!
        }
        MyListRenewal();
    }

    void MyListRenewal()
    {
        // 최대페이지
        maxPage = (myList.Count % roomCellBtns.Length == 0) ? myList.Count / roomCellBtns.Length : myList.Count / roomCellBtns.Length + 1;

        // 이전, 다음버튼
        PreviousBtn.interactable = (currentPage <= 1) ? false : true;
        NextBtn.interactable = (currentPage >= maxPage) ? false : true;

        // 페이지에 맞는 리스트 대입
        multiple = (currentPage - 1) * roomCellBtns.Length;
        for (int i = 0; i < roomCellBtns.Length; i++)
        {
            roomCellBtns[i].interactable = (multiple + i < myList.Count) ? true : false;
            string str = (multiple + i < myList.Count) ? 
                myList[multiple + i].Name +"\n" + myList[multiple + i].PlayerCount + "/" + myList[multiple + i].MaxPlayers : "";
            roomCellBtns[i].transform.GetChild(0).GetComponent<Text>().text = str;
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        
        Debug.Log("OnRoomListUpdate is called");
        int roomCount = roomList.Count;
        for (int i = 0; i < roomCount; i++)
        {
            if (!roomList[i].RemovedFromList)
            {
                if (!myList.Contains(roomList[i])) myList.Add(roomList[i]);
                else myList[myList.IndexOf(roomList[i])] = roomList[i];
            }
            else if (myList.IndexOf(roomList[i]) != -1) myList.RemoveAt(myList.IndexOf(roomList[i]));
        }
        MyListRenewal();
    }
    #endregion

    // 마스터 서버 접속 성공시 자동 실행
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        myList.Clear();
        MyListRenewal();
        // 룸 접속 버튼을 활성화
        //joinButtonObj.SetActive(true);
        createPartyButton.interactable = true;
        //nickNameInputObj.SetActive(true);
        //roomNameInputObj.SetActive(true);
        // 접속 정보 표시
        //playerCountInRoomText.text = "";
        if (connectionInfoText.text != "중복된 닉네임으로 입장 실패.")
        {
            connectionInfoText.text = "온라인 : 마스터 서버와 연결됨";
        }
        // 접속 로그 표시
        Debug.Log("마스터 서버에 연결됨");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("로비 접속 완료.");
    }

    // 마스터 서버 접속 실패시 자동 실행
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("마스터 서버 재접속 시도.");
        // 마스터 서버로의 재접속 시도
        PhotonNetwork.ConnectUsingSettings();
    }

    public void CreateRoom()
    {
        // 중복 접속 시도를 막기 위해, 접속 버튼 잠시 비활성화
        createPartyButton.interactable = false;
        // 마스터 서버에 접속중이라면
        if (PhotonNetwork.IsConnected)
        {
            // 룸 생성 실행
            connectionInfoText.text = "룸을 생성중...";
            while (true)
            {
                if (PhotonNetwork.CreateRoom("Room " + Random.Range(0, 10000), new RoomOptions { MaxPlayers = 4, IsOpen = true, IsVisible = true }, null))
                {
                    break;
                }
            }

            //PhotonNetwork.JoinOrCreateRoom(RoomInput.text == "" ? "Room" + Random.Range(0, 100) : RoomInput.text, new RoomOptions { MaxPlayers = 4, IsOpen = true, IsVisible = true }, null);
            //PhotonNetwork.CreateRoom(RoomInput.text == "" ? "Room" + Random.Range(0, 100) : RoomInput.text, new RoomOptions { MaxPlayers = 2, IsVisible = true });
            //PhotonNetwork.JoinOrCreateRoom("Room1", new RoomOptions { MaxPlayers = 20 , IsOpen = true, IsVisible = true }, null);
        }
        else
        {
            // 마스터 서버에 접속중이 아니라면, 마스터 서버에 접속 시도
            connectionInfoText.text = "오프라인 : 마스터 서버와 연결되지 않음\n접속 재시도중...";

            // 마스터 서버로의 재접속 시도
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public void LeaveRoom()
    {
        //myPhotonView.RPC("updateUIForLeave", RpcTarget.All,PhotonNetwork.LocalPlayer.NickName);
        //LobbyPanel.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

    public void Play()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        myPhotonView.RPC("allPlayerStart", RpcTarget.All);
    }

    [PunRPC]
    private void allPlayerStart()
    {
        //PhotonNetwork.LoadLevel("Main");
        PhotonNetwork.LoadLevel("SampleScene");
    }

    // 다른 플레이어가 룸 생성중 룸을 만들었기 때문에 실패함; JoinOrCreateRoom 덕분에 필요가 없긴하다
    void OnPhotonCreateRoomFailed()
    {
        // 룸 접속 실행
        connectionInfoText.text = "룸에 접속...";
        PhotonNetwork.JoinRoom("Room1");
    }

    // (빈 방이 없어 Or 꽉참) 룸 참가에 실패한 경우 자동 실행
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnPhotonJoinRoomFailed");
        // 접속 상태 표시
        connectionInfoText.text = "입장에 실패했습니다.";
        // 접속 실패후 접속 버튼 활성화
        //joinButtonObj.SetActive(true);
        //joinButton.interactable = true;
        //PhotonNetwork.JoinOrCreateRoom("Room1", new RoomOptions { MaxPlayers = 3 },null);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // 반장이 바뀌면 준비에서 시작으로 변경! 해당 상태도 준비상태에서 해제해야함!!!
            connectionInfoText.text = "방 참가 성공(방장) / 당신의 닉네임 : " + PhotonNetwork.LocalPlayer.NickName;
            startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "시작";
            //startButtonObj.SetActive(true);
        }
        else
        {
            connectionInfoText.text = "방 참가 성공(참가자) / 당신의 닉네임 : " + PhotonNetwork.LocalPlayer.NickName;
            startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "준비";
        }
        Debug.Log("방장 바뀜");
        //myPhotonView.RPC("updateUI", RpcTarget.All);
    }

    // 다른 플레이어가 나감
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log(otherPlayer.NickName + " 나갔습니다");
        updateUIForJoin();
        //playerCountText.text = "현재 방 인원수: " + PhotonNetwork.CurrentRoom.PlayerCount;

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        updateUIForJoin();
    }

    // 내가 나감
    public override void OnLeftRoom()
    {
        //leaveRoomButtonObj.SetActive(false);
        //startButtonObj.SetActive(false);
        quitPartyButton.interactable = false;
        startButton.interactable = false;
        createPartyButton.interactable|= true;
        Debug.Log("내가 방 나감!");
        for (int i = 0; i < cur_RoomCellBtns.Length; i++)
        {
            cur_RoomCellBtns[i].transform.GetChild(0).GetComponent<Text>().text = "";
            // 다른 정보 추가 하면 그것도 삭제 해줘!
        }
        startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "---";
    }


    // 룸에 참가 완료된 경우 자동 실행
    public override void OnJoinedRoom()
    {
        //myPhotonView.RPC("updateUIForJoin", RpcTarget.All, playerNickName.text);

        //PhotonNetwork.LocalPlayer.NickName = playerNickName.text;
        //LobbyPanel.SetActive(false);
        // 접속 상태 표시
        //nickNameInputObj.SetActive(false);
        //roomNameInputObj.SetActive(false);
        //joinButtonObj.SetActive(false);

        /*
        for (int i = 0; i < PhotonNetwork.PlayerListOthers.Length; i++)
        {
            GameObject.Instantiate(nickNameBlock, nickNameGroup.transform).GetComponentInChildren<Text>().text = PhotonNetwork.PlayerList[i].NickName;
        }
        */
        createPartyButton.interactable = false;
        quitPartyButton.interactable = true;
        startButton.interactable = true;

        updateUIForJoin();
        connectionInfoText.text = "방 참가 성공(참가자) / 당신의 닉네임 : " + PhotonNetwork.LocalPlayer.NickName;
        Debug.Log("방 참가 성공");
        if (PhotonNetwork.IsMasterClient)
        {
            startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "시작";
            //startButtonObj.SetActive(true);
            //leaveRoomButtonObj.SetActive(true);
        }
        else
        {
            startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "준비";
            //leaveRoomButtonObj.SetActive(true);
        }
        // 모든 룸 참가자들이 Main 씬을 로드하게 함
        //PhotonNetwork.LoadLevel("Main");
    }
    [PunRPC]
    private void updateUIForJoin()
    {
        if (cur_RoomCellBtns.Length < PhotonNetwork.PlayerList.Length)
            Debug.Log("파티 총 인원이 4명 보다 많음! 버그!!!");
        for (int i = 0; i < cur_RoomCellBtns.Length; i++)
        {
            cur_RoomCellBtns[i].transform.GetChild(0).GetComponent<Text>().text = "";
            // 다른 정보 추가 하면 그것도 삭제 해줘!
        }
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            cur_RoomCellBtns[i].transform.GetChild(0).GetComponent<Text>().text = PhotonNetwork.PlayerList[i].NickName + i;
        }
    }

    /*
    [PunRPC]
    private void updateUIForLeave(string nick)
    {
        GameObject[] nickObjects = GameObject.FindGameObjectsWithTag("Nick");
        for (int i = 0; i < nickObjects.Length; i++)
        {
            if(nickObjects[i].GetComponentInChildren<Text>().text == nick)
            {
                Destroy(nickObjects[i]);
                break;
            }
        }
        int temp = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        playerCountText.text = "현재 방 인원수: " + temp;
    }
    */

    private bool CheckNickName(string nick)
    {
        for (int i = 0; i < PhotonNetwork.PlayerList.Length - 1; i++)
        {
            if (nick == PhotonNetwork.PlayerListOthers[i].NickName) return false;
        }
        return true;
    }

    [ContextMenu("정보")]
    void Info()
    {
        print(PhotonNetwork.InLobby);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
