using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Drag_Drop_To_Inventory : MonoBehaviour, IDrag_Drop
{
    public void Drop(ItemData_MonoBehaviour itemData_Mono)
    {
        ItemData itemData = itemData_Mono.itemData;
        if (itemData.type == '0')
        {
            Debug.Log(itemData_Mono.itemData.itemName + "을 인벤토리로 옮깁니다!");
            if(((Equipment_ItemData)itemData).part == '0')
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
