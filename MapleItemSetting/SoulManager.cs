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

        if (soulDropdown.value == 13 || soulDropdown.value == 14) // 무공, 에피네아
        {
            switch (soulOptionDropdown.value)
            {
                case 0:
                    curItem.soul = "기운찬 ";
                    break;
                case 1:
                    curItem.soul = "날렵한 ";
                    break;
                case 2:
                    curItem.soul = "총명한 ";
                    break;
                case 3:
                    curItem.soul = "놀라운 ";
                    break;
                case 4:
                    curItem.soul = "화려한 ";
                    break;
                case 5:
                    curItem.soul = "강인한 ";
                    break;
                case 6:
                    curItem.soul = "풍부한 ";
                    break;
            }
        }

        curItem.soul += soulDropdown.options[soulDropdown.value].text;
        curItem.soulOption = soulOptionDropdown.options[soulOptionDropdown.value].text;


        fileManager.SaveIs(itemSettingLogic.GetItemSettingData(), itemSettingLogic.GetCurPath());

        itemInfo.InfoUpdate();

        PopUpManager.Instance.GeneratePopUp("소울 웨폰이 적용되었습니다.");
    }

    public void OnDropdownChanged(TMP_Dropdown dropdown)
    {
        soulOptionDropdown.ClearOptions();

        if (dropdown.value < 13) // 위대한 소울
        {
            soulOptionDropdown.AddOptions(new List<string> { "공격력 : +3%", "마력 : +3%", "보스 몬스터 공격 시 데미지 : +7%", "몬스터 방어율 무시 : +7%", "크리티컬 확률 : +12%", "올스탯 : +5%", "최대 HP : +2000" });
        }
        else if (dropdown.value == 13) // 무공
        {
            soulOptionDropdown.AddOptions(new List<string> { "STR : +7", "DEX : +7", "INT : +7", "LUK : +7", "ALL : +5", "HP : +300", "MP : +300" });
        }
        else if (dropdown.value == 14) // 에피네아
        {
            soulOptionDropdown.AddOptions(new List<string> { "STR : +4", "DEX : +4", "INT : +4", "LUK : +4", "ALL : +2", "HP : +180", "MP : +180" });
        }
    }
}
