using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMaster : MonoBehaviour
{
    private static ItemMaster instance;

    public static ItemMaster Instance
    {
        get
        {
            if (null == instance)
            {
                return Create();
            }
            return instance;
        }
    }

    private static ItemMaster Create()
    {
        return Instantiate(Resources.Load<ItemMaster>("ItemMaster"));
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadDictionary();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Dictionary<int, string> etcItem_Dic = new Dictionary<int, string>();
    public Dictionary<int, Armor_ItemData> armor_Dic = new Dictionary<int, Armor_ItemData>();
    public Dictionary<int, Weapon_ItemData> weapon_Dic = new Dictionary<int, Weapon_ItemData>();

    void LoadDictionary()
    {
        etcItem_Dic.Add(100000, "Stone_0");
        etcItem_Dic.Add(100001, "Stone_1");
        etcItem_Dic.Add(100002, "Stone_2");

        armor_Dic.Add(10000, new Armor_ItemData("", 10000, "Rusty_Pendant", 1, 0, 20));
        armor_Dic.Add(20000, new Armor_ItemData("", 20000, "Rusty_Gloves", 2, 0, 20));
        armor_Dic.Add(30000, new Armor_ItemData("", 30000, "Rusty_Helmet", 3, 0, 20));
        armor_Dic.Add(40000, new Armor_ItemData("", 40000, "Rusty_Breastplate", 4, 0, 20));
        armor_Dic.Add(50000, new Armor_ItemData("", 50000, "Rusty_Boots", 5, 0, 20));

        weapon_Dic.Add(0, new Weapon_ItemData("", 0, "M16", 0, 0, 10));
        weapon_Dic.Add(100, new Weapon_ItemData("", 100, "AK-47", 0, 0, 20));
    }

    public int GetPartOfEquipment(int _id)
    {
        return _id / 10000;
    }
}
