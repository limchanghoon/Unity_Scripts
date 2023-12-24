using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// 추가옵션
public class AdditionalManager : MonoBehaviour
{
    public ItemInfo itemInfo;
    public ItemSettingLogic itemSettingLogic;
    public ISFileManager fileManager;
    public ItemSettingUI uiManager;

    public TMP_Dropdown[] additionals;
    public TMP_Dropdown[] additionalValues;

    public GameObject[] explanations;

    int[] zero170 = { 9, 20, 32, 47, 64 };
    int[] zero180 = { 11, 23, 38, 56, 76 };
    int[] zero200 = { 18, 40, 65, 95, 131 };
    int[] zeroGenesis = { 21, 46, 75, 110, 151 };

    int[] unleashedKayserium = { 16, 36, 59, 86, 118 };

    public void UIReset()
    {
        foreach(var dd in additionals)
            dd.value = 0;

        if (itemInfo.GetCurItem().isAdditionalOption)
        {
            explanations[0].SetActive(true);
            explanations[1].SetActive(false);
        }
        else
        {
            explanations[0].SetActive(false);
            explanations[1].SetActive(true);
        }
    }

    public void additionalsChanged(TMP_Dropdown dropdown)
    {
        var curItem = itemInfo.GetCurItem();

        for (int i = 0; i < additionals.Length; i++)
            if (additionals[i] == dropdown)
                additionalValues[i].ClearOptions();

        if (!curItem.isAdditionalOption && dropdown.value != 0)
            dropdown.value = 0;

        if (dropdown.value == 0)
            return;

        if (!(curItem.type == ItemType.Weapon || curItem.type == ItemType.Lapis))
        {
            if (dropdown.value == 16 || dropdown.value == 17)
            {
                dropdown.value = 0;
                return;
            }
        }

        for (int i = 0; i < additionals.Length; i++)
        {
            if (additionals[i] != dropdown && additionals[i].value == dropdown.value)
            {
                dropdown.value = 0;
                return;
            }
        }


        for (int i = 0; i < additionals.Length; i++)
        {
            if (additionals[i] == dropdown)
            {
                additionalValues[i].AddOptions(GetadditionalValues(i));
                return;
            }
        }


    }

    List<string> GetadditionalValues(int idx)
    {
        List<string> list = new List<string>();

        var curItem = itemInfo.GetCurItem();
        int L = curItem.reqLev;
        int basicAM = curItem.reqClassGroup == CharacterClassGroup.Magician ? curItem.basicMAG : curItem.basicATK;



        int C = curItem.isNormalAdditional ? 1 : 3;
        switch (additionals[idx].value)
        {
            case 0:
                break;

            case 1:
            case 2:
            case 3:
            case 4:
                for (int i = C; i <= 4 + C; i++)
                {
                    if (L == 250)
                    {
                        list.Add(((PotentialOption)additionals[idx].value).ToString() + " +" + (i * (220 / 20 + 1)).ToString());
                    }
                    else
                        list.Add(((PotentialOption)additionals[idx].value).ToString() + " +" + (i * (L / 20 + 1)).ToString());
                }
                break;

            case 5:
                for (int i = C; i <= 4 + C; i++)
                {
                    list.Add("STR +" + (i * (L / 40 + 1)).ToString() + "\nDEX +" + (i * (L / 40 + 1)).ToString());
                }
                break;

            case 6:
                for (int i = C; i <= 4 + C; i++)
                {
                    list.Add("STR +" + (i * (L / 40 + 1)).ToString() + "\nINT +" + (i * (L / 40 + 1)).ToString());
                }
                break;

            case 7:
                for (int i = C; i <= 4 + C; i++)
                {
                    list.Add("STR +" + (i * (L / 40 + 1)).ToString() + "\nLUK +" + (i * (L / 40 + 1)).ToString());
                }
                break;

            case 8:
                for (int i = C; i <= 4 + C; i++)
                {
                    list.Add("DEX +" + (i * (L / 40 + 1)).ToString() + "\nINT +" + (i * (L / 40 + 1)).ToString());
                }
                break;

            case 9:
                for (int i = C; i <= 4 + C; i++)
                {
                    list.Add("DEX +" + (i * (L / 40 + 1)).ToString() + "\nLUK +" + (i * (L / 40 + 1)).ToString());
                }
                break;

            case 10:
                for (int i = C; i <= 4 + C; i++)
                {
                    list.Add("INT +" + (i * (L / 40 + 1)).ToString() + "\nLUK +" + (i * (L / 40 + 1)).ToString());
                }
                break;

            case 11:
                if (L == 250)
                {
                    for (int i = C; i <= 4 + C; i++)
                        list.Add("최대 HP +" + (i * 700).ToString());
                }
                else
                {
                    for (int i = C; i <= 4 + C; i++)
                    {
                        if (L == 0)
                            list.Add("최대 HP +" + (i * 3).ToString());
                        else
                            list.Add("최대 HP +" + (i * 30 * (L / 10)).ToString());
                    }
                }
                break;

            case 12:
                if (L == 250)
                {
                    for (int i = C; i <= 4 + C; i++)
                        list.Add("최대 MP +" + (i * 700).ToString());
                }
                else
                {
                    for (int i = C; i <= 4 + C; i++)
                    {
                        if (L == 0)
                            list.Add("최대 MP +" + (i * 3).ToString());
                        else
                            list.Add("최대 MP +" + (i * 30 * (L / 10)).ToString());
                    }
                }
                break;

            case 13:
                list.AddRange(GetATKAdditional(curItem));
                break;

            case 14:
                list.AddRange(GetMAGAdditional(curItem));
                break;

            case 15:
                for (int i = C; i <= 4 + C; i++)
                    list.Add("올스탯 +" + (i).ToString() + "%");
                break;

            case 16:
                for (int i = C; i <= 4 + C; i++)
                    list.Add("보스 몬스터 공격 시 데미지 +" + (i * 2).ToString() + "%");
                break;

            case 17:
                for (int i = C; i <= 4 + C; i++)
                    list.Add("데미지 +" + (i).ToString() + "%");
                break;

            default:
                break;
        }
        

        return list;
    }

