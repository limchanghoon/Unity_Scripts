using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StarForceManager : MonoBehaviour
{
    public ItemInfo itemInfo;
    public ItemSettingLogic itemSettingLogic;
    public ISFileManager fileManager;
    public ItemSettingUI uiManager;

    public GameObject starForcePanel;
    public GameObject amazingPanel;

    // 놀타포스같은 것 제외한다.
    public TextMeshProUGUI[] texts;

    public TextMeshProUGUI starText;
    public TextMeshProUGUI amazingText;

    public TMP_Dropdown[] amazingDropdowns; //스텟,공마,MaxHP
    public TMP_Dropdown dropdown;

    int count = 0;
    // 놀장 스텟
    int[] AZ150S = { 19, 20, 22, 25, 29, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 1~15성
    int[] AZ145S = { 18, 19, 21, 24, 28, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 1~15성
    int[] AZ140S = { 17, 18, 20, 23, 27, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 1~15성
    int[] AZ135S = { 15, 16, 18, 21, 25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 1~15성
    int[] AZ130S = { 14, 15, 17, 20, 24, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 1~15성
    int[] AZ125S = { 13, 14, 16, 19, 23, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 1~15성
    int[] AZ120S = { 12, 13, 15, 18, 22, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 1~15성
    int[] AZ115S = { 10, 11, 13, 16, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 1~15성
    int[] AZ110S = { 9, 10, 12, 15, 19, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 1~15성
    int[] AZ105S = { 8, 9, 11, 14, 18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 1~15성
    int[] AZ100S = { 7, 8, 10, 13, 17, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 1~15성
    int[] AZ95S = { 5, 6, 8, 11, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 1~15성
    int[] AZ90S = { 4, 5, 7, 10, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 1~15성
    int[] AZ85S = { 3, 4, 6, 9, 13, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 1~15성
    int[] AZ80S = { 2, 3, 5, 8, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 1~15성
    int[] AZ75S = { 1, 2, 4, 7, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 1~15성

    // 놀장 공격력
    int[] AZ150 = { 0, 0, 0, 0, 0, 9, 10, 11, 12, 13, 14, 16, 18, 20, 22 }; // 1~15성
    int[] AZ140 = { 0, 0, 0, 0, 0, 8, 9, 10, 11, 12, 13, 15, 17, 19, 21 }; // 1~15성
    int[] AZ130 = { 0, 0, 0, 0, 0, 7, 8, 9, 10, 11, 12, 14, 16, 18, 20 }; // 1~15성
    int[] AZ120 = { 0, 0, 0, 0, 0, 6, 7, 8, 9, 10, 11, 13, 15, 17, 19 }; // 1~15성
    int[] AZ110 = { 0, 0, 0, 0, 0, 5, 6, 7, 8, 9, 10, 12, 14, 16, 18 }; // 1~15성
    int[] AZ100 = { 0, 0, 0, 0, 0, 4, 5, 6, 7, 8, 9, 11, 13, 15, 17 }; // 1~15성
    int[] AZ90 = { 0, 0, 0, 0, 0, 3, 4, 5, 6, 7, 8, 10, 12, 14, 16 }; // 1~15성
    int[] AZ80 = { 0, 0, 0, 0, 0, 2, 3, 4, 5, 6, 7, 9, 11, 13, 15 }; // 1~15성
    int[] AZ75 = { 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 8, 10, 12, 14 }; // 1~15성

    int[] Superior150S = { 19, 20, 22, 25, 29, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 1~15성
    int[] Superior150 = { 0, 0, 0, 0, 0, 9, 10, 11, 12, 13, 15, 17, 19, 21, 23 }; // 1~15성


    // 15성 이상에서 기본 스텟 > 0 || 작 스텟 > 0
    void SetStatTexts(int value)
    {
        if (value == 0)
            return;
        var curItem = itemInfo.GetCurItem();
        int starCount = curItem.starforce;
        if (curItem.reqClassGroup == CharacterClassGroup.NULL || curItem.reqClassGroup == CharacterClassGroup.Warrior 
            || curItem.reqClassGroup == CharacterClassGroup.Bowman || curItem.reqClassGroup == CharacterClassGroup.Pirate || curItem.reqClassGroup == CharacterClassGroup.Hybrid)
            texts[count++].text = "STR +" + value.ToString();
        else if (starCount >= 15 && (curItem.basicSTR > 0 || curItem.spellSTR > 0))
            texts[count++].text = "STR +" + value.ToString();

        if (curItem.reqClassGroup == CharacterClassGroup.NULL || curItem.reqClassGroup == CharacterClassGroup.Warrior 
            || curItem.reqClassGroup == CharacterClassGroup.Bowman || curItem.reqClassGroup == CharacterClassGroup.Thief 
            || curItem.reqClassGroup == CharacterClassGroup.Pirate || curItem.reqClassGroup == CharacterClassGroup.Hybrid)
            texts[count++].text = "DEX +" + value.ToString();
        else if (starCount >= 15 && (curItem.basicDEX > 0 || curItem.spellDEX > 0))
            texts[count++].text = "DEX +" + value.ToString();

        if (curItem.reqClassGroup == CharacterClassGroup.NULL || curItem.reqClassGroup == CharacterClassGroup.Magician )
            texts[count++].text = "INT +" + value.ToString();
        else if (starCount >= 15 && (curItem.basicINT > 0 || curItem.spellINT > 0))
            texts[count++].text = "INT +" + value.ToString();

        if (curItem.reqClassGroup == CharacterClassGroup.NULL || curItem.reqClassGroup == CharacterClassGroup.Magician 
            || curItem.reqClassGroup == CharacterClassGroup.Thief || curItem.reqClassGroup == CharacterClassGroup.Hybrid)
            texts[count++].text = "LUK +" + value.ToString();
        else if (starCount >= 15 && (curItem.basicLUK > 0 || curItem.spellLUK > 0))
            texts[count++].text = "LUK +" + value.ToString();
    }

    void SetAMTexts(int valueA, int valueM)
    {
        if (valueA == 0 && valueM == 0)
            return;

        var curItem = itemInfo.GetCurItem();

        if (curItem.reqClassGroup != CharacterClassGroup.Magician
            || itemInfo.CheckAccessory()
            || curItem.basicATK > 0 || curItem.spellATK > 0)
            texts[count++].text = "공격력 +" + valueA.ToString();

        if (curItem.reqClassGroup == CharacterClassGroup.Magician || curItem.reqClassGroup == CharacterClassGroup.NULL
            || itemInfo.CheckAccessory()
            || curItem.basicMAG > 0 || curItem.spellMAG > 0)
            texts[count++].text = "마력 +" + valueM.ToString();
    }

    void SetAMTexts(int value)
    {
        if (value == 0)
            return;
        SetAMTexts(value, value);
    }

    void SetMaxHPMP(int _startCount, ItemType _itemType)
    {
        if (_startCount >= 15)
            return;

        if (_itemType == ItemType.Face || _itemType == ItemType.Eye || _itemType == ItemType.Earring
            || _itemType == ItemType.Shoes || _itemType == ItemType.Gloves || _itemType == ItemType.Heart)
            return;

        if (_startCount <= 2)
            texts[count++].text = "최대 HP + 5";
        else if (_startCount <= 4)
            texts[count++].text = "최대 HP + 10";
        else if (_startCount <= 6)
            texts[count++].text = "최대 HP + 15";
        else if (_startCount <= 8)
            texts[count++].text = "최대 HP + 20";
        else if (_startCount <= 14)
            texts[count++].text = "최대 HP + 25";

        if(_itemType == ItemType.Weapon || _itemType == ItemType.Blade || _itemType == ItemType.Lapis)
        {
            if (_startCount <= 2)
                texts[count++].text = "최대 MP + 5";
            else if (_startCount <= 4)
                texts[count++].text = "최대 MP + 10";
            else if (_startCount <= 6)
                texts[count++].text = "최대 MP + 15";
            else if (_startCount <= 8)
                texts[count++].text = "최대 MP + 20";
            else if (_startCount <= 14)
                texts[count++].text = "최대 MP + 25";
        }
    }

    void SetStatTextsForAmazing(int value)
    {
        if (value == 0)
            return;
        var curItem = itemInfo.GetCurItem();

        if (curItem.Get3STR() > 0)
            texts[count++].text = "STR +" + value.ToString();
        if (curItem.Get3DEX() > 0)
            texts[count++].text = "DEX +" + value.ToString();
        if (curItem.Get3INT() > 0)
            texts[count++].text = "INT +" + value.ToString();
        if (curItem.Get3LUK() > 0)
            texts[count++].text = "LUK +" + value.ToString();
    }

    void SetAMTextsForAmazing(int valueA, int valueM)
    {
        if (valueA == 0 && valueM == 0)
            return;

        var curItem = itemInfo.GetCurItem();

        if (curItem.Get3ATK() > 0)
            texts[count++].text = "공격력 +" + valueA.ToString();

        if (curItem.Get3MAG() > 0)
            texts[count++].text = "마력 +" + valueM.ToString();
    }

    void SetAMTextsForAmazing(int value)
    {
        if (value == 0)
            return;
        SetAMTextsForAmazing(value, value);
    }


    int GetMaxStarForce()
    {
        if (itemInfo.GetCurItem().isStarForce == false)
            return itemInfo.GetCurItem().starforce;

        if (itemInfo.GetCurItem().isSuperior == true)//타일런트 시리즈
            return 15;

        int L = itemInfo.GetCurItem().reqLev;

        if (L >= 138)
            return 25;
        else if (L >= 128)
            return 20;
        else if (L >= 118)
            return 15;
        else if (L >= 108)
            return 10;
        else if (L >= 95)
            return 8;
        else
            return 5;
    }


    public void UIReset()
    {
        foreach (var txt in texts)
            txt.text = "";

        count = 0;
        var curItem = itemInfo.GetCurItem();
        int L = curItem.reqLev;
        int starCount = curItem.starforce;
        ItemType curitemType = curItem.type;

        if (curItem.isAmazing == false)
        {
            starText.text = curItem.starforce.ToString() + "성 -> " + (curItem.starforce + 1).ToString() + "성";

            if (curItem.starforce == GetMaxStarForce())
            {
                texts[0].text = "스타포스 최대치 달성";
                starText.text = curItem.starforce.ToString() + "성(최대치)";
                return;
            }
        }
        else
        {
            starText.text = "0성 -> 1성";
            starCount = 0;
        }

        if(curItem.isSuperior == true)
        {
            SetAMTexts(Superior150[starCount]);
            SetStatTexts(Superior150S[starCount]);
            return;
        }


        int weaponA = 0;
        int weaponM = 0;
        if ((curitemType == ItemType.Weapon || curitemType == ItemType.Blade || curitemType == ItemType.Lapis) && starCount <= 14)
        {
            int preWeaponA = 0;
            int preWeaponM = 0;
            int _S = Mathf.Min(15, starCount + 1);
            for (int i = 0; i < _S; i++)
            {
                preWeaponA = weaponA;
                preWeaponM = weaponM;

                weaponA += (curItem.basicATK + curItem.spellATK + weaponA) / 50 + 1;
                weaponM += (curItem.basicMAG + curItem.spellMAG + weaponM) / 50 + 1;
            }
            weaponA = weaponA - preWeaponA;
            weaponM = weaponM - preWeaponM;
        }


        if (L >= 248)       // 에테르넬
        {
            if (curitemType == ItemType.Weapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis)
                SetAMTexts(weaponA + itemInfo.SF250W[starCount + 1] - itemInfo.SF250W[starCount], weaponM + itemInfo.SF250W[starCount + 1] - itemInfo.SF250W[starCount]);
            else
            {
                if (curitemType == ItemType.Gloves)
                    SetAMTexts(itemInfo.SF250[starCount + 1] - itemInfo.SF250[starCount] + itemInfo.SFGloveBonus[starCount + 1] - itemInfo.SFGloveBonus[starCount]);
                else
                    SetAMTexts(itemInfo.SF250[starCount + 1] - itemInfo.SF250[starCount]);
            }
            SetStatTexts(itemInfo.SF250S[starCount + 1] - itemInfo.SF250S[starCount]);
            SetMaxHPMP(starCount, curitemType);
        } 
        else if(L >= 198)   // 아케인
        {
            if (curitemType == ItemType.Weapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis)
                SetAMTexts(weaponA + itemInfo.SF200W[starCount + 1] - itemInfo.SF200W[starCount], weaponM + itemInfo.SF200W[starCount + 1] - itemInfo.SF200W[starCount]);
            else
            {
                if (curitemType == ItemType.Gloves)
                    SetAMTexts(itemInfo.SF200[starCount + 1] - itemInfo.SF200[starCount] + itemInfo.SFGloveBonus[starCount + 1] - itemInfo.SFGloveBonus[starCount]);
                else
                    SetAMTexts(itemInfo.SF200[starCount + 1] - itemInfo.SF200[starCount]);
            }
            SetStatTexts(itemInfo.SF200S[starCount + 1] - itemInfo.SF200S[starCount]);
            SetMaxHPMP(starCount, curitemType);
        }
        else if (L >= 158)  // 앱솔
        {
            if (curitemType == ItemType.Weapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis)
                SetAMTexts(weaponA + itemInfo.SF160W[starCount + 1] - itemInfo.SF160W[starCount], weaponM + itemInfo.SF160W[starCount + 1] - itemInfo.SF160W[starCount]);
            else
            {
                if (curitemType == ItemType.Gloves)
                    SetAMTexts(itemInfo.SF160[starCount + 1] - itemInfo.SF160[starCount] + itemInfo.SFGloveBonus[starCount + 1] - itemInfo.SFGloveBonus[starCount]);
                else
                    SetAMTexts(itemInfo.SF160[starCount + 1] - itemInfo.SF160[starCount]);
            }
            SetStatTexts(itemInfo.SF160S[starCount + 1] - itemInfo.SF160S[starCount]);
            SetMaxHPMP(starCount, curitemType);
        }
        else if (L >= 148)  // 루타
        {
            if (curitemType == ItemType.Weapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis)
                SetAMTexts(weaponA + itemInfo.SF150W[starCount + 1] - itemInfo.SF150W[starCount], weaponM + itemInfo.SF150W[starCount + 1] - itemInfo.SF150W[starCount]);
            else
            {
                if (curitemType == ItemType.Gloves)
                    SetAMTexts(itemInfo.SF150[starCount + 1] - itemInfo.SF150[starCount] + itemInfo.SFGloveBonus[starCount + 1] - itemInfo.SFGloveBonus[starCount]);
                else
                    SetAMTexts(itemInfo.SF150[starCount + 1] - itemInfo.SF150[starCount]);
            }
            SetStatTexts(itemInfo.SF150S[starCount + 1] - itemInfo.SF150S[starCount]);
            SetMaxHPMP(starCount, curitemType);
        }
        else if (L >= 138)
        {
            if (curitemType == ItemType.Weapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis)
                SetAMTexts(weaponA + itemInfo.SF140W[starCount + 1] - itemInfo.SF140W[starCount], weaponM + itemInfo.SF140W[starCount + 1] - itemInfo.SF140W[starCount]);
            else
            {
                if (curitemType == ItemType.Gloves)
                    SetAMTexts(itemInfo.SF140[starCount + 1] - itemInfo.SF140[starCount] + itemInfo.SFGloveBonus[starCount + 1] - itemInfo.SFGloveBonus[starCount]);
                else
                    SetAMTexts(itemInfo.SF140[starCount + 1] - itemInfo.SF140[starCount]);
            }
            SetStatTexts(itemInfo.SF140S[starCount + 1] - itemInfo.SF140S[starCount]);
            SetMaxHPMP(starCount, curitemType);
        }
        else
        {
            if (curitemType == ItemType.Weapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis)
                SetAMTexts(weaponA + itemInfo.SF130W[starCount + 1] - itemInfo.SF130W[starCount], weaponM + itemInfo.SF130W[starCount + 1] - itemInfo.SF130W[starCount]);
            else
            {
                if (curitemType == ItemType.Gloves)
                    SetAMTexts(itemInfo.SF130[starCount + 1] - itemInfo.SF130[starCount] + itemInfo.SFGloveBonus[starCount + 1] - itemInfo.SFGloveBonus[starCount]);
                else
                    SetAMTexts(itemInfo.SF130[starCount + 1] - itemInfo.SF130[starCount]);
            }
            SetStatTexts(itemInfo.SF130S[starCount + 1] - itemInfo.SF130S[starCount]);
            SetMaxHPMP(starCount, curitemType);
        }
    }

    public void UIResetForAmazing()
    {
        foreach (var txt in texts)
            txt.text = "";

        foreach (var drop in amazingDropdowns)
            drop.ClearOptions();

        count = 0;
        var curItem = itemInfo.GetCurItem();
        int L = curItem.reqLev;
        int starCount = curItem.starforce;
        ItemType curitemType = curItem.type;

        if(curItem.reqClass == CharacterClass.Zero)
        {
            amazingText.text = "놀장 불가능";
            texts[0].text = "제로 무기는 놀장 불가능";
            return;
        }

        if (curItem.isSuperior == true)
        {
            amazingText.text = "놀장 불가능";
            texts[0].text = "슈페리얼 장비는 놀장 불가능";
            return;
        }

        if (L > 150)
        {
            amazingText.text = "놀장 불가능";
            texts[0].text = "150레벨 초과하는 아이템은 놀장 불가능";
            return;
        }

        if (curItem.isAmazing)
        {
            amazingText.text = curItem.starforce.ToString() + "성 -> " + (curItem.starforce + 1).ToString() + "성";
            if (curItem.starforce == 15)
            {
                texts[0].text = "놀장 최대치 달성";
                amazingText.text = curItem.starforce.ToString() + "성(최대치)";
                return;
            }
        }
        else
        {
            amazingText.text = "0성 -> 1성";
            starCount = 0;
        }

        int _stats = 0;
        int _atk = 0;
        int _mag = 0;
        int _am = 0;

        if (curitemType == ItemType.Weapon || curItem.type == ItemType.Blade)
        {
            amazingDropdowns[0].AddOptions(new List<string> { "공/마 보너스", "+1" });
            _atk += (curItem.Get3ATK() + curItem.amazingATK) / 50 + 1;
            _mag += (curItem.Get3MAG() + curItem.amazingMAG) / 50 + 1;
        }
        else if (curitemType == ItemType.Shield)
        {
            amazingDropdowns[0].AddOptions(new List<string> { "공/마 보너스", "+1" });
        }
        else if(!itemInfo.CheckAccessory() && curitemType != ItemType.Shoulder && curitemType != ItemType.Heart) // 방어구
        {
            amazingDropdowns[2].AddOptions(new List<string> { "최대 Hp 보너스", "+50" });
        }



        if (L == 150)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+1", "+2" });
                else
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+2" });
            }

            if (starCount < 5)
                _stats += AZ150S[starCount];
            else
                _am += AZ150[starCount];
        }
        else if (L >= 141)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+1", "+2" });
                else
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+2" });
            }

            if (starCount < 5)
                _stats += AZ145S[starCount];
            else
                _am += AZ140[starCount];
        }
        else if (L == 140)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+1", "+2" });
                else
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+2" });
            }

            if (starCount < 5)
                _stats += AZ140S[starCount];
            else
                _am += AZ140[starCount];
        }
        else if (L >= 131)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+1", "+2" });
                else
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+2" });
            }

            if (starCount < 5)
                _stats += AZ135S[starCount];
            else
                _am += AZ130[starCount];
        }
        else if (L == 130)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+1", "+2" });
                else
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+2" });
            }

            if (starCount < 5)
                _stats += AZ130S[starCount];
            else
                _am += AZ130[starCount];
        }
        else if (L >= 121)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+1", "+2" });
                else
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+2" });
            }

            if (starCount < 5)
                _stats += AZ125S[starCount];
            else
                _am += AZ120[starCount];
        }
        else if (L == 120)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+1", "+2" });
                else
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+2" });
            }

            if (starCount < 5)
                _stats += AZ120S[starCount];
            else
                _am += AZ120[starCount];
        }
        else if (L >= 111)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+1" });
                else
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+2" });
            }

            if (starCount < 5)
                _stats += AZ115S[starCount];
            else
                _am += AZ110[starCount];
        }
        else if (L == 110)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+1" });
                else
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+2" });
            }

            if (starCount < 5)
                _stats += AZ110S[starCount];
            else
                _am += AZ110[starCount];
        }
        else if (L >= 101)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+1" });
                else
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+2" });
            }

            if (starCount < 5)
                _stats += AZ105S[starCount];
            else
                _am += AZ100[starCount];
        }
        else if (L == 100)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+1" });
                else
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+2" });
            }

            if (starCount < 5)
                _stats += AZ100S[starCount];
            else
                _am += AZ110[starCount];
        }
        else if (L >= 91)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+1" });
                else
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+2" });
            }

            if (starCount < 5)
                _stats += AZ95S[starCount];
            else
                _am += AZ90[starCount];
        }
        else if (L == 90)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+1" });
                else
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+2" });
            }

            if (starCount < 5)
                _stats += AZ90S[starCount];
            else
                _am += AZ90[starCount];
        }
        else if (L >= 81)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+1" });
                else
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+2" });
            }

            if (starCount < 5)
                _stats += AZ85S[starCount];
            else
                _am += AZ80[starCount];
        }
        else if (L == 80)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+1" });
                else
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+2" });
            }

            if (starCount < 5)
                _stats += AZ80S[starCount];
            else
                _am += AZ80[starCount];
        }
        else
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+1" });
                else
                    amazingDropdowns[1].AddOptions(new List<string> { "스텟 보너스", "+2" });
            }

            if (starCount < 5)
                _stats += AZ75S[starCount];
            else
                _am += AZ75[starCount];
        }

        SetAMTextsForAmazing(_am + _atk, _am + _mag);
        SetStatTextsForAmazing(_stats);
        texts[count++].text = "(보너스 능력치 미포함)";
    }

    private void AmazingStatsUp(int value)
    {
        if (value == 0)
            return;
        var curItem = itemInfo.GetCurItem();

        if (curItem.Get3STR() > 0)
            curItem.amazingSTR += value;
        if (curItem.Get3DEX() > 0)
            curItem.amazingDEX += value;
        if (curItem.Get3INT() > 0)
            curItem.amazingINT += value;
        if (curItem.Get3LUK() > 0)
            curItem.amazingLUK += value;
    }

    private void AmazingAMUp(int valueA, int valueM)
    {
        if (valueA == 0 && valueM == 0)
            return;

        var curItem = itemInfo.GetCurItem();

        if (curItem.Get3ATK() > 0)
            curItem.amazingATK += valueA;

        if (curItem.Get3MAG() > 0)
            curItem.amazingMAG += valueM;
    }

    private void AmazingAMUp(int value)
    {
        if (value == 0)
            return;
        AmazingAMUp(value, value);
    }

    private void AmazingMaxHPUp(int _maxHP)
    {
        itemInfo.GetCurItem().amazingMaxHP += _maxHP;
    }


    private void AmazingUp(Item curItem)
    {
        int starCount = curItem.starforce++;
        int L = curItem.reqLev;
        ItemType curitemType = curItem.type;

        int _stats = 0;
        int _atk = 0;
        int _mag = 0;
        int _am = 0;
        int _maxHP = 0;

        if (curitemType == ItemType.Weapon || curItem.type == ItemType.Blade)
        {
            if (amazingDropdowns[0].value == 1)
                _am += 1;
            _atk += (curItem.Get3ATK() + curItem.amazingATK) / 50 + 1;
            _mag += (curItem.Get3MAG() + curItem.amazingMAG) / 50 + 1;
        }
        else if (curitemType == ItemType.Shield)
        {
            if (amazingDropdowns[0].value == 1)
                _am += 1;
        }
        else if (!itemInfo.CheckAccessory() && curitemType != ItemType.Shoulder && curitemType != ItemType.Heart) // 방어구
        {
            if (amazingDropdowns[2].value == 1)
                _maxHP += 50;
        }



        if (L == 150)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 1;
                    else if (amazingDropdowns[1].value == 2)
                        _stats += 2;
                }
                else
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 2;
                }
            }

            if (starCount < 5)
                _stats += AZ150S[starCount];
            else
                _am += AZ150[starCount];
        }
        else if (L >= 141)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 1;
                    else if (amazingDropdowns[1].value == 2)
                        _stats += 2;
                }
                else
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 2;
                }
            }

            if (starCount < 5)
                _stats += AZ145S[starCount];
            else
                _am += AZ140[starCount];
        }
        else if (L == 140)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 1;
                    else if (amazingDropdowns[1].value == 2)
                        _stats += 2;
                }
                else
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 2;
                }
            }

            if (starCount < 5)
                _stats += AZ140S[starCount];
            else
                _am += AZ140[starCount];

        }
        else if (L >= 131)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 1;
                    else if (amazingDropdowns[1].value == 2)
                        _stats += 2;
                }
                else
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 2;
                }
            }

            if (starCount < 5)
                _stats += AZ135S[starCount];
            else
                _am += AZ130[starCount];
        }
        else if (L == 130)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 1;
                    else if (amazingDropdowns[1].value == 2)
                        _stats += 2;
                }
                else
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 2;
                }
            }

            if (starCount < 5)
                _stats += AZ130S[starCount];
            else
                _am += AZ130[starCount];
        }
        else if (L >= 121)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 1;
                    else if (amazingDropdowns[1].value == 2)
                        _stats += 2;
                }
                else
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 2;
                }
            }

            if (starCount < 5)
                _stats += AZ125S[starCount];
            else
                _am += AZ120[starCount];
        }
        else if (L == 120)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 1;
                    else if (amazingDropdowns[1].value == 2)
                        _stats += 2;
                }
                else
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 2;
                }
            }

            if (starCount < 5)
                _stats += AZ120S[starCount];
            else
                _am += AZ120[starCount];
        }
        else if (L >= 111)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 1;
                }
                else
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 2;
                }
            }

            if (starCount < 5)
                _stats += AZ115S[starCount];
            else
                _am += AZ110[starCount];
        }
        else if (L == 110)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 1;
                }
                else
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 2;
                }
            }

            if (starCount < 5)
                _stats += AZ110S[starCount];
            else
                _am += AZ110[starCount];
        }
        else if (L >= 101)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 1;
                }
                else
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 2;
                }
            }

            if (starCount < 5)
                _stats += AZ105S[starCount];
            else
                _am += AZ100[starCount];
        }
        else if (L == 100)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 1;
                }
                else
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 2;
                }
            }

            if (starCount < 5)
                _stats += AZ100S[starCount];
            else
                _am += AZ100[starCount];
        }
        else if (L >= 91)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 1;
                }
                else
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 2;
                }
            }

            if (starCount < 5)
                _stats += AZ95S[starCount];
            else
                _am += AZ90[starCount];
        }
        else if (L == 90)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 1;
                }
                else
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 2;
                }
            }

            if (starCount < 5)
                _stats += AZ90S[starCount];
            else
                _am += AZ90[starCount];
        }
        else if (L >= 81)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 1;
                }
                else
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 2;
                }
            }

            if (starCount < 5)
                _stats += AZ85S[starCount];
            else
                _am += AZ80[starCount];
        }
        else if (L == 80)
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 1;
                }
                else
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 2;
                }
            }

            if (starCount < 5)
                _stats += AZ80S[starCount];
            else
                _am += AZ80[starCount];
        }
        else
        {
            if (itemInfo.CheckAccessory() || curitemType == ItemType.Shoulder)
            {
                if (starCount < 5)
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 1;
                }
                else
                {
                    if (amazingDropdowns[1].value == 1)
                        _stats += 2;
                }
            }

            if (starCount < 5)
                _stats += AZ75S[starCount];
            else
                _am += AZ75[starCount];
        }
        AmazingAMUp(_am + _atk, _am + _mag);
        AmazingStatsUp(_stats);
        AmazingMaxHPUp(_maxHP);
    }

    private void AmazingStatsReset()
    {
        var curItem = itemInfo.GetCurItem();

        curItem.amazingSTR = 0;
        curItem.amazingDEX = 0;
        curItem.amazingINT = 0;
        curItem.amazingLUK = 0;

        curItem.amazingATK = 0;
        curItem.amazingMAG = 0;
    }

    public void StarForceUp()
    {
        var curItem = itemInfo.GetCurItem();

        if (curItem.isStarForce == false)
            return;

        if (curItem.isAmazing == true)
        {
            curItem.starforce = 1;
            curItem.isAmazing = false;

            AmazingStatsReset();

            fileManager.SaveIs(itemSettingLogic.GetItemSettingData(), itemSettingLogic.GetCurPath());
            itemInfo.InfoUpdate();

            UIReset();

            return;
        }

        int SFmax = GetMaxStarForce();

        if (curItem.starforce < SFmax)
        {
            curItem.starforce++;
            itemInfo.UpdateStarForceStats(curItem);

            fileManager.SaveIs(itemSettingLogic.GetItemSettingData(), itemSettingLogic.GetCurPath());
            itemInfo.InfoUpdate();

            UIReset();
        }

    }

    public void StarForceDown()
    {
        var curItem = itemInfo.GetCurItem();

        if (curItem.isStarForce == false)
            return;

        if (curItem.isAmazing == true)
            return;

        if (curItem.starforce > 0)
        {
            curItem.starforce--;
            itemInfo.UpdateStarForceStats(curItem);

            fileManager.SaveIs(itemSettingLogic.GetItemSettingData(), itemSettingLogic.GetCurPath());
            itemInfo.InfoUpdate();

            UIReset();
        }
    }

    public void AmazingUp()
    {
        var curItem = itemInfo.GetCurItem();

        if (curItem.isStarForce == false || curItem.reqLev > 150 || curItem.reqClass == CharacterClass.Zero || curItem.isSuperior == true)
            return;

        if (curItem.isAmazing == false)
        {
            curItem.isAmazing = true;
            curItem.starforce = 0;
            AmazingUp(curItem);


            fileManager.SaveIs(itemSettingLogic.GetItemSettingData(), itemSettingLogic.GetCurPath());
            itemInfo.InfoUpdate();

            UIResetForAmazing();

            return;
        }



        if (curItem.starforce < 15)
        {
            AmazingUp(curItem);

            fileManager.SaveIs(itemSettingLogic.GetItemSettingData(), itemSettingLogic.GetCurPath());
            itemInfo.InfoUpdate();

            UIResetForAmazing();
        }
        

    }

    public void AmazingToZero()
    {
        var curItem = itemInfo.GetCurItem();

        if (curItem.isStarForce == false || curItem.reqLev > 150 || curItem.reqClass == CharacterClass.Zero || curItem.isSuperior == true)
            return;

        curItem.starforce = 0;

        AmazingStatsReset();

        fileManager.SaveIs(itemSettingLogic.GetItemSettingData(), itemSettingLogic.GetCurPath());
        itemInfo.InfoUpdate();

        UIResetForAmazing();

    }

    public void OnDropdownChanged(TMP_Dropdown dropdown)
    {
        if(dropdown.value == 0) // 스타포스
        {
            starForcePanel.SetActive(true);
            amazingPanel.SetActive(false);

            UIReset();
        }
        else if(dropdown.value == 1) // 놀장강
        {
            starForcePanel.SetActive(false);
            amazingPanel.SetActive(true);

            UIResetForAmazing();
        }
    }
}
