using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalNPC : MonoBehaviour, IInteract
{
    public string map_name = "Farming World";
    public void Interact()
    {
        if(PhotonNetwork.InRoom)
            PhotonNetwork.LeaveRoom();

        LoadingSceneController.Instance.LoadScene(map_name);
    }

}