    public void AdditionalApply()
    {
        var curItem = itemInfo.GetCurItem();

        if (!curItem.isAdditionalOption)
            return;

        curItem.SetAdditionalToZero();
        int L = curItem.reqLev;
        int basicAM = curItem.reqClassGroup == CharacterClassGroup.Magician ? curItem.basicMAG : curItem.basicATK;

        for (int i = 0; i < additionals.Length; i++)
        {
            int C = curItem.isNormalAdditional ? 1 + additionalValues[i].value : 3 + additionalValues[i].value;
            switch (additionals[i].value)
            {
                case 0:
                    break;

                case 1:
                    if (L == 250)
                        curItem.additionalSTR += C * (220 / 20 + 1);
                    else
                        curItem.additionalSTR += C * (L / 20 + 1);
                    break;

                case 2:
                    if (L == 250)
                        curItem.additionalDEX += C * (220 / 20 + 1);
                    else
                        curItem.additionalDEX += C * (L / 20 + 1);
                    break;

                case 3:
                    if (L == 250)
                        curItem.additionalINT += C * (220 / 20 + 1);
                    else
                        curItem.additionalINT += C * (L / 20 + 1);
                    break;

                case 4:
                    if (L == 250)
                        curItem.additionalLUK += C * (220 / 20 + 1);
                    else
                        curItem.additionalLUK += C * (L / 20 + 1);
                    break;

                case 5:
                    curItem.additionalSTR += C * (L / 40 + 1);
                    curItem.additionalDEX += C * (L / 40 + 1);
                    break;

                case 6:
                    curItem.additionalSTR += C * (L / 40 + 1);
                    curItem.additionalINT += C * (L / 40 + 1);
                    break;

                case 7:
                    curItem.additionalSTR += C * (L / 40 + 1);
                    curItem.additionalLUK += C * (L / 40 + 1);
                    break;

                case 8:
                    curItem.additionalDEX += C * (L / 40 + 1);
                    curItem.additionalINT += C * (L / 40 + 1);
                    break;

                case 9:
                    curItem.additionalDEX += C * (L / 40 + 1);
                    curItem.additionalLUK += C * (L / 40 + 1);
                    break;

                case 10:
                    curItem.additionalINT += C * (L / 40 + 1);
                    curItem.additionalLUK += C * (L / 40 + 1);
                    break;

                case 11:
                    if (L == 250)
                        curItem.additionalMaxHP += (C * 700);
                    else if (L == 0)
                        curItem.additionalMaxHP += C * 3;
                    else
                        curItem.additionalMaxHP += C * 30 * (L / 10);
                    break;

                case 12:
                    if (L == 250)
                        curItem.additionalMaxMP += (C * 700);
                    else if (L == 0)
                        curItem.additionalMaxMP += C * 3;
                    else
                        curItem.additionalMaxMP += C * 30 * (L / 10);
                    break;

                case 13:
                    if (curItem.type == ItemType.Weapon || curItem.type == ItemType.Lapis)
                    {
                        if (curItem.reqClass == CharacterClass.Zero)
                        {
                            if (curItem.name == "제네시스 라즐리" || curItem.name == "제네시스 라피스")
                                curItem.additionalATK += zeroGenesis[C - 1];
                            else if (L == 200)
                                curItem.additionalATK += zero200[C - 1];
                            else if (L == 180)
                                curItem.additionalATK += zero180[C - 1];
                            else if (L == 170)
                                curItem.additionalATK += zero170[C - 1];
                        }
                        else if (curItem.name == "해방된 카이세리움")
                        {
                            curItem.additionalATK += unleashedKayserium[C - 1];
                        }
                        else
                        {
                            double tmp = ((float)basicAM / 100) * (System.Math.Truncate((float)L / 40) + 1) * C * Mathf.Pow(1.1f, C - 3);
                            curItem.additionalATK += (int)System.Math.Ceiling(tmp);
                        }
                    }
                    else
                        curItem.additionalATK += C;
                    break;

                case 14:
                    if (curItem.type == ItemType.Weapon || curItem.type == ItemType.Lapis)
                    {
                        if (curItem.reqClass == CharacterClass.Zero)
                        {
                            if (curItem.name == "제네시스 라즐리" || curItem.name == "제네시스 라피스")
                                curItem.additionalMAG += zeroGenesis[C - 1];
                            else if (L == 200)
                                curItem.additionalMAG += zero200[C - 1];
                            else if (L == 180)
                                curItem.additionalMAG += zero180[C - 1];
                            else if (L == 170)
                                curItem.additionalMAG += zero170[C - 1];
                        }
                        else if (curItem.name == "해방된 카이세리움")
                        {
                            curItem.additionalMAG += unleashedKayserium[C - 1];
                        }
                        else
                        {
                            double tmp = ((float)basicAM / 100) * (System.Math.Truncate((float)L / 40) + 1) * C * Mathf.Pow(1.1f, C - 3);
                            curItem.additionalMAG += (int)System.Math.Ceiling(tmp);
                        }
                    }
                    else
                        curItem.additionalMAG += C;
                    break;

                case 15:
                    curItem.additionalAllStats += C;
                    break;

                case 16:
                    curItem.additionalBossATK += C * 2;
                    break;

                case 17:
                    curItem.additionalDamage += C;
                    break;

                default:
                    break;
            }
        }

        fileManager.SaveIs(itemSettingLogic.GetItemSettingData(), itemSettingLogic.GetCurPath());

        itemInfo.InfoUpdate();

        PopUpManager.Instance.GeneratePopUp("추가 옵션이 적용되었습니다.");
    }

