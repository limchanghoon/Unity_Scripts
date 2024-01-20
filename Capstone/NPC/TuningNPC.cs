using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TuningNPC : MonoBehaviour, IInteract
{
    public GameObject tuningShop_UI;
    public Drag_Drop_To_Tuning ddtt;


    bool isActive = false;


    private void OnDestroy()
    {
        if(isActive)
            ETC_Memory.Instance.windowDepth--;
    }

    public void Interact()
    {
        if (tuningShop_UI.activeSelf)
            return;
        Debug.Log("TuningShop Interaction!");
        tuningShop_UI.SetActive(true);
        isActive = true;
        tuningShop_UI.GetComponent<Canvas>().sortingOrder = ETC_Memory.Instance.top_orderLayer++;
        ETC_Memory.Instance.windowDepth++;
    }

    public void Close_UI()
    {
        tuningShop_UI.SetActive(false);
        isActive = false;
        ETC_Memory.Instance.windowDepth--;
        ddtt.TurnOffTuningMode();
    }
}
