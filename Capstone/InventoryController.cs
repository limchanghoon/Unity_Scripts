using Firebase.Database;
using Mono.Cecil.Cil;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Image[] cells;
    public Equipment_ItemData[] equipments;
    public ETC_ItemData[] etcs;
    public Canvas canvas;

    public int curWindow = 0;   /* 0: 장비, 1: 소비?, 2: 기타, 3: 퀘스트 */

    private static InventoryController instance;
    public static InventoryController Instance
    {
        get
        {
            var obj = FindObjectOfType<InventoryController>();
            if (obj != null)
            {
                instance = obj;
            }
            else
            {
                instance = Create();
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
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        equipments = new Equipment_ItemData[cells.Length];
        etcs = new ETC_ItemData[cells.Length];
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
                break;
            }
            if (etc.itemName == _itemName)
            {
                return etc;
            }
        }
        return null;
    }

    public void Update_Equipment_Inventory()
    {
        curWindow = 0;
        for (int i = 0; i < cells.Length; i++)
        {
            if (equipments[i] == null)
                cells[i].gameObject.SetActive(false);
            else
            {
                cells[i].gameObject.SetActive(true);
                cells[i].sprite = Resources.Load("Images/Items/" + equipments[i].itemName, typeof(Sprite)) as Sprite;
                cells[i].transform.GetComponentInChildren<TextMeshProUGUI>().text = "+ " + equipments[i].level.ToString();

                if(equipments[i].part == '0')
                {
                    Weapon_ItemData itemData = new Weapon_ItemData(equipments[i].id, equipments[i].itemName
                        , equipments[i].part, equipments[i].level, ((Weapon_ItemData)equipments[i]).power);

                    cells[i].GetComponent<ItemData_MonoBehaviour>().itemData = itemData;
                }
                else
                {
                    Armor_ItemData itemData = new Armor_ItemData(equipments[i].id, equipments[i].itemName
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
                cells[i].gameObject.SetActive(false);
            else
            {
                cells[i].gameObject.SetActive(true);
                cells[i].sprite = Resources.Load("Images/Items/" + etcs[i].itemName, typeof(Sprite)) as Sprite;
                cells[i].transform.GetComponentInChildren<TextMeshProUGUI>().text = "x " + etcs[i].count.ToString();

                ETC_ItemData itemData = new ETC_ItemData(etcs[i].itemName, etcs[i].count);

                cells[i].GetComponent<ItemData_MonoBehaviour>().itemData = itemData;
            }
        }
    }

    public void Close_Inventory_UI()
    {
        canvas.enabled = false;
    }
}
