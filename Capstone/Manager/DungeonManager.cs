using System.Collections;
using System.Collections.Generic;
using Photon.Pun;   // ����Ƽ�� ���� ������Ʈ��
using Photon.Realtime;  // ���� ���� ���� ���̺귯��
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class DungeonManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1"; // ���� ����

    public PhotonView myPhotonView;
    public TextMeshProUGUI connectionInfoText;     // ��Ʈ��ũ ������ ǥ���� �ؽ�Ʈ
    public Button createPartyButton;   // �� ���� ��ư
    public Button quitPartyButton;   // �� ������ ��ư
    public Button startButton;   // ���� ����(�غ�) ��ư
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

    // ���� ����� ���ÿ� ������ ���� ���� �õ�
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
        // ���ӿ� �ʿ��� ����(���� ����) ����
        PhotonNetwork.GameVersion = gameVersion;
        // ������ ������ ������ ������ ���� ���� �õ�
        PhotonNetwork.ConnectUsingSettings();

        PhotonNetwork.LocalPlayer.NickName = Player_Info.Instance.nickName;
        
        // �� ���� ��ư�� ��� ��Ȱ��ȭ
        createPartyButton.interactable = false;
        quitPartyButton.interactable = false;
        startButton.interactable = false;

        // ������ �õ� ������ �ؽ�Ʈ�� ǥ��
        connectionInfoText.text = "������ ������ ������...";

    }


    #region �渮��Ʈ ����
    // ����ư -2 , ����ư -1 , �� ����
    public void MyListClick(int num)
    {
        if (num == -2) --currentPage;
        else if (num == -1) ++currentPage;
        else 
        {
            if(!PhotonNetwork.InRoom)
                PhotonNetwork.JoinRoom(myList[multiple + num].Name); // �濡�� �� �����ϴ� ��� ����ؾ���!!
        }
        MyListRenewal();
    }

    void MyListRenewal()
    {
        // �ִ�������
        maxPage = (myList.Count % roomCellBtns.Length == 0) ? myList.Count / roomCellBtns.Length : myList.Count / roomCellBtns.Length + 1;

        // ����, ������ư
        PreviousBtn.interactable = (currentPage <= 1) ? false : true;
        NextBtn.interactable = (currentPage >= maxPage) ? false : true;

        // �������� �´� ����Ʈ ����
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

    // ������ ���� ���� ������ �ڵ� ����
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        myList.Clear();
        MyListRenewal();

        createPartyButton.interactable = true;

        if (connectionInfoText.text != "�ߺ��� �г������� ���� ����.")
        {
            connectionInfoText.text = "�¶��� : ������ ������ �����";
        }
        // ���� �α� ǥ��
        Debug.Log("������ ������ �����");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("�κ� ���� �Ϸ�.");
    }

    // ������ ���� ���� ���н� �ڵ� ����
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("������ ���� ������ �õ�.");
        // ������ �������� ������ �õ�
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

        // �ߺ� ���� �õ��� ���� ����, ���� ��ư ��� ��Ȱ��ȭ
        createPartyButton.interactable = false;
        // ������ ������ �������̶��
        if (PhotonNetwork.IsConnected)
        {
            // �� ���� ����
            connectionInfoText.text = "���� ������...";
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
            // ������ ������ �������� �ƴ϶��, ������ ������ ���� �õ�
            connectionInfoText.text = "�������� : ���� ��õ���...";

            // ������ �������� ������ �õ�
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

            // ���� ����
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
                startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "�غ�";
            }
            else
            {
                PhotonNetwork.LocalPlayer.CustomProperties["Ready"] = true;
                PhotonNetwork.LocalPlayer.SetCustomProperties(PhotonNetwork.LocalPlayer.CustomProperties);
                startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "�غ� ���";
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

    // �ٸ� �÷��̾ �� ������ ���� ������� ������ ������; JoinOrCreateRoom ���п� �ʿ䰡 �����ϴ�
    void OnPhotonCreateRoomFailed()
    {
        // �� ���� ����
        connectionInfoText.text = "�뿡 ����...";
        PhotonNetwork.JoinRoom("Room1");
    }

    // (�� ���� ���� Or ����) �� ������ ������ ��� �ڵ� ����
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnPhotonJoinRoomFailed");
        connectionInfoText.text = "���忡 �����߽��ϴ�.";
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // ������ �ٲ�� �غ񿡼� �������� ����! �ش� ���µ� �غ���¿��� �����ؾ���!!!
            PhotonNetwork.LocalPlayer.CustomProperties["Ready"] = false;
            PhotonNetwork.LocalPlayer.SetCustomProperties(PhotonNetwork.LocalPlayer.CustomProperties);
            connectionInfoText.text = "�� ���� ����(����) : " + PhotonNetwork.LocalPlayer.NickName;
            startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "����";
            dropdown.interactable = true;
        }
        else
        {
            connectionInfoText.text = "�� ���� ����(������) : " + PhotonNetwork.LocalPlayer.NickName;
            var ready = PhotonNetwork.LocalPlayer.CustomProperties["Ready"];
            if (ready != null && (bool)ready == true)
                startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "�غ� ���";
            else
                startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "�غ�";
            dropdown.interactable = false;
        }
        Debug.Log("���� �ٲ�");
        updateUIForJoin();
    }

    // �ٸ� �÷��̾ ����
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log(otherPlayer.NickName + " �������ϴ�");
        updateUIForJoin();
        //playerCountText.text = "���� �� �ο���: " + PhotonNetwork.CurrentRoom.PlayerCount;

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        updateUIForJoin();
        if (PhotonNetwork.IsMasterClient)
            myPhotonView.RPC("ChangeBossRPC", newPlayer, dropdown.value);
    }

    // ���� ����
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

        Debug.Log("���� �� ����!");
        for (int i = 0; i < cur_RoomCells.Length; i++)
        {
            cur_RoomCells[i].GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            playersOfCell[i] = null;
            cur_RoomCells[i].GetChild(1).gameObject.SetActive(false);
            // �ٸ� ���� �߰� �ϸ� �װ͵� ���� ����!
        }
        startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "---";

        foreach(Transform child in chatListTr)
        {
            Destroy(child.gameObject);
        }

    }


    // �뿡 ���� �Ϸ�� ��� �ڵ� ����
    public override void OnJoinedRoom()
    {
        roomName.text = "������ : " + PhotonNetwork.CurrentRoom.Name;

        PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable { { "Ready", false } });
        createPartyButton.interactable = false;
        quitPartyButton.interactable = true;
        startButton.interactable = true;
        roomListPanel.SetActive(false);
        chatPanel.SetActive(true);

        chatInputField.ActivateInputField();

        updateUIForJoin();
        Debug.Log("�� ���� ����");
        OnMasterClientSwitched(PhotonNetwork.MasterClient);
    }

    // �÷��̾� Ŀ���� ������Ƽ ����� �ݹ�
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
            Debug.Log("��Ƽ �� �ο��� 4�� ���� ����! ����!!!");
        for (int i = 0; i < cur_RoomCells.Length; i++)
        {
            cur_RoomCells[i].GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            playersOfCell[i] = null;
            cur_RoomCells[i].GetChild(1).gameObject.SetActive(false);
            // �ٸ� ���� �߰� �ϸ� �װ͵� ���� ����!
        }
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            playersOfCell[i] = PhotonNetwork.PlayerList[i];
            var ready = playersOfCell[i].CustomProperties["Ready"];
            if (ready != null && (bool)ready == true)
                cur_RoomCells[i].GetChild(1).gameObject.SetActive(true);

            if (PhotonNetwork.PlayerList[i].IsMasterClient)
                cur_RoomCells[i].GetChild(0).GetComponent<TextMeshProUGUI>().text = "�� "+PhotonNetwork.PlayerList[i].NickName;
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
                bossName.text = "[��� ���� �κ� ������]";
                break;

            case 1:
                bossName.text = "[�ΰ��� �κ� ������]";
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
