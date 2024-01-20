using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIRaycast : MonoBehaviour
{
    public RectTransform itemInfoRectTr;
    public GameObject itemInfoObj;

    public RectTransform itemDeleteRectTr;
    public GameObject itemDeleteObj;

    public Image itemImage;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemAtk;
    public TextMeshProUGUI itemDf;
    public TextMeshProUGUI itemDescription;

    GameObject preObj = null;

    private ItemData curItemData;
    //private ItemType curItemType = ItemType.None;
    //private string curItemUUID = string.Empty;

    private static UIRaycast instance;
    public static UIRaycast Instance
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

    private static UIRaycast Create()
    {
        return Instantiate(Resources.Load<UIRaycast>("RayCast For Item Info"));
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            PointerEventData pointer = new PointerEventData(EventSystem.current);
            pointer.position = Input.mousePosition;

            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointer, raycastResults);

            if (itemDeleteObj.activeSelf)
            {
                if (itemInfoObj.activeSelf)
                    itemInfoObj.SetActive(false);

                for(int i = 0; i < 2; ++i)
                {
                    if (raycastResults.Count > i)
                    {
                        Drag_Item drag_ = raycastResults[i].gameObject.GetComponent<Drag_Item>();

                        if (drag_ != null && drag_.isDragging == true)
                        {
                            itemDeleteObj.SetActive(false);
                            return;
                        }

                        if (raycastResults[i].gameObject == preObj)
                            return;
                    }
                }

                itemDeleteObj.SetActive(false);
            }
                

            if (raycastResults.Count > 0)
            {
                ItemData_MonoBehaviour itemData_Mono = raycastResults[0].gameObject.GetComponent<ItemData_MonoBehaviour>();
                if(itemData_Mono != null && itemData_Mono.itemData.type != ItemType.None)
                {

                    Drag_Item drag_ = raycastResults[0].gameObject.GetComponent<Drag_Item>();
                    if (drag_ != null && drag_.isDragging == true)
                    {
                        if (itemInfoObj.activeSelf)
                            itemInfoObj.SetActive(false);
                        if (itemDeleteObj.activeSelf)
                            itemDeleteObj.SetActive(false);
                        return;
                    }

                    if (Input.GetMouseButtonDown(1) && itemData_Mono.itemWindow == ItemData_MonoBehaviour.ItemWindow.Inventory)
                    {
                        curItemData = itemData_Mono.itemData;
                        itemDeleteObj.SetActive(true);
                    }
                    

                    if (!itemInfoObj.activeSelf)
                        itemInfoObj.SetActive(true);

                    if(preObj == null || preObj != raycastResults[0].gameObject)
                    {
                        preObj = raycastResults[0].gameObject;
                        string path;

                        if (itemData_Mono.itemData.type == ItemType.Other)
                        {
                            path = "Images/Items/" + itemData_Mono.itemData.itemName;

                            itemAtk.gameObject.SetActive(false);
                            itemDf.gameObject.SetActive(false);
                        }
                        else
                        {
                            itemAtk.gameObject.SetActive(true);
                            itemDf.gameObject.SetActive(true);

                            path = "Images/Items/"
                                + ((Equipment_ItemData)itemData_Mono.itemData).part.ToString()
                                + "/" + itemData_Mono.itemData.itemName;

                            if (((Equipment_ItemData)itemData_Mono.itemData).part == Equipment_Part.Gun)
                            {
                                itemAtk.text = "공격력 : " + ((Weapon_ItemData)itemData_Mono.itemData).attack;
                                itemDf.text = "추가 체력 : 0";
                            }
                            else
                            {
                                itemAtk.text = "공격력 : 0";
                                itemDf.text = "추가 체력 : " + ((Armor_ItemData)itemData_Mono.itemData).defense;
                            }
                        }

                        itemImage.sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
                        itemName.text = itemData_Mono.itemData.itemName;
                        itemDescription.text = ItemMaster.itemDescriptionDic[itemData_Mono.itemData.id];
                    }

                    if (pointer.position.x < Screen.width / 2)
                    {
                        if (pointer.position.y < Screen.height / 2)
                        {
                            itemInfoRectTr.pivot = new Vector2(0, 0);
                            itemDeleteRectTr.pivot = new Vector2(0, 0);
                        }
                        else
                        {
                            itemInfoRectTr.pivot = new Vector2(0, 1);
                            itemDeleteRectTr.pivot = new Vector2(0, 1);
                        }
                    }
                    else
                    {
                        if (pointer.position.y < Screen.height / 2)
                        {
                            itemInfoRectTr.pivot = new Vector2(1, 0);
                            itemDeleteRectTr.pivot = new Vector2(1, 0);
                        }
                        else
                        {
                            itemInfoRectTr.pivot = new Vector2(1, 1);
                            itemDeleteRectTr.pivot = new Vector2(1, 1);
                        }
                    }

                    itemInfoRectTr.position = pointer.position;
                    itemDeleteRectTr.position = pointer.position;
                }
                else
                {
                    if (itemInfoObj.activeSelf)
                        itemInfoObj.SetActive(false);
                }
            }
        }
        else
        {
            if (itemInfoObj.activeSelf)
                itemInfoObj.SetActive(false);
        }
    }

    public void DeleteItem()
    {
        Debug.Log("DeleteItem");
        itemDeleteObj.SetActive(false);
       
        CFirebase.Instance.DiscardItem(curItemData);
        //CFirebase.Instance.DiscardItem(curItemUUID, curItemType);
    }

    public void PreObjSetNull()
    {
        preObj = null;
    }
}
