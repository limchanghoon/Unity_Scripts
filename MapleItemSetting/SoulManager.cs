using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoulManager : MonoBehaviour
{
    public ItemInfo itemInfo;
    public ItemSettingLogic itemSettingLogic;
    public ISFileManager fileManager;
    public ItemSettingUI uiManager;

    public GameObject soulPanel;

    public TMP_Dropdown soulDropdown;
    public TMP_Dropdown soulOptionDropdown;

    public void UIReset()
    {
        var curItem = itemInfo.GetCurItem();

        if (curItem.type == ItemType.Weapon || curItem.type == ItemType.Lapis)
        {
            soulPanel.SetActive(true);
        }
        else
        {
            soulPanel.SetActive(false);
        }

        if (curItem.soul != "")
        {
            for (int i = 0; i < soulDropdown.options.Count; i++)
            {
                if (curItem.soul == soulDropdown.options[i].text)
                {
                    soulDropdown.value = i;
                    break;
                }
            }
        }

        if (curItem.soulOption != "")
        {
            for (int i = 0; i < soulOptionDropdown.options.Count; i++)
            {
                if (curItem.soulOption == soulOptionDropdown.options[i].text)
                {
                    soulOptionDropdown.value = i;
                    break;
                }
            }
        }

    }


    public void ApplySoul()
    {
        var curItem = itemInfo.GetCurItem();

        if (curItem.type != ItemType.Weapon && curItem.type != ItemType.Lapis)
            return;

        curItem.soul = "";

        if (soulDropdown.value == 13 || soulDropdown.value == 14) // ����, ���ǳ׾�
        {
            switch (soulOptionDropdown.value)
            {
                case 0:
                    curItem.soul = "����� ";
                    break;
                case 1:
                    curItem.soul = "������ ";
                    break;
                case 2:
                    curItem.soul = "�Ѹ��� ";
                    break;
                case 3:
                    curItem.soul = "���� ";
                    break;
                case 4:
                    curItem.soul = "ȭ���� ";
                    break;
                case 5:
                    curItem.soul = "������ ";
                    break;
                case 6:
                    curItem.soul = "ǳ���� ";
                    break;
            }
        }

        curItem.soul += soulDropdown.options[soulDropdown.value].text;
        curItem.soulOption = soulOptionDropdown.options[soulOptionDropdown.value].text;


        fileManager.SaveIs(itemSettingLogic.GetItemSettingData(), itemSettingLogic.GetCurPath());

        itemInfo.InfoUpdate();

        PopUpManager.Instance.GeneratePopUp("�ҿ� ������ ����Ǿ����ϴ�.");
    }

    public void OnDropdownChanged(TMP_Dropdown dropdown)
    {
        soulOptionDropdown.ClearOptions();

        if (dropdown.value < 13) // ������ �ҿ�
        {
            soulOptionDropdown.AddOptions(new List<string> { "���ݷ� : +3%", "���� : +3%", "���� ���� ���� �� ������ : +7%", "���� ����� ���� : +7%", "ũ��Ƽ�� Ȯ�� : +12%", "�ý��� : +5%", "�ִ� HP : +2000" });
        }
        else if (dropdown.value == 13) // ����
        {
            soulOptionDropdown.AddOptions(new List<string> { "STR : +7", "DEX : +7", "INT : +7", "LUK : +7", "ALL : +5", "HP : +300", "MP : +300" });
        }
        else if (dropdown.value == 14) // ���ǳ׾�
        {
            soulOptionDropdown.AddOptions(new List<string> { "STR : +4", "DEX : +4", "INT : +4", "LUK : +4", "ALL : +2", "HP : +180", "MP : +180" });
        }
    }
}
