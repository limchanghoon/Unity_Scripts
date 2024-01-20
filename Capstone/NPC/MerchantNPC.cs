using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantNPC : MonoBehaviour, IInteract
{
    public GameObject shop_UI;
    public void Interact()
    {
        if (shop_UI.activeSelf)
            return;
        Debug.Log("MerchantNPC Interaction!");
        shop_UI.SetActive(true);
        shop_UI.GetComponent<Canvas>().sortingOrder = ETC_Memory.Instance.top_orderLayer++;
        ETC_Memory.Instance.windowDepth++;
    }

    public void Close_UI()
    {
        shop_UI.SetActive(false);
        ETC_Memory.Instance.windowDepth--;
    }

    public void BuyEquipment(EquipmentMerchandise equipmentMerchandise)
    {
        CFirebase.Instance.GetItem(equipmentMerchandise.equipment_ItemData);
    }
}
