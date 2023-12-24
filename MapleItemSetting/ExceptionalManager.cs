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

        if (curItem.name == "��ȯ�� ��Ʈ")
        {
            exceptionalPanel.SetActive(true);
            explanation1.SetActive(false);

            exceptionalPartsImage.sprite = exceptionalParts[0];
            itemSettingLogic.ResizeImage(exceptionalPartsImage.transform.GetComponent<RectTransform>(), exceptionalPartsImage.sprite, 200);
            exceptionalPartsText.text = "�Ǹ��� ����";

            if (cnt != 0)
                explanation2.text = "�̹� �ͼ��ų� ��ȭ�� �Ϸ��߽��ϴ�.";
            else
                explanation2.text = "STR : +20\nDEX : +20\nINT : +20\nLUK : +20\n���ݷ� : +15\n���� : +15\n�ִ� HP : +1000\n�ִ� MP : +1000";
        }
        else if (curItem.name == "���� ��Ʈ�� �ӽ� ��ũ")
        {
            exceptionalPanel.SetActive(true);
            explanation1.SetActive(false);

            exceptionalPartsImage.sprite = exceptionalParts[1];
            itemSettingLogic.ResizeImage(exceptionalPartsImage.transform.GetComponent<RectTransform>(), exceptionalPartsImage.sprite, 200);
            exceptionalPartsText.text = "�׶��Ƽ ���";

            if (cnt != 0)
                explanation2.text = "�̹� �ͼ��ų� ��ȭ�� �Ϸ��߽��ϴ�.";
            else
                explanation2.text = "STR : +15\nDEX : +15\nINT : +15\nLUK : +15\n���ݷ� : +10\n���� : +10\n�ִ� HP : +750\n�ִ� MP : +750";
        }
        else if (curItem.name == "������ ��� �ȴ�")
        {
            exceptionalPanel.SetActive(true);
            explanation1.SetActive(false);

            exceptionalPartsImage.sprite = exceptionalParts[2];
            itemSettingLogic.ResizeImage(exceptionalPartsImage.transform.GetComponent<RectTransform>(), exceptionalPartsImage.sprite, 200);
            exceptionalPartsText.text = "�ĸ��� ¡ǥ";

            if (cnt != 0)
                explanation2.text = "�̹� �ͼ��ų� ��ȭ�� �Ϸ��߽��ϴ�.";
            else
                explanation2.text = "STR : +15\nDEX : +15\nINT : +15\nLUK : +15\n���ݷ� : +10\n���� : +10\n�ִ� HP : +750\n�ִ� MP : +750";
        }
        else if (curItem.name == "Ŀ�Ǵ� ���� �̾")
        {
            exceptionalPanel.SetActive(true);
            explanation1.SetActive(false);

            exceptionalPartsImage.sprite = exceptionalParts[3];
            itemSettingLogic.ResizeImage(exceptionalPartsImage.transform.GetComponent<RectTransform>(), exceptionalPartsImage.sprite, 200);
            exceptionalPartsText.text = "������ ����";

            if (cnt != 0)
                explanation2.text = "�̹� �ͼ��ų� ��ȭ�� �Ϸ��߽��ϴ�.";
            else
                explanation2.text = "STR : +20\nDEX : +20\nINT : +20\nLUK : +20\n���ݷ� : +15\n���� : +15\n�ִ� HP : +1000\n�ִ� MP : +1000";
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

        if (curItem.name == "��ȯ�� ��Ʈ" || curItem.name == "���� ��Ʈ�� �ӽ� ��ũ" || curItem.name == "������ ��� �ȴ�" || curItem.name == "Ŀ�Ǵ� ���� �̾")
        {
            string[] optionsStrs = explanation2.text.Split('\n');
            foreach (var str in optionsStrs)
                curItem.exceptionalOption.Add(new Potential(str));


            fileManager.SaveIs(itemSettingLogic.GetItemSettingData(), itemSettingLogic.GetCurPath());

            itemInfo.InfoUpdate();

            UIReset();

            PopUpManager.Instance.GeneratePopUp("�ͼ��ų� ��ȭ�� ����Ǿ����ϴ�.");
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

            PopUpManager.Instance.GeneratePopUp("�ͼ��ų� ��ȭ�� �ʱ�ȭ�Ǿ����ϴ�.");
        }
    }
}
