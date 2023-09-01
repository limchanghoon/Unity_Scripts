using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Image[] cells;
    TextMeshProUGUI[] miniText;
    public Equipment_ItemData[] equipments;
    public ETC_ItemData[] etcs;
    public Canvas canvas;
    public Sprite back;
    public Scrollbar scrollbar;
    public RectTransform content;
    public static string[] part_names = { "Gun", "Pendant", "Gloves", "Helmet", "Breastplate", "Boots" };

    public int curWindow = 0;   /* 0: 장비, 1: 소비?, 2: 기타, 3: 퀘스트 */

    private static InventoryController instance;
    public static InventoryController Instance
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

    private static InventoryController Create()
    {
        return Instantiate(Resources.Load<InventoryController>("Inventory_UI"));
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            equipments = new Equipment_ItemData[cells.Length];
            etcs = new ETC_ItemData[cells.Length];
            miniText = new TextMeshProUGUI[cells.Length];
            for (int i = 0; i < cells.Length; i++)
            {
                miniText[i] = cells[i].GetComponentInChildren<TextMeshProUGUI>();
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Read_Inventory()
    {
        CFirebase.Instance.ReadItems();
        CFirebase.Instance.ReadEquipments();
    }

    public ETC_ItemData Find_Item(string _itemName)
    {
        foreach (var etc in etcs)
        {
            
            if (etc == null)
            {
                continue;
            }
            if (etc.itemName == _itemName)
            {
                return etc;
            }
        }
        return null;
    }

    public int Find_Item_Index(string _itemName)
    {
        for(int i = 0; i < etcs.Length; i++)
        {
            if (etcs[i] == null)
            {
                continue;
            }
            if (etcs[i].itemName == _itemName)
            {
                return i;
            }
        }
        return -1;
    }

    public void Update_Equipment_Inventory()
    {
        curWindow = 0;
        for (int i = 0; i < cells.Length; i++)
        {
            if (equipments[i] == null)
            {
                cells[i].sprite = back;
                cells[i].GetComponent<ItemData_MonoBehaviour>().itemData = new ItemData();
                miniText[i].text = String.Empty;
            }
            else
            {
                string path = "Images/Items/" + part_names[equipments[i].part] + "/" + equipments[i].itemName;

                cells[i].GetComponent<Drag_Item>().ReturnToFixPosition();

                cells[i].sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
                miniText[i].text = "+ " + equipments[i].level.ToString();

                if(equipments[i].part == 0)
                {
                    Weapon_ItemData itemData = new Weapon_ItemData(equipments[i].uuid, equipments[i].id, equipments[i].itemName
                        , equipments[i].part, equipments[i].level, ((Weapon_ItemData)equipments[i]).attack);

                    cells[i].GetComponent<ItemData_MonoBehaviour>().itemData = itemData;
                }
                else
                {
                    Armor_ItemData itemData = new Armor_ItemData(equipments[i].uuid, equipments[i].id, equipments[i].itemName
                        , equipments[i].part, equipments[i].level, ((Armor_ItemData)equipments[i]).defense);

                    cells[i].GetComponent<ItemData_MonoBehaviour>().itemData = itemData;
                }
            }
        }
    }

    public void Update_ETC_Inventory()
    {
        curWindow = 2;
        for (int i =0; i < cells.Length; i++)
        {
            if (etcs[i] == null)
            {
                cells[i].sprite = back;
                cells[i].GetComponent<ItemData_MonoBehaviour>().itemData = new ItemData();
                miniText[i].text = String.Empty;
            }
            else
            {
                cells[i].GetComponent<Drag_Item>().ReturnToFixPosition();

                cells[i].sprite = Resources.Load("Images/Items/" + etcs[i].itemName, typeof(Sprite)) as Sprite;
                miniText[i].text = "x " + etcs[i].count.ToString();

                ETC_ItemData itemData = new ETC_ItemData(etcs[i].itemName, etcs[i].count);

                cells[i].GetComponent<ItemData_MonoBehaviour>().itemData = itemData;
            }
        }
    }

    public void Close_Inventory_UI()
    {
        ETC_Memory.Instance.windowDepth--;
        gameObject.SetActive(false);
    }
}
