using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalNPC : MonoBehaviour, IInteract
{
    public string map_name = "Farming World";
    [SerializeField] GameObject confirmCanvas;
    Canvas canvas;
    [SerializeField] Player_Move player_Move;

    bool isActive = false;

    private void Start()
    {
        canvas = confirmCanvas.GetComponent<Canvas>();
    }

    private void OnDestroy()
    {
        if (isActive)
            ETC_Memory.Instance.windowDepth--;
    }

    public void Interact()
    {
        if (isActive)
            return;
        canvas.sortingOrder = ETC_Memory.Instance.top_orderLayer++;
        ETC_Memory.Instance.windowDepth++;
        player_Move.dontMove++;
        confirmCanvas.SetActive(true);
        isActive = true;
    }

    public void Cancle()
    {
        ETC_Memory.Instance.windowDepth--;
        player_Move.dontMove--;
        confirmCanvas.SetActive(false);
        isActive = false;
    }


    public void Load()
    {
        player_Move.GetComponent<Laycast_Check_NPC>().enabled = true;
        Cancle();
        if (PhotonNetwork.InRoom)
            PhotonNetwork.LeaveRoom();

        LoadingSceneController.Instance.LoadScene(map_name);
    }

}
