using System.Collections;
using System.Collections.Generic;

public class Other_ItemData : ItemData
{
    public int count;

    public Other_ItemData(int _id, string _itemName, int _count)
    {
        id = _id;
        itemName = _itemName;
        count = _count;

        type = ItemType.Other;
    }

    public Other_ItemData(int _id, int _count)
    {
        id = _id;
        itemName = ItemMaster.item_Dic[_id].itemName;
        count = _count;

        type = ItemType.Other;
    }
}