    public List<string> GetATKAdditional(Item curItem)
    {
        var resultList = new List<string>();
        foreach (var _num in GetATKMAGAdditional_Num(curItem))
            resultList.Add("공격력 +" + (_num).ToString());
        return resultList;
    }

    public List<string> GetMAGAdditional(Item curItem)
    {
        var resultList = new List<string>();
        foreach (var _num in GetATKMAGAdditional_Num(curItem))
            resultList.Add("마력 +" + (_num).ToString());
        return resultList;
    }

    public List<int> GetATKMAGAdditional_Num(Item curItem)
    {
        int C = curItem.isNormalAdditional ? 1 : 3;
        int basicAM = curItem.reqClassGroup == CharacterClassGroup.Magician ? curItem.basicMAG : curItem.basicATK;
        var resultList = new List<int>();
        int L = curItem.reqLev;
        if (curItem.type == ItemType.Weapon || curItem.type == ItemType.Lapis)
        {
            if (curItem.reqClass == CharacterClass.Zero)
            {
                if (curItem.name == "제네시스 라즐리" || curItem.name == "제네시스 라피스")
                    resultList.AddRange(new List<int> { 21, 46, 75, 110, 151 });
                else if (L == 200)
                    resultList.AddRange(new List<int> { 18, 40, 65, 95, 131 });
                else if (L == 180)
                    resultList.AddRange(new List<int> { 11, 23, 38, 56, 76 });
                else if (L == 170)
                    resultList.AddRange(new List<int> { 9, 20, 32, 47, 64 });
            }
            else if (curItem.name == "해방된 카이세리움")
            {
                resultList.AddRange(new List<int> {16, 36, 59, 86, 118 });
            }
            else
            {
                for (int i = C; i <= 4 + C; i++)
                {
                    double tmp = ((float)basicAM / 100) * (System.Math.Truncate((float)L / 40) + 1) * i * Mathf.Pow(1.1f, i - 3);
                    resultList.Add((int)System.Math.Ceiling(tmp));
                }
            }
        }
        else
        {
            for (int i = C; i <= 4 + C; i++)
                resultList.Add(i);
        }
        return resultList;
    }

}
