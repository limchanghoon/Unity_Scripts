using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeySet_Window : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!InventoryController.Instance.gameObject.activeSelf)
            {
                ETC_Memory.Instance.windowDepth++;
                InventoryController.Instance.canvas.sortingOrder = ETC_Memory.Instance.top_orderLayer++;
                InventoryController.Instance.Read_Inventory();
            }
            else
            {
                ETC_Memory.Instance.windowDepth--;
            }
            InventoryController.Instance.gameObject.SetActive(!InventoryController.Instance.gameObject.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (!EquipmentWindowController.Instance.canvas.enabled)
            {
                ETC_Memory.Instance.windowDepth++;
                EquipmentWindowController.Instance.canvas.sortingOrder = ETC_Memory.Instance.top_orderLayer++;
                CFirebase.Instance.ReadWearingEquipment();
            }
            else
            {
                ETC_Memory.Instance.windowDepth--;
            }
            EquipmentWindowController.Instance.canvas.enabled = !EquipmentWindowController.Instance.canvas.enabled;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!StatsWindowController.Instance.canvas.enabled)
            {
                ETC_Memory.Instance.windowDepth++;
                StatsWindowController.Instance.canvas.sortingOrder = ETC_Memory.Instance.top_orderLayer++;
                Player_Info.Instance.UpdateStats();
            }
            else
            {
                ETC_Memory.Instance.windowDepth--;
            }
            StatsWindowController.Instance.canvas.enabled = !StatsWindowController.Instance.canvas.enabled;
        }
    }

}
