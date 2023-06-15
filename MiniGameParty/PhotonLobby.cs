using System.Collections;
using System.Collections.Generic;
using Photon.Pun;   // ����Ƽ�� ���� ������Ʈ��
using Photon.Realtime;  // ���� ���� ���� ���̺귯��
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
    private string gameVersion = "1"; // ���� ����

    PhotonView myPhotonView;
    public TextMeshProUGUI connectionInfoText;     // ��Ʈ��ũ ������ ǥ���� �ؽ�Ʈ

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
        {"��Ʈ����","��Ʈ���� 1 �� 1 ���� �ܷ���!\n5���� ���� ������ ����ϰ� ������ �� �� �ִ�!\n��븦 ���� GameOver��Ű�� �¸�!"},
        {"��Ʈ����","��Ʈ���� �ִ� 4����� �����!\n����� ü���� �� ��ų� �������� ����߷� ���������� ��Ƴ��ƶ�!"},
        {"����3","���� 3\n 333333!"} };
    Dictionary<string, string> simpleImageDic = new Dictionary<string, string> {
        {"��Ʈ����","Images/Tetris/TetrisSimple"},
        {"��Ʈ����","Images/Fortress/FortressSimple"},
        {"����3","Images/G3Simple"} };
    Dictionary<string, _Pair> capacityDic = new Dictionary<string, _Pair> {
        {"��Ʈ����", new _Pair(2,2)},
        {"��Ʈ����", new _Pair(2,4)},
        {"����3", new _Pair(2,4)} };
    [Header("RoomPanel")]
    public GameObject roomPanel;
    public TextMeshProUGUI roomInfoText;
    public TextMeshProUGUI[] nickNameTexts;

    List<RoomInfo> myList = new List<RoomInfo>();
    int currentPage = 1, maxPage, multiple;

    // ���� ����� ���ÿ� ������ ���� ���� �õ�
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

        // ���ӿ� �ʿ��� ����(���� ����) ����
        PhotonNetwork.GameVersion = gameVersion;
        // ������ ������ ������ ������ ���� ���� �õ�
        PhotonNetwork.ConnectUsingSettings();


        // ������ �õ� ������ �ؽ�Ʈ�� ǥ��
        connectionInfoText.text = "������ ������ ������...";

    }


    #region 1. �渮��Ʈ ����
    // ����ư -2 , ����ư -1 , �� ����
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
                PhotonNetwork.JoinRoom(myList[multiple + num].Name); // �濡�� �� �����ϴ� ��� ����ؾ���!!
            }
        }
        MyListRenewal();
    }

    void MyListRenewal()
    {
        // �ִ�������
        maxPage = (myList.Count % roomCellBtns.Length == 0) ? myList.Count / roomCellBtns.Length : myList.Count / roomCellBtns.Length + 1;

        // ����, ������ư
        previousBtn.interactable = (currentPage <= 1) ? false : true;
        nextBtn.interactable = (currentPage >= maxPage) ? false : true;

        // �������� �´� ����Ʈ ����
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

    #region 2. ���� �ݹ� �Լ�
    // ������ ���� ���� ������ �ڵ� ����
    public override void OnConnectedToMaster()
    {
        // ���� �α� ǥ��
        Debug.Log("������ ������ �����");

        Debug.Log("���� ������ : " + PhotonNetwork.CountOfPlayers);
        PhotonNetwork.JoinLobby();
        myList.Clear();
        MyListRenewal();

        if (connectionInfoText.text != "�ߺ��� �г������� ���� ����.")
        {
            connectionInfoText.text = "�¶��� : ������ ������ �����";
        }
    }

    // �κ� ���� �Ϸ�
    public override void OnJoinedLobby()
    {
        Debug.Log("�κ� ���� �Ϸ�.");
        LobbyPanel.SetActive(true);
        showCreateRoomPanelBtn.interactable = true;
    }

    // ������ ���� ���� ���н� �ڵ� ����
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("������ ���� ������ �õ�.");
        // ������ �������� ������ �õ�
        PhotonNetwork.ConnectUsingSettings();
    }

    // (�� ���� ���� Or ����) �� ������ ������ ��� �ڵ� ����
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnPhotonJoinRoomFailed");
        // ���� ���� ǥ��
        connectionInfoText.text = "���忡 �����߽��ϴ�.";
        LobbyPanel.SetActive(true);
        // ���� ������ ���� ��ư Ȱ��ȭ
        //joinButtonObj.SetActive(true);
        //joinButton.interactable = true;
        //PhotonNetwork.JoinOrCreateRoom("Room1", new RoomOptions { MaxPlayers = 3 },null);
    }

    // ������ �ٲ�
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // ������ �ٲ�� �غ񿡼� �������� ����! �ش� ���µ� �غ���¿��� �����ؾ���!!!
            connectionInfoText.text = "�� ���� ����(����) : " + PhotonNetwork.LocalPlayer.NickName;

            //startButtonObj.SetActive(true);
        }
        else
        {
            connectionInfoText.text = "�� ���� ����(������) : " + PhotonNetwork.LocalPlayer.NickName;

        }
        Debug.Log("���� �ٲ�");
        //myPhotonView.RPC("updateUI", RpcTarget.All);
    }

    // �ٸ� �÷��̾ ����
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log(otherPlayer.NickName + " �������ϴ�");

        UpdateRoomInfo();
    }

    // �ٸ� �÷��̾� ����
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdateRoomInfo();
    }

    // ���� ���� ����
    public override void OnLeftRoom()
    {
        //leaveRoomButtonObj.SetActive(false);
        //startButtonObj.SetActive(false);

    }

    // �뿡 ���� �Ϸ�� ��� �ڵ� ����
    public override void OnJoinedRoom()
    {
        Debug.Log("�� ���� ����");
        roomPanel.SetActive(true);

        UpdateRoomInfo();

        if (PhotonNetwork.IsMasterClient)
            connectionInfoText.text = "�� ���� ����(����) : " + PhotonNetwork.LocalPlayer.NickName;
        else
            connectionInfoText.text = "�� ���� ����(������) : " + PhotonNetwork.LocalPlayer.NickName;
    }
    #endregion

    #region 3. �游��� �޴�
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
        Debug.Log(currentGame + " �����߽��ϴ�.");
        overviewText.text = overviewDic[currentGame];
        overviewImage.sprite = Resources.Load<Sprite>(simpleImageDic[currentGame]);
        dropdown.options.Clear();
        for(int i = capacityDic[currentGame].min; i <= capacityDic[currentGame].max; i++)
        {
            TMP_Dropdown.OptionData newData = new TMP_Dropdown.OptionData();
            newData.text = "�ο� "+i.ToString()+"��";
            dropdown.options.Add(newData);
        }
        dropdown.value = 0;
    }

    public void CreateRoom()
    {
        // �ߺ� ���� �õ��� ���� ����, ���� ��ư ��� ��Ȱ��ȭ

        // ������ ������ �������̶��
        if (PhotonNetwork.IsConnected)
        {
            createRoomPanel.SetActive(false);
            int Maxpersonnel = System.Convert.ToInt32(System.Text.RegularExpressions.Regex.Match(dropdown.options[dropdown.value].text, "\\d+").Value);
            Debug.Log("���Ӹ� : " + currentGame + ", �ִ� �ο� : " + Maxpersonnel + "��");
            // �� ���� ����
            connectionInfoText.text = "���� ������...";
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
            // ������ ������ �������� �ƴ϶��, ������ ������ ���� �õ�
            connectionInfoText.text = "�������� : ���� ��õ���...";

            // ������ �������� ������ �õ�
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
            Debug.Log("�г��� : " + player.NickName + ", ID : " + tmp.Key);
            nickNameTexts[i++].text = "[" + player.NickName + "]";
        }
        for(; i < PhotonNetwork.CurrentRoom.MaxPlayers; i++)
        {
            nickNameTexts[i].text = "X";
        }
        roomInfoText.text = "������ : " + PhotonNetwork.CurrentRoom.Name
            + "\n�� : " + PhotonNetwork.CurrentRoom.CustomProperties["GameName"]
            + "\n�ο� " + PhotonNetwork.CurrentRoom.PlayerCount + "/" + PhotonNetwork.CurrentRoom.MaxPlayers;
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
