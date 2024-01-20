using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

public class ItemData
{
    public int id;
    public string itemName;
    public ItemType type;
    public string description;


    public ItemData() 
    {
        id = -1;
        itemName = "-";
        type = ItemType.None;
    }
}

public enum ItemType : byte
{
    None=0,
    Other,
    Equipment
}

