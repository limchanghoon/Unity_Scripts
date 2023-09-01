using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellManager : MonoBehaviour
{
    public ItemInfo itemInfo;
    public ItemSettingLogic itemSettingLogic;
    public ISFileManager fileManager;
    public ItemSettingUI uiManager;

    public TMP_Dropdown spellDropdown1;
    public TMP_Dropdown spellDropdown2;
    public TMP_Dropdown spellDropdown3;

    public TextMeshProUGUI[] spellInfoTexts;

    public GameObject chaosSpellPanel;
    public TMP_Dropdown[] chaosSpellDropdowns;
    public GameObject[] chaosSpellDropdownParents;

    public TextMeshProUGUI upgradeCountText;

    PotentialOption[] stats = { PotentialOption.STR, PotentialOption.DEX, PotentialOption.LUK, PotentialOption.MaxHP, PotentialOption.INT, PotentialOption.AllStats };

    bool CheckSpellBonus()
    {
        var curItem = itemInfo.GetCurItem();
        int UC = curItem.totalUpgrade - curItem.remainingUpgrade; // UC�� 3�� �� �������ϸ� ��/�� +1 (�� ����) �尩����
        if (UC == 3)
            return true;
        return false;
    }

    void SetTextSpell4th(int idx)
    {
        var curItem = itemInfo.GetCurItem();
        if (CheckSpellBonus())
        {
            if (curItem.reqClassGroup == CharacterClassGroup.NULL) 
            {
                spellInfoTexts[idx].text = "���ݷ� +1";
                spellInfoTexts[idx + 1].text = "���� +1";
            }
            else if (curItem.reqClassGroup == CharacterClassGroup.Magician)
                spellInfoTexts[idx].text = "���� +1";
            else
                spellInfoTexts[idx].text = "���ݷ� +1";
        }
    }

    void GetSpellBonus()
    {
        var curItem = itemInfo.GetCurItem();
        if (CheckSpellBonus())
        {
            if (curItem.reqClassGroup == CharacterClassGroup.NULL)
            {
                curItem.spellATK += 1;
                curItem.spellMAG += 1;
            }
            else if (curItem.reqClassGroup == CharacterClassGroup.Magician)
                curItem.spellMAG += 1;
            else
                curItem.spellATK += 1;
        }
    }

    public void OnDropdown1Changed(TMP_Dropdown dropdown)
    {
        chaosSpellPanel.SetActive(false);
        spellDropdown2.ClearOptions();
        spellDropdown3.ClearOptions();
        spellDropdown2.gameObject.SetActive(false);
        spellDropdown3.gameObject.SetActive(false);

        var curItem = itemInfo.GetCurItem();

        if (dropdown.value != 0 && curItem.totalUpgrade == 0)
        {
            dropdown.value = 0;
            return;
        }
            

        switch (dropdown.value)
        {
            case 0:
                foreach (var txt in spellInfoTexts)
                    txt.text = "";
                break;

            case 1: // 15��
                if (itemInfo.CheckAccessory() || curItem.type == ItemType.Heart)
                {
                    PopUpManager.Instance.GeneratePopUp("15% ���� �Ұ����� �������Դϴ�.");
                    dropdown.value = 0;
                    break;
                }
                else if (curItem.type == ItemType.Weapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis)
                {
                    List<string> strList;
                    strList = new List<string>
                            { "���ݷ�(��)" ,"���ݷ�(��ø)" ,"���ݷ�(��)" ,"���ݷ�(ü��)" ,"����(����)"};
                    spellDropdown2.AddOptions(strList);
                }
                else if(curItem.type == ItemType.Gloves)
                {
                    List<string> strList;
                    strList = new List<string>
                            { "���ݷ�" ,"����"};
                    spellDropdown2.AddOptions(strList);
                }
                else
                {
                    List<string> strList;
                    strList = new List<string>
                            { "��" ,"��ø" ,"��" ,"ü��" ,"����" ,"�ý���"};
                    spellDropdown2.AddOptions(strList);
                }
                spellDropdown2.gameObject.SetActive(true);
                break;

            case 2: // 30��
                if (curItem.type == ItemType.Weapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis)
                {
                    List<string> strList;
                    strList = new List<string>
                            { "���ݷ�(��)" ,"���ݷ�(��ø)" ,"���ݷ�(��)" ,"���ݷ�(ü��)" ,"����(����)"};
                    spellDropdown2.AddOptions(strList);
                }
                else if (curItem.type == ItemType.Gloves)
                {
                    List<string> strList;
                    strList = new List<string>
                            { "���ݷ�" ,"����"};
                    spellDropdown2.AddOptions(strList);
                }
                else if (curItem.type == ItemType.Heart)
                {
                    List<string> strList;
                    strList = new List<string>
                            { "���ݷ�" ,"����"};
                    spellDropdown2.AddOptions(strList);
                }
                else
                {
                    List<string> strList;
                    strList = new List<string>
                            { "��" ,"��ø" ,"��" ,"ü��", "����","�ý���"};
                    spellDropdown2.AddOptions(strList);
                }
                spellDropdown2.gameObject.SetActive(true);
                break;

            case 3: // 70��
            case 4: // 100��
                if (curItem.type == ItemType.Weapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis)
                {
                    List<string> strList;
                    strList = new List<string>
                            { "���ݷ�(��)" ,"���ݷ�(��ø)" ,"���ݷ�(��)" ,"���ݷ�(ü��)" ,"����(����)"};
                    spellDropdown2.AddOptions(strList);
                }
                else if (curItem.type == ItemType.Gloves)
                {
                    List<string> strList;
                    strList = new List<string>
                            { "���ݷ�" ,"����"};
                    spellDropdown2.AddOptions(strList);
                }
                else if (curItem.type == ItemType.Heart)
                {
                    List<string> strList;
                    strList = new List<string>
                            { "���ݷ�" ,"����"};
                    spellDropdown2.AddOptions(strList);
                }
                else
                {
                    List<string> strList;
                    strList = new List<string>
                            { "��" ,"��ø" ,"��" ,"ü��" ,"����"};
                    spellDropdown2.AddOptions(strList);
                }
                spellDropdown2.gameObject.SetActive(true);
                break;

            case 5: // ȥ��
                chaosSpellPanel.SetActive(true);
                if (curItem.Get3STR() > 0)
                    chaosSpellDropdownParents[0].SetActive(true);
                else
                    chaosSpellDropdownParents[0].SetActive(false);

                if (curItem.Get3DEX() > 0)
                    chaosSpellDropdownParents[1].SetActive(true);
                else
                    chaosSpellDropdownParents[1].SetActive(false);

                if (curItem.Get3INT() > 0)
                    chaosSpellDropdownParents[2].SetActive(true);
                else
                    chaosSpellDropdownParents[2].SetActive(false);

                if (curItem.Get3LUK() > 0)
                    chaosSpellDropdownParents[3].SetActive(true);
                else
                    chaosSpellDropdownParents[3].SetActive(false);

                if (curItem.Get3MaxHP() > 0)
                    chaosSpellDropdownParents[4].SetActive(true);
                else
                    chaosSpellDropdownParents[4].SetActive(false);

                if (curItem.Get3MaxMP() > 0)
                    chaosSpellDropdownParents[5].SetActive(true);
                else
                    chaosSpellDropdownParents[5].SetActive(false);

                if (curItem.Get3ATK() > 0)
                    chaosSpellDropdownParents[6].SetActive(true);
                else
                    chaosSpellDropdownParents[6].SetActive(false);

                if (curItem.Get3MAG() > 0)
                    chaosSpellDropdownParents[7].SetActive(true);
                else
                    chaosSpellDropdownParents[7].SetActive(false);

                break;

            case 6: // �Ǽ����� �ֹ���
                if (itemInfo.CheckAccessory())
                {
                    List<string> strList;
                    strList = new List<string>
                            { "�� +1" ,"�� +2" ,"�� +3" ,"�� +4" ,"�� +5" ,"���� +1" ,"���� +2" ,"���� +3" ,"���� +4" ,"���� +5"};
                    spellDropdown2.AddOptions(strList);
                }
                else
                {
                    PopUpManager.Instance.GeneratePopUp("�Ǽ������� �ƴմϴ�.(�����ĵ� �ȵ˴ϴ�.)");
                    dropdown.value = 0;
                    break;
                }
                spellDropdown2.gameObject.SetActive(true);
                break;


            case 7: // ����� (��)
                if (curItem.type == ItemType.Cape || curItem.type == ItemType.Gloves || curItem.type == ItemType.Helmet || curItem.type == ItemType.Pants
                    || curItem.type == ItemType.Shirt || curItem.type == ItemType.Shoes || curItem.type == ItemType.Shield)
                {
                    List<string> strList;
                    strList = new List<string>
                            { "���ݷ� +1" ,"���ݷ� +2", "���ݷ� +3", "���� +1" ,"���� +2", "���� +3"};
                    spellDropdown2.AddOptions(strList);
                }
                else
                {
                    PopUpManager.Instance.GeneratePopUp("���� �ƴմϴ�.(�����ĵ� �ȵ˴ϴ�.)");
                    dropdown.value = 0;
                    break;
                }
                spellDropdown2.gameObject.SetActive(true);
                break;

            case 8: // �̱׵����� �ູ(120�� �̻�)
                if (curItem.reqLev < 120 || curItem.isYggdrasil == true || curItem.isBasicGrowth == true)
                {
                    if (curItem.reqLev < 120)
                        PopUpManager.Instance.GeneratePopUp("120�� �̸��� ����Դϴ�.");
                    else if(curItem.isYggdrasil == true)
                        PopUpManager.Instance.GeneratePopUp("�̹� �̱׵����� ����ƽ��ϴ�.");
                    else
                        PopUpManager.Instance.GeneratePopUp("���� �����ۿ��� �Ұ����մϴ�.");
                    dropdown.value = 0;
                    break;
                }
                else
                {
                    List<string> strList;
                    strList = new List<string>
                            { "STR" ,"DEX" ,"INT" ,"LUK"};
                    spellDropdown2.AddOptions(strList);

                    List<string> strList2;
                    strList2 = new List<string>
                            { "+5", "+6", "+7", "+8", "+9", "+10", "+11", "+12", "+13", "+14", "+15"};
                    spellDropdown3.AddOptions(strList2);
                    spellDropdown2.gameObject.SetActive(true);
                    spellDropdown3.gameObject.SetActive(true);
                }
                break;

            case 9: // ������
                if (curItem.type != ItemType.Earring)
                {
                    PopUpManager.Instance.GeneratePopUp("�Ͱ��� �ƴմϴ�.");
                    dropdown.value = 0;
                    break;
                }
                else
                {
                    List<string> strList;
                    strList = new List<string>
                            { "���� +5, INT +3"};
                    spellDropdown2.AddOptions(strList);
                }
                break;

            case 10: // �������� (����, ��� ����)
                if(curItem.type == ItemType.Weapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis || curItem.type == ItemType.Heart)
                {
                    List<string> strList;
                    strList = new List<string>
                            { "���ݷ� +9" ,"���ݷ� +10", "���ݷ� +11", "���� +9" ,"���� +10", "���� +11"};
                    spellDropdown2.AddOptions(strList);
                }
                else
                {
                    PopUpManager.Instance.GeneratePopUp("���� �Ǵ� ��� ������ �ƴմϴ�.");
                    dropdown.value = 0;
                    break;
                }
                spellDropdown2.gameObject.SetActive(true);
                break;

            case 11:    // ��ũ �̳뼾Ʈ
                break;

            case 12:    // ���� �ֹ���
                break;

            case 13: // ���� ��Ʈ ���� �ֹ���
                if (curItem.type == ItemType.Weapon && curItem.reqClass == CharacterClass.Zero && curItem.name != "���׽ý� ����")
                {
                    List<string> strList;
                    strList = new List<string>
                            { "��Ʈ�� �����ϼ���","-��Ÿ��(����) ��Ű ������ �ֹ���","-�ۼַ��� ��Ű������ �ֹ���","-�����μ��̵� ��Ű������ �ֹ���"};
                    spellDropdown2.AddOptions(strList);

                    spellDropdown2.gameObject.SetActive(true);
                }
                break;

            default:
                break;
        }
        OnDropdown2Changed(spellDropdown2);
    }

    public void OnDropdown2Changed(TMP_Dropdown dropdown)
    {
        var curItem = itemInfo.GetCurItem();
        int L = curItem.reqLev;

        foreach (var txt in spellInfoTexts)
            txt.text = "";

        switch (spellDropdown1.value)
        {
            case 0:
                break;

            case 1: // 15��
                if (curItem.type == ItemType.Weapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis)
                {
                    if(L <= 70)
                    {
                        if(dropdown.value <= 3)
                            spellInfoTexts[0].text = "���ݷ� +5";
                        else
                            spellInfoTexts[0].text = "���� +5";
                        spellInfoTexts[1].text = stats[dropdown.value].ToString();
                        spellInfoTexts[1].text += dropdown.value == 3 ? " +100" : " +2";
                    }
                    else if(L <= 110)
                    {
                        if (dropdown.value <= 3)
                            spellInfoTexts[0].text = "���ݷ� +7";
                        else
                            spellInfoTexts[0].text = "���� +7";
                        spellInfoTexts[1].text = stats[dropdown.value].ToString();
                        spellInfoTexts[1].text += dropdown.value == 3 ? " +150" : " +3";
                    }
                    else
                    {
                        if (dropdown.value <= 3)
                            spellInfoTexts[0].text = "���ݷ� +9";
                        else
                            spellInfoTexts[0].text = "���� +9";
                        spellInfoTexts[1].text = stats[dropdown.value].ToString();
                        spellInfoTexts[1].text += dropdown.value == 3 ? " +200" : " +4";
                    }
                }
                else if (curItem.type == ItemType.Gloves)
                {
                    if (L <= 70)
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "���ݷ� +3";
                        else
                            spellInfoTexts[0].text = "���� +3";
                    }
                    else
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "���ݷ� +4";
                        else
                            spellInfoTexts[0].text = "���� +4";
                    }
                }
                else
                {
                    if (L <= 70)
                    {
                        if (dropdown.value == 3)
                        {
                            spellInfoTexts[0].text = "�ִ� HP +245";
                            SetTextSpell4th(1);
                        }
                        else if (dropdown.value == 5)
                        {
                            spellInfoTexts[0].text = "STR +2";
                            spellInfoTexts[1].text = "DEX +2";
                            spellInfoTexts[2].text = "INT +2";
                            spellInfoTexts[3].text = "LUK +2";
                            spellInfoTexts[4].text = "�ִ� HP +45";
                            SetTextSpell4th(5);
                        }
                        else
                        {
                            spellInfoTexts[0].text = stats[dropdown.value].ToString() + " +4";
                            spellInfoTexts[1].text = "�ִ� HP +45";
                            SetTextSpell4th(2);
                        }
                        
                    }
                    else if (L <= 115)
                    {
                        if (dropdown.value == 3)
                        {
                            spellInfoTexts[0].text = "�ִ� HP +460";
                            SetTextSpell4th(1);
                        }
                        else if (dropdown.value == 5)
                        {
                            spellInfoTexts[0].text = "STR +3";
                            spellInfoTexts[1].text = "DEX +3";
                            spellInfoTexts[2].text = "INT +3";
                            spellInfoTexts[3].text = "LUK +3";
                            spellInfoTexts[4].text = "�ִ� HP +110";
                            SetTextSpell4th(5);
                        }
                        else
                        {
                            spellInfoTexts[0].text = stats[dropdown.value].ToString() + " +7";
                            spellInfoTexts[1].text = "�ִ� HP +110";
                            SetTextSpell4th(2);
                        }
                    }
                    else
                    {
                        if (dropdown.value == 3)
                        {
                            spellInfoTexts[0].text = "�ִ� HP +670";
                            SetTextSpell4th(1);
                        }
                        else if (dropdown.value == 5)
                        {
                            spellInfoTexts[0].text = "STR +4";
                            spellInfoTexts[1].text = "DEX +4";
                            spellInfoTexts[2].text = "INT +4";
                            spellInfoTexts[3].text = "LUK +4";
                            spellInfoTexts[4].text = "�ִ� HP +170";
                            SetTextSpell4th(5);
                        }
                        else
                        {
                            spellInfoTexts[0].text = stats[dropdown.value].ToString() + " +10";
                            spellInfoTexts[1].text = "�ִ� HP +170";
                            SetTextSpell4th(2);
                        }
                    }
                }
                break;

            case 2: // 30��
                if (curItem.type == ItemType.Weapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis)
                {
                    if (L <= 70)
                    {
                        if (dropdown.value <= 3)
                            spellInfoTexts[0].text = "���ݷ� +3";
                        else
                            spellInfoTexts[0].text = "���� +3";
                        spellInfoTexts[1].text = stats[dropdown.value].ToString();
                        spellInfoTexts[1].text += dropdown.value == 3 ? " +50" : " +1";
                    }
                    else if (L <= 110)
                    {
                        if (dropdown.value <= 3)
                            spellInfoTexts[0].text = "���ݷ� +5";
                        else
                            spellInfoTexts[0].text = "���� +5";
                        spellInfoTexts[1].text = stats[dropdown.value].ToString();
                        spellInfoTexts[1].text += dropdown.value == 3 ? " +100" : " +2";
                    }
                    else
                    {
                        if (dropdown.value <= 3)
                            spellInfoTexts[0].text = "���ݷ� +7";
                        else
                            spellInfoTexts[0].text = "���� +7";
                        spellInfoTexts[1].text = stats[dropdown.value].ToString();
                        spellInfoTexts[1].text += dropdown.value == 3 ? " +150" : " +3";
                    }
                }
                else if (curItem.type == ItemType.Gloves)
                {
                    if (L <= 70)
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "���ݷ� +2";
                        else
                            spellInfoTexts[0].text = "���� +2";
                    }
                    else
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "���ݷ� +3";
                        else
                            spellInfoTexts[0].text = "���� +3";
                    }
                }
                else if (itemInfo.CheckAccessory())
                {
                    if (L <= 70)
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "STR +3";
                        else if (dropdown.value == 1)
                            spellInfoTexts[0].text = "DEX +3";
                        else if (dropdown.value == 2)
                            spellInfoTexts[0].text = "LUK +3";
                        else if (dropdown.value == 3)
                            spellInfoTexts[0].text = "�ִ� HP +150";
                        else if (dropdown.value == 4)
                            spellInfoTexts[0].text = "INT +3";
                        else if (dropdown.value == 5)
                        {
                            spellInfoTexts[0].text = "STR +1";
                            spellInfoTexts[1].text = "DEX +1";
                            spellInfoTexts[2].text = "INT +1";
                            spellInfoTexts[3].text = "LUK +1";
                        }
                    }
                    else if (L <= 115)
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "STR +4";
                        else if (dropdown.value == 1)
                            spellInfoTexts[0].text = "DEX +4";
                        else if (dropdown.value == 2)
                            spellInfoTexts[0].text = "LUK +4";
                        else if (dropdown.value == 3)
                            spellInfoTexts[0].text = "�ִ� HP +200";
                        else if (dropdown.value == 4)
                            spellInfoTexts[0].text = "INT +4";
                        else if (dropdown.value == 5)
                        {
                            spellInfoTexts[0].text = "STR +2";
                            spellInfoTexts[1].text = "DEX +2";
                            spellInfoTexts[2].text = "INT +2";
                            spellInfoTexts[3].text = "LUK +2";
                        }
                    }
                    else
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "STR +5";
                        else if (dropdown.value == 1)
                            spellInfoTexts[0].text = "DEX +5";
                        else if (dropdown.value == 2)
                            spellInfoTexts[0].text = "LUK +5";
                        else if (dropdown.value == 3)
                            spellInfoTexts[0].text = "�ִ� HP +250";
                        else if (dropdown.value == 4)
                            spellInfoTexts[0].text = "INT +5";
                        else if (dropdown.value == 5)
                        {
                            spellInfoTexts[0].text = "STR +3";
                            spellInfoTexts[1].text = "DEX +3";
                            spellInfoTexts[2].text = "INT +3";
                            spellInfoTexts[3].text = "LUK +3";
                        }
                    }
                }
                else if (curItem.type == ItemType.Heart)
                {
                    if (L <= 30)
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "���ݷ� +3";
                        else
                            spellInfoTexts[0].text = "���� +3";
                    }
                    else
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "���ݷ� +5";
                        else
                            spellInfoTexts[0].text = "���� +5";
                    }
                }
                else
                {
                    if (L <= 70)
                    {
                        if (dropdown.value == 3)
                        {
                            spellInfoTexts[0].text = "�ִ� HP +180";
                            SetTextSpell4th(1);
                        }
                        else if (dropdown.value == 5)
                        {
                            spellInfoTexts[0].text = "STR +1";
                            spellInfoTexts[1].text = "DEX +1";
                            spellInfoTexts[2].text = "INT +1";
                            spellInfoTexts[3].text = "LUK +1";
                            spellInfoTexts[4].text = "�ִ� HP +30";
                            SetTextSpell4th(5);
                        }
                        else
                        {
                            spellInfoTexts[0].text = stats[dropdown.value].ToString() + " +3";
                            spellInfoTexts[1].text = "�ִ� HP +30";
                            SetTextSpell4th(2);
                        }

                    }
                    else if (L <= 115)
                    {
                        if (dropdown.value == 3)
                        {
                            spellInfoTexts[0].text = "�ִ� HP +320";
                            SetTextSpell4th(1);
                        }
                        else if (dropdown.value == 5)
                        {
                            spellInfoTexts[0].text = "STR +2";
                            spellInfoTexts[1].text = "DEX +2";
                            spellInfoTexts[2].text = "INT +2";
                            spellInfoTexts[3].text = "LUK +2";
                            spellInfoTexts[4].text = "�ִ� HP +70";
                            SetTextSpell4th(5);
                        }
                        else
                        {
                            spellInfoTexts[0].text = stats[dropdown.value].ToString() + " +5";
                            spellInfoTexts[1].text = "�ִ� HP +70";
                            SetTextSpell4th(2);
                        }
                    }
                    else
                    {
                        if (dropdown.value == 3)
                        {
                            spellInfoTexts[0].text = "�ִ� HP +470";
                            SetTextSpell4th(1);
                        }
                        else if (dropdown.value == 5)
                        {
                            spellInfoTexts[0].text = "STR +3";
                            spellInfoTexts[1].text = "DEX +3";
                            spellInfoTexts[2].text = "INT +3";
                            spellInfoTexts[3].text = "LUK +3";
                            spellInfoTexts[4].text = "�ִ� HP +120";
                            SetTextSpell4th(5);
                        }
                        else
                        {
                            spellInfoTexts[0].text = stats[dropdown.value].ToString() + " +7";
                            spellInfoTexts[1].text = "�ִ� HP +120";
                            SetTextSpell4th(2);
                        }
                    }
                }
                break;

            case 3: // 70��
                if (curItem.type == ItemType.Weapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis)
                {
                    if (L <= 70)
                    {
                        if (dropdown.value <= 3)
                            spellInfoTexts[0].text = "���ݷ� +2";
                        else
                            spellInfoTexts[0].text = "���� +2";
                    }
                    else if (L <= 110)
                    {
                        if (dropdown.value <= 3)
                            spellInfoTexts[0].text = "���ݷ� +3";
                        else
                            spellInfoTexts[0].text = "���� +3";
                        spellInfoTexts[1].text = stats[dropdown.value].ToString();
                        spellInfoTexts[1].text += dropdown.value == 3 ? " +50" : " +1";
                    }
                    else
                    {
                        if (dropdown.value <= 3)
                            spellInfoTexts[0].text = "���ݷ� +5";
                        else
                            spellInfoTexts[0].text = "���� +5";
                        spellInfoTexts[1].text = stats[dropdown.value].ToString();
                        spellInfoTexts[1].text += dropdown.value == 3 ? " +100" : " +2";
                    }
                }
                else if (curItem.type == ItemType.Gloves)
                {
                    if (L <= 70)
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "���ݷ� +1";
                        else
                            spellInfoTexts[0].text = "���� +1";
                    }
                    else
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "���ݷ� +2";
                        else
                            spellInfoTexts[0].text = "���� +2";
                    }
                }
                else if (itemInfo.CheckAccessory())
                {
                    if (L <= 115)
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "STR +2";
                        else if (dropdown.value == 1)
                            spellInfoTexts[0].text = "DEX +2";
                        else if (dropdown.value == 2)
                            spellInfoTexts[0].text = "LUK +2";
                        else if (dropdown.value == 3)
                            spellInfoTexts[0].text = "�ִ� HP +100";
                        else if (dropdown.value == 4)
                            spellInfoTexts[0].text = "INT +2";
                    }
                    else
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "STR +3";
                        else if (dropdown.value == 1)
                            spellInfoTexts[0].text = "DEX +3";
                        else if (dropdown.value == 2)
                            spellInfoTexts[0].text = "LUK +3";
                        else if (dropdown.value == 3)
                            spellInfoTexts[0].text = "�ִ� HP +150";
                        else if (dropdown.value == 4)
                            spellInfoTexts[0].text = "INT +3";
                    }
                }
                else if (curItem.type == ItemType.Heart)
                {
                    if (L <= 30)
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "���ݷ� +2";
                        else
                            spellInfoTexts[0].text = "���� +2";
                    }
                    else
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "���ݷ� +3";
                        else
                            spellInfoTexts[0].text = "���� +3";
                    }
                }
                else
                {
                    if (L <= 70)
                    {
                        if (dropdown.value == 3)
                        {
                            spellInfoTexts[0].text = "�ִ� HP +115";
                            SetTextSpell4th(1);
                        }
                        else
                        {
                            spellInfoTexts[0].text = stats[dropdown.value].ToString() + " +2";
                            spellInfoTexts[1].text = "�ִ� HP +15";
                            SetTextSpell4th(2);
                        }

                    }
                    else if (L <= 115)
                    {
                        if (dropdown.value == 3)
                        {
                            spellInfoTexts[0].text = "�ִ� HP +190";
                            SetTextSpell4th(1);
                        }
                        else
                        {
                            spellInfoTexts[0].text = stats[dropdown.value].ToString() + " +3";
                            spellInfoTexts[1].text = "�ִ� HP +40";
                            SetTextSpell4th(2);
                        }
                    }
                    else
                    {
                        if (dropdown.value == 3)
                        {
                            spellInfoTexts[0].text = "�ִ� HP +270";
                            SetTextSpell4th(1);
                        }
                        else
                        {
                            spellInfoTexts[0].text = stats[dropdown.value].ToString() + " +4";
                            spellInfoTexts[1].text = "�ִ� HP +70";
                            SetTextSpell4th(2);
                        }
                    }
                }
                break;

            case 4: // 100��
                if (curItem.type == ItemType.Weapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis)
                {
                    if (L <= 70)
                    {
                        if (dropdown.value <= 3)
                            spellInfoTexts[0].text = "���ݷ� +1";
                        else
                            spellInfoTexts[0].text = "���� +1";
                    }
                    else if (L <= 110)
                    {
                        if (dropdown.value <= 3)
                            spellInfoTexts[0].text = "���ݷ� +2";
                        else
                            spellInfoTexts[0].text = "���� +2";
                    }
                    else
                    {
                        if (dropdown.value <= 3)
                            spellInfoTexts[0].text = "���ݷ� +3";
                        else
                            spellInfoTexts[0].text = "���� +3";
                        spellInfoTexts[1].text = stats[dropdown.value].ToString();
                        spellInfoTexts[1].text += dropdown.value == 3 ? " +50" : " +1";
                    }
                }
                else if (curItem.type == ItemType.Gloves)
                {
                    if (L <= 70)
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "���ݷ� +0(���� ��)";
                        else
                            spellInfoTexts[0].text = "���� +0(���� ��)";
                    }
                    else
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "���ݷ� +1";
                        else
                            spellInfoTexts[0].text = "���� +1";
                    }
                }
                else if (itemInfo.CheckAccessory())
                {
                    if (L <= 115)
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "STR +1";
                        else if (dropdown.value == 1)
                            spellInfoTexts[0].text = "DEX +1";
                        else if (dropdown.value == 2)
                            spellInfoTexts[0].text = "LUK +1";
                        else if (dropdown.value == 3)
                            spellInfoTexts[0].text = "�ִ� HP +50";
                        else if (dropdown.value == 4)
                            spellInfoTexts[0].text = "INT +1";
                    }
                    else
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "STR +1";
                        else if (dropdown.value == 1)
                            spellInfoTexts[0].text = "DEX +1";
                        else if (dropdown.value == 2)
                            spellInfoTexts[0].text = "LUK +1";
                        else if (dropdown.value == 3)
                            spellInfoTexts[0].text = "�ִ� HP +100";
                        else if (dropdown.value == 4)
                            spellInfoTexts[0].text = "INT +1";
                    }
                }
                else if (curItem.type == ItemType.Heart)
                {
                    if (L <= 30)
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "���ݷ� +1";
                        else
                            spellInfoTexts[0].text = "���� +1";
                    }
                    else
                    {
                        if (dropdown.value == 0)
                            spellInfoTexts[0].text = "���ݷ� +2";
                        else
                            spellInfoTexts[0].text = "���� +2";
                    }
                }
                else
                {
                    if (L <= 70)
                    {
                        if (dropdown.value == 3)
                        {
                            spellInfoTexts[0].text = "�ִ� HP +55";
                            SetTextSpell4th(1);
                        }
                        else
                        {
                            spellInfoTexts[0].text = stats[dropdown.value].ToString() + " +1";
                            spellInfoTexts[1].text = "�ִ� HP +5";
                            SetTextSpell4th(2);
                        }

                    }
                    else if (L <= 115)
                    {
                        if (dropdown.value == 3)
                        {
                            spellInfoTexts[0].text = "�ִ� HP +120";
                            SetTextSpell4th(1);
                        }
                        else
                        {
                            spellInfoTexts[0].text = stats[dropdown.value].ToString() + " +2";
                            spellInfoTexts[1].text = "�ִ� HP +20";
                            SetTextSpell4th(2);
                        }
                    }
                    else
                    {
                        if (dropdown.value == 3)
                        {
                            spellInfoTexts[0].text = "�ִ� HP +180";
                            SetTextSpell4th(1);
                        }
                        else
                        {
                            spellInfoTexts[0].text = stats[dropdown.value].ToString() + " +3";
                            spellInfoTexts[1].text = "�ִ� HP +30";
                            SetTextSpell4th(2);
                        }
                    }
                }
                break;

            case 5: // ȥ��

                break;

            case 6: // �Ǽ����� �ֹ���
                if (dropdown.value == 0)
                    spellInfoTexts[0].text = "���ݷ� +1";
                else if (dropdown.value == 1)
                    spellInfoTexts[0].text = "���ݷ� +2";
                else if (dropdown.value == 2)
                    spellInfoTexts[0].text = "���ݷ� +3";
                else if (dropdown.value == 3)
                    spellInfoTexts[0].text = "���ݷ� +4";
                else if (dropdown.value == 4)
                    spellInfoTexts[0].text = "���ݷ� +5";
                else if (dropdown.value == 5)
                    spellInfoTexts[0].text = "���� +1";
                else if (dropdown.value == 6)
                    spellInfoTexts[0].text = "���� +2";
                else if (dropdown.value == 7)
                    spellInfoTexts[0].text = "���� +3";
                else if (dropdown.value == 8)
                    spellInfoTexts[0].text = "���� +4";
                else if (dropdown.value == 9)
                    spellInfoTexts[0].text = "���� +5";
                break;

            case 7: // �� �ֹ���
                if (dropdown.value == 0)
                    spellInfoTexts[0].text = "���ݷ� +1";
                else if (dropdown.value == 1)
                    spellInfoTexts[0].text = "���ݷ� +2";
                else if (dropdown.value == 2)
                    spellInfoTexts[0].text = "���ݷ� +3";
                else if (dropdown.value == 3)
                    spellInfoTexts[0].text = "���� +1";
                else if (dropdown.value == 4)
                    spellInfoTexts[0].text = "���� +2";
                else if (dropdown.value == 5)
                    spellInfoTexts[0].text = "���� +3";
                break;

            case 8: // �̱׵����� �ູ
                if (dropdown.value == 0)
                    spellInfoTexts[0].text = "STR +" + (spellDropdown3.value + 5).ToString();
                else if (dropdown.value == 1)
                    spellInfoTexts[0].text = "DEX +" + (spellDropdown3.value + 5).ToString();
                else if (dropdown.value == 2)
                    spellInfoTexts[0].text = "INT +" + (spellDropdown3.value + 5).ToString();
                else if (dropdown.value == 3)
                    spellInfoTexts[0].text = "LUK +" + (spellDropdown3.value + 5).ToString();
                break;

            case 9: // ������
                spellInfoTexts[0].text = "���� +5";
                spellInfoTexts[1].text = "INT +3";
                break;

            case 10: // �������� (����, ������)
                if (dropdown.value == 0)
                    spellInfoTexts[0].text = "���ݷ� +9";
                else if (dropdown.value == 1)
                    spellInfoTexts[0].text = "���ݷ� +10";
                else if (dropdown.value == 2)
                    spellInfoTexts[0].text = "���ݷ� +11";
                else if (dropdown.value == 3)
                    spellInfoTexts[0].text = "���� +9";
                else if (dropdown.value == 4)
                    spellInfoTexts[0].text = "���� +10";
                else if (dropdown.value == 5)
                    spellInfoTexts[0].text = "���� +11";
                break;

            case 11:    // �̳뼾Ʈ
                spellInfoTexts[0].text = "�ֹ����� �ʱ�ȭ\n(���� ������ �ʱ�ȭ���� �ʽ��ϴ�.)";
                break;

            case 12:    // ����, ������
                if(curItem.name == "ȥ������ �����" || curItem.name == "ī���� ȥ������ �����")
                {
                    if(curItem.remainingUpgrade == 3)
                    {
                        spellInfoTexts[0].text = "STR +15";
                        spellInfoTexts[1].text = "DEX +15";
                        spellInfoTexts[2].text = "INT +15";
                        spellInfoTexts[3].text = "LUK +15";
                        spellInfoTexts[4].text = "�ִ� HP +750";
                    }
                    else
                    {
                        spellInfoTexts[0].text = "������ ���׷��̵� Ƚ�� 3�� ���� �����մϴ�.";
                    }
                }
                else if (curItem.name == "���̳����� ���Ʈ")
                {
                    spellInfoTexts[0].text = "STR +3";
                    spellInfoTexts[1].text = "DEX +3";
                    spellInfoTexts[2].text = "INT +3";
                    spellInfoTexts[3].text = "LUK +3";
                    spellInfoTexts[4].text = "�ִ� HP +40";
                    spellInfoTexts[5].text = "�ִ� MP +40";
                    spellInfoTexts[6].text = "���ݷ� +3";
                    spellInfoTexts[7].text = "���� +3";
                }
                else
                {
                    spellInfoTexts[0].text = "���� �ֹ����� �������� �ʽ��ϴ�.";
                }
                break;

            case 13: // ���� ��Ʈ ���� �ֹ���
                if (dropdown.value == 1)
                    spellInfoTexts[0].text = "������ ���⸦ ��Ÿ�� ���缼Ʈ�� ���Խ�Ų��.";
                else if (dropdown.value == 2)
                    spellInfoTexts[0].text = "������ ���⸦ �ۼַ��� ���缼Ʈ�� ���Խ�Ų��.";
                else if (dropdown.value == 3)
                    spellInfoTexts[0].text = "������ ���⸦ �����μ��̵� ���缼Ʈ�� ���Խ�Ų��.";
                else
                    spellInfoTexts[0].text = "�� ���� ������ ����(���ǽ� X)�� �����մϴ�. ���� ���׽ý� ���񸮵� �Ұ��մϴ�.";
                break;

            default:
                break;
        }
    }

    public void OnDropdown3Changed(TMP_Dropdown dropdown)
    {

        if (spellDropdown1.value == 8)
        {
            foreach (var txt in spellInfoTexts)
                txt.text = "";

            if (spellDropdown2.value == 0)
                spellInfoTexts[0].text = "STR +" + (dropdown.value + 5).ToString();
            else if (spellDropdown2.value == 1)
                spellInfoTexts[0].text = "DEX +" + (dropdown.value + 5).ToString();
            else if (spellDropdown2.value == 2)
                spellInfoTexts[0].text = "INT +" + (dropdown.value + 5).ToString();
            else if (spellDropdown2.value == 3)
                spellInfoTexts[0].text = "LUK +" + (dropdown.value + 5).ToString();
        }
    }

    public void UpdateUpgradeCountText()
    {
        var curItem = itemInfo.GetCurItem();
        if (curItem.totalUpgrade > 0)
            upgradeCountText.text = "���� ���׷��̵� ���� Ƚ�� : " + curItem.remainingUpgrade.ToString();
        else
            upgradeCountText.text = "�ֹ��� ���� �Ұ����� ����Դϴ�.";
    }

    public void SpellApply()
    {
        var curItem = itemInfo.GetCurItem();
        int L = curItem.reqLev;
        if (spellDropdown1.value != 11 && spellDropdown1.value != 13 && curItem.remainingUpgrade <= 0)
            return;
        switch (spellDropdown1.value)
        {
            case 0:
                break;

            case 1: // 15��
                if (curItem.type == ItemType.Weapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis)
                {
                    if (L <= 70)
                    {
                        if (spellDropdown2.value <= 3)
                            curItem.spellATK += 5;
                        else
                            curItem.spellMAG += 5;

                        if (spellDropdown2.value == 0)
                            curItem.spellSTR += 2;
                        else if (spellDropdown2.value == 1)
                            curItem.spellDEX += 2;
                        else if (spellDropdown2.value == 2)
                            curItem.spellLUK += 2;
                        else if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 100;
                        else if (spellDropdown2.value == 4)
                            curItem.spellINT += 2;
                    }
                    else if (L <= 110)
                    {
                        if (spellDropdown2.value <= 3)
                            curItem.spellATK += 7;
                        else
                            curItem.spellMAG += 7;

                        if (spellDropdown2.value == 0)
                            curItem.spellSTR += 3;
                        else if (spellDropdown2.value == 1)
                            curItem.spellDEX += 3;
                        else if (spellDropdown2.value == 2)
                            curItem.spellLUK += 3;
                        else if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 150;
                        else if (spellDropdown2.value == 4)
                            curItem.spellINT += 3;
                    }
                    else
                    {
                        if (spellDropdown2.value <= 3)
                            curItem.spellATK += 9;
                        else
                            curItem.spellMAG += 9;

                        if (spellDropdown2.value == 0)
                            curItem.spellSTR += 4;
                        else if (spellDropdown2.value == 1)
                            curItem.spellDEX += 4;
                        else if (spellDropdown2.value == 2)
                            curItem.spellLUK += 4;
                        else if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 200;
                        else if (spellDropdown2.value == 4)
                            curItem.spellINT += 4;
                    }
                }
                else if (curItem.type == ItemType.Gloves)
                {
                    if (L <= 70)
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellATK += 3;
                        else
                            curItem.spellMAG += 3;
                    }
                    else
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellATK += 4;
                        else
                            curItem.spellMAG += 4;
                    }
                }
                else
                {
                    GetSpellBonus();
                    if (L <= 70)
                    {
                        if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 245;
                        else if (spellDropdown2.value == 5)
                        {
                            curItem.spellSTR += 2;
                            curItem.spellDEX += 2;
                            curItem.spellLUK += 2;
                            curItem.spellMaxHP += 45;
                            curItem.spellINT += 2;
                        }
                        else
                        {
                            if (spellDropdown2.value == 0)
                                curItem.spellSTR += 4;
                            else if (spellDropdown2.value == 1)
                                curItem.spellDEX += 4;
                            else if (spellDropdown2.value == 2)
                                curItem.spellLUK += 4;
                            else if (spellDropdown2.value == 4)
                                curItem.spellINT += 4;
                            curItem.spellMaxHP += 45;
                        }

                    }
                    else if (L <= 115)
                    {
                        if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 460;
                        else if (spellDropdown2.value == 5)
                        {
                            curItem.spellSTR += 3;
                            curItem.spellDEX += 3;
                            curItem.spellLUK += 3;
                            curItem.spellMaxHP += 110;
                            curItem.spellINT += 3;
                        }
                        else
                        {
                            if (spellDropdown2.value == 0)
                                curItem.spellSTR += 7;
                            else if (spellDropdown2.value == 1)
                                curItem.spellDEX += 7;
                            else if (spellDropdown2.value == 2)
                                curItem.spellLUK += 7;
                            else if (spellDropdown2.value == 4)
                                curItem.spellINT += 7;
                            curItem.spellMaxHP += 110;
                        }
                    }
                    else
                    {
                        if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 670;
                        else if (spellDropdown2.value == 5)
                        {
                            curItem.spellSTR += 4;
                            curItem.spellDEX += 4;
                            curItem.spellLUK += 4;
                            curItem.spellMaxHP += 170;
                            curItem.spellINT += 4;
                        }
                        else
                        {
                            if (spellDropdown2.value == 0)
                                curItem.spellSTR += 10;
                            else if (spellDropdown2.value == 1)
                                curItem.spellDEX += 10;
                            else if (spellDropdown2.value == 2)
                                curItem.spellLUK += 10;
                            else if (spellDropdown2.value == 4)
                                curItem.spellINT += 10;
                            curItem.spellMaxHP += 170;
                        }
                    }
                }

                curItem.remainingUpgrade--;
                break;


            case 2: // 30��
                if (curItem.type == ItemType.Weapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis)
                {
                    if (L <= 70)
                    {
                        if (spellDropdown2.value <= 3)
                            curItem.spellATK += 3;
                        else
                            curItem.spellMAG += 3;

                        if (spellDropdown2.value == 0)
                            curItem.spellSTR += 1;
                        else if (spellDropdown2.value == 1)
                            curItem.spellDEX += 1;
                        else if (spellDropdown2.value == 2)
                            curItem.spellLUK += 1;
                        else if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 50;
                        else if (spellDropdown2.value == 4)
                            curItem.spellINT += 1;
                    }
                    else if (L <= 110)
                    {
                        if (spellDropdown2.value <= 3)
                            curItem.spellATK += 5;
                        else
                            curItem.spellMAG += 5;

                        if (spellDropdown2.value == 0)
                            curItem.spellSTR += 2;
                        else if (spellDropdown2.value == 1)
                            curItem.spellDEX += 2;
                        else if (spellDropdown2.value == 2)
                            curItem.spellLUK += 2;
                        else if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 100;
                        else if (spellDropdown2.value == 4)
                            curItem.spellINT += 2;
                    }
                    else
                    {
                        if (spellDropdown2.value <= 3)
                            curItem.spellATK += 7;
                        else
                            curItem.spellMAG += 7;

                        if (spellDropdown2.value == 0)
                            curItem.spellSTR += 3;
                        else if (spellDropdown2.value == 1)
                            curItem.spellDEX += 3;
                        else if (spellDropdown2.value == 2)
                            curItem.spellLUK += 3;
                        else if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 150;
                        else if (spellDropdown2.value == 4)
                            curItem.spellINT += 3;
                    }
                }
                else if (curItem.type == ItemType.Gloves)
                {
                    if (L <= 70)
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellATK += 2;
                        else
                            curItem.spellMAG += 2;
                    }
                    else
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellATK += 3;
                        else
                            curItem.spellMAG += 3;
                    }
                }
                else if(itemInfo.CheckAccessory())
                {
                    if (L <= 70)
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellSTR += 3;
                        else if (spellDropdown2.value == 1)
                            curItem.spellDEX += 3;
                        else if (spellDropdown2.value == 2)
                            curItem.spellLUK += 3;
                        else if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 150;
                        else if (spellDropdown2.value == 4)
                            curItem.spellINT += 3;
                        else if (spellDropdown2.value == 5)
                        {
                            curItem.spellSTR += 1;
                            curItem.spellDEX += 1;
                            curItem.spellINT += 1;
                            curItem.spellLUK += 1;
                        }
                    }
                    else if (L <= 115)
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellSTR += 4;
                        else if (spellDropdown2.value == 1)
                            curItem.spellDEX += 4;
                        else if (spellDropdown2.value == 2)
                            curItem.spellLUK += 4;
                        else if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 200;
                        else if (spellDropdown2.value == 4)
                            curItem.spellINT += 4;
                        else if (spellDropdown2.value == 5)
                        {
                            curItem.spellSTR += 2;
                            curItem.spellDEX += 2;
                            curItem.spellINT += 2;
                            curItem.spellLUK += 2;
                        }
                    }
                    else
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellSTR += 5;
                        else if (spellDropdown2.value == 1)
                            curItem.spellDEX += 5;
                        else if (spellDropdown2.value == 2)
                            curItem.spellLUK += 5;
                        else if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 250;
                        else if (spellDropdown2.value == 4)
                            curItem.spellINT += 5;
                        else if (spellDropdown2.value == 5)
                        {
                            curItem.spellSTR += 3;
                            curItem.spellDEX += 3;
                            curItem.spellINT += 3;
                            curItem.spellLUK += 3;
                        }
                    }
                }
                else if (curItem.type == ItemType.Heart)
                {
                    if (L <= 30)
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellATK += 3;
                        else
                            curItem.spellMAG += 3;
                    }
                    else
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellATK += 5;
                        else
                            curItem.spellMAG += 5;
                    }
                }
                else
                {
                    GetSpellBonus();
                    if (L <= 70)
                    {
                        if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 180;
                        else if (spellDropdown2.value == 5)
                        {
                            curItem.spellSTR += 1;
                            curItem.spellDEX += 1;
                            curItem.spellLUK += 1;
                            curItem.spellMaxHP += 30;
                            curItem.spellINT += 1;
                        }
                        else
                        {
                            if (spellDropdown2.value == 0)
                                curItem.spellSTR += 3;
                            else if (spellDropdown2.value == 1)
                                curItem.spellDEX += 3;
                            else if (spellDropdown2.value == 2)
                                curItem.spellLUK += 3;
                            else if (spellDropdown2.value == 4)
                                curItem.spellINT += 3;
                            curItem.spellMaxHP += 30;
                        }

                    }
                    else if (L <= 115)
                    {
                        if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 320;
                        else if (spellDropdown2.value == 5)
                        {
                            curItem.spellSTR += 2;
                            curItem.spellDEX += 2;
                            curItem.spellLUK += 2;
                            curItem.spellMaxHP += 70;
                            curItem.spellINT += 2;
                        }
                        else
                        {
                            if (spellDropdown2.value == 0)
                                curItem.spellSTR += 5;
                            else if (spellDropdown2.value == 1)
                                curItem.spellDEX += 5;
                            else if (spellDropdown2.value == 2)
                                curItem.spellLUK += 5;
                            else if (spellDropdown2.value == 4)
                                curItem.spellINT += 5;
                            curItem.spellMaxHP += 70;
                        }
                    }
                    else
                    {
                        if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 470;
                        else if (spellDropdown2.value == 5)
                        {
                            curItem.spellSTR += 3;
                            curItem.spellDEX += 3;
                            curItem.spellLUK += 3;
                            curItem.spellMaxHP += 120;
                            curItem.spellINT += 3;
                        }
                        else
                        {
                            if (spellDropdown2.value == 0)
                                curItem.spellSTR += 7;
                            else if (spellDropdown2.value == 1)
                                curItem.spellDEX += 7;
                            else if (spellDropdown2.value == 2)
                                curItem.spellLUK += 7;
                            else if (spellDropdown2.value == 4)
                                curItem.spellINT += 7;
                            curItem.spellMaxHP += 120;
                        }
                    }
                }

                curItem.remainingUpgrade--;
                break;


            case 3: // 70��
                if (curItem.type == ItemType.Weapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis)
                {
                    if (L <= 70)
                    {
                        if (spellDropdown2.value <= 3)
                            curItem.spellATK += 2;
                        else
                            curItem.spellMAG += 2;
                    }
                    else if (L <= 110)
                    {
                        if (spellDropdown2.value <= 3)
                            curItem.spellATK += 3;
                        else
                            curItem.spellMAG += 3;

                        if (spellDropdown2.value == 0)
                            curItem.spellSTR += 1;
                        else if (spellDropdown2.value == 1)
                            curItem.spellDEX += 1;
                        else if (spellDropdown2.value == 2)
                            curItem.spellLUK += 1;
                        else if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 50;
                        else if (spellDropdown2.value == 4)
                            curItem.spellINT += 1;
                    }
                    else
                    {
                        if (spellDropdown2.value <= 3)
                            curItem.spellATK += 5;
                        else
                            curItem.spellMAG += 5;

                        if (spellDropdown2.value == 0)
                            curItem.spellSTR += 2;
                        else if (spellDropdown2.value == 1)
                            curItem.spellDEX += 2;
                        else if (spellDropdown2.value == 2)
                            curItem.spellLUK += 2;
                        else if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 100;
                        else if (spellDropdown2.value == 4)
                            curItem.spellINT += 2;
                    }
                }
                else if (curItem.type == ItemType.Gloves)
                {
                    if (L <= 70)
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellATK += 1;
                        else
                            curItem.spellMAG += 1;
                    }
                    else
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellATK += 2;
                        else
                            curItem.spellMAG += 2;
                    }
                }
                else if (itemInfo.CheckAccessory())
                {
                    if (L <= 115)
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellSTR += 2;
                        else if (spellDropdown2.value == 1)
                            curItem.spellDEX += 2;
                        else if (spellDropdown2.value == 2)
                            curItem.spellLUK += 2;
                        else if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 100;
                        else if (spellDropdown2.value == 4)
                            curItem.spellINT += 2;
                    }
                    else
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellSTR += 3;
                        else if (spellDropdown2.value == 1)
                            curItem.spellDEX += 3;
                        else if (spellDropdown2.value == 2)
                            curItem.spellLUK += 3;
                        else if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 150;
                        else if (spellDropdown2.value == 4)
                            curItem.spellINT += 3;
                    }
                }
                else if (curItem.type == ItemType.Heart)
                {
                    if (L <= 30)
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellATK += 2;
                        else
                            curItem.spellMAG += 2;
                    }
                    else
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellATK += 3;
                        else
                            curItem.spellMAG += 3;
                    }
                }
                else
                {
                    GetSpellBonus();
                    if (L <= 70)
                    {
                        if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 115;
                        else
                        {
                            if (spellDropdown2.value == 0)
                                curItem.spellSTR += 2;
                            else if (spellDropdown2.value == 1)
                                curItem.spellDEX += 2;
                            else if (spellDropdown2.value == 2)
                                curItem.spellLUK += 2;
                            else if (spellDropdown2.value == 4)
                                curItem.spellINT += 2;
                            curItem.spellMaxHP += 15;
                        }

                    }
                    else if (L <= 115)
                    {
                        if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 190;
                        else
                        {
                            if (spellDropdown2.value == 0)
                                curItem.spellSTR += 3;
                            else if (spellDropdown2.value == 1)
                                curItem.spellDEX += 3;
                            else if (spellDropdown2.value == 2)
                                curItem.spellLUK += 3;
                            else if (spellDropdown2.value == 4)
                                curItem.spellINT += 3;
                            curItem.spellMaxHP += 40;
                        }
                    }
                    else
                    {
                        if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 270;
                        else
                        {
                            if (spellDropdown2.value == 0)
                                curItem.spellSTR += 4;
                            else if (spellDropdown2.value == 1)
                                curItem.spellDEX += 4;
                            else if (spellDropdown2.value == 2)
                                curItem.spellLUK += 4;
                            else if (spellDropdown2.value == 4)
                                curItem.spellINT += 4;
                            curItem.spellMaxHP += 70;
                        }
                    }
                }

                curItem.remainingUpgrade--;
                break;


            case 4: // 100��
                if (curItem.type == ItemType.Weapon || curItem.type == ItemType.Blade || curItem.type == ItemType.Lapis)
                {
                    if (L <= 70)
                    {
                        if (spellDropdown2.value <= 3)
                            curItem.spellATK += 1;
                        else
                            curItem.spellMAG += 1;
                    }
                    else if (L <= 110)
                    {
                        if (spellDropdown2.value <= 3)
                            curItem.spellATK += 2;
                        else
                            curItem.spellMAG += 2;
                    }
                    else
                    {
                        if (spellDropdown2.value <= 3)
                            curItem.spellATK += 3;
                        else
                            curItem.spellMAG += 3;

                        if (spellDropdown2.value == 0)
                            curItem.spellSTR += 1;
                        else if (spellDropdown2.value == 1)
                            curItem.spellDEX += 1;
                        else if (spellDropdown2.value == 2)
                            curItem.spellLUK += 1;
                        else if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 50;
                        else if (spellDropdown2.value == 4)
                            curItem.spellINT += 1;
                    }
                }
                else if (curItem.type == ItemType.Gloves)
                {
                    if (L <= 70)
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellATK += 0;
                        else
                            curItem.spellMAG += 0;
                    }
                    else
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellATK += 1;
                        else
                            curItem.spellMAG += 1;
                    }
                }
                else if (itemInfo.CheckAccessory())
                {
                    if (L <= 115)
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellSTR += 1;
                        else if (spellDropdown2.value == 1)
                            curItem.spellDEX += 1;
                        else if (spellDropdown2.value == 2)
                            curItem.spellLUK += 1;
                        else if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 50;
                        else if (spellDropdown2.value == 4)
                            curItem.spellINT += 1;
                    }
                    else
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellSTR += 1;
                        else if (spellDropdown2.value == 1)
                            curItem.spellDEX += 1;
                        else if (spellDropdown2.value == 2)
                            curItem.spellLUK += 1;
                        else if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 100;
                        else if (spellDropdown2.value == 4)
                            curItem.spellINT += 1;
                    }
                }
                else if (curItem.type == ItemType.Heart)
                {
                    if (L <= 30)
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellATK += 1;
                        else
                            curItem.spellMAG += 1;
                    }
                    else
                    {
                        if (spellDropdown2.value == 0)
                            curItem.spellATK += 2;
                        else
                            curItem.spellMAG += 2;
                    }
                }
                else
                {
                    GetSpellBonus();
                    if (L <= 70)
                    {
                        if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 55;
                        else
                        {
                            if (spellDropdown2.value == 0)
                                curItem.spellSTR += 1;
                            else if (spellDropdown2.value == 1)
                                curItem.spellDEX += 1;
                            else if (spellDropdown2.value == 2)
                                curItem.spellLUK += 1;
                            else if (spellDropdown2.value == 4)
                                curItem.spellINT += 1;
                            curItem.spellMaxHP += 5;
                        }

                    }
                    else if (L <= 115)
                    {
                        if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 120;
                        else
                        {
                            if (spellDropdown2.value == 0)
                                curItem.spellSTR += 2;
                            else if (spellDropdown2.value == 1)
                                curItem.spellDEX += 2;
                            else if (spellDropdown2.value == 2)
                                curItem.spellLUK += 2;
                            else if (spellDropdown2.value == 4)
                                curItem.spellINT += 2;
                            curItem.spellMaxHP += 20;
                        }
                    }
                    else
                    {
                        if (spellDropdown2.value == 3)
                            curItem.spellMaxHP += 180;
                        else
                        {
                            if (spellDropdown2.value == 0)
                                curItem.spellSTR += 3;
                            else if (spellDropdown2.value == 1)
                                curItem.spellDEX += 3;
                            else if (spellDropdown2.value == 2)
                                curItem.spellLUK += 3;
                            else if (spellDropdown2.value == 4)
                                curItem.spellINT += 3;
                            curItem.spellMaxHP += 30;
                        }
                    }
                }

                curItem.remainingUpgrade--;
                break;


            case 5: // ȥ��
                if (curItem.Get3STR() > 0)
                {
                    if (chaosSpellDropdowns[0].value <= 6)
                        curItem.spellSTR += chaosSpellDropdowns[0].value;
                    else
                        curItem.spellSTR += 6 - chaosSpellDropdowns[0].value;

                    if (curItem.Get2STR() < 0)
                        curItem.spellSTR = -curItem.basicSTR;
                }

                if (curItem.Get3DEX() > 0)
                {
                    if (chaosSpellDropdowns[1].value <= 6)
                        curItem.spellDEX += chaosSpellDropdowns[1].value;
                    else
                        curItem.spellDEX += 6 - chaosSpellDropdowns[1].value;

                    if (curItem.Get2DEX() < 0)
                        curItem.spellDEX = -curItem.basicDEX;
                }

                if (curItem.Get3INT() > 0)
                {
                    if (chaosSpellDropdowns[2].value <= 6)
                        curItem.spellINT += chaosSpellDropdowns[2].value;
                    else
                        curItem.spellINT += 6 - chaosSpellDropdowns[2].value;

                    if (curItem.Get2INT() < 0)
                        curItem.spellINT = -curItem.basicINT;
                }

                if (curItem.Get3LUK() > 0)
                {
                    if (chaosSpellDropdowns[3].value <= 6)
                        curItem.spellLUK += chaosSpellDropdowns[3].value;
                    else
                        curItem.spellLUK += 6 - chaosSpellDropdowns[3].value;
                    if (curItem.Get2LUK() < 0)
                        curItem.spellLUK = -curItem.basicLUK;
                }

                if (curItem.Get3MaxHP() > 0)
                {
                    if (chaosSpellDropdowns[4].value <= 6)
                        curItem.spellMaxHP += 10 * chaosSpellDropdowns[4].value;
                    else
                        curItem.spellMaxHP += 60 - 10 * chaosSpellDropdowns[4].value;

                    if (curItem.Get2MaxHP() < 0)
                        curItem.spellMaxHP = -curItem.basicMaxHP;
                }

                if (curItem.Get3MaxMP() > 0)
                {
                    if (chaosSpellDropdowns[5].value <= 6)
                        curItem.spellMaxMP += 10 * chaosSpellDropdowns[5].value;
                    else
                        curItem.spellMaxMP += 60 - 10 * chaosSpellDropdowns[5].value;

                    if (curItem.Get2MaxMP() < 0)
                        curItem.spellMaxMP = -curItem.basicMaxMP;
                }

                if (curItem.Get3ATK() > 0)
                {
                    if (chaosSpellDropdowns[6].value <= 6)
                        curItem.spellATK += chaosSpellDropdowns[6].value;
                    else
                        curItem.spellATK += 6 - chaosSpellDropdowns[6].value;

                    if (curItem.Get2ATK() < 0)
                        curItem.spellATK = -curItem.basicATK;
                }

                if (curItem.Get3MAG() > 0)
                {
                    if (chaosSpellDropdowns[7].value <= 6)
                        curItem.spellMAG += chaosSpellDropdowns[7].value;
                    else
                        curItem.spellMAG += 6 - chaosSpellDropdowns[7].value;

                    if (curItem.Get2MAG() < 0)
                        curItem.spellMAG = -curItem.basicMAG;
                }

                curItem.remainingUpgrade--;
                break;



            case 6: // �Ǽ����� �ֹ���
                if (spellDropdown2.value == 0)
                    curItem.spellATK += 1;
                else if (spellDropdown2.value == 1)
                    curItem.spellATK += 2;
                else if (spellDropdown2.value == 2)
                    curItem.spellATK += 3;
                else if (spellDropdown2.value == 3)
                    curItem.spellATK += 4;
                else if (spellDropdown2.value == 4)
                    curItem.spellATK += 5;
                else if (spellDropdown2.value == 5)
                    curItem.spellMAG += 1;
                else if (spellDropdown2.value == 6)
                    curItem.spellMAG += 2;
                else if (spellDropdown2.value == 7)
                    curItem.spellMAG += 3;
                else if (spellDropdown2.value == 8)
                    curItem.spellMAG += 4;
                else if (spellDropdown2.value == 9)
                    curItem.spellMAG += 5;

                curItem.remainingUpgrade--;
                break;


            case 7: // �� �ֹ���
                if (spellDropdown2.value == 0)
                    curItem.spellATK += 1;
                else if (spellDropdown2.value == 1)
                    curItem.spellATK += 2;
                else if (spellDropdown2.value == 2)
                    curItem.spellATK += 3;
                else if (spellDropdown2.value == 3)
                    curItem.spellMAG += 1;
                else if (spellDropdown2.value == 4)
                    curItem.spellMAG += 2;
                else if (spellDropdown2.value == 5)
                    curItem.spellMAG += 3;

                curItem.remainingUpgrade--;
                break;


            case 8: // �̱׵����� �ູ
                if (curItem.isYggdrasil == true || curItem.isBasicGrowth == true)
                    break;

                if (spellDropdown2.value == 0)
                    curItem.spellSTR += spellDropdown3.value + 5;
                else if (spellDropdown2.value == 1)
                    curItem.spellDEX += spellDropdown3.value + 5;
                else if (spellDropdown2.value == 2)
                    curItem.spellINT += spellDropdown3.value + 5;
                else if (spellDropdown2.value == 3)
                    curItem.spellLUK += spellDropdown3.value + 5;

                curItem.isYggdrasil = true;
                spellDropdown1.value = 0;

                curItem.remainingUpgrade--;
                break;


            case 9: // ������
                curItem.spellMAG += 5;
                curItem.spellINT += 3;

                curItem.remainingUpgrade--;
                break;


            case 10: // �������� (����, ������)
                if (spellDropdown2.value == 0)
                    curItem.spellATK += 9;
                else if (spellDropdown2.value == 1)
                    curItem.spellATK += 10;
                else if (spellDropdown2.value == 2)
                    curItem.spellATK += 11;
                else if (spellDropdown2.value == 3)
                    curItem.spellMAG += 9;
                else if (spellDropdown2.value == 4)
                    curItem.spellMAG += 10;
                else if (spellDropdown2.value == 5)
                    curItem.spellMAG += 11;

                curItem.remainingUpgrade--;
                break;


            case 11: //  ��ũ�̳뼾Ʈ
                curItem.SetSpellToZero();
                break;



            case 12:    // ����, ������
                if ((curItem.name == "ȥ������ �����" || curItem.name == "ī���� ȥ������ �����") && curItem.remainingUpgrade == 3)
                {
                    curItem.spellSTR += 15;
                    curItem.spellDEX += 15;
                    curItem.spellINT += 15;
                    curItem.spellLUK += 15;
                    curItem.spellMaxHP += 750;

                    curItem.remainingUpgrade--;
                }
                else if (curItem.name == "���̳����� ���Ʈ")
                {
                    curItem.spellSTR += 3;
                    curItem.spellDEX += 3;
                    curItem.spellINT += 3;
                    curItem.spellLUK += 3;
                    curItem.spellMaxHP += 40;
                    curItem.spellMaxMP += 40;
                    curItem.spellATK += 3;
                    curItem.spellMAG += 3;

                    curItem.remainingUpgrade--;
                }
                else
                {
                    return;
                }
                break;

            case 13: // ���� ��Ʈ ���� �ֹ���
                if (spellDropdown2.value == 1)
                    curItem.setName = SetName.Rootabis_Warrior;
                else if (spellDropdown2.value == 2)
                    curItem.setName = SetName.Absolute_Warrior;
                else if (spellDropdown2.value == 3)
                    curItem.setName = SetName.Arcane_Warrior;
                else
                    return;

                break;

            default:
                return;
        }


        fileManager.SaveIs(itemSettingLogic.GetItemSettingData(), itemSettingLogic.GetCurPath());
        itemInfo.InfoUpdate();
        OnDropdown2Changed(spellDropdown2);
        if(spellDropdown1.value == 5)
            OnDropdown1Changed(spellDropdown1);
        UpdateUpgradeCountText();

        PopUpManager.Instance.GeneratePopUp("�ֹ����� ����Ǿ����ϴ�.");
    }
}
