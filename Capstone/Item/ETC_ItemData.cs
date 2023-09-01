using System.Collections;
using System.Collections.Generic;

public class ETC_ItemData : ItemData
{
    public int id;
    public int count;

    public ETC_ItemData(string _itemName, int _count)
    {
        itemName = _itemName;
        count = _count;

        type = '1';
    }
}
