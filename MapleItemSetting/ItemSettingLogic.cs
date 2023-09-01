using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSettingLogic : MonoBehaviour
{
    public ItemSettingUI itemSettingUI;


    public GameObject itemButtonPrefab;
    public GameObject inventoryButtonPrefab;

    public Sprite uiMask;

    ItemSettingData itemSettingData;
    string curPath;
    public ItemDictionary itemDictionary = new ItemDictionary();

    Color noneColor = new Color(0f, 0f, 0f, 0f);
    Color rareColor = new Color(124f / 255f, 230f / 255f, 1f);
    Color epicColor = new Color(162f / 255f, 9f / 255f, 248f / 255f, 1f);
    Color uniqueColor = new Color(1f, 243f / 255f, 0f, 1f);
    Color legendaryColor = new Color(179f / 255f, 1f, 26f / 255f, 1f);

    public void SetItems(ItemSettingData _itemSettingData, Image[] _itemImages, Transform _inventoryTr, string _path)
    {
        itemSettingData = _itemSettingData;
        curPath = _path;
        for(int i = 0; i <= 24; i++)
        {
            if (_itemSettingData.items[i].type == ItemType.NULL)
            {
                _itemImages[i].sprite = uiMask;

                SetColorForPotential(_itemImages[i].transform.GetChild(0).GetComponent<Image>(), OptionGrade.None, OptionGrade.None);
            }
            else
            {
                ItemType typeTMP = _itemSettingData.items[i].type;
                if (typeTMP == ItemType.Blade || typeTMP == ItemType.Lapis || typeTMP == ItemType.Shield || typeTMP == ItemType.SubWeapon2)
                    typeTMP = ItemType.SubWeapon;

                _itemImages[i].sprite = Resources.Load<Sprite>($"Image/Item/{typeTMP.ToString()}/{_itemSettingData.items[i].name}");
                ResizeImage(_itemImages[i].transform.GetComponent<RectTransform>(), _itemImages[i].sprite, 80);

                SetColorForPotential(_itemImages[i].transform.GetChild(0).GetComponent<Image>(), _itemSettingData.items[i].upPotentialGrade, _itemSettingData.items[i].downPotentialGrade);
            }
        }

        for(int i = 0; i < _inventoryTr.childCount; i++)
        {
            if (i < _itemSettingData.Inventory.Count)
            {
                _inventoryTr.GetChild(i).gameObject.SetActive(true);

                ItemType typeTMP = _itemSettingData.Inventory[i].type;
                if (typeTMP == ItemType.Blade || typeTMP == ItemType.Lapis || typeTMP == ItemType.Shield || typeTMP == ItemType.SubWeapon2)
                    typeTMP = ItemType.SubWeapon;

                _inventoryTr.GetChild(i).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/Item/" + typeTMP.ToString() + "/" + _itemSettingData.Inventory[i].name);
                ResizeImage(_inventoryTr.GetChild(i).GetChild(0).GetComponent<RectTransform>(), _inventoryTr.GetChild(i).GetComponent<Image>().sprite, 80);

                SetColorForPotential(_inventoryTr.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>(), _itemSettingData.Inventory[i].upPotentialGrade, _itemSettingData.Inventory[i].downPotentialGrade);
            }
            else
            {
                _inventoryTr.GetChild(i).gameObject.SetActive(false);
            }
        }

        for(int i = _inventoryTr.childCount; i < _itemSettingData.Inventory.Count; i++)
        {
            Button _btn = Instantiate(inventoryButtonPrefab, _inventoryTr).GetComponent<Button>();
            int temp = i;
            _btn.onClick.AddListener(() => {
                itemSettingUI.TurnOnInventoryItemInfo(temp);
            });

            ItemType typeTMP = _itemSettingData.Inventory[i].type;
            if (typeTMP == ItemType.Blade || typeTMP == ItemType.Lapis || typeTMP == ItemType.Shield || typeTMP == ItemType.SubWeapon2)
                typeTMP = ItemType.SubWeapon;

            _inventoryTr.GetChild(i).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/Item/" + typeTMP.ToString() + "/" + _itemSettingData.Inventory[i].name);
            ResizeImage(_inventoryTr.GetChild(i).GetChild(0).GetComponent<RectTransform>(), _inventoryTr.GetChild(i).GetComponent<Image>().sprite, 80);

            SetColorForPotential(_inventoryTr.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>(), _itemSettingData.Inventory[i].upPotentialGrade, _itemSettingData.Inventory[i].downPotentialGrade);
        }
    }

    public void SearchItems(ItemType _itemType, Transform tr)
    {
        SearchItems(_itemType, tr, -1);
    }

    public void SearchItems(ItemType _itemType, Transform tr, int _cell)
    {

        //itemListList
        int childCount = tr.childCount;
        int idx = 0;
        foreach (var _item in itemDictionary.itemListList[(int)_itemType])
        {
            Transform _goTr = tr.GetChild(idx++);
            _goTr.GetComponent<ItemButtonCTR>().itemType = _itemType;
            _goTr.GetComponent<ItemButtonCTR>().reqClassGroup = _item.reqClassGroup;
            _goTr.GetComponent<ItemButtonCTR>().reqClass = _item.reqClass;
            _goTr.GetComponent<ItemButtonCTR>().cell = _cell;
            _goTr.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/Item/" + _itemType.ToString() + "/" + _item.name);
            ResizeImage(_goTr.GetChild(0).GetComponent<RectTransform>(), _goTr.GetChild(0).GetComponent<Image>().sprite, 130);
            _goTr.GetChild(1).GetComponent<TextMeshProUGUI>().text = _item.name;
            _goTr.GetChild(2).GetComponent<TextMeshProUGUI>().text = _item.reqLev.ToString() + "Lv";
        }

        for (; idx < childCount; idx++)
        {
            Transform _goTr = tr.GetChild(idx);
            _goTr.GetComponent<ItemButtonCTR>().reqClassGroup = CharacterClassGroup.Fail;
        }
    }

    public void DisplayCertainItem(CharacterClassGroup _classGroup, Transform tr)
    {
        foreach (Transform child in tr)
        {
            var btnCTR = child.GetComponent<ItemButtonCTR>();
            if (btnCTR.reqClassGroup == _classGroup)
                child.gameObject.SetActive(true);
            else if (btnCTR.reqClassGroup == CharacterClassGroup.Hybrid && (_classGroup == CharacterClassGroup.Thief || _classGroup == CharacterClassGroup.Pirate))
                child.gameObject.SetActive(true);
            else
                child.gameObject.SetActive(false);
        }
    }

    public void ResizeImage(RectTransform rT, Sprite _sprite, int _WH)
    {
        if (_sprite.rect.width > _sprite.rect.height)
        {
            float ratio = _WH / _sprite.rect.width;
            rT.sizeDelta = new Vector2(_WH, ratio * _sprite.rect.height);
        }
        else
        {
            float ratio = _WH / _sprite.rect.height;
            rT.sizeDelta = new Vector2(ratio * _sprite.rect.width, _WH);
        }

    }

    public void SetColorForPotential(Image _image, OptionGrade _upPotentialGrade, OptionGrade _downPotentialGrade)
    {
        if (_upPotentialGrade == OptionGrade.Legendary || _downPotentialGrade == OptionGrade.Legendary)
            _image.color = legendaryColor;
        else if (_upPotentialGrade == OptionGrade.Unique || _downPotentialGrade == OptionGrade.Unique)
            _image.color = uniqueColor;
        else if (_upPotentialGrade == OptionGrade.Epic || _downPotentialGrade == OptionGrade.Epic)
            _image.color = epicColor;
        else if (_upPotentialGrade == OptionGrade.Rare || _downPotentialGrade == OptionGrade.Rare)
            _image.color = rareColor;
        else
            _image.color = noneColor;
    }

    public int IndexFromType(ItemType _type)
    {
        int index;
        switch (_type)
        {
            case ItemType.Ring:
                index = 3;
                break;
            case ItemType.Pocket:
                index = 4;
                break;
            case ItemType.Pendant:
                index = 6;
                break;
            case ItemType.Weapon:
                index = 7;
                break;
            case ItemType.Belt:
                index = 8;
                break;
            case ItemType.Helmet:
                index = 9;
                break;
            case ItemType.Face:
                index = 10;
                break;
            case ItemType.Eye:
                index = 11;
                break;
            case ItemType.Shirt:
                index = 12;
                break;
            case ItemType.Pants:
                index = 13;
                break;
            case ItemType.Shoes:
                index = 14;
                break;
            case ItemType.Earring:
                index = 15;
                break;
            case ItemType.Shoulder:
                index = 16;
                break;
            case ItemType.Gloves:
                index = 17;
                break;
            case ItemType.Android:
                index = 18;
                break;
            case ItemType.Emblem:
                index = 19;
                break;
            case ItemType.Badge:
                index = 20;
                break;
            case ItemType.Medal:
                index = 21;
                break;
            case ItemType.SubWeapon:
                index = 22;
                break;
            case ItemType.Cape:
                index = 23;
                break;
            case ItemType.Heart:
                index = 24;
                break;
            case ItemType.Blade:
                index = 22;
                break;
            case ItemType.Lapis:
                index = 22;
                break;
            case ItemType.Shield:
                index = 22;
                break;
            case ItemType.SubWeapon2:
                index = 22;
                break;
            default:
                index = -1;
                break;
        }

        return index;
    }

    public ItemType TypeFromIndex(int i)
    {
        switch (i)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                return ItemType.Ring;
            case 4:
                return ItemType.Pocket;
            case 5:
            case 6:
                return ItemType.Pendant;
            case 7:
                return ItemType.Weapon;
            case 8:
                return ItemType.Belt;
            case 9:
                return ItemType.Helmet;
            case 10:
                return ItemType.Face;
            case 11:
                return ItemType.Eye;
            case 12:
                return ItemType.Shirt;
            case 13:
                return ItemType.Pants;
            case 14:
                return ItemType.Shoes;
            case 15:
                return ItemType.Earring;
            case 16:
                return ItemType.Shoulder;
            case 17:
                return ItemType.Gloves;
            case 18:
                return ItemType.Android;
            case 19:
                return ItemType.Emblem;
            case 20:
                return ItemType.Badge;
            case 21:
                return ItemType.Medal;
            case 22:
                return ItemType.SubWeapon;
            case 23:
                return ItemType.Cape;
            case 24:
                return ItemType.Heart;
            default:
                return ItemType.NULL;
        }
    }

    public ItemSettingData GetItemSettingData()
    {
        return itemSettingData;
    }

    public string GetCurPath()
    {
        return curPath;
    }

}
