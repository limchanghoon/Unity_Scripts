using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Reward_MonoBehaviour : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] ItemData_MonoBehaviour itemData_MonoBehaviour;

    public void SetItem(ItemData itemData, int _count)
    {
        switch (itemData.type)
        {
            case ItemType.None:
                break;
            case ItemType.Other:
                Set_OtherItem((Other_ItemData)itemData, _count);
                break;
            case ItemType.Equipment:
                Set_EquipmentItem((Equipment_ItemData)itemData, _count);
                break;
        }
    }

    private void Set_OtherItem(Other_ItemData _etc_item, int _count)
    {
        itemData_MonoBehaviour.itemData = _etc_item;

        image.sprite = Resources.Load("Images/Items/" + _etc_item.itemName, typeof(Sprite)) as Sprite;

        text.text = " " + _etc_item.itemName + " " + _count.ToString() + "°³";
    }

    private void Set_EquipmentItem(Equipment_ItemData _equipment, int _count)
    {
        itemData_MonoBehaviour.itemData = _equipment;

        image.sprite = Resources.Load("Images/Items/"
            + _equipment.part.ToString() + "/" + _equipment.itemName, typeof(Sprite)) as Sprite;

        text.text = " " + _equipment.itemName + " " + _count.ToString() + "°³";
    }
}
