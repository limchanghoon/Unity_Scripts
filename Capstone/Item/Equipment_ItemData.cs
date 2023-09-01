using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

public class Equipment_ItemData : ItemData
{
    public string uuid;
    public int id;
    public int part;
    public int level;
    /* part 0 : ����
     * part 1 : ����� 
     * part 2 : �尩 
     * part 3 : ���� 
     * part 4 : �䰩 
     * part 5 : �Ź� 
     */
    public Equipment_ItemData() : base()
    {
        uuid = string.Empty;
        id = -1;
        part = -1;
        level = -1;

        type = '0';
    }

    public Equipment_ItemData(string _uuid, int _id, string _itemName, int _part, int _level = 0)
    {
        uuid = _uuid;
        id = _id;
        itemName = _itemName;
        level = _level;
        part = _part;

        type = '0';
    }

    public void Set(Equipment_ItemData _equipment_ItemData)
    {
        uuid = _equipment_ItemData.uuid;
        id = _equipment_ItemData.id;
        itemName = _equipment_ItemData.itemName;
        level = _equipment_ItemData.level;
        part = _equipment_ItemData.part;

        type = '0';
    }
}
