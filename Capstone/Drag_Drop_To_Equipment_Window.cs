using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Drop_To_Equipment_Window : MonoBehaviour, IDrag_Drop
{
    public char part;
    private ItemData_MonoBehaviour itemData_MonoBehaviour;
    public GameObject toggle;

    private void Awake()
    {
        itemData_MonoBehaviour = GetComponent<ItemData_MonoBehaviour>();
    }

    public void Drop(ItemData_MonoBehaviour itemData_Mono)
    {
        ItemData itemData = itemData_Mono.itemData;
        if (itemData.type == '0' && ((Equipment_ItemData)itemData).part == part)
        {
            if(itemData_MonoBehaviour.itemData.type == '-')
            {
                Debug.Log(itemData_Mono.itemData.itemName + "�� ���â���� �ű�ϴ�!");
                CFirebase.Instance.WearWeapon(itemData.itemName, itemData_MonoBehaviour);
            }
            else
            {
                Debug.Log(itemData_Mono.itemData.itemName + "���� ����Ī�մϴ�!");
                CFirebase.Instance.SwitchEquipment();
            }
        }
    }

    private void TurnOnTuningMode(ItemData itemData)
    {

    }
}
