using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMaster// : MonoBehaviour
{
    /*
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
    */

    public static Dictionary<int, ItemData> item_Dic = new Dictionary<int, ItemData>();

    public static Dictionary<int, string> itemDescriptionDic = new Dictionary<int, string>();

    static ItemMaster()
    {
        LoadDictionary();
    }

    static void LoadDictionary()
    {
        item_Dic.Add(100000, new Other_ItemData(100000, "Stone_0", 0));
        item_Dic.Add(100001, new Other_ItemData(100001, "Stone_1", 0));
        item_Dic.Add(100002, new Other_ItemData(100002, "Stone_2", 0));



        item_Dic.Add(10000, new Armor_ItemData("", 10000, "Necklace_1", Equipment_Part.Pendant, 0, 20));
        item_Dic.Add(10001, new Armor_ItemData("", 10001, "Necklace_2", Equipment_Part.Pendant, 0, 40));


        item_Dic.Add(20000, new Armor_ItemData("", 20000, "Gloves_1", Equipment_Part.Gloves, 0, 20));
        item_Dic.Add(20001, new Armor_ItemData("", 20001, "Gloves_2", Equipment_Part.Gloves, 0, 40));


        item_Dic.Add(30000, new Armor_ItemData("", 30000, "Helmet_1", Equipment_Part.Helmet, 0, 20));
        item_Dic.Add(30001, new Armor_ItemData("", 30001, "Helmet_2", Equipment_Part.Helmet, 0, 40));


        item_Dic.Add(40000, new Armor_ItemData("", 40000, "BodyArmor_1", Equipment_Part.Breastplate, 0, 20));
        item_Dic.Add(40001, new Armor_ItemData("", 40001, "BodyArmor_2", Equipment_Part.Breastplate, 0, 40));


        item_Dic.Add(50000, new Armor_ItemData("", 50000, "Boots_1", Equipment_Part.Boots, 0, 20));
        item_Dic.Add(50001, new Armor_ItemData("", 50001, "Boots_2", Equipment_Part.Boots, 0, 40));


        item_Dic.Add(0, new Weapon_ItemData("", 0, "M16", Equipment_Part.Gun, GunType.Rifle, 0, 10));
        item_Dic.Add(100, new Weapon_ItemData("", 100, "AK-47", Equipment_Part.Gun, GunType.Rifle, 0, 30));
        item_Dic.Add(200, new Weapon_ItemData("", 200, "M24", Equipment_Part.Gun, GunType.Sniper, 0, 100));










        itemDescriptionDic.Add(100000, "쉽게 얻을 수 있는 하급 강화석이다.");
        itemDescriptionDic.Add(100001, "약간의 마력이 깃든 하급 강화석이다.");
        itemDescriptionDic.Add(100002, "일반인은 다루기 힘든 중급 강화석이다.");

        itemDescriptionDic.Add(10000, "장신구로서는 볼품없는 녹슨 목걸이다.");
        itemDescriptionDic.Add(10001, "약간의 마력이 깃든 낡은 목걸이다.");


        itemDescriptionDic.Add(20000, "장갑으로서 최소한의 기능은 보장하는 녹슨 장갑이다.");
        itemDescriptionDic.Add(20001, "약간의 마력이 깃든 낡은 장갑이다.");


        itemDescriptionDic.Add(30000, "헬멧으로서 최소한의 기능은 보장하는 녹슨 헬멧이다.");
        itemDescriptionDic.Add(30001, "약간의 마력이 깃든 낡은 헬멧이다.");


        itemDescriptionDic.Add(40000, "갑옷으로서 최소한의 기능은 보장하는 녹슨 갑옷이다.");
        itemDescriptionDic.Add(40001, "약간의 마력이 깃든 낡은 갑옷이다.");


        itemDescriptionDic.Add(50000, "신발으로서 최소한의 기능은 보장하는 녹슨 신발이다.");
        itemDescriptionDic.Add(50001, "약간의 마력이 깃든 낡은 신발이다.");


        itemDescriptionDic.Add(0, "5.56mm 돌격소총으로 경량에 우수한 성능을 보여주는 명기이다.");
        itemDescriptionDic.Add(100, "7.62mm 돌격소총으로 우수한 저지력을 자랑한다. 또한 견고함과 높은 신뢰성으로 높이 평가된다.");
        itemDescriptionDic.Add(200, "7.62mm M24 저격용화기체제 소총으로 미군의 제식 저격소총이다.");
    }
}
