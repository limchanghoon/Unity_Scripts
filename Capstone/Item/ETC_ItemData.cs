using System.Collections;
using System.Collections.Generic;

public class ETC_ItemData : ItemData
{
    public int count;

    public ETC_ItemData(int _id, string _itemName, int _count)
    {
        id = _id;
        itemName = _itemName;
        count = _count;

        type = '1';
    }
}
