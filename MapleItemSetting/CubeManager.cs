using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CubeManager : MonoBehaviour
{
    public ItemInfo itemInfo;
    public ItemSettingLogic itemSettingLogic;
    public ISFileManager fileManager;
    public ItemSettingUI uiManager;


    public TMP_Dropdown[] upP_Dropdowns;

    public TMP_Dropdown[] downP_Dropdowns;

    List<string> grades = new List<string> { "잠재옵션 없음", "레어", "에픽", "유니크", "레전더리" };

    public void Init()
    {


        var curItem = itemInfo.GetCurItem();
        if (curItem.upPotentialPossible)
        {
            upP_Dropdowns[0].ClearOptions();
            upP_Dropdowns[0].AddOptions(grades);
            upP_Dropdowns[0].value = (int)curItem.upPotentialGrade;
            U_GradeChanged(upP_Dropdowns[0]);
        }
        else
        {
            upP_Dropdowns[0].ClearOptions();
            upP_Dropdowns[1].ClearOptions();
            upP_Dropdowns[2].ClearOptions();
            upP_Dropdowns[3].ClearOptions();
        }

        if (curItem.downPotentialPossible)
        {
            downP_Dropdowns[0].ClearOptions();
            downP_Dropdowns[0].AddOptions(grades);
            downP_Dropdowns[0].value = (int)curItem.downPotentialGrade;
            D_GradeChanged(downP_Dropdowns[0]);
        }
        else
        {
            downP_Dropdowns[0].ClearOptions();
            downP_Dropdowns[1].ClearOptions();
            downP_Dropdowns[2].ClearOptions();
            downP_Dropdowns[3].ClearOptions();
        }
    }

    public void U_GradeChanged(TMP_Dropdown dropdown)
    {
        var curItem = itemInfo.GetCurItem();
        ItemType curItemType = curItem.type;
        int Level = curItem.reqLev;

        upP_Dropdowns[1].ClearOptions();
        upP_Dropdowns[2].ClearOptions();
        upP_Dropdowns[3].ClearOptions();

        upP_Dropdowns[1].AddOptions(fileManager.GetUpPotentialList((OptionGrade)dropdown.value, curItemType, Level, 0));
        upP_Dropdowns[2].AddOptions(fileManager.GetUpPotentialList((OptionGrade)dropdown.value, curItemType, Level, 1));
        upP_Dropdowns[3].AddOptions(fileManager.GetUpPotentialList((OptionGrade)dropdown.value, curItemType, Level, 1));

        if (curItem.upPotentialGrade == (OptionGrade)dropdown.value)
        {
            upP_Dropdowns[1].value = curItem.upPotentialN1;
            upP_Dropdowns[2].value = curItem.upPotentialN2;
            upP_Dropdowns[3].value = curItem.upPotentialN3;
        }
    }

    public void D_GradeChanged(TMP_Dropdown dropdown)
    {
        var curItem = itemInfo.GetCurItem();
        ItemType curItemType = curItem.type;
        int Level = curItem.reqLev;

        downP_Dropdowns[1].ClearOptions();
        downP_Dropdowns[2].ClearOptions();
        downP_Dropdowns[3].ClearOptions();

        downP_Dropdowns[1].AddOptions(fileManager.GetDownPotentialList((OptionGrade)dropdown.value, curItemType, Level, 0));
        downP_Dropdowns[2].AddOptions(fileManager.GetDownPotentialList((OptionGrade)dropdown.value, curItemType, Level, 1));
        downP_Dropdowns[3].AddOptions(fileManager.GetDownPotentialList((OptionGrade)dropdown.value, curItemType, Level, 1));

        if (curItem.downPotentialGrade == (OptionGrade)dropdown.value)
        {
            downP_Dropdowns[1].value = curItem.downPotentialN1;
            downP_Dropdowns[2].value = curItem.downPotentialN2;
            downP_Dropdowns[3].value = curItem.downPotentialN3;
        }
    }

    public void CubePotentialApply()
    {
        var curItem = itemInfo.GetCurItem();
        if (curItem.upPotentialPossible)
        {
            if ((OptionGrade)upP_Dropdowns[0].value == OptionGrade.None)
            {
                curItem.upPotentialGrade = OptionGrade.None;
                curItem.upPotential1 = "";
                curItem.upPotential2 = "";
                curItem.upPotential3 = "";

                curItem.upPotentialN1 = 0;
                curItem.upPotentialN2 = 0;
                curItem.upPotentialN3 = 0;
            }
            else
            {
                curItem.upPotentialGrade = (OptionGrade)upP_Dropdowns[0].value;
                curItem.upPotential1 = upP_Dropdowns[1].options[upP_Dropdowns[1].value].text;
                curItem.upPotential2 = upP_Dropdowns[2].options[upP_Dropdowns[2].value].text;
                curItem.upPotential3 = upP_Dropdowns[3].options[upP_Dropdowns[3].value].text;

                curItem.upPotentialN1 = upP_Dropdowns[1].value;
                curItem.upPotentialN2 = upP_Dropdowns[2].value;
                curItem.upPotentialN3 = upP_Dropdowns[3].value;
            }
        }

        if (curItem.downPotentialPossible)
        {
            if ((OptionGrade)downP_Dropdowns[0].value == OptionGrade.None)
            {
                curItem.downPotentialGrade = OptionGrade.None;
                curItem.downPotential1 = "";
                curItem.downPotential2 = "";
                curItem.downPotential3 = "";

                curItem.downPotentialN1 = 0;
                curItem.downPotentialN2 = 0;
                curItem.downPotentialN3 = 0;
            }
            else
            {
                curItem.downPotentialGrade = (OptionGrade)downP_Dropdowns[0].value;
                curItem.downPotential1 = downP_Dropdowns[1].options[downP_Dropdowns[1].value].text;
                curItem.downPotential2 = downP_Dropdowns[2].options[downP_Dropdowns[2].value].text;
                curItem.downPotential3 = downP_Dropdowns[3].options[downP_Dropdowns[3].value].text;

                curItem.downPotentialN1 = downP_Dropdowns[1].value;
                curItem.downPotentialN2 = downP_Dropdowns[2].value;
                curItem.downPotentialN3 = downP_Dropdowns[3].value;
            }
        }

        if(curItem.upPotentialPossible || curItem.downPotentialPossible)
        {
            fileManager.SaveIs(itemSettingLogic.GetItemSettingData(), itemSettingLogic.GetCurPath());

            itemInfo.InfoUpdate();

            uiManager.TurnOnItemSetting(itemSettingLogic.GetItemSettingData(), itemSettingLogic.GetCurPath());

            PopUpManager.Instance.GeneratePopUp("큐브 옵션이 적용되었습니다.");
        }
    }
}
