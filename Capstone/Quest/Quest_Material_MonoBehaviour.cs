using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Material_MonoBehaviour : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI text;

    public void SetMaterial(string _name, int _count)
    {
        image.sprite = Resources.Load("Images/Items/" + _name, typeof(Sprite)) as Sprite;
        var item = InventoryController.Instance.Find_Item(_name);
        string completed_cnt = item != null ? item.count.ToString() : "0";
        text.text = " " + _name + " " + _count.ToString() + "°³ : " + completed_cnt + "/" + _count.ToString();
    }
}