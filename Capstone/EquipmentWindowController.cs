using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentWindowController : MonoBehaviour
{
    public Image[] cells;
    TextMeshProUGUI[] miniText;
    public Equipment_ItemData[] equipments;
    public Canvas canvas;
    public Sprite[] backs;


    private static EquipmentWindowController instance;

    public static EquipmentWindowController Instance
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

    private static EquipmentWindowController Create()
    {
        return Instantiate(Resources.Load<EquipmentWindowController>("EquipmentWindow_UI"));
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            equipments = new Equipment_ItemData[cells.Length];
            DontDestroyOnLoad(gameObject);
            miniText = new TextMeshProUGUI[cells.Length];
            for(int i = 0; i < cells.Length; i++)
            {
                miniText[i] = cells[i].GetComponentInChildren<TextMeshProUGUI>();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CellToEmpty(int idx)
    {
        cells[idx].sprite = backs[idx];
        miniText[idx].text = String.Empty;
    }

    public void SetLevel(int idx)
    {
        miniText[idx].text = "+ " + equipments[idx].level.ToString();
    }

    public void Update_Equipment_Window()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            if (equipments[i] == null)
            {
                cells[i].sprite = backs[i];
                cells[i].GetComponent<ItemData_MonoBehaviour>().itemData = new ItemData();
                cells[i].transform.GetComponentInChildren<TextMeshProUGUI>().text = String.Empty;
            }
            else
            {
                string path = "Images/Items/" + InventoryController.part_names[equipments[i].part] + "/" + equipments[i].itemName;

                cells[i].sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
                cells[i].transform.GetComponentInChildren<TextMeshProUGUI>().text = "+ " + equipments[i].level.ToString();

                if (equipments[i].part == 0)
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

    public void Close_Equipment_Window_UI()
    {
        canvas.enabled = false;
    }

    public void GetEquipmentStats(ref int attack, ref int defense)
    {
        attack = 0;
        defense = 0;
        foreach(var equipment in equipments)
        {
            if (equipment == null)
                continue;
            if(equipment.part == 0)
            {
                attack += ((Weapon_ItemData)equipment).attack;
                //Debug.Log("Attack : " + ((Weapon_ItemData)equipment).attack);
            }
            else
            {
                defense += ((Armor_ItemData)equipment).defense;
                //Debug.Log("Defense : " + ((Armor_ItemData)equipment).defense);
            }
        }
    }
}
