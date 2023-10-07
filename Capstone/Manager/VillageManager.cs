using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour
{
    private void Awake()
    {
        InventoryController.Instance.Read_Inventory();
        CFirebase.Instance.ReadWearingEquipment();
    }
}
