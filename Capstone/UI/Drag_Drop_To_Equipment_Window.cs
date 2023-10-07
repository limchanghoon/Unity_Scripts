using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Drop_To_Equipment_Window : MonoBehaviour, IDrag_Drop
{
    public int part;
    private ItemData_MonoBehaviour itemData_MonoBehaviour;

    private void Awake()
    {
        itemData_MonoBehaviour = GetComponent<ItemData_MonoBehaviour>();
    }

    public bool Drop(ItemData_MonoBehaviour itemData_Mono)
    {
        ItemData itemData = itemData_Mono.itemData;
        if (itemData.type == '0' && ((Equipment_ItemData)itemData).part == part 
            && itemData_Mono.itemWindow == ItemData_MonoBehaviour.ItemWindow.Inventory)
        {
            if(itemData_MonoBehaviour.itemData.type == '-')
            {
                Debug.Log(itemData.itemName + "�� ���â���� �ű�ϴ�!");
                CFirebase.Instance.WearEquipment((Equipment_ItemData)itemData, itemData_MonoBehaviour);
            }
            else
            {
                Debug.Log(itemData.itemName + "���� ����Ī�մϴ�!");
                CFirebase.Instance.SwitchEquipment((Equipment_ItemData)itemData, itemData_MonoBehaviour);
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
