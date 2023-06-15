using System.Collections;
using System.Collections.Generic;
using Photon.Pun;   // 유니티용 포톤 컴포넌트들
using Photon.Realtime;  // 포톤 서비스 관련 라이브러리
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public class _Pair
    {
        public int min;
        public int max;

        public _Pair(int _min, int _max)
        {
            min = _min;
            max = _max;
        }
    }
    private string gameVersion = "1"; // 게임 버전

    PhotonView myPhotonView;
    public TextMeshProUGUI connectionInfoText;     // 네트워크 정보를 표시할 텍스트

    [Header("LobbyPanel")]
    public GameObject LobbyPanel;
    public TextMeshProUGUI nickNameField;
    public Button showCreateRoomPanelBtn;
    public Button previousBtn;
    public Button nextBtn;
    public Button[] roomCellBtns;

    [Header("CreateRoomPanel")]
    public GameObject createRoomPanel;
    public TMP_Dropdown dropdown;
    public TMP_InputField roomNameInputField;
    public TextMeshProUGUI overviewText;
    public Image overviewImage;
    public string currentGame = string.Empty;
    Dictionary<string, string> overviewDic = new Dictionary<string, string> {
        {"테트리스","테트리스 1 대 1 대결로 겨루자!\n5줄을 없앨 때마다 상대하게 공격을 할 수 있다!\n상대를 먼저 GameOver시키면 승리!"},
        {"포트리스","포트리스 최대 4명까지 즐기자!\n상대의 체력을 다 깍거나 땅속으로 떨어뜨려 마지막까지 살아남아라!"},
        {"게임3","게임 3\n 333333!"} };
    Dictionary<string, string> simpleImageDic = new Dictionary<string, string> {
        {"테트리스","Images/Tetris/TetrisSimple"},
        {"포트리스","Images/Fortress/FortressSimple"},
        {"게임3","Images/G3Simple"} };
    Dictionary<string, _Pair> capacityDic = new Dictionary<string, _Pair> {
        {"테트리스", new _Pair(2,2)},
        {"포트리스", new _Pair(2,4)},
        {"게임3", new _Pair(2,4)} };
    [Header("RoomPanel")]
    public GameObject roomPanel;
    public TextMeshProUGUI roomInfoText;
    public TextMeshProUGUI[] nickNameTexts;

    List<RoomInfo> myList = new List<RoomInfo>();
    int currentPage = 1, maxPage, multiple;

    // 게임 실행과 동시에 마스터 서버 접속 시도
    void Start()
    {
        myPhotonView = GetComponent<PhotonView>();
        if (PhotonNetwork.InRoom)
        {
            OnJoinedRoom();
            return;
        }
        else if (PhotonNetwork.InLobby)
        {
            OnConnectedToMaster();
            return;
        }

        // 접속에 필요한 정보(게임 버전) 설정
        PhotonNetwork.GameVersion = gameVersion;
        // 설정한 정보를 가지고 마스터 서버 접속 시도
        PhotonNetwork.ConnectUsingSettings();


        // 접속을 시도 중임을 텍스트로 표시
        connectionInfoText.text = "마스터 서버에 접속중...";

    }


    #region 1. 방리스트 갱신
    // ◀버튼 -2 , ▶버튼 -1 , 셀 숫자
    public void MyListClick(int num)
    {
        if (num == -2) --currentPage;
        else if (num == -1) ++currentPage;
        else
        {
            if (!PhotonNetwork.InRoom)
            {
                PhotonNetwork.LocalPlayer.NickName = nickNameField.text;
                LobbyPanel.SetActive(false);
                PhotonNetwork.JoinRoom(myList[multiple + num].Name); // 방에서 방 접속하는 경우 고려해야함!!
            }
        }
        MyListRenewal();
    }

    void MyListRenewal()
    {
        // 최대페이지
        maxPage = (myList.Count % roomCellBtns.Length == 0) ? myList.Count / roomCellBtns.Length : myList.Count / roomCellBtns.Length + 1;

        // 이전, 다음버튼
        previousBtn.interactable = (currentPage <= 1) ? false : true;
        nextBtn.interactable = (currentPage >= maxPage) ? false : true;

        // 페이지에 맞는 리스트 대입
        multiple = (currentPage - 1) * roomCellBtns.Length;
        for (int i = 0; i < roomCellBtns.Length; i++)
        {
            roomCellBtns[i].interactable = (multiple + i < myList.Count) ? true : false;
            string str = (multiple + i < myList.Count) ?
                myList[multiple + i].CustomProperties["GameName"] + "\n" + myList[multiple + i].Name + "\n" + myList[multiple + i].PlayerCount + "/" + myList[multiple + i].MaxPlayers : "";
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

    #region 2. 포톤 콜백 함수
    // 마스터 서버 접속 성공시 자동 실행
    public override void OnConnectedToMaster()
    {
        // 접속 로그 표시
        Debug.Log("마스터 서버에 연결됨");

        Debug.Log("동시 접속자 : " + PhotonNetwork.CountOfPlayers);
        PhotonNetwork.JoinLobby();
        myList.Clear();
        MyListRenewal();

        if (connectionInfoText.text != "중복된 닉네임으로 입장 실패.")
        {
            connectionInfoText.text = "온라인 : 마스터 서버와 연결됨";
        }
    }

    // 로비에 접속 완료
    public override void OnJoinedLobby()
    {
        Debug.Log("로비 접속 완료.");
        LobbyPanel.SetActive(true);
        showCreateRoomPanelBtn.interactable = true;
    }

    // 마스터 서버 접속 실패시 자동 실행
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("마스터 서버 재접속 시도.");
        // 마스터 서버로의 재접속 시도
        PhotonNetwork.ConnectUsingSettings();
    }

    // (빈 방이 없어 Or 꽉참) 룸 참가에 실패한 경우 자동 실행
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnPhotonJoinRoomFailed");
        // 접속 상태 표시
        connectionInfoText.text = "입장에 실패했습니다.";
        LobbyPanel.SetActive(true);
        // 접속 실패후 접속 버튼 활성화
        //joinButtonObj.SetActive(true);
        //joinButton.interactable = true;
        //PhotonNetwork.JoinOrCreateRoom("Room1", new RoomOptions { MaxPlayers = 3 },null);
    }

    // 방장이 바뀜
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // 반장이 바뀌면 준비에서 시작으로 변경! 해당 상태도 준비상태에서 해제해야함!!!
            connectionInfoText.text = "방 참가 성공(방장) : " + PhotonNetwork.LocalPlayer.NickName;

            //startButtonObj.SetActive(true);
        }
        else
        {
            connectionInfoText.text = "방 참가 성공(참가자) : " + PhotonNetwork.LocalPlayer.NickName;

        }
        Debug.Log("방장 바뀜");
        //myPhotonView.RPC("updateUI", RpcTarget.All);
    }

    // 다른 플레이어가 나감
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log(otherPlayer.NickName + " 나갔습니다");

        UpdateRoomInfo();
    }

    // 다른 플레이어 들어옴
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdateRoomInfo();
    }

    // 내가 방을 나감
    public override void OnLeftRoom()
    {
        //leaveRoomButtonObj.SetActive(false);
        //startButtonObj.SetActive(false);

    }

    // 룸에 참가 완료된 경우 자동 실행
    public override void OnJoinedRoom()
    {
        Debug.Log("방 참가 성공");
        roomPanel.SetActive(true);

        UpdateRoomInfo();

        if (PhotonNetwork.IsMasterClient)
            connectionInfoText.text = "방 참가 성공(방장) : " + PhotonNetwork.LocalPlayer.NickName;
        else
            connectionInfoText.text = "방 참가 성공(참가자) : " + PhotonNetwork.LocalPlayer.NickName;
    }
    #endregion

    #region 3. 방만들기 메뉴
    public void ShowCreateRoomPanel()
    {
        PhotonNetwork.LocalPlayer.NickName = nickNameField.text;
        roomNameInputField.text = string.Empty;
        overviewText.text = currentGame;
        LobbyPanel.SetActive(false);
        createRoomPanel.SetActive(true);
        SelectGame(currentGame);
    }

    public void QuitCreateRoomPanel()
    {
        createRoomPanel.SetActive(false);
        LobbyPanel.SetActive(true);
    }

    public void SelectGame(string gameName)
    {
        currentGame = gameName;
        Debug.Log(currentGame + " 선택했습니다.");
        overviewText.text = overviewDic[currentGame];
        overviewImage.sprite = Resources.Load<Sprite>(simpleImageDic[currentGame]);
        dropdown.options.Clear();
        for(int i = capacityDic[currentGame].min; i <= capacityDic[currentGame].max; i++)
        {
            TMP_Dropdown.OptionData newData = new TMP_Dropdown.OptionData();
            newData.text = "인원 "+i.ToString()+"명";
            dropdown.options.Add(newData);
        }
        dropdown.value = 0;
    }

    public void CreateRoom()
    {
        // 중복 접속 시도를 막기 위해, 접속 버튼 잠시 비활성화

        // 마스터 서버에 접속중이라면
        if (PhotonNetwork.IsConnected)
        {
            createRoomPanel.SetActive(false);
            int Maxpersonnel = System.Convert.ToInt32(System.Text.RegularExpressions.Regex.Match(dropdown.options[dropdown.value].text, "\\d+").Value);
            Debug.Log("게임명 : " + currentGame + ", 최대 인원 : " + Maxpersonnel + "명");
            // 룸 생성 실행
            connectionInfoText.text = "룸을 생성중...";
            while (true)
            {
                RoomOptions roomOptions = new RoomOptions { MaxPlayers = Maxpersonnel, IsOpen = true, IsVisible = true, CustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { "GameName", currentGame } } };
                roomOptions.CustomRoomPropertiesForLobby = new string[1] { "GameName" };
                if (PhotonNetwork.CreateRoom(roomNameInputField.text, roomOptions, null))
                {
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
    #endregion

    public void LeaveRoom()
    {
        //myPhotonView.RPC("updateUIForLeave", RpcTarget.All,PhotonNetwork.LocalPlayer.NickName);
        roomPanel.SetActive(false);
        PhotonNetwork.LeaveRoom();
    }

    public void StartGame()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        myPhotonView.RPC("allPlayerStart", RpcTarget.All);
    }

    [PunRPC]
    private void allPlayerStart()
    {
        Debug.Log(PhotonNetwork.CurrentRoom.CustomProperties["GameName"] + " : allPlayerStart RPC Start!");
        PhotonNetwork.LoadLevel(PhotonNetwork.CurrentRoom.CustomProperties["GameName"].ToString());

        //LoadingLevelController.Instance.LoadLevel("SampleScene");
    }

    private void UpdateRoomInfo()
    {
        var dic = PhotonNetwork.CurrentRoom.Players;
        int i = 0;
        foreach (var tmp in dic)
        {
            Player player = tmp.Value;
            Debug.Log("닉네임 : " + player.NickName + ", ID : " + tmp.Key);
            nickNameTexts[i++].text = "[" + player.NickName + "]";
        }
        for(; i < PhotonNetwork.CurrentRoom.MaxPlayers; i++)
        {
            nickNameTexts[i].text = "X";
        }
        roomInfoText.text = "방제목 : " + PhotonNetwork.CurrentRoom.Name
            + "\n맵 : " + PhotonNetwork.CurrentRoom.CustomProperties["GameName"]
            + "\n인원 " + PhotonNetwork.CurrentRoom.PlayerCount + "/" + PhotonNetwork.CurrentRoom.MaxPlayers;
    }

    private bool CheckNickName(string nick)
    {
        for (int i = 0; i < PhotonNetwork.PlayerList.Length - 1; i++)
        {
            if (nick == PhotonNetwork.PlayerListOthers[i].NickName) return false;
        }
        return true;
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
                 Application.OpenURL(webplayerQuitURL);
        #else
                 Application.Quit();
        #endif
    }

}
