using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExceptionalManager : MonoBehaviour
{
    public ItemInfo itemInfo;
    public ItemSettingLogic itemSettingLogic;
    public ISFileManager fileManager;
    public ItemSettingUI uiManager;

    public GameObject exceptionalPanel;
    public GameObject explanation1;
    public TextMeshProUGUI explanation2;

    public Image exceptionalPartsImage;
    public TextMeshProUGUI exceptionalPartsText;
    public Sprite[] exceptionalParts;


    public void UIReset()
    {
        var curItem = itemInfo.GetCurItem();
        int cnt = curItem.exceptionalOption.Count;

        if (curItem.name == "몽환의 벨트")
        {
            exceptionalPanel.SetActive(true);
            explanation1.SetActive(false);

            exceptionalPartsImage.sprite = exceptionalParts[0];
            itemSettingLogic.ResizeImage(exceptionalPartsImage.transform.GetComponent<RectTransform>(), exceptionalPartsImage.sprite, 200);
            exceptionalPartsText.text = "악몽의 조각";

            if (cnt != 0)
                explanation2.text = "이미 익셉셔널 강화를 완료했습니다.";
            else
                explanation2.text = "STR : +20\nDEX : +20\nINT : +20\nLUK : +20\n공격력 : +15\n마력 : +15\n최대 HP : +1000\n최대 MP : +1000";
        }
        else if (curItem.name == "루즈 컨트롤 머신 마크")
        {
            exceptionalPanel.SetActive(true);
            explanation1.SetActive(false);

            exceptionalPartsImage.sprite = exceptionalParts[1];
            itemSettingLogic.ResizeImage(exceptionalPartsImage.transform.GetComponent<RectTransform>(), exceptionalPartsImage.sprite, 200);
            exceptionalPartsText.text = "그라비티 모듈";

            if (cnt != 0)
                explanation2.text = "이미 익셉셔널 강화를 완료했습니다.";
            else
                explanation2.text = "STR : +15\nDEX : +15\nINT : +15\nLUK : +15\n공격력 : +10\n마력 : +10\n최대 HP : +750\n최대 MP : +750";
        }
        else if (curItem.name == "마력이 깃든 안대")
        {
            exceptionalPanel.SetActive(true);
            explanation1.SetActive(false);

            exceptionalPartsImage.sprite = exceptionalParts[2];
            itemSettingLogic.ResizeImage(exceptionalPartsImage.transform.GetComponent<RectTransform>(), exceptionalPartsImage.sprite, 200);
            exceptionalPartsText.text = "파멸의 징표";

            if (cnt != 0)
                explanation2.text = "이미 익셉셔널 강화를 완료했습니다.";
            else
                explanation2.text = "STR : +15\nDEX : +15\nINT : +15\nLUK : +15\n공격력 : +10\n마력 : +10\n최대 HP : +750\n최대 MP : +750";
        }
        else if (curItem.name == "커맨더 포스 이어링")
        {
            exceptionalPanel.SetActive(true);
            explanation1.SetActive(false);

            exceptionalPartsImage.sprite = exceptionalParts[3];
            itemSettingLogic.ResizeImage(exceptionalPartsImage.transform.GetComponent<RectTransform>(), exceptionalPartsImage.sprite, 200);
            exceptionalPartsText.text = "충정의 투구";

            if (cnt != 0)
                explanation2.text = "이미 익셉셔널 강화를 완료했습니다.";
            else
                explanation2.text = "STR : +20\nDEX : +20\nINT : +20\nLUK : +20\n공격력 : +15\n마력 : +15\n최대 HP : +1000\n최대 MP : +1000";
        }
        else
        {
            exceptionalPanel.SetActive(false);
            explanation1.SetActive(true);
        }
    }


    public void ApplyExceptional()
    {
        var curItem = itemInfo.GetCurItem();
        if (curItem.exceptionalOption.Count != 0)
            return;

        if (curItem.name == "몽환의 벨트" || curItem.name == "루즈 컨트롤 머신 마크" || curItem.name == "마력이 깃든 안대" || curItem.name == "커맨더 포스 이어링")
        {
            string[] optionsStrs = explanation2.text.Split('\n');
            foreach (var str in optionsStrs)
                curItem.exceptionalOption.Add(new Potential(str));


            fileManager.SaveIs(itemSettingLogic.GetItemSettingData(), itemSettingLogic.GetCurPath());

            itemInfo.InfoUpdate();

            UIReset();

            PopUpManager.Instance.GeneratePopUp("익셉셔널 강화가 적용되었습니다.");
        }
    }

    public void ResetExceptional()
    {
        var curItem = itemInfo.GetCurItem();
        if (curItem.exceptionalOption.Count == 0)
            return;
        else
        {
            curItem.exceptionalOption.Clear();

            fileManager.SaveIs(itemSettingLogic.GetItemSettingData(), itemSettingLogic.GetCurPath());

            itemInfo.InfoUpdate();

            UIReset();

            PopUpManager.Instance.GeneratePopUp("익셉셔널 강화가 초기화되었습니다.");
        }
    }
}
