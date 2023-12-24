using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSettingLogic : MonoBehaviour
{
    public SetOptionManager setOptionManager;
    public ItemSettingUI itemSettingUI;
    public AdditionalManager additionalManager;
    public ItemInfo itemInfo;

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

    int STR = 4;
    int STR_p = 100;
    int STR_c = 0;

    int DEX = 4;
    int DEX_p = 100;
    int DEX_c = 0;

    int INT = 4;
    int INT_p = 100;
    int INT_c = 0;

    int LUK = 4;
    int LUK_p = 100;
    int LUK_c = 0;

    int MAXHP = 0;
    int MAXHP_p = 100;
    int MAXHP_c = 0;

    int ATK = 0;
    int ATK_p = 100;
    int MAG = 0;
    int MAG_p = 100;
    int DMG = 100;
    double CRI = 135d;
    double FNL = 1d;

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

    public string GetCombatPower()
    {
        var myCharacterClass = GetItemSettingData().charaacterClass;
        if (myCharacterClass == CharacterClass.DemonAvenger)
            return "������ ������ ���� �Ұ�";
        else if (myCharacterClass == CharacterClass.Xenon)
            return "���� ������ ���� �Ұ�";

        var _items = itemSettingData.items;

        STR = 4;
        STR_p = 100;
        STR_c = 0;

        DEX = 4;
        DEX_p = 100;
        DEX_c = 0;

        INT = 4;
        INT_p = 100;
        INT_c = 0;

        LUK = 4;
        LUK_p = 100;
        LUK_c = 0;

        MAXHP = 0; // �⺻ ü�� ã�ƺ���!
        MAXHP_p = 100;
        MAXHP_c = 0;

        ATK = 0;
        ATK_p = 100;
        MAG = 0;
        MAG_p = 100;
        DMG = 100;
        CRI = 135d;
        FNL = 1d;

        bool checkWeapon = false;
        // ���
        foreach (var _item in _items)
        {
            if (_item.type == ItemType.NULL)
                continue;

            if(_item.weaponType == WeaponType.HeavySword)   // ���δ� �������� ������!
                continue;

            if (_item.type == ItemType.Weapon)
                checkWeapon = true;

            STR += _item.Get3STR() + _item.starforceSTR;
            DEX += _item.Get3DEX() + _item.starforceDEX;
            INT += _item.Get3INT() + _item.starforceINT;
            LUK += _item.Get3LUK() + _item.starforceLUK;
            MAXHP += _item.Get3MaxHP() + _item.starforceMaxHP;

            int allStats = _item.basicAllStats + _item.additionalAllStats + _item.spellAllStats;
            STR_p += allStats;
            DEX_p += allStats;
            INT_p += allStats;
            LUK_p += allStats;

            // ���� ������, ���� ���� ���� X
            CorrectATKMAG(_item);
            DMG += _item.basicDamage + _item.additionalDamage + _item.spellDamage + _item.basicBossATK + _item.additionalBossATK + _item.spellBossATK;
            CRI += _item.basicCriDamage;

            //�ҿ�
            if(_item.soulOption != null)
                InnerAddPotentialOptions(_item.soulOption);

            // ����, �Ʒ���
            AddPotentialOptions(_item);
            if (_item.weaponType == WeaponType.Longsword)   // ���δ� ���� ���� 2��� ���ش�!
                AddPotentialOptions(_item);

            // �ͼ��ų�
            foreach (var _option in _item.exceptionalOption)
                InnerAddPotentialOptions(_option);

            // ���� ���� ����������
            if (_item.type == ItemType.Weapon && _item.isGenesis)
                FNL = 1.1d;
        }

        // ����Ʈ ȯ��
        ReBoot();
        
        // ���� �ȳ��� ������ 0
        if (!checkWeapon)
            return "���⸦ �����Ͻÿ�.";

        // ��Ʈ �ɼ�
        setOptionManager.SetOptionUpdate();
        var snObjList = setOptionManager.GetsnObjList();
        foreach(var setOptionObj in snObjList)
        {
            int count = setOptionObj.GetCount();
            for(int i = 0; i < setOptionObj.setCounts.Length; ++i)
                if (setOptionObj.setCounts[i] <= count)
                    foreach (var _potential in setOptionObj.potentials_2Array[i].potentials)
                        InnerAddPotentialOptions(_potential);
        }

        // ���� ����(�ϴ�260�̶�� ����) => 5n+14+4(4�� �⺻����) (4�� ���Ķ�� ����)
        DividStat();
        // �߰� ����(�ɺ�,���Ͽ�,�����۽���,�����Ƽ,������ �ູ,�����,�����,������,��罺��)
        AddPlusStat();

        double FINAL_STAT = GetFinal_Stat();
        int FINAL_ATK = GetFinal_Atk();
        double FINAL_DMG = (double)DMG / 100;
        double FINAL_CRI = CRI / 100;
        double FINAL_FNL = FNL;

        if (FINAL_STAT < 0 || FINAL_ATK < 0 || FINAL_DMG < 0 || FINAL_CRI < 0 || FINAL_FNL < 0)
            return convertPower(-1);


        /*Debug.Log("FINAL_STAT : " + FINAL_STAT.ToString());
        Debug.Log("FINAL_ATK : " + FINAL_ATK.ToString());
        Debug.Log("FINAL_DMG : " + FINAL_DMG.ToString());
        Debug.Log("FINAL_CRI : " + FINAL_CRI.ToString());
        Debug.Log("FINAL_FNL : " + FINAL_FNL.ToString());*/
        long result = 0;
        checked
        {
            try
            {
                double temp = FINAL_STAT;
                temp *= FINAL_ATK;
                temp *= FINAL_DMG;
                temp *= FINAL_CRI;
                temp *= FINAL_FNL;
                temp = System.Math.Truncate(temp);
                result = (long)temp;
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
                return "������ �ʰ� ����! (�߰� ���� Ȯ��)";
            }
        }
        return convertPower(result);
    }

    private void CorrectATKMAG(Item _item)
    {
        //Ȱ/��󺸿��/���μ�Ʈ ����/�극�� ����/�ܰ�/ü��/��ä/��ũ��
        switch(_item.weaponType)
        {
            case WeaponType.None://���⸦ ������ ��� ����
            case WeaponType.Bow:
            case WeaponType.DualBowguns:
            case WeaponType.AncientBow:
            case WeaponType.Whispershot:
            case WeaponType.Dagger:
            case WeaponType.Chain:
            case WeaponType.RitualFan:
            case WeaponType.Chakram:
                ATK += _item.Get3ATK() + _item.starforceATK;
                MAG += _item.Get3MAG() + _item.starforceMAG;
                break;
            default:
                // ġȯ �⺻ ����, ġȯ �߿� ���� ���ϱ�
                int L = _item.reqLev;
                Item tempItem;
                if (_item.isGenesis) // �ع湫��
                    tempItem = new Item(ItemType.Weapon, "���׽ý� ���", 200, 0, 150, 0, 150, 0, 318, 0, 30, 20, 0, 0, 0, -1);
                else if (L == 200) // ������
                    tempItem = new Item(ItemType.Weapon, "�����μ��̵� ���", 200, 0, 100, 0, 100, 0, 276, 0, 30, 20, 0, 0, 9, 10);
                else if (L == 180) // ���� �ۼ�
                    tempItem = new Item(ItemType.Weapon, "�ۼַ��� ������", 160, 0, 60, 0, 60, 0, 192, 0, 30, 10, 0, 0, 9, 10);
                else if (L == 170) // ���� ����
                    tempItem = new Item(ItemType.Weapon, "�����ϸ� �ٸ���Ŀ��", 150, 0, 40, 0, 40, 0, 160, 0, 30, 10, 0, 0, 9, 10);
                else if (L == 160) // �ۼ�
                    tempItem = new Item(ItemType.Weapon, "�ۼַ��� ������", 160, 0, 60, 0, 60, 0, 192, 0, 30, 10, 0, 0, 9, 10);
                else//if (L == 150)// ����
                    tempItem = new Item(ItemType.Weapon, "�����ϸ� �ٸ���Ŀ��", 150, 0, 40, 0, 40, 0, 160, 0, 30, 10, 0, 0, 9, 10);
                var correctAdditionalList = additionalManager.GetATKMAGAdditional_Num(tempItem);

                var additionalList = additionalManager.GetATKMAGAdditional_Num(_item);
                tempItem.starforce = _item.starforce;
                tempItem.isAmazing = _item.isAmazing;
                // ���ݷ� ȯ��
                var addATK = _item.additionalATK;
                int idx = 0;//5�� �߿� ����!
                for (; idx < 5; ++idx)
                    if (addATK == additionalList[idx])
                        break;
                if (idx < 5)
                    tempItem.additionalATK = correctAdditionalList[idx];
                tempItem.spellATK = _item.spellATK;

                // ���� ȯ��
                var addMAG = _item.additionalMAG;
                idx = 0;//5�� �߿� ����!
                for (; idx < 5; ++idx)
                    if (addMAG == additionalList[idx])
                        break;
                if (idx < 5)
                    tempItem.additionalMAG = correctAdditionalList[idx];
                tempItem.spellMAG = _item.spellMAG;

                // ��Ÿ���� ���, ���� ���??
                itemInfo.UpdateStarForceStats(tempItem);
                if(tempItem.isAmazing)
                {
                    ATK += tempItem.Get3ATK() + _item.starforceATK;
                    MAG += tempItem.Get3MAG() + _item.starforceMAG;
                }
                else
                {
                    ATK += tempItem.Get3ATK() + tempItem.starforceATK;
                    MAG += tempItem.Get3MAG() + tempItem.starforceMAG;
                }
                break;
        }
    }

    private void AddPotentialOptions(Item _item)
    {
        //����
        foreach (var _option in _item.upPotential)
        {
            InnerAddPotentialOptions(_option);
        }

        //�Ʒ���
        foreach (var _option in _item.downPotential)
        {
            InnerAddPotentialOptions(_option);
        }
    }

    private void InnerAddPotentialOptions(Potential _option)
    {
        if (_option.potentialOption == PotentialOption.STR)
        {
            if (_option.percentOrPlus == PP.Plus)
                STR += _option.potentialValue;
            else
                STR_p += _option.potentialValue;
        }
        else if (_option.potentialOption == PotentialOption.DEX)
        {
            if (_option.percentOrPlus == PP.Plus)
                DEX += _option.potentialValue;
            else
                DEX_p += _option.potentialValue;
        }
        else if (_option.potentialOption == PotentialOption.INT)
        {
            if (_option.percentOrPlus == PP.Plus)
                INT += _option.potentialValue;
            else
                INT_p += _option.potentialValue;
        }
        else if (_option.potentialOption == PotentialOption.LUK)
        {
            if (_option.percentOrPlus == PP.Plus)
                LUK += _option.potentialValue;
            else
                LUK_p += _option.potentialValue;
        }
        else if (_option.potentialOption == PotentialOption.MaxHP)
        {
            if (_option.percentOrPlus == PP.Plus)
                MAXHP += _option.potentialValue;
            else
                MAXHP_p += _option.potentialValue;
        }
        else if (_option.potentialOption == PotentialOption.ATK)
        {
            if (_option.percentOrPlus == PP.Plus)
                ATK += _option.potentialValue;
            else
                ATK_p += _option.potentialValue;
        }
        else if (_option.potentialOption == PotentialOption.MAG)
        {
            if (_option.percentOrPlus == PP.Plus)
                MAG += _option.potentialValue;
            else
                MAG_p += _option.potentialValue;
        }
        else if (_option.potentialOption == PotentialOption.CriticalDamage)
        {
            CRI += _option.potentialValue;
        }
        else if (_option.potentialOption == PotentialOption.Damage)
        {
            DMG += _option.potentialValue;
        }
        else if (_option.potentialOption == PotentialOption.AllStats)
        {
            if (_option.percentOrPlus == PP.Plus)
            {
                STR += _option.potentialValue;
                DEX += _option.potentialValue;
                INT += _option.potentialValue;
                LUK += _option.potentialValue;
            }
            else
            {
                STR_p += _option.potentialValue;
                DEX_p += _option.potentialValue;
                INT_p += _option.potentialValue;
                LUK_p += _option.potentialValue;
            }
        }
        else if (_option.potentialOption == PotentialOption.BossATK)
        {
            DMG += _option.potentialValue;
        }
        else if (_option.potentialOption == PotentialOption.STR9)
            STR += (itemSettingData.plusStat.Level / 9) * _option.potentialValue;
        else if (_option.potentialOption == PotentialOption.DEX9)
            DEX += (itemSettingData.plusStat.Level / 9) * _option.potentialValue;
        else if (_option.potentialOption == PotentialOption.INT9)
            INT += (itemSettingData.plusStat.Level / 9) * _option.potentialValue;
        else if (_option.potentialOption == PotentialOption.LUK9)
            LUK += (itemSettingData.plusStat.Level / 9) * _option.potentialValue;
    }

    private void ReBoot()
    {
        var plusStat = itemSettingData.plusStat;
        if (plusStat.isReboot)
        {
            int L = plusStat.Level;
            if (L < 100)
                FNL *= 1.3d;
            else if (L < 150)
                FNL *= 1.4d;
            else if (L < 200)
                FNL *= 1.5d;
            else if (L < 250)
                FNL *= 1.6d;
            else if (L < 300)
                FNL *= 1.65d;
            else
                FNL *= 1.7d;
            ATK += 5;
            MAG += 5;
        }
    }

    private void DividStat()
    {
        var plusStat = itemSettingData.plusStat;
        CharacterClassGroup m_classGroup = itemSettingData.charaacterClassGroup;
        CharacterClass m_class = itemSettingData.charaacterClass;
        if (m_class == CharacterClass.Xenon)
        {
            // ����
            return;
        }
        else if (m_classGroup == CharacterClassGroup.Warrior)
        {
            if (m_class == CharacterClass.DemonAvenger)
            {
                // ������
                return;
            }
            STR += 5 * plusStat.Level + 14;
        }
        else if (m_classGroup == CharacterClassGroup.Bowman)
        {
            DEX += 5 * plusStat.Level + 14;
        }
        else if (m_classGroup == CharacterClassGroup.Magician)
        {
            INT += 5 * plusStat.Level + 14;
        }
        else if (m_classGroup == CharacterClassGroup.Thief)
        {
            LUK += 5 * plusStat.Level + 14;
        }
        else if (m_classGroup == CharacterClassGroup.Pirate)
        {
            if (m_class == CharacterClass.Captain || m_class == CharacterClass.Mechanic || m_class == CharacterClass.AngelicBuster)
                DEX += 5 * plusStat.Level + 14;
            else
                STR += 5 * plusStat.Level + 14;
        }
        else
        {
            Debug.LogError("������ ������ �� ���� ����!!!! : " + m_classGroup.ToFriendlyString() + ", " + m_class.ToFriendlyString());
            return ;
        }
    }

    private void AddPlusStat()
    {
        //(�ɺ�, ���Ͽ�, �����۽���, �����Ƽ, ������ �ູ, �����, �����, ������, ��罺��, ����ü(ǥâ,�Ҹ�))
        var plusStat = itemSettingData.plusStat;

        STR += plusStat.stats[0];           // ��
        STR_c += plusStat.stats[1];         // �� (%������)
        DEX += plusStat.stats[2];           // ��
        DEX_c += plusStat.stats[3];         // �� (%������)
        INT += plusStat.stats[4];           // ��
        INT_c += plusStat.stats[5];         // �� (%������)
        LUK += plusStat.stats[6];           // ��
        LUK_c += plusStat.stats[7];         // �� (%������)
        MAXHP += plusStat.stats[8];         // ü
        MAXHP_c += plusStat.stats[9];       // ü (%������)
        MAXHP_p += plusStat.stats[10];      // ü%
        ATK += plusStat.stats[11];          // ��
        MAG += plusStat.stats[12];          // ��
        DMG += plusStat.stats[13];          // ��
        DMG += plusStat.stats[14];          // ����
        CRI += plusStat.criDamage;          // ũ��
    }

    private double GetFinal_Stat()
    {
        CharacterClassGroup m_classGroup = itemSettingData.charaacterClassGroup;
        CharacterClass m_class = itemSettingData.charaacterClass;
        int mainStat = 0, mainStat_p = 0, mainStat_c = 0, subStat = 0, subStat_p = 0, subStat_c = 0;
        if (m_class == CharacterClass.Xenon)
        {
            // ����
            return 0;
        }
        else if(m_classGroup == CharacterClassGroup.Warrior)
        {
            if(m_class == CharacterClass.DemonAvenger)
            {
                // ������
                return 0;
            }
            mainStat = STR; mainStat_p = STR_p; mainStat_c = STR_c; subStat = DEX; subStat_p = DEX_p; subStat_c = DEX_c;
        }
        else if (m_classGroup == CharacterClassGroup.Bowman)
        {
            mainStat = DEX; mainStat_p = DEX_p; mainStat_c = DEX_c; subStat = STR; subStat_p = STR_p; subStat_c = STR_c;
        }
        else if (m_classGroup == CharacterClassGroup.Magician)
        {
            mainStat = INT; mainStat_p = INT_p; mainStat_c = INT_c; subStat = LUK; subStat_p = LUK_p; subStat_c = LUK_c;
        }
        else if (m_classGroup == CharacterClassGroup.Thief)
        {
            if (m_class == CharacterClass.Shadower || m_class == CharacterClass.DualBlade || m_class == CharacterClass.Cadena)
            {
                //mainStat = LUK; mainStat_p = LUK_p; mainStat_c = LUK_c; subStat = STR + DEX; subStat_p = STR_p + DEX_p; subStat_c = STR_c + DEX_c;
                return (System.Math.Truncate(LUK * LUK_p / 100d + LUK_c) * 4 + System.Math.Truncate(STR * STR_p / 100d + STR_c + DEX * DEX_p / 100d + DEX_c)) / 100d;
            }
            else
            {
                mainStat = LUK; mainStat_p = LUK_p; mainStat_c = LUK_c; subStat = DEX; subStat_p = DEX_p; subStat_c = DEX_c;
            }
        }
        else if (m_classGroup == CharacterClassGroup.Pirate)
        {
            if (m_class == CharacterClass.Captain || m_class == CharacterClass.Mechanic || m_class == CharacterClass.AngelicBuster)
            {
                mainStat = DEX; mainStat_p = DEX_p; mainStat_c = DEX_c; subStat = STR; subStat_p = STR_p; subStat_c = STR_c;
            }
            else
            {
                mainStat = STR; mainStat_p = STR_p; mainStat_c = STR_c; subStat = DEX; subStat_p = DEX_p; subStat_c = DEX_c;
            }
        }
        else
        {
            Debug.LogError("������ ������ �� ���� ����!!!! : " + m_classGroup.ToFriendlyString() + ", " + m_class.ToFriendlyString());
            return 0;
        }

        return (System.Math.Truncate(mainStat * mainStat_p / 100d + mainStat_c) * 4 + System.Math.Truncate(subStat * subStat_p / 100d + subStat_c)) / 100d;
    }

    private int GetFinal_Atk()
    {
        if (itemSettingData.charaacterClassGroup == CharacterClassGroup.Magician)
            return MAG * MAG_p / 100;
        else
            return ATK * ATK_p / 100;
    }


    private string convertPower(long power)
    {
        if (power < 0)
            return "������ ���� ����!(�߰� ���� Ȯ��)";
        else if (power == 0)
            return "0";

        string num = string.Format("{0:#### #### #### #### #### ####}", power).TrimStart().Replace(" ", ",");

        string[] unit = new string[] { "", "��", "��", "��", "��", "��" };
        string[] str = num.Split(',');

        string result = "";
        int cnt = 0;
        for (int i = str.Length; i > 0; --i)
        {
            if (System.Convert.ToInt32(str[i - 1]) != 0)
            {
                result = System.Convert.ToInt32(str[i - 1]) + unit[cnt] + result;
            }
            cnt++;
        }
        return result;
    }
}
