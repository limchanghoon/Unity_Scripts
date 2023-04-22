using System.Collections;
using System.Collections.Generic;
using Photon.Pun;   // ����Ƽ�� ���� ������Ʈ��
using Photon.Realtime;  // ���� ���� ���� ���̺귯��
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DungeonManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1"; // ���� ����

    public PhotonView myPhotonView;
    public TextMeshProUGUI connectionInfoText;     // ��Ʈ��ũ ������ ǥ���� �ؽ�Ʈ
    public TextMeshProUGUI playerCountInRoomText;   // �� ���� ��ư������Ʈ
    public Button createPartyButton;   // �� ���� ��ư
    public Button quitPartyButton;   // �� ���� ��ư
    public Button startButton;   // ���� ���� ��ư
    public GameObject leaveRoomButtonObj;   // �� ������ ��ư������Ʈ
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

    // ���� ����� ���ÿ� ������ ���� ���� �õ�
    void Start()
    {
        // ���ӿ� �ʿ��� ����(���� ����) ����
        PhotonNetwork.GameVersion = gameVersion;
        // ������ ������ ������ ������ ���� ���� �õ�
        PhotonNetwork.ConnectUsingSettings();

        PhotonNetwork.LocalPlayer.NickName = "�ӽ� �̸�";
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

    // ������ ���� ���� ������ �ڵ� ����
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        myList.Clear();
        MyListRenewal();
        // �� ���� ��ư�� Ȱ��ȭ
        //joinButtonObj.SetActive(true);
        createPartyButton.interactable = true;
        //nickNameInputObj.SetActive(true);
        //roomNameInputObj.SetActive(true);
        // ���� ���� ǥ��
        //playerCountInRoomText.text = "";
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

    public void CreateRoom()
    {
        // �ߺ� ���� �õ��� ���� ����, ���� ��ư ��� ��Ȱ��ȭ
        createPartyButton.interactable = false;
        // ������ ������ �������̶��
        if (PhotonNetwork.IsConnected)
        {
            // �� ���� ����
            connectionInfoText.text = "���� ������...";
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
            // ������ ������ �������� �ƴ϶��, ������ ������ ���� �õ�
            connectionInfoText.text = "�������� : ������ ������ ������� ����\n���� ��õ���...";

            // ������ �������� ������ �õ�
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
        // ���� ���� ǥ��
        connectionInfoText.text = "���忡 �����߽��ϴ�.";
        // ���� ������ ���� ��ư Ȱ��ȭ
        //joinButtonObj.SetActive(true);
        //joinButton.interactable = true;
        //PhotonNetwork.JoinOrCreateRoom("Room1", new RoomOptions { MaxPlayers = 3 },null);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // ������ �ٲ�� �غ񿡼� �������� ����! �ش� ���µ� �غ���¿��� �����ؾ���!!!
            connectionInfoText.text = "�� ���� ����(����) / ����� �г��� : " + PhotonNetwork.LocalPlayer.NickName;
            startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "����";
            //startButtonObj.SetActive(true);
        }
        else
        {
            connectionInfoText.text = "�� ���� ����(������) / ����� �г��� : " + PhotonNetwork.LocalPlayer.NickName;
            startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "�غ�";
        }
        Debug.Log("���� �ٲ�");
        //myPhotonView.RPC("updateUI", RpcTarget.All);
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
    }

    // ���� ����
    public override void OnLeftRoom()
    {
        //leaveRoomButtonObj.SetActive(false);
        //startButtonObj.SetActive(false);
        quitPartyButton.interactable = false;
        startButton.interactable = false;
        createPartyButton.interactable|= true;
        Debug.Log("���� �� ����!");
        for (int i = 0; i < cur_RoomCellBtns.Length; i++)
        {
            cur_RoomCellBtns[i].transform.GetChild(0).GetComponent<Text>().text = "";
            // �ٸ� ���� �߰� �ϸ� �װ͵� ���� ����!
        }
        startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "---";
    }


    // �뿡 ���� �Ϸ�� ��� �ڵ� ����
    public override void OnJoinedRoom()
    {
        //myPhotonView.RPC("updateUIForJoin", RpcTarget.All, playerNickName.text);

        //PhotonNetwork.LocalPlayer.NickName = playerNickName.text;
        //LobbyPanel.SetActive(false);
        // ���� ���� ǥ��
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
        connectionInfoText.text = "�� ���� ����(������) / ����� �г��� : " + PhotonNetwork.LocalPlayer.NickName;
        Debug.Log("�� ���� ����");
        if (PhotonNetwork.IsMasterClient)
        {
            startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "����";
            //startButtonObj.SetActive(true);
            //leaveRoomButtonObj.SetActive(true);
        }
        else
        {
            startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "�غ�";
            //leaveRoomButtonObj.SetActive(true);
        }
        // ��� �� �����ڵ��� Main ���� �ε��ϰ� ��
        //PhotonNetwork.LoadLevel("Main");
    }
    [PunRPC]
    private void updateUIForJoin()
    {
        if (cur_RoomCellBtns.Length < PhotonNetwork.PlayerList.Length)
            Debug.Log("��Ƽ �� �ο��� 4�� ���� ����! ����!!!");
        for (int i = 0; i < cur_RoomCellBtns.Length; i++)
        {
            cur_RoomCellBtns[i].transform.GetChild(0).GetComponent<Text>().text = "";
            // �ٸ� ���� �߰� �ϸ� �װ͵� ���� ����!
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
        playerCountText.text = "���� �� �ο���: " + temp;
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

    [ContextMenu("����")]
    void Info()
    {
        print(PhotonNetwork.InLobby);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
