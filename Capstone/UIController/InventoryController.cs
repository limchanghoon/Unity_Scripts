using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public List<Image> cells;
    List<TextMeshProUGUI> miniText;
    public List<Equipment_ItemData> equipments;
    public List<ETC_ItemData> etcs;
    public Canvas canvas;
    public Transform top_Canvas_Tr;
    public Sprite back;
    public Scrollbar scrollbar;
    public RectTransform content;
    public static string[] part_names = { "Gun", "Pendant", "Gloves", "Helmet", "Breastplate", "Boots" };

    public GameObject cellPrefab;
    public Transform cellParent;

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
            equipments = new List<Equipment_ItemData>(new Equipment_ItemData[cells.Count]);
            etcs = new List<ETC_ItemData>(new ETC_ItemData[cells.Count]);
            miniText = new List<TextMeshProUGUI>(new TextMeshProUGUI[cells.Count]);
            for (int i = 0; i < cells.Count; i++)
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
        for(int i = 0; i < etcs.Count; i++)
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
        UIRaycast.Instance.PreObjSetNull();
        for (int i = 0; i < cells.Count; i++)
        {
            if (equipments[i] == null)
            {
                //cells[i].sprite = back;
                //cells[i].GetComponent<ItemData_MonoBehaviour>().itemData = new ItemData();
                //miniText[i].text = String.Empty;
                cells[i].transform.parent.gameObject.SetActive(false);
            }
            else
            {
                cells[i].transform.parent.gameObject.SetActive(true);
                string path = "Images/Items/" + part_names[equipments[i].part] + "/" + equipments[i].itemName;

                cells[i].GetComponent<Drag_Item>().ReturnToFixPosition();

                cells[i].sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
                miniText[i].text = "+ " + equipments[i].level.ToString();

                cells[i].GetComponent<ItemData_MonoBehaviour>().itemData = equipments[i];
            }
        }
    }

    public void Update_ETC_Inventory()
    {
        curWindow = 2;
        UIRaycast.Instance.PreObjSetNull();
        for (int i =0; i < cells.Count; i++)
        {
            if (etcs[i] == null)
            {
                //cells[i].sprite = back;
                //cells[i].GetComponent<ItemData_MonoBehaviour>().itemData = new ItemData();
                //miniText[i].text = String.Empty;
                cells[i].transform.parent.gameObject.SetActive(false);
            }
            else
            {
                cells[i].transform.parent.gameObject.SetActive(true);
                cells[i].GetComponent<Drag_Item>().ReturnToFixPosition();

                cells[i].sprite = Resources.Load("Images/Items/" + etcs[i].itemName, typeof(Sprite)) as Sprite;
                miniText[i].text = "x " + etcs[i].count.ToString();

                cells[i].GetComponent<ItemData_MonoBehaviour>().itemData = etcs[i];
            }
        }
    }

    public void AddCell()
    {
        var _tr = Instantiate(cellPrefab, cellParent).transform.GetChild(0);
        Drag_Item _drag_Item = _tr.GetComponent<Drag_Item>();
        _drag_Item.canvas = top_Canvas_Tr.GetComponent<Canvas>();
        _drag_Item.top_parent = top_Canvas_Tr;
        cells.Add(_tr.GetComponent<Image>());
        equipments.Add(null);
        etcs.Add(null);
        miniText.Add(cells[cells.Count - 1].GetComponentInChildren<TextMeshProUGUI>());
    }

    public void Close_Inventory_UI()
    {
        for (int i = 0; i < cells.Count; i++)
        {
            cells[i].GetComponent<Drag_Item>().ReturnToFixPosition();
            cells[i].GetComponent<Drag_Item>().isDragging = false;
        }

        ETC_Memory.Instance.windowDepth--;
        gameObject.SetActive(false);
    }
}
