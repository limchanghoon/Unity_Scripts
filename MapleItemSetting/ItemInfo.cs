using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

enum stats
{
    Basic = 0,
    Additional,
    Spell,
    StarForce,
    None
}

public class ItemInfo : MonoBehaviour
{
    public ItemSettingLogic itemSettingLogic;
    public ISFileManager fileManager;
    public ItemSettingUI uiManager;

    public Sprite uiSprite;

    public Image itemImage;

    public GameObject ringSelectPanel;
    public GameObject pendantSelectPanel;

    public GameObject starTextParent;
    public TextMeshProUGUI starText;
    public GameObject[] starImages;
    public GameObject[] textParents;
    public TextMeshProUGUI[] textNames;
    public TextMeshProUGUI[] texts;
    public TextMeshProUGUI itemNameText;
    public GameObject[] growthParents;

    public GameObject[] exceptional_objs;
    public TextMeshProUGUI exceptionalText;

    public GameObject equipBtn;
    public GameObject endressBtn;
    public GameObject addBtn;
    public GameObject discardBtn;

    public GameObject enforcesPanel;
    public GameObject additionalPanel;
    public GameObject spellPanel;
    public GameObject starforcePanel;
    public GameObject cubePanel;
    public GameObject exceptionalPanel;
    public GameObject soulPanel;
    public GameObject growthPanel;

    public TMP_Dropdown enforcesDropdown;
    public Scrollbar infoScrollbar;
    public Scrollbar infoVerticalScrollbar;

    public ContentSizeFitter[] csfs;


    ItemType curItemType;
    int curIndex;
    bool isMine;
    bool isInventory;

    int cell = -1;

    string impossibleColor = "<color=#D21F1F>";
    string noneColor = "<color=#000000>";
    string rareColor = "<color=#7CE6FF>";
    string epicColor = "<color=#A209F8>";
    string uniqueColor = "<color=#FFF300>";
    string legendaryColor = "<color=#B3FF1A>";

    // 장갑 5, 7, 9, 11, 13, 14, 15 공/마 +1
    [HideInInspector] public int[] SFGloveBonus = { 0, 0, 0, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 6, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7 };
    [HideInInspector] public int[] SFHPMPBonus = { 0, 5, 10, 15, 25, 35, 50, 65, 85, 105, 130, 155, 180, 205, 230, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255 };

