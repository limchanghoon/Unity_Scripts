using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Drop_To_Inventory : MonoBehaviour, IDrag_Drop
{
    public bool Drop(ItemData_MonoBehaviour itemData_Mono)
    {
        ItemData itemData = itemData_Mono.itemData;
        if (itemData.type == ItemType.Equipment && itemData_Mono.itemWindow == ItemData_MonoBehaviour.ItemWindow.EquipmentWindow)
        {
            CFirebase.Instance.TakeOffEquipment((Equipment_ItemData)itemData);
            
            return true;
        }
        else
        {
            return false;
        }
    }


}
