using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Material_MonoBehaviour : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] ItemData_MonoBehaviour itemData_MonoBehaviour;

    public void SetETC(ETC_ItemData _etc_item, int _count)
    {
        itemData_MonoBehaviour.itemData = _etc_item;

        image.sprite = Resources.Load("Images/Items/" + _etc_item.itemName, typeof(Sprite)) as Sprite;
        var item = InventoryController.Instance.Find_Item(_etc_item.itemName);
        string completed_cnt = item != null ? item.count.ToString() : "0";
        text.text = " " + _etc_item.itemName + " " + _count.ToString() + "°³ : " + completed_cnt + "/" + _count.ToString();
    }

    public void SetEquiment(Equipment_ItemData _equipment, int _count)
    {
        itemData_MonoBehaviour.itemData = _equipment;

        image.sprite = Resources.Load("Images/Items/" 
            + InventoryController.part_names[_equipment.part] + "/"+ _equipment.itemName, typeof(Sprite)) as Sprite;
        var item = InventoryController.Instance.Find_Item(_equipment.itemName);
        string completed_cnt = item != null ? item.count.ToString() : "0";
        text.text = " " + _equipment.itemName + " " + _count.ToString() + "°³ : " + completed_cnt + "/" + _count.ToString();
    }
}