    [HideInInspector] public int[] SF250 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 14, 29, 45, 62, 80, 99, 120, 143, 168, 195 };
    [HideInInspector] public int[] SF200 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 25, 39, 54, 70, 87, 106, 127, 150, 175 };
    [HideInInspector] public int[] SF160 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 21, 33, 46, 60, 75, 92, 111, 132, 155 };
    [HideInInspector] public int[] SF150 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 19, 30, 42, 55, 69, 85, 103, 123, 145 };
    [HideInInspector] public int[] SF140 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 17, 27, 38, 50, 63, 78, 95, 114, 135 };
    [HideInInspector] public int[] SF130 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 15, 24, 34, 45 }; // 0~20성

    [HideInInspector] public int[] SF250W = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999 };
    [HideInInspector] public int[] SF200W = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 13, 26, 40, 54, 69, 85, 102, 136, 171, 207 };
    [HideInInspector] public int[] SF160W = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 18, 28, 39, 51, 64, 78, 110, 143, 177 };
    [HideInInspector] public int[] SF150W = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 17, 26, 36, 47, 59, 72, 103, 135, 168 };
    [HideInInspector] public int[] SF140W = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 15, 23, 32, 42, 53, 65, 95, 126, 158 };
    [HideInInspector] public int[] SF130W = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 13, 20, 28, 37 }; // 0~20성

    [HideInInspector] public int[] SF250S = { 0, 2, 4, 6, 8, 10, 13, 16, 19, 22, 25, 28, 31, 34, 37, 40, 57, 74, 91, 108, 125, 142, 159, 159, 159, 159 };
    [HideInInspector] public int[] SF200S = { 0, 2, 4, 6, 8, 10, 13, 16, 19, 22, 25, 28, 31, 34, 37, 40, 55, 70, 85, 100, 115, 130, 145, 145, 145, 145 };
    [HideInInspector] public int[] SF160S = { 0, 2, 4, 6, 8, 10, 13, 16, 19, 22, 25, 28, 31, 34, 37, 40, 53, 66, 79, 92, 105, 118, 131, 131, 131, 131 };
    [HideInInspector] public int[] SF150S = { 0, 2, 4, 6, 8, 10, 13, 16, 19, 22, 25, 28, 31, 34, 37, 40, 51, 62, 73, 84, 95, 106, 117, 117, 117, 117 };
    [HideInInspector] public int[] SF140S = { 0, 2, 4, 6, 8, 10, 13, 16, 19, 22, 25, 28, 31, 34, 37, 40, 49, 58, 67, 76, 85, 94, 103, 103, 103, 103 };
    [HideInInspector] public int[] SF130S = { 0, 2, 4, 6, 8, 10, 13, 16, 19, 22, 25, 28, 31, 34, 37, 40, 47, 54, 61, 68, 75 }; // 0~20성

    int[] Superior150S = { 0, 19, 39, 61, 86, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115 }; // 0~15성
    int[] Superior150 = { 0, 0, 0, 0, 0, 0, 9, 19, 30, 42, 55, 70, 87, 106, 127, 150 }; // 0~15성


    public void Init(ItemType _itemType, int _curIndex, bool _isMine, bool _isInventory, int _cell = -1, bool _reset = true)
    {
        curItemType = _itemType;
        curIndex = _curIndex;
        isMine = _isMine;
        isInventory = _isInventory;
        cell = _cell;

        UpdateStarForceStats();

        if (_reset)
        {
            enforcesDropdown.value = 0;
            infoScrollbar.value = 0;
            infoVerticalScrollbar.value = 1;
            //additionalPanel.GetComponent<AdditionalManager>().UIReset();
            //spellPanel.GetComponent<SpellManager>().spellDropdown1.value = 0;
            //spellPanel.GetComponent<SpellManager>().UpdateUpgradeCountText();
            //starforcePanel.GetComponent<StarForceManager>().UIReset();
        }
        var curItem = GetCurItem();

        ItemType typeTMP = _itemType;
        if (typeTMP == ItemType.Blade || typeTMP == ItemType.Lapis || typeTMP == ItemType.Shield || typeTMP == ItemType.SubWeapon2)
            typeTMP = ItemType.SubWeapon;
        itemImage.sprite = Resources.Load<Sprite>("Image/Item/" + typeTMP.ToString() + "/" + curItem.name);
        itemSettingLogic.ResizeImage(itemImage.transform.GetComponent<RectTransform>(), itemImage.sprite, 200);

        if (curItem.starforce == 0)
            starTextParent.SetActive(false);
        else
        {
            starTextParent.SetActive(true);
            if (curItem.isAmazing)
            {
                starImages[0].SetActive(false);
                starImages[1].SetActive(true);
                starText.text = "<color=#00FFFD>" + curItem.starforce.ToString() + "성</color>";
            }
            else
            {
                starImages[0].SetActive(true);
                starImages[1].SetActive(false);
                starText.text = "<color=#FFE400>" + curItem.starforce.ToString() + "성</color>";
            }
        }

        if (curItem.type == ItemType.Weapon && curItem.reqClass == CharacterClass.Zero && curItem.setName != SetName.NULL && curItem.name != "제네시스 라즐리")
            itemNameText.text = curItem.setName.ToFriendlyString() + " " + curItem.name;
        else
            itemNameText.text = curItem.name;

        if(curItem.GetCompletedUpgrade() > 0)
            itemNameText.text += " (+" + curItem.GetCompletedUpgrade() + ")";

        if (curItem.isYggdrasil || curItem.isBasicGrowth)
        {
            growthParents[0].SetActive(true);
            growthParents[1].SetActive(true);
        }
        else
        {
            growthParents[0].SetActive(false);
            growthParents[1].SetActive(false);
        }

        texts[0].text = curItem.reqClassGroup.ToFriendlyString();
        texts[1].text = curItem.type.ToFriendlyString();
        texts[2].text = curItem.reqLev.ToString();

        ChangeText(curItem.basicSTR, curItem.additionalSTR, curItem.spellSTR, curItem.starforceSTR, false, 3);
        ChangeText(curItem.basicDEX, curItem.additionalDEX, curItem.spellDEX, curItem.starforceDEX, false, 4);
        ChangeText(curItem.basicINT, curItem.additionalINT, curItem.spellINT, curItem.starforceINT, false, 5);
        ChangeText(curItem.basicLUK, curItem.additionalLUK, curItem.spellLUK, curItem.starforceLUK, false, 6);
        ChangeText(curItem.basicMaxHP, curItem.additionalMaxHP, curItem.spellMaxHP, curItem.starforceMaxHP, false, 7);
        ChangeText(curItem.basicMaxMP, curItem.additionalMaxMP, curItem.spellMaxMP, curItem.starforceMaxMP, false, 8);
        ChangeText(curItem.basicMaxHP_Per, 0, 0, 0, true, 9);
        ChangeText(curItem.basicMaxMP_Per, 0, 0, 0, true, 10);
        ChangeText(curItem.maxDF, 0, 0, 0, false, 11);
        ChangeText(curItem.basicATK, curItem.additionalATK, curItem.spellATK, curItem.starforceATK, false, 12);
        ChangeText(curItem.basicMAG, curItem.additionalMAG, curItem.spellMAG, curItem.starforceMAG, false, 13);
        ChangeText(curItem.basicBossATK, curItem.additionalBossATK, curItem.spellBossATK, curItem.starforceBossATK, true, 14);
        ChangeText(curItem.basicIgnoreDF, curItem.additionalIgnoreDF, curItem.spellIgnoreDF, curItem.starforceIgnoreDF, true, 15);
        ChangeText(curItem.basicAllStats, curItem.additionalAllStats, curItem.spellAllStats, curItem.starforceAllStats, true, 16);
        ChangeText(curItem.basicDamage, curItem.additionalDamage, curItem.spellDamage, curItem.starforceDamage, true, 17);
        ChangeText(curItem.arc, 0, 0, 0, false, 18);
        ChangeText(curItem.basicCriPro, 0, 0, 0, true, 19);
        ChangeText(curItem.basicCriDamage, 0, 0, 0, true, 20);




        texts[21].text = curItem.remainingUpgrade + "회";
        if (curItem.totalScissors > 100)
            texts[22].text = "무한 교환";
        else if (curItem.totalScissors > 10)
            texts[22].text = "무한 교환(가위 필요)";
        else if (curItem.remainingScissors > 0)
            texts[22].text = curItem.remainingScissors + "회";
        else if (curItem.remainingScissors == 0)
            texts[22].text = "장착시 교환 불가";
        else
            texts[22].text = "교환 불가";



        // 잠재능력
        if (curItem.upPotentialGrade == OptionGrade.None)
        {
            textNames[23].text = noneColor + "잠재옵션</color>";
            texts[23].text = impossibleColor + "해당 사항 없음</color>";
            texts[24].text = "";
            texts[25].text = "";
        }
        else
        {
            string colorStr = ConvertGardeToColorString(curItem.upPotentialGrade);
            textNames[23].text = colorStr + "잠재옵션(" + curItem.upPotentialGrade.ToFriendlyString() + ")</color>";
            texts[23].text = ConvertToColorString(curItem.upPotential1, colorStr);
            texts[24].text = ConvertToColorString(curItem.upPotential2, colorStr);
            texts[25].text = ConvertToColorString(curItem.upPotential3, colorStr);
        }


        // 에디셔널
        if (curItem.downPotentialGrade == OptionGrade.None)
        {
            textNames[24].text = noneColor + "에디셔널 잠재옵션</color>";
            texts[26].text = impossibleColor + "해당 사항 없음</color>";
            texts[27].text = "";
            texts[28].text = "";
        }
        else
        {
            string colorStr = ConvertGardeToColorString(curItem.downPotentialGrade);
            textNames[24].text = colorStr + "에디셔널 잠재옵션(" + curItem.downPotentialGrade.ToFriendlyString() + ")</color>";
            texts[26].text = ConvertToColorString(curItem.downPotential1, colorStr);
            texts[27].text = ConvertToColorString(curItem.downPotential2, colorStr);
            texts[28].text = ConvertToColorString(curItem.downPotential3, colorStr);
        }

        // 익셉셔널
        if (curItem.exceptionalOption == "")
        {
            exceptional_objs[0].SetActive(false);
            exceptional_objs[1].SetActive(false);
        }
        else
        {
            exceptional_objs[0].SetActive(true);
            exceptional_objs[1].SetActive(true);

            exceptionalText.text = curItem.exceptionalOption;
        }

        // 소울 관련
        if (curItem.soul == "")
        {
            textParents[25].SetActive(false);
        }
        else
        {
            textParents[25].SetActive(true);
            texts[29].text = curItem.soul + " 적용";
            texts[30].text = curItem.soulOption;
        }

        if (isMine)
        {
            enforcesPanel.SetActive(true);

            if (isInventory)
            {
                equipBtn.SetActive(true);
                endressBtn.SetActive(false);
            }
            else
            {
                equipBtn.SetActive(false);
                endressBtn.SetActive(true);
            }
            addBtn.SetActive(false);
            discardBtn.SetActive(true);
        }
        else
        {
            enforcesPanel.SetActive(false);

            equipBtn.SetActive(false);
            endressBtn.SetActive(false);
            addBtn.SetActive(true);
            discardBtn.SetActive(false);
        }

        foreach(var csf in csfs)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)csf.transform);
        }

    }

    void ChangeText(int stats1, int stats2, int stats3, int stats4,bool isPercent, int i)
    {
        Color greenColor;
        ColorUtility.TryParseHtmlString("#0096BF", out greenColor);

        string p = "";
        if (isPercent)
            p = "%";

        int str = stats1 + stats2 + stats3 + stats4;
        if (str <= 0)
            textParents[i].SetActive(false);
        else
        {
            textParents[i].SetActive(true);
            if (stats2 == 0 && stats3 == 0 && stats4 == 0)
            {
                textNames[i].color = Color.white;
                texts[i].text = "+" + str.ToString() + p;
            }
            else
            {
                if (str > stats1)
                {
                    textNames[i].color = greenColor;
                    texts[i].text = "<color=#0085A9>+" + str.ToString() + p + "</color>";
                }
                else
                {
                    textNames[i].color = Color.white;
                    texts[i].text = "<color=#000000>+" + str.ToString() + p + "</color>";
                }
                texts[i].text += "(";
                texts[i].text += stats1 + " ";
                texts[i].text += ConvertStatsToString(stats2, stats.Additional, p);
                texts[i].text += ConvertStatsToString(stats3, stats.Spell, p);
                texts[i].text += ConvertStatsToString(stats4, stats.StarForce, p);
                texts[i].text += ")";
            }
        }
    }

    string ConvertStatsToString(int number, stats _stats, string p)
    {
        string str = "";

        if (number > 0)
        {
            switch (_stats)
            {
                case stats.Additional:
                    str += " <color=#25911B>";
                    break;

                case stats.Spell:
                    str += " <color=#6A02FF>";
                    break;

                case stats.StarForce:
                    str += " <color=#FFEC5D>";
                    break;

                default:
                    Debug.Log("ConvertStatsToString Default!!!!!!!");
                    break;
            }
            str += " +" + number.ToString() + p + "</color>";
        }
        else if (number < 0)
            str += " <color=#C80000>" + number.ToString() + p + "</color>";

        return str;
    }

    string ConvertGardeToColorString(OptionGrade optionGrade)
    {
        switch (optionGrade)
        {
            case OptionGrade.Rare:
                return rareColor;
            case OptionGrade.Epic:
                return epicColor;
            case OptionGrade.Unique:
                return uniqueColor;
            case OptionGrade.Legendary:
                return legendaryColor;
            default:
                return noneColor;
        }
    }

    string ConvertToColorString(string potential, string colorStr)
    {
        return colorStr + potential + "</color>";
    }

    void UpdateStarForceStats()
    {
        var curItem = GetCurItem();
        int starCount = curItem.starforce;

        if (curItem.isAmazing == true)
        {
            SetStarForceStats(0, 0, 0);
            return;
        }

        if(curItem.isSuperior == true)
        {
            SetStarForceStats(Superior150S[starCount], Superior150[starCount], 0);
            return;
        }

        if (curItem.type == ItemType.Medal)
        {
            SetStarForceStats(0, 0, 0);
            return;
        }


        int L = curItem.reqLev;
        ItemType curitemType = curItem.type;

        int gloveAlpha = 0;
        if (curItemType == ItemType.Gloves)
            gloveAlpha = SFGloveBonus[starCount];

        int weaponA = 0;
        int weaponM = 0;
        int _S = Mathf.Min(15, starCount);
        for (int i = 0; i < _S; i++)
        {
            weaponA += (curItem.basicATK + curItem.spellATK + weaponA) / 50 + 1;
            weaponM += (curItem.basicMAG + curItem.spellMAG + weaponM) / 50 + 1;
        }



        if (L >= 248)       // 에테르넬
        {
            if (curitemType == ItemType.Weapon || curitemType == ItemType.Blade || curitemType == ItemType.Lapis)
                SetStarForceStats(SF200S[starCount], SF250W[starCount] + weaponA, SF250W[starCount] + weaponM, SFHPMPBonus[starCount]);
            else
                SetStarForceStats(SF250S[starCount], SF250[starCount] + gloveAlpha, SFHPMPBonus[starCount]);
        }
        else if (L >= 198)   // 아케인
        {
            if (curitemType == ItemType.Weapon || curitemType == ItemType.Blade || curitemType == ItemType.Lapis)
                SetStarForceStats(SF200S[starCount], SF200W[starCount] + weaponA, SF200W[starCount] + weaponM, SFHPMPBonus[starCount]);
            else
                SetStarForceStats(SF200S[starCount], SF200[starCount] + gloveAlpha, SFHPMPBonus[starCount]);
        }
        else if (L >= 158)  // 앱솔
        {
            if (curitemType == ItemType.Weapon || curitemType == ItemType.Blade || curitemType == ItemType.Lapis)
                SetStarForceStats(SF160S[starCount], SF160W[starCount] + weaponA, SF160W[starCount] + weaponM, SFHPMPBonus[starCount]);
            else
                SetStarForceStats(SF160S[starCount], SF160[starCount] + gloveAlpha, SFHPMPBonus[starCount]);
        }
        else if (L >= 148)  // 루타
        {
            if (curitemType == ItemType.Weapon || curitemType == ItemType.Blade || curitemType == ItemType.Lapis)
                SetStarForceStats(SF150S[starCount], SF150W[starCount] + weaponA, SF150W[starCount] + weaponM, SFHPMPBonus[starCount]);
            else
                SetStarForceStats(SF150S[starCount], SF150[starCount] + gloveAlpha, SFHPMPBonus[starCount]);
        }
        else if (L >= 138)
        {
            if (curitemType == ItemType.Weapon || curitemType == ItemType.Blade || curitemType == ItemType.Lapis)
                SetStarForceStats(SF140S[starCount], SF140W[starCount] + weaponA, SF140W[starCount] + weaponM, SFHPMPBonus[starCount]);
            else
                SetStarForceStats(SF140S[starCount], SF140[starCount] + gloveAlpha, SFHPMPBonus[starCount]);
        }
        else
        {
            if (curitemType == ItemType.Weapon || curitemType == ItemType.Blade || curitemType == ItemType.Lapis)
                SetStarForceStats(SF130S[starCount], SF130W[starCount] + weaponA, SF130W[starCount] + weaponM, SFHPMPBonus[starCount]);
            else
                SetStarForceStats(SF130S[starCount], SF130[starCount] + gloveAlpha, SFHPMPBonus[starCount]);

        }
    }

    void SetStarForceStats(int stats, int _A, int _M, int hpmp)
    {
        var curItem = GetCurItem();

        if (curItem.reqClassGroup == CharacterClassGroup.NULL || curItem.reqClassGroup == CharacterClassGroup.Warrior
            || curItem.reqClassGroup == CharacterClassGroup.Bowman || curItem.reqClassGroup == CharacterClassGroup.Pirate || curItem.reqClassGroup == CharacterClassGroup.Hybrid
            || curItem.basicSTR > 0 || curItem.spellSTR > 0)
            curItem.starforceSTR = stats;
        else
            curItem.starforceSTR = 0;

        if (curItem.reqClassGroup == CharacterClassGroup.NULL || curItem.reqClassGroup == CharacterClassGroup.Warrior
            || curItem.reqClassGroup == CharacterClassGroup.Bowman || curItem.reqClassGroup == CharacterClassGroup.Thief
            || curItem.reqClassGroup == CharacterClassGroup.Pirate || curItem.reqClassGroup == CharacterClassGroup.Hybrid
            || curItem.basicDEX > 0 || curItem.spellDEX > 0)
            curItem.starforceDEX = stats;
        else
            curItem.starforceDEX = 0;

        if (curItem.reqClassGroup == CharacterClassGroup.NULL || curItem.reqClassGroup == CharacterClassGroup.Magician
            || curItem.basicINT > 0 || curItem.spellINT > 0)
            curItem.starforceINT = stats;
        else
            curItem.starforceINT = 0;

        if (curItem.reqClassGroup == CharacterClassGroup.NULL || curItem.reqClassGroup == CharacterClassGroup.Magician
            || curItem.reqClassGroup == CharacterClassGroup.Thief || curItem.reqClassGroup == CharacterClassGroup.Hybrid
            || curItem.basicLUK > 0 || curItem.spellLUK > 0)
            curItem.starforceLUK = stats;
        else
            curItem.starforceLUK = 0;

        if (curItem.reqClassGroup != CharacterClassGroup.Magician
            || CheckAccessory()
            || curItem.basicATK > 0 || curItem.spellATK > 0)
            curItem.starforceATK = _A;
        else
            curItem.starforceATK = 0;

        if (curItem.reqClassGroup == CharacterClassGroup.Magician || curItem.reqClassGroup == CharacterClassGroup.NULL
            || CheckAccessory()
            || curItem.basicMAG > 0 || curItem.spellMAG > 0)
            curItem.starforceMAG = _M;
        else
            curItem.starforceMAG = 0;

        if (curItem.type == ItemType.Weapon || curItem.type == ItemType.Helmet || curItem.type == ItemType.Shirt || curItem.type == ItemType.Pants
            || curItem.type == ItemType.Cape || curItem.type == ItemType.Ring || curItem.type == ItemType.Pendant || curItem.type == ItemType.Belt
            || curItem.type == ItemType.Shoulder || curItem.type == ItemType.SubWeapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis)
            curItem.starforceMaxHP = hpmp;

        if (curItem.type == ItemType.Weapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis)
            curItem.starforceMaxMP = hpmp;
    }

    void SetStarForceStats(int stats, int am, int hpmp)
    {
        SetStarForceStats(stats, am, am, hpmp);
    }

    public Item GetCurItem()
    {
        Item curItem;
        if (isMine)
        {
            curItem = isInventory ? itemSettingLogic.GetItemSettingData().Inventory[curIndex] : itemSettingLogic.GetItemSettingData().items[curIndex];
        }
        else
        {
            curItem = itemSettingLogic.itemDictionary.itemListList[(int)curItemType][curIndex];
        }
       
        return curItem;
    }

    public bool CheckAccessory()
    {
        var curItem = GetCurItem();
        if (curItem.type == ItemType.Ring || curItem.type == ItemType.Pendant || curItem.type == ItemType.Belt || curItem.type == ItemType.Eye || curItem.type == ItemType.Face || curItem.type == ItemType.Earring)
            return true;
        return false;
    }

    public void EquipItem()
    {
        var curItem = GetCurItem();
        var curItemType = curItem.type;
        var curItemSettingData = itemSettingLogic.GetItemSettingData();

        if (curItem.reqClassGroup != CharacterClassGroup.NULL && curItem.reqClassGroup != curItemSettingData.charaacterClassGroup && curItemSettingData.charaacterClassGroup != CharacterClassGroup.Hybrid)
        {
            PopUpManager.Instance.GeneratePopUp("직업군이 일치하지 않습니다.");
            return;
        }
        else if (curItemSettingData.charaacterClassGroup == CharacterClassGroup.Hybrid && curItem.reqClassGroup != CharacterClassGroup.Thief && curItem.reqClassGroup != CharacterClassGroup.Pirate) //제논
        {
            PopUpManager.Instance.GeneratePopUp("직업군이 일치하지 않습니다.");
            return;
        }

        if (curItem.type == ItemType.Ring)
        {
            ringSelectPanel.SetActive(true);
            BackStackManager.Instance.Push(ringSelectPanel);
            for(int i = 0; i < 4; i++)
            {
                if (curItemSettingData.items[3-i].type == ItemType.NULL)
                    ringSelectPanel.transform.GetChild(0).GetChild(i + 1).GetChild(0).GetComponent<Image>().sprite = uiSprite;
                else
                {
                    ringSelectPanel.transform.GetChild(0).GetChild(i + 1).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/Item/{curItemType.ToString()}/{curItemSettingData.items[3-i].name}");
                    itemSettingLogic.ResizeImage(ringSelectPanel.transform.GetChild(0).GetChild(i + 1).GetChild(0).GetComponent<RectTransform>(), ringSelectPanel.transform.GetChild(0).GetChild(i + 1).GetChild(0).GetComponent<Image>().sprite, 200);
                }
            }
           
            return;
        }
        else if (curItem.type == ItemType.Pendant)
        {
            pendantSelectPanel.SetActive(true);
            BackStackManager.Instance.Push(pendantSelectPanel);
            for (int i = 0; i < 2; i++)
            {
                if (curItemSettingData.items[6 - i].type == ItemType.NULL)
                    pendantSelectPanel.transform.GetChild(0).GetChild(i + 1).GetChild(0).GetComponent<Image>().sprite = uiSprite;
                else
                {
                    pendantSelectPanel.transform.GetChild(0).GetChild(i + 1).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/Item/{curItemType.ToString()}/{curItemSettingData.items[6 - i].name}");
                    itemSettingLogic.ResizeImage(pendantSelectPanel.transform.GetChild(0).GetChild(i + 1).GetChild(0).GetComponent<RectTransform>(), pendantSelectPanel.transform.GetChild(0).GetChild(i + 1).GetChild(0).GetComponent<Image>().sprite, 200);
                }
            }
            return;
        }



        itemSettingLogic.GetItemSettingData().Inventory.RemoveAt(curIndex);
        var _item = itemSettingLogic.GetItemSettingData().items[itemSettingLogic.IndexFromType(curItem.type)];
        if (_item.type != ItemType.NULL)
            itemSettingLogic.GetItemSettingData().Inventory.Add(_item);
        itemSettingLogic.GetItemSettingData().items[itemSettingLogic.IndexFromType(curItem.type)] = curItem;

        fileManager.SaveIs(curItemSettingData, itemSettingLogic.GetCurPath());
        uiManager.TurnOffItemSelectInfo();
        uiManager.TurnOnItemSetting(curItemSettingData, itemSettingLogic.GetCurPath());
    }

    public void EndressItem()
    {
        var curItem = GetCurItem();
        var curItemSettingData = itemSettingLogic.GetItemSettingData();

        itemSettingLogic.GetItemSettingData().items[curIndex] = null;
        itemSettingLogic.GetItemSettingData().Inventory.Add(curItem);

        fileManager.SaveIs(curItemSettingData, itemSettingLogic.GetCurPath());
        uiManager.TurnOffItemSelectInfo();
        uiManager.TurnOnItemSetting(curItemSettingData, itemSettingLogic.GetCurPath());
    }

    public void GetItem()
    {
        var newItem = GetCurItem().DeepCopy();
        var curItemSettingData = itemSettingLogic.GetItemSettingData();
        if (cell != -1) // 장비창으로 바로 얻어서 입기
        {
            if(newItem.reqClassGroup != CharacterClassGroup.NULL && newItem.reqClassGroup != curItemSettingData.charaacterClassGroup && curItemSettingData.charaacterClassGroup != CharacterClassGroup.Hybrid)
            {
                PopUpManager.Instance.GeneratePopUp("직업군이 일치하지 않습니다.");
                return;
            }
            else if (curItemSettingData.charaacterClassGroup == CharacterClassGroup.Hybrid && newItem.reqClassGroup != CharacterClassGroup.Thief && newItem.reqClassGroup != CharacterClassGroup.Pirate) //제논
            {
                PopUpManager.Instance.GeneratePopUp("직업군이 일치하지 않습니다.");
                return;
            }
            curItemSettingData.items[cell] = newItem;
        }
        else
        {
            curItemSettingData.Inventory.Add(newItem);
        }

        fileManager.SaveIs(curItemSettingData, itemSettingLogic.GetCurPath());

        uiManager.TurnOffItemSelectInfo();
        uiManager.TurnOffSelectWindow();
        uiManager.TurnOffTypeSelect();
        uiManager.TurnOnItemSetting(curItemSettingData, itemSettingLogic.GetCurPath());
    }

    public void Discard()
    {
        var curItemSettingData = itemSettingLogic.GetItemSettingData();

        if (isInventory)
        {
            itemSettingLogic.GetItemSettingData().Inventory.RemoveAt(curIndex);
        }
        else
        {
            itemSettingLogic.GetItemSettingData().items[curIndex] = null;
        }

        fileManager.SaveIs(curItemSettingData, itemSettingLogic.GetCurPath());

        uiManager.TurnOffItemSelectInfo();
        uiManager.TurnOnItemSetting(curItemSettingData, itemSettingLogic.GetCurPath());
    }

    public void SelectRingSlot(int _slot)
    {
        var curItem = GetCurItem();
        var curItemSettingData = itemSettingLogic.GetItemSettingData();


        curItemSettingData.Inventory.RemoveAt(curIndex);
        if (curItemSettingData.items[4 - _slot].type != ItemType.NULL)
            curItemSettingData.Inventory.Add(curItemSettingData.items[4 - _slot]);
        curItemSettingData.items[4 - _slot] = curItem;

        fileManager.SaveIs(curItemSettingData, itemSettingLogic.GetCurPath());

        TurnOffSelectRing();
        uiManager.TurnOffItemSelectInfo();
        uiManager.TurnOnItemSetting(curItemSettingData, itemSettingLogic.GetCurPath());
    }

    public void SelectPendantSlot(int _slot)
    {
        var curItem = GetCurItem();
        var curItemSettingData = itemSettingLogic.GetItemSettingData();

        curItemSettingData.Inventory.RemoveAt(curIndex);
        if (curItemSettingData.items[7 - _slot].type != ItemType.NULL)
            curItemSettingData.Inventory.Add(curItemSettingData.items[7 - _slot]);
        curItemSettingData.items[7 - _slot] = curItem;

        fileManager.SaveIs(curItemSettingData, itemSettingLogic.GetCurPath());

        TurnOffSelectPendant();
        uiManager.TurnOffItemSelectInfo();
        uiManager.TurnOnItemSetting(curItemSettingData, itemSettingLogic.GetCurPath());
    }

    public void TurnOffSelectRing()
    {
        BackStackManager.Instance.Pop();
        ringSelectPanel.SetActive(false);
    }

    public void TurnOffSelectPendant()
    {
        BackStackManager.Instance.Pop();
        pendantSelectPanel.SetActive(false);
    }




    #region 아이템 정보창에서 UI관련

    public void OnItemEnchantValueChanged(TMP_Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0:
                additionalPanel.SetActive(false);
                spellPanel.SetActive(false);
                starforcePanel.SetActive(false);
                cubePanel.SetActive(false);
                exceptionalPanel.SetActive(false);
                soulPanel.SetActive(false);
                growthPanel.SetActive(false);
                break;

            case 1: // 추가옵션
                additionalPanel.SetActive(true);
                spellPanel.SetActive(false);
                starforcePanel.SetActive(false);
                cubePanel.SetActive(false);
                exceptionalPanel.SetActive(false);
                soulPanel.SetActive(false);
                growthPanel.SetActive(false);

                var additionalManager = additionalPanel.GetComponent<AdditionalManager>();
                additionalManager.UIReset();
                break;

            case 2: // 주문서 작
                additionalPanel.SetActive(false);
                spellPanel.SetActive(true);
                starforcePanel.SetActive(false);
                cubePanel.SetActive(false);
                exceptionalPanel.SetActive(false);
                soulPanel.SetActive(false);
                growthPanel.SetActive(false);

                var spellManager = spellPanel.GetComponent<SpellManager>();
                spellManager.spellDropdown1.value = 0;
                spellManager.OnDropdown1Changed(spellManager.spellDropdown1);
                spellPanel.GetComponent<SpellManager>().UpdateUpgradeCountText();
                break;

            case 3: // 스타포스/놀장
                additionalPanel.SetActive(false);
                spellPanel.SetActive(false);
                starforcePanel.SetActive(true);
                cubePanel.SetActive(false);
                exceptionalPanel.SetActive(false);
                soulPanel.SetActive(false);
                growthPanel.SetActive(false);

                var starForceManager = starforcePanel.GetComponent<StarForceManager>();
                starForceManager.dropdown.value = 0;
                starForceManager.OnDropdownChanged(starForceManager.dropdown);

                break;

            case 4: // 큐브
                additionalPanel.SetActive(false);
                spellPanel.SetActive(false);
                starforcePanel.SetActive(false);
                cubePanel.SetActive(true);
                exceptionalPanel.SetActive(false);
                soulPanel.SetActive(false);
                growthPanel.SetActive(false);

                var cubeManager = cubePanel.GetComponent<CubeManager>();
                cubeManager.Init();
                break;

            case 5: // 익셉셔널
                additionalPanel.SetActive(false);
                spellPanel.SetActive(false);
                starforcePanel.SetActive(false);
                cubePanel.SetActive(false);
                exceptionalPanel.SetActive(true);
                soulPanel.SetActive(false);
                growthPanel.SetActive(false);

                var exceptionalManager = exceptionalPanel.GetComponent<ExceptionalManager>();
                exceptionalManager.UIReset();
                break;

            case 6: // 소울(무기)
                additionalPanel.SetActive(false);
                spellPanel.SetActive(false);
                starforcePanel.SetActive(false);
                cubePanel.SetActive(false);
                exceptionalPanel.SetActive(false);
                soulPanel.SetActive(true);
                growthPanel.SetActive(false);

                var soulManager = soulPanel.GetComponent<SoulManager>();
                soulManager.UIReset();
                break;

            case 7: // 성장(타임리스/피어리스)
                additionalPanel.SetActive(false);
                spellPanel.SetActive(false);
                starforcePanel.SetActive(false);
                cubePanel.SetActive(false);
                exceptionalPanel.SetActive(false);
                soulPanel.SetActive(false);
                growthPanel.SetActive(true);

                var growthManager = growthPanel.GetComponent<GrowthManager>();
                growthManager.UIReset();
                break;

            default:
                additionalPanel.SetActive(false);
                spellPanel.SetActive(false);
                starforcePanel.SetActive(false);
                cubePanel.SetActive(false);
                exceptionalPanel.SetActive(false);
                soulPanel.SetActive(false);
                growthPanel.SetActive(false);
                break;
        }
    }

    public void InfoUpdate()
    {
        Init(curItemType, curIndex, isMine, isInventory, cell, false);
    }
    
    #endregion
}
