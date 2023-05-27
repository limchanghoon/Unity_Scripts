using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Drop_To_Inventory : MonoBehaviour, IDrag_Drop
{
    public void Drop(ItemData_MonoBehaviour itemData_Mono)
    {
        ItemData itemData = itemData_Mono.itemData;
        if (itemData.type == '0' && itemData_Mono.itemWindow == ItemData_MonoBehaviour.ItemWindow.EquipmentWindow)
        {
            Debug.Log(itemData_Mono.itemData.itemName + "�� �κ��丮�� �ű�ϴ�!");
            if(((Equipment_ItemData)itemData).part == 0)
            {
                CFirebase.Instance.TakeOffWeapon(itemData.itemName);
            }
            else
            {
                CFirebase.Instance.TakeOffArmor(itemData.itemName);
            }
        }
    }


}
