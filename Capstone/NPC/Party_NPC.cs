using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party_NPC : MonoBehaviour, IInteract
{
    [SerializeField] GameObject party_UI;
    [SerializeField] Canvas canvas;
    [SerializeField] Player_Move player_Move;

    bool isActive = false;



    private void OnDestroy()
    {
        if (isActive)
            ETC_Memory.Instance.windowDepth--;
    }

    public void Interact()
    {
        if (party_UI.activeSelf)
            return;
        party_UI.SetActive(true);
        isActive = true;
        canvas.sortingOrder = ETC_Memory.Instance.top_orderLayer++;
        ETC_Memory.Instance.windowDepth++;

        player_Move.dontMove++;
    }

    public void Close_Party_UI()
    {
        party_UI.SetActive(false);
        isActive = false;
        ETC_Memory.Instance.windowDepth--;

        player_Move.dontMove--;
    }
}
