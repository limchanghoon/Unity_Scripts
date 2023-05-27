using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData_MonoBehaviour : MonoBehaviour
{
    public enum ItemWindow{
        Inventory,
        EquipmentWindow,
        Other
    }

    public ItemData itemData;
    public ItemWindow itemWindow = ItemWindow.Other;

    private void Awake()
    {
        itemData = new ItemData();
    }
}
