using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party_NPC : MonoBehaviour, IInteract
{
    public GameObject party_UI;
    public Canvas canvas;

    public void Interact()
    {
        party_UI.SetActive(true);
        canvas.sortingOrder = ETC_Memory.Instance.top_orderLayer++;
    }

    public void Close_Party_UI()
    {
        party_UI.SetActive(false);
    }
}
