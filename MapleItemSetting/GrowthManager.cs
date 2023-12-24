using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrowthManager : MonoBehaviour
{
    public ItemInfo itemInfo;
    public ItemSettingLogic itemSettingLogic;
    public ISFileManager fileManager;
    public ItemSettingUI uiManager;

    public GameObject explanation1;
    public GameObject explanation2;
    public GameObject growthPanel;

    public TMP_Dropdown[] option_Dropdowns;
    private void ResetPanel()
    {
        growthPanel.SetActive(true);
        explanation2.SetActive(false);
        foreach (var drop in option_Dropdowns)
            drop.ClearOptions();
    }

    public void UIReset()
    {
        var curItem = itemInfo.GetCurItem();

        if(curItem.isBasicGrowth == true)
        {
            explanation1.SetActive(false);

            switch (curItem.name)
            {
                case "피어리스 펜던트":
                    ResetPanel();
                    option_Dropdowns[0].AddOptions(new List<string> { "+0", "+1", "+2", "+3", "+4", "+5", "+6", "+7", "+8", "+9", "+10", "+11", "+12", "+13", "+14", "+15", "+16", "+17", "+18", "+19", "+20" });
                    option_Dropdowns[1].AddOptions(new List<string> { "+0", "+1", "+2", "+3", "+4", "+5", "+6", "+7", "+8", "+9", "+10", "+11", "+12", "+13", "+14", "+15", "+16", "+17", "+18", "+19", "+20" });
                    option_Dropdowns[2].AddOptions(new List<string> { "+0", "+1", "+2", "+3", "+4", "+5", "+6", "+7", "+8", "+9", "+10", "+11", "+12", "+13", "+14", "+15", "+16", "+17", "+18", "+19", "+20" });
                    option_Dropdowns[3].AddOptions(new List<string> { "+0", "+1", "+2", "+3", "+4", "+5", "+6", "+7", "+8", "+9", "+10", "+11", "+12", "+13", "+14", "+15", "+16", "+17", "+18", "+19", "+20" });

                    option_Dropdowns[0].value = curItem.growthSTR;
                    option_Dropdowns[1].value = curItem.growthDEX;
                    option_Dropdowns[2].value = curItem.growthINT;
                    option_Dropdowns[3].value = curItem.growthLUK;
                    break;

                case "타임리스 프렐류드":
                    ResetPanel();
                    option_Dropdowns[2].AddOptions(new List<string> { "+0", "+1", "+2", "+3", "+4", "+5" });
                    option_Dropdowns[3].AddOptions(new List<string> { "+0", "+1", "+2", "+3", "+4", "+5" });

                    option_Dropdowns[2].value = curItem.growthINT;
                    option_Dropdowns[3].value = curItem.growthLUK;
                    break;

                case "피어리스 프렐류드":
                    ResetPanel();
                    option_Dropdowns[2].AddOptions(new List<string> { "+0", "+1", "+2", "+3", "+4", "+5", "+6", "+7", "+8", "+9", "+10", "+11", "+12", "+13", "+14", "+15", "+16", "+17", "+18", "+19", "+20" });
                    option_Dropdowns[3].AddOptions(new List<string> { "+0", "+1", "+2", "+3", "+4", "+5", "+6", "+7", "+8", "+9", "+10", "+11", "+12", "+13", "+14", "+15", "+16", "+17", "+18", "+19", "+20" });

                    option_Dropdowns[2].value = curItem.growthINT;
                    option_Dropdowns[3].value = curItem.growthLUK;
                    break;

                case "타임리스 리스트":
                    ResetPanel();
                    option_Dropdowns[1].AddOptions(new List<string> { "+0", "+1", "+2", "+3", "+4", "+5" });
                    option_Dropdowns[3].AddOptions(new List<string> { "+0", "+1", "+2", "+3", "+4", "+5" });

                    option_Dropdowns[1].value = curItem.growthDEX;
                    option_Dropdowns[3].value = curItem.growthLUK;
                    break;

                case "피어리스 리스트":
                    ResetPanel();
                    option_Dropdowns[1].AddOptions(new List<string> { "+0", "+1", "+2", "+3", "+4", "+5", "+6", "+7", "+8", "+9", "+10", "+11", "+12", "+13", "+14", "+15", "+16", "+17", "+18", "+19", "+20" });
                    option_Dropdowns[3].AddOptions(new List<string> { "+0", "+1", "+2", "+3", "+4", "+5", "+6", "+7", "+8", "+9", "+10", "+11", "+12", "+13", "+14", "+15", "+16", "+17", "+18", "+19", "+20" });

                    option_Dropdowns[1].value = curItem.growthDEX;
                    option_Dropdowns[3].value = curItem.growthLUK;
                    break;

                default:
                    growthPanel.SetActive(false);
                    explanation2.SetActive(true);
                    break;
            }
        }
        else
        {
            growthPanel.SetActive(false);
            explanation1.SetActive(true);
            explanation2.SetActive(false);
            return;
        }

    }

    public void ApplyGrowth()
    {
        var curItem = itemInfo.GetCurItem();

        curItem.spellSTR -= curItem.growthSTR;
        curItem.spellDEX -= curItem.growthDEX;
        curItem.spellINT -= curItem.growthINT;
        curItem.spellLUK -= curItem.growthLUK;

        switch (curItem.name)
        {
            case "피어리스 펜던트":
                curItem.growthSTR = option_Dropdowns[0].value;
                curItem.growthDEX = option_Dropdowns[1].value;
                curItem.growthINT = option_Dropdowns[2].value;
                curItem.growthLUK = option_Dropdowns[3].value;

                PopUpManager.Instance.GeneratePopUp("아이템 성장이 적용되었습니다.");
                break;

            case "타임리스 프렐류드":
                curItem.growthINT = option_Dropdowns[2].value;
                curItem.growthLUK = option_Dropdowns[3].value;

                PopUpManager.Instance.GeneratePopUp("아이템 성장이 적용되었습니다.");
                break;

            case "피어리스 프렐류드":
                curItem.growthINT = option_Dropdowns[2].value;
                curItem.growthLUK = option_Dropdowns[3].value;

                PopUpManager.Instance.GeneratePopUp("아이템 성장이 적용되었습니다.");
                break;

            case "타임리스 리스트":
                curItem.growthDEX = option_Dropdowns[1].value;
                curItem.growthLUK = option_Dropdowns[3].value;

                PopUpManager.Instance.GeneratePopUp("아이템 성장이 적용되었습니다.");
                break;

            case "피어리스 리스트":
                curItem.growthDEX = option_Dropdowns[1].value;
                curItem.growthLUK = option_Dropdowns[3].value;

                PopUpManager.Instance.GeneratePopUp("아이템 성장이 적용되었습니다.");
                break;

            default:
                break;
        }

        curItem.spellSTR += curItem.growthSTR;
        curItem.spellDEX += curItem.growthDEX;
        curItem.spellINT += curItem.growthINT;
        curItem.spellLUK += curItem.growthLUK;

        fileManager.SaveIs(itemSettingLogic.GetItemSettingData(), itemSettingLogic.GetCurPath());

        itemInfo.InfoUpdate();
    }
}
