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
            }
            EquipmentWindowController.Instance.canvas.enabled = !EquipmentWindowController.Instance.canvas.enabled;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            party_UI.GetComponent<Canvas>().sortingOrder = ETC_Memory.Instance.top_orderLayer++;
            party_UI.SetActive(!party_UI.activeSelf);
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
