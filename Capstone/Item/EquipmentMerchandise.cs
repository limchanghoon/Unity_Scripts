using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentMerchandise : MonoBehaviour
{
    [SerializeField] int m_Id;

    public Equipment_ItemData equipment_ItemData;
    public ItemData_MonoBehaviour ItemData_Mono;

    private void Start()
    {
        if(ItemMaster.Instance.GetPartOfEquipment(m_Id) == 0)
        {
            equipment_ItemData = ItemMaster.Instance.weapon_Dic[m_Id];
        }
        else
        {
            equipment_ItemData = ItemMaster.Instance.armor_Dic[m_Id];
        }

        ItemData_Mono.itemData = equipment_ItemData;
    }
}
