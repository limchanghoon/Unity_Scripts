using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_In_Village : MonoBehaviour
{
    public GameObject euipment_UI;
    public GameObject party_UI;

    private void Awake()
    {
        InventoryController.Instance.Read_Inventory();
        CFirebase.Instance.ReadWearingEquipment();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!InventoryController.Instance.canvas.enabled)
            {
                InventoryController.Instance.canvas.sortingOrder = ETC_Memory.Instance.top_orderLayer++;
                InventoryController.Instance.Read_Inventory();
            }
            InventoryController.Instance.canvas.enabled = !InventoryController.Instance.canvas.enabled;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (!EquipmentWindowController.Instance.canvas.enabled)
            {
                EquipmentWindowController.Instance.canvas.sortingOrder = ETC_Memory.Instance.top_orderLayer++;
                CFirebase.Instance.ReadWearingEquipment();
            }
            EquipmentWindowController.Instance.canvas.enabled = !EquipmentWindowController.Instance.canvas.enabled;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!StatsWindowController.Instance.canvas.enabled)
            {
                StatsWindowController.Instance.canvas.sortingOrder = ETC_Memory.Instance.top_orderLayer++;
                Player_Info.Instance.UpdateStats();
            }
            StatsWindowController.Instance.canvas.enabled = !StatsWindowController.Instance.canvas.enabled;
        }
    }

    public void Close_Euipment_UI()
    {
        euipment_UI.SetActive(false);
    }

    public void Close_Party_UI()
    {
        party_UI.SetActive(false);
    }

}
