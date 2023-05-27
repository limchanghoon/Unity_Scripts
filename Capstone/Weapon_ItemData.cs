using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_ItemData : Equipment_ItemData
{
    public int attack;

    public Weapon_ItemData() : base()
    {
        attack = -1;
    }

    public Weapon_ItemData(string _uuid, int _id, string _itemName, int _part, int _level = 0, int _attack = 0) : base(_uuid, _id, _itemName, _part ,_level)
    {
        this.attack = _attack;
    }
}
