using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

public class ItemData
{
    public int id;
    public string itemName;
    public char type;
    public string description;


    public ItemData() 
    {
        id = -1;
        itemName = "-";
        type = '-';
    }
    /*
    public ItemData(char _type , string _itemName)
    {
        Set(_type, _itemName);
    }

    public void Set(char _type, string _itemName)
    {
        type = _type;
        itemName = _itemName;
    }

    public void Set(ItemData _itemData)
    {
        type = _itemData.type;
        itemName = _itemData.itemName;
    }
    */
}

