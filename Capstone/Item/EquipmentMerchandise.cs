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
        equipment_ItemData = ItemMaster.Instance.GetEquipmentFrom_ID(m_Id);

        ItemData_Mono.itemData = equipment_ItemData;
    }
}
