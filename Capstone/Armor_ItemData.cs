using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor_ItemData : Equipment_ItemData
{
    public int defense;

    public Armor_ItemData(int _id, string _itemName, char _part, int _level = 0, int _defense = 0) : base(_id, _itemName, _part, _level)
    {
        this.defense = _defense;
    }
}
