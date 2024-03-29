using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemSettingUI : MonoBehaviour
{
    public ISFileManager fileManager;
    public ItemSettingLogic itemSettingLogic;

    public GameObject createCanvas;
    public GameObject itemSettingCanvas;
    public GameObject itemSelectCanvas;
    public GameObject typeSelectCanvas;
    public GameObject itemSelectInfoPanel;
    public GameObject trashCanPanel;
    public GameObject setOptionCanvas;

    public Transform itemListTr;

    public TextMeshProUGUI settingNameInSettingCanvas;
    public TextMeshProUGUI classNameInSettingCanvas;
    public TextMeshProUGUI settingName;
    public TMP_Dropdown classGroupDropdown;
    public TMP_Dropdown classDropdown;

    public TMP_Dropdown itemClassGroupDropdown;

    public Scrollbar itemSelectScrollbar;

    public Image[] itemImages;
    public Transform inventoryTr;

    public TextMeshProUGUI combatPowerText;
    public Toggle rebootToggle;
    public TMP_InputField level_text;
    public TMP_InputField[] plusStat_texts;
    public TMP_InputField criDamage_text;

    List<string> classOptionList = new List<string>();

    public void OnClassGroupValueChanged(TMP_Dropdown dropdown)
    {
        switch ((CharacterClassGroup)dropdown.value)
        {
            case CharacterClassGroup.Warrior:
                classOptionList.Clear();
                classOptionList.Add("직업을 선택하세요");
                classOptionList.Add("히어로");
                classOptionList.Add("팔라딘");
                classOptionList.Add("다크나이트");
                classOptionList.Add("소울마스터");
                classOptionList.Add("미하일");
                classOptionList.Add("블래스터");
                classOptionList.Add("데몬슬레이어");
                classOptionList.Add("데몬어벤져");
                classOptionList.Add("아란");
                classOptionList.Add("카이저");
                classOptionList.Add("아델");
                classOptionList.Add("제로");
                classDropdown.ClearOptions();
                classDropdown.AddOptions(classOptionList);
                break;

            case CharacterClassGroup.Magician:
                classOptionList.Clear();
                classOptionList.Add("직업을 선택하세요");
                classOptionList.Add("아크메이지(불,독)");
                classOptionList.Add("아크메이지(썬,콜)");
                classOptionList.Add("비숍");
                classOptionList.Add("플레임위자드");
                classOptionList.Add("배틀메이지");
                classOptionList.Add("에반");
                classOptionList.Add("루미너스");
                classOptionList.Add("일리움");
                classOptionList.Add("라라");
                classOptionList.Add("키네시스");
                classDropdown.ClearOptions();
                classDropdown.AddOptions(classOptionList);
                break;

            case CharacterClassGroup.Bowman:
                classOptionList.Clear();
                classOptionList.Add("직업을 선택하세요");
                classOptionList.Add("보우마스터");
                classOptionList.Add("신궁");
                classOptionList.Add("패스파인더");
                classOptionList.Add("윈드브레이커");
                classOptionList.Add("와일드헌터");
                classOptionList.Add("메르세데스");
                classOptionList.Add("카인");
                classDropdown.ClearOptions();
                classDropdown.AddOptions(classOptionList);
                break;

            case CharacterClassGroup.Thief:
                classOptionList.Clear();
                classOptionList.Add("직업을 선택하세요");
                classOptionList.Add("나이트로드");
                classOptionList.Add("섀도어");
                classOptionList.Add("듀얼블레이드");
                classOptionList.Add("나이트워커");
                classOptionList.Add("팬텀");
                classOptionList.Add("카데나");
                classOptionList.Add("칼리");
                classOptionList.Add("호영");
                classDropdown.ClearOptions();
                classDropdown.AddOptions(classOptionList);
                break;

            case CharacterClassGroup.Pirate:
                classOptionList.Clear();
                classOptionList.Add("직업을 선택하세요");
                classOptionList.Add("바이퍼");
                classOptionList.Add("캡틴");
                classOptionList.Add("캐논슈터");
                classOptionList.Add("스트라이커");
                classOptionList.Add("메카닉");
                classOptionList.Add("은월");
                classOptionList.Add("엔젤릭버스터");
                classOptionList.Add("아크");
                classDropdown.ClearOptions();
                classDropdown.AddOptions(classOptionList);
                break;

            case CharacterClassGroup.Hybrid:
                classOptionList.Clear();
                classOptionList.Add("직업을 선택하세요");
                classOptionList.Add("제논");
                classDropdown.ClearOptions();
                classDropdown.AddOptions(classOptionList);
                break;

            default:
                classOptionList.Clear();
                classOptionList.Add("직업을 선택하세요");
                classDropdown.ClearOptions();
                classDropdown.AddOptions(classOptionList);
                break;
        }
    }

    public void OnItemClassChanged(TMP_Dropdown dropdown)
    {
        itemSettingLogic.DisplayCertainItem((CharacterClassGroup)itemClassGroupDropdown.value, itemListTr);
        itemSelectScrollbar.value = 1;
    }

    public void OnNameFieldChanged(TMP_InputField inputField)
    {
        inputField.text = System.Text.RegularExpressions.Regex.Replace(inputField.text, @"[^0-9a-zA-Z가-힣ㄱ-ㅎㅏ-ㅣ]", "");
    }

    public void OnLevelFieldEndEdit(TMP_InputField inputField)
    {
        int _LEVEL = int.Parse(inputField.text);
        if (_LEVEL < 100)
            _LEVEL = 100;
        else if (_LEVEL > 300)
            _LEVEL = 300;

        inputField.text = _LEVEL.ToString();
    }

    public void SetSettingName(string _settingName, string _settingClass)
    {
        settingNameInSettingCanvas.text = _settingName;
        classNameInSettingCanvas.text = "직업 : " + _settingClass;
    }


    #region 버튼관련
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main");
    }

    public void TurnOnTrashCan()
    {
        if (!trashCanPanel.activeSelf)
        {
            BackStackManager.Instance.PushAndSetTrue(trashCanPanel);
        }
    }
    public void TurnOffTrashCan()
    {
        if (trashCanPanel.activeSelf)
        {
            BackStackManager.Instance.PopAndSetFalse();
        }
    }

    public void DeleteCurSetting()
    {
        if (trashCanPanel.activeSelf)
        {
            BackStackManager.Instance.PopAndSetFalse();
            //trashCanPanel.SetActive(false);

            BackStackManager.Instance.PopAndSetFalse();
            //itemSettingCanvas.SetActive(false);

            fileManager.DeleteCurFile(itemSettingLogic.GetCurPath());
        }
    }

    public void TurnOnSelectWindowWithType(int _type)
    {
        ItemType itemType = (ItemType)_type;
        itemClassGroupDropdown.value = 0;

        itemSettingLogic.SearchItems(itemType, itemListTr);

        itemSettingLogic.DisplayCertainItem((CharacterClassGroup)itemClassGroupDropdown.value, itemListTr);

        BackStackManager.Instance.PushAndSetTrue(itemSelectCanvas);
    }

    public void TurnOffSelectWindow()
    {
        itemSelectScrollbar.value = 1;
        if (itemSelectCanvas.activeSelf)
        {
            BackStackManager.Instance.PopAndSetFalse();
        }
    }

    public void TurnOnCreateWindow()
    {
        if (!createCanvas.activeSelf)
        {
            BackStackManager.Instance.PushAndSetTrue(createCanvas);
        }
    }

    public void TurnOffCreateWindow()
    {
        if (createCanvas.activeSelf)
        {
            BackStackManager.Instance.PopAndSetFalse();
        }
    }

    
    public void TurnOnItemSetting(ItemSettingData _itemSettingData, string _path)
    {
        if (!itemSettingCanvas.activeSelf)
        {
            BackStackManager.Instance.PushAndSetTrue(itemSettingCanvas);
        }
        itemSettingLogic.SetItems(_itemSettingData, itemImages, inventoryTr, _path);
    }

    public void TurnOffItemSetting()
    {
        if (itemSettingCanvas.activeSelf)
        {
            BackStackManager.Instance.PopAndSetFalse();
        }
    }

    public void TurnOnTypeSelect()
    {
        if (!typeSelectCanvas.activeSelf)
        {
            BackStackManager.Instance.PushAndSetTrue(typeSelectCanvas);
        }
    }


    public void TurnOffTypeSelect()
    {
        if (typeSelectCanvas.activeSelf)
        {
            BackStackManager.Instance.PopAndSetFalse();
        }
    }

    public void TurnOnInventoryItemInfo(int index)
    {
        if (index >= itemSettingLogic.GetItemSettingData().Inventory.Count)
            return;

        BackStackManager.Instance.PushAndSetTrue(itemSelectInfoPanel);

        var _type = itemSettingLogic.GetItemSettingData().Inventory[index].type;

        itemSelectInfoPanel.GetComponent<ItemInfo>().Init(_type, index, true, true);
    }


    public void TurnOffItemSelectInfo()
    {
        if (itemSelectInfoPanel.activeSelf)
        {
            BackStackManager.Instance.PopAndSetFalse();
        }
    }

    public void TurnOnSetOption()
    {
        if (!setOptionCanvas.activeSelf)
        {
            BackStackManager.Instance.PushAndSetTrue(setOptionCanvas);

            setOptionCanvas.GetComponent<SetOptionManager>().UIReset();
        }
    }

    public void TurnOffSetOption()
    {
        if (setOptionCanvas.activeSelf)
        {
            BackStackManager.Instance.PopAndSetFalse();
        }
    }

    public void ClickEquipmentWindowBtn(int idx)
    {
        if(itemSettingLogic.GetItemSettingData().items[idx].type == ItemType.NULL)
        {
            // 추가
            ItemType itemType = itemSettingLogic.TypeFromIndex(idx);
            itemClassGroupDropdown.value = 0;

            itemSettingLogic.SearchItems(itemType, itemListTr, idx);

            itemSettingLogic.DisplayCertainItem((CharacterClassGroup)itemClassGroupDropdown.value, itemListTr);

            BackStackManager.Instance.PushAndSetTrue(itemSelectCanvas);
        }
        else
        {
            // 장착중인 장비 정보
            BackStackManager.Instance.PushAndSetTrue(itemSelectInfoPanel);

            var _type = itemSettingLogic.GetItemSettingData().items[idx].type;

            itemSelectInfoPanel.GetComponent<ItemInfo>().Init(_type, idx, true, false);
        }
    }

    public void SetPlusStatTexts()
    {
        var myPlusStat = itemSettingLogic.GetItemSettingData().plusStat;
        rebootToggle.isOn = myPlusStat.isReboot;
        level_text.text = myPlusStat.Level.ToString();

        for (int i = 0; i < plusStat_texts.Length; ++i)
            plusStat_texts[i].text = myPlusStat.stats[i].ToString();

        criDamage_text.text = myPlusStat.criDamage.ToString();
    }

    public void SetPlusStats()
    {
        var myPlusStat = itemSettingLogic.GetItemSettingData().plusStat;
        myPlusStat.isReboot = rebootToggle.isOn;
        if (level_text.text == string.Empty)
            myPlusStat.Level = 260;
        else
            myPlusStat.Level = int.Parse(level_text.text);


        for (int i = 0; i < plusStat_texts.Length; ++i)
        {
            if (plusStat_texts[i].text == string.Empty)
                myPlusStat.stats[i] = 0;
            else
                myPlusStat.stats[i] = int.Parse(plusStat_texts[i].text);
        }

        if (criDamage_text.text == string.Empty)
            myPlusStat.criDamage = 0f;
        else
            myPlusStat.criDamage = float.Parse(criDamage_text.text);

        fileManager.SaveIs(itemSettingLogic.GetItemSettingData(), itemSettingLogic.GetCurPath());
        PopUpManager.Instance.GeneratePopUp("레벨 및 추가 스탯이 적용되었습니다.");
    }


    // 일단 제논, 데벤져, 제로(한번 확인 작업 필요함) 제외
    public void ShowCombatPower()
    {
        Debug.Log("전투력 체크!");
        combatPowerText.text = itemSettingLogic.GetCombatPower();
    }

    public void CreateNewItemSetting()
    {
        if(classGroupDropdown.value == 0 || classDropdown.value == 0)
        {
            PopUpManager.Instance.GeneratePopUp("직업을 제대로 고리시오");
            return;
        }

        if(settingName.text == string.Empty)
        {
            PopUpManager.Instance.GeneratePopUp("이름을 입력하시오");
            return;
        }

        ItemSettingData itemSettingData = new ItemSettingData(settingName.text
            , (CharacterClassGroup)classGroupDropdown.value, (CharacterClass)(1000 * classGroupDropdown.value + classDropdown.value));
        if(fileManager.CreateISToJson(itemSettingData))
            TurnOffCreateWindow();
    }
    #endregion
}
