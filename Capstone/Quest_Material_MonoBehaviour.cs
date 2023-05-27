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
        text.text = "x " + _count.ToString();
        text.text = " "  +  _name + " " + _count.ToString() + "°³";
    }
}