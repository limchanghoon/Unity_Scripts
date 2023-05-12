using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

public class Equipment_ItemData : ItemData
{
    public int id;
    public char part;
    public int level;

    public Equipment_ItemData() : base()
    {
        id = -1;
        part = '-';
        level = -1;
    }

    public Equipment_ItemData(int _id, string _itemName, char _part, int _level = 0)
    {
        id = _id;
        itemName = _itemName;
        level = _level;
        part = _part;

        type = '0';
    }

    public void Set(Equipment_ItemData _equipment_ItemData)
    {
        id = _equipment_ItemData.id;
        itemName = _equipment_ItemData.itemName;
        level = _equipment_ItemData.level;
        part = _equipment_ItemData.part;

        type = '0';
    }
}
