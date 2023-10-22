using System.Collections;
using System.Collections.Generic;
using Photon.Pun;   // 유니티용 포톤 컴포넌트들
using Photon.Realtime;  // 포톤 서비스 관련 라이브러리
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class DungeonManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1"; // 게임 버전

    public PhotonView myPhotonView;
    public TextMeshProUGUI connectionInfoText;     // 네트워크 정보를 표시할 텍스트
    public Button createPartyButton;   // 룸 생성 버튼
    public Button quitPartyButton;   // 룸 나가기 버튼
    public Button startButton;   // 게임 시작(준비) 버튼
    public GameObject createPanel;
    public GameObject chatPanel;
    public TMP_InputField roomNameInputField;
    public TMP_InputField chatInputField;
    public ContentSizeFitter chatCSF;
    public Transform chatListTr;
    public GameObject chatBlock;
    public Scrollbar chatScrollbar;
    public TMP_Dropdown dropdown;
    public TextMeshProUGUI bossName;
    public TextMeshProUGUI roomName;


    public GameObject roomListPanel;
    public Button[] roomCellBtns;
    public Transform[] cur_RoomCells;
    public Player[] playersOfCell;
    public Button PreviousBtn;
    public Button NextBtn;

    List<RoomInfo> myList = new List<RoomInfo>();
    int currentPage = 1, maxPage, multiple;

    // 게임 실행과 동시에 마스터 서버 접속 시도
    void Start()
    {
        roomNameInputField.onSubmit.AddListener(delegate { CreateRoom(); });
        chatInputField.onSubmit.AddListener(delegate { SendChatting(); });

        playersOfCell = new Player[cur_RoomCells.Length];

        if (PhotonNetwork.InRoom)
        {
            OnJoinedRoom();
            if(PhotonNetwork.IsMasterClient)
                PhotonNetwork.CurrentRoom.IsOpen = true;
            return;
        }
        else if (PhotonNetwork.InLobby)
        {
            OnConnectedToMaster();
            return;
        }

        //CFirebase.Instance.ReadUserData();
        // 접속에 필요한 정보(게임 버전) 설정
        PhotonNetwork.GameVersion = gameVersion;
        // 설정한 정보를 가지고 마스터 서버 접속 시도
        PhotonNetwork.ConnectUsingSettings();

        PhotonNetwork.LocalPlayer.NickName = Player_Info.Instance.nickName;
        
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
            roomCellBtns[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str;
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

        createPartyButton.interactable = true;

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

    public void ActiveTrueCreatePanel()
    {
        createPanel.SetActive(true);
        roomListPanel.SetActive(false);

        roomNameInputField.ActivateInputField();
    }

    public void ActiveFalseCreatePanel()
    {
        createPanel.SetActive(false);
        roomListPanel.SetActive(true);
    }

    public void CreateRoom()
    {
        createPanel.SetActive(false);

        // 중복 접속 시도를 막기 위해, 접속 버튼 잠시 비활성화
        createPartyButton.interactable = false;
        // 마스터 서버에 접속중이라면
        if (PhotonNetwork.IsConnected)
        {
            // 룸 생성 실행
            connectionInfoText.text = "룸을 생성중...";
            while (true)
            {
                if (PhotonNetwork.CreateRoom(roomNameInputField.text, new RoomOptions { MaxPlayers = 4, IsOpen = true, IsVisible = true }, null))
                {
                    roomNameInputField.text = "";
                    ChangeBossRPC(dropdown.value);
                    break;
                }
            }
        }
        else
        {
            // 마스터 서버에 접속중이 아니라면, 마스터 서버에 접속 시도
            connectionInfoText.text = "오프라인 : 접속 재시도중...";

            // 마스터 서버로의 재접속 시도
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void Play()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; ++i)
            {
                if (PhotonNetwork.PlayerList[i] != PhotonNetwork.LocalPlayer
                    && (bool)PhotonNetwork.PlayerList[i].CustomProperties["Ready"] == false)
                    return;
            }

            // 보스 입장
            PhotonNetwork.CurrentRoom.IsOpen = false;
            string _dungeonStr;
            switch (dropdown.value)
            {
                case 0:
                    _dungeonStr = "BD1";
                    break;

                case 1:
                    _dungeonStr = "BD2";
                    break;

                default:
                    _dungeonStr = "NULL";
                    break;
            }
            myPhotonView.RPC("allPlayerStart", RpcTarget.All, _dungeonStr);
        }
        else
        {
            if ((bool)PhotonNetwork.LocalPlayer.CustomProperties["Ready"] == true)
            {
                PhotonNetwork.LocalPlayer.CustomProperties["Ready"] = false;
                PhotonNetwork.LocalPlayer.SetCustomProperties(PhotonNetwork.LocalPlayer.CustomProperties);
                startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "준비";
            }
            else
            {
                PhotonNetwork.LocalPlayer.CustomProperties["Ready"] = true;
                PhotonNetwork.LocalPlayer.SetCustomProperties(PhotonNetwork.LocalPlayer.CustomProperties);
                startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "준비 취소";
            }
        }

        
        
    }

    [PunRPC]
    private void allPlayerStart(string dungeonStr)
    {
        quitPartyButton.interactable = false;
        startButton.interactable = false;
        LoadingLevelController.Instance.LoadLevel(dungeonStr);
        PhotonNetwork.LocalPlayer.CustomProperties["Ready"] = false;
        PhotonNetwork.LocalPlayer.SetCustomProperties(PhotonNetwork.LocalPlayer.CustomProperties);
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
        connectionInfoText.text = "입장에 실패했습니다.";
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // 반장이 바뀌면 준비에서 시작으로 변경! 해당 상태도 준비상태에서 해제해야함!!!
            PhotonNetwork.LocalPlayer.CustomProperties["Ready"] = false;
            PhotonNetwork.LocalPlayer.SetCustomProperties(PhotonNetwork.LocalPlayer.CustomProperties);
            connectionInfoText.text = "방 참가 성공(방장) : " + PhotonNetwork.LocalPlayer.NickName;
            startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "시작";
            dropdown.interactable = true;
        }
        else
        {
            connectionInfoText.text = "방 참가 성공(참가자) : " + PhotonNetwork.LocalPlayer.NickName;
            var ready = PhotonNetwork.LocalPlayer.CustomProperties["Ready"];
            if (ready != null && (bool)ready == true)
                startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "준비 취소";
            else
                startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "준비";
            dropdown.interactable = false;
        }
        Debug.Log("방장 바뀜");
        updateUIForJoin();
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
        if (PhotonNetwork.IsMasterClient)
            myPhotonView.RPC("ChangeBossRPC", newPlayer, dropdown.value);
    }

    // 내가 나감
    public override void OnLeftRoom()
    {
        //leaveRoomButtonObj.SetActive(false);
        //startButtonObj.SetActive(false);
        roomName.text = "";

        quitPartyButton.interactable = false;
        startButton.interactable = false;
        dropdown.interactable = false;
        createPartyButton.interactable|= true;
        roomListPanel.SetActive(true);
        chatPanel.SetActive(false);

        Debug.Log("내가 방 나감!");
        for (int i = 0; i < cur_RoomCells.Length; i++)
        {
            cur_RoomCells[i].GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            playersOfCell[i] = null;
            cur_RoomCells[i].GetChild(1).gameObject.SetActive(false);
            // 다른 정보 추가 하면 그것도 삭제 해줘!
        }
        startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "---";

        foreach(Transform child in chatListTr)
        {
            Destroy(child.gameObject);
        }

    }


    // 룸에 참가 완료된 경우 자동 실행
    public override void OnJoinedRoom()
    {
        roomName.text = "방제목 : " + PhotonNetwork.CurrentRoom.Name;

        PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable { { "Ready", false } });
        createPartyButton.interactable = false;
        quitPartyButton.interactable = true;
        startButton.interactable = true;
        roomListPanel.SetActive(false);
        chatPanel.SetActive(true);

        chatInputField.ActivateInputField();

        updateUIForJoin();
        Debug.Log("방 참가 성공");
        OnMasterClientSwitched(PhotonNetwork.MasterClient);
    }

    // 플레이어 커스텀 프로퍼티 변경시 콜백
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        Debug.Log("OnPlayerPropertiesUpdate");
        for (int i = 0; i < playersOfCell.Length; ++i)
        {
            if (playersOfCell[i] == targetPlayer)
            {
                cur_RoomCells[i].GetChild(1).gameObject.SetActive((bool)changedProps["Ready"]);
                break;
            }
        }
    }


    private void updateUIForJoin()
    {
        if (cur_RoomCells.Length < PhotonNetwork.PlayerList.Length)
            Debug.Log("파티 총 인원이 4명 보다 많음! 버그!!!");
        for (int i = 0; i < cur_RoomCells.Length; i++)
        {
            cur_RoomCells[i].GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            playersOfCell[i] = null;
            cur_RoomCells[i].GetChild(1).gameObject.SetActive(false);
            // 다른 정보 추가 하면 그것도 삭제 해줘!
        }
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            playersOfCell[i] = PhotonNetwork.PlayerList[i];
            var ready = playersOfCell[i].CustomProperties["Ready"];
            if (ready != null && (bool)ready == true)
                cur_RoomCells[i].GetChild(1).gameObject.SetActive(true);

            if (PhotonNetwork.PlayerList[i].IsMasterClient)
                cur_RoomCells[i].GetChild(0).GetComponent<TextMeshProUGUI>().text = "★ "+PhotonNetwork.PlayerList[i].NickName;
            else
                cur_RoomCells[i].GetChild(0).GetComponent<TextMeshProUGUI>().text = PhotonNetwork.PlayerList[i].NickName;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnBossChanged(TMP_Dropdown _dropdown)
    {
        if(PhotonNetwork.IsMasterClient)
            myPhotonView.RPC("ChangeBossRPC", RpcTarget.All, _dropdown.value);
    }

    [PunRPC]
    public void ChangeBossRPC(int _value)
    {
        dropdown.value = _value;
        switch (_value)
        {
            case 0:
                bossName.text = "[대왕 문어 로봇 보스전]";
                break;

            case 1:
                bossName.text = "[인간형 로봇 보스전]";
                break;

            default:
                break;
        }
    }


    public void SendChatting()
    {
        myPhotonView.RPC("SendChattingRPC", RpcTarget.All, Player_Info.Instance.nickName, chatInputField.text);
        StartCoroutine(ClearInputField());
    }


    [PunRPC]
    void SendChattingRPC(string _nickName, string _chat)
    {
        Instantiate(chatBlock, chatListTr).GetComponent<TextMeshProUGUI>().text
            = _nickName + " : " + _chat;


        if (chatScrollbar.value <= 0)
            StartCoroutine(CheckScroolbar());


        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)chatCSF.transform);
    }

    IEnumerator ClearInputField()
    {
        yield return null;

        chatInputField.ActivateInputField();
        chatInputField.text = "";
    }


    IEnumerator CheckScroolbar()
    {
        yield return null;

        chatScrollbar.value = -0.01f;
    }
}
