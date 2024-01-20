using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

public enum Equipment_Part : byte
{
    Gun=0,
    Pendant,
    Gloves,
    Helmet,
    Breastplate,
    Boots,
    None
}

public class Equipment_ItemData : ItemData
{
    public string uuid;
    public Equipment_Part part;
    public int level;

    public Equipment_ItemData() : base()
    {
        uuid = string.Empty;
        id = -1;
        part = Equipment_Part.None;
        level = -1;

        type = ItemType.Equipment;
    }

    public Equipment_ItemData(string _uuid, int _id, string _itemName, Equipment_Part _part, int _level = 0)
    {
        uuid = _uuid;
        id = _id;
        itemName = _itemName;
        level = _level;
        part = _part;

        type = ItemType.Equipment;
    }

    public void Set(Equipment_ItemData _equipment_ItemData)
    {
        uuid = _equipment_ItemData.uuid;
        id = _equipment_ItemData.id;
        itemName = _equipment_ItemData.itemName;
        level = _equipment_ItemData.level;
        part = _equipment_ItemData.part;

        type = ItemType.Equipment;
    }
}
