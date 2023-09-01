using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantNPC : MonoBehaviour, IInteract
{
    public GameObject daiso_UI;
    public void Interact()
    {
        if (daiso_UI.activeSelf)
            return;
        Debug.Log("Daiso Interaction!");
        daiso_UI.SetActive(true);
        daiso_UI.GetComponent<Canvas>().sortingOrder = ETC_Memory.Instance.top_orderLayer++;
        ETC_Memory.Instance.windowDepth++;
    }

    public void Close_UI()
    {
        daiso_UI.SetActive(false);
        ETC_Memory.Instance.windowDepth--;
    }

    public void BuyEquipment(EquipmentMerchandise equipmentMerchandise)
    {
        if(equipmentMerchandise.m_Part == 0)
        {
            CFirebase.Instance.GetWeapon((Weapon_ItemData)equipmentMerchandise.equipment_ItemData);
        }
        else
        {
            CFirebase.Instance.GetArmor((Armor_ItemData)equipmentMerchandise.equipment_ItemData);
        }
    }
}
