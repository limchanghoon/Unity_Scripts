using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor_ItemData : Equipment_ItemData
{
    public int defense;

    public Armor_ItemData(string _uuid, int _id, string _itemName, Equipment_Part _part, int _level = 0, int _defense = 0) : base(_uuid, _id, _itemName, _part, _level)
    {
        this.defense = _defense;
    }
}
