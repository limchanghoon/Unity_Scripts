using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_ItemData : Equipment_ItemData
{
    public int power;

    public Weapon_ItemData() : base()
    {
        power = -1;
    }

    public Weapon_ItemData(int _id, string _itemName, char _part, int _level = 0, int _power = 0) : base(_id, _itemName, _part ,_level)
    {
        this.power = _power;
    }
}
