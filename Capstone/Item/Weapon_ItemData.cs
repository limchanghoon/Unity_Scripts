using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon_ItemData : Equipment_ItemData
{
    public int attack;
    public GunType gunType;

    public Weapon_ItemData() : base()
    {
        attack = -1;
    }

    public Weapon_ItemData(string _uuid, int _id, string _itemName, Equipment_Part _part, GunType _gunType, int _level = 0, int _attack = 0) : base(_uuid, _id, _itemName, _part ,_level)
    {
        this.attack = _attack;
        this.gunType = _gunType;
    }
}
