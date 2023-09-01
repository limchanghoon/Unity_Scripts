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
            trashCanPanel.SetActive(true);
            BackStackManager.Instance.Push(trashCanPanel);
        }
    }
    public void TurnOffTrashCan()
    {
        if (trashCanPanel.activeSelf)
        {
            BackStackManager.Instance.Pop();
            trashCanPanel.SetActive(false);
        }
    }

    public void DeleteCurSetting()
    {
        if (trashCanPanel.activeSelf)
        {
            BackStackManager.Instance.Pop();
            trashCanPanel.SetActive(false);

            BackStackManager.Instance.Pop();
            itemSettingCanvas.SetActive(false);

            fileManager.DeleteCurFile(itemSettingLogic.GetCurPath());
        }
    }

    public void TurnOnSelectWindowWithType(int _type)
    {
        ItemType itemType = (ItemType)_type;
        itemClassGroupDropdown.value = 0;

        itemSettingLogic.SearchItems(itemType, itemListTr);

        itemSettingLogic.DisplayCertainItem((CharacterClassGroup)itemClassGroupDropdown.value, itemListTr);

        itemSelectCanvas.SetActive(true);
        BackStackManager.Instance.Push(itemSelectCanvas);
    }

    public void TurnOffSelectWindow()
    {
        itemSelectScrollbar.value = 1;
        if (itemSelectCanvas.activeSelf)
        {
            BackStackManager.Instance.Pop();
            itemSelectCanvas.SetActive(false);
        }
    }

    public void TurnOnCreateWindow()
    {
        if (!createCanvas.activeSelf)
        {
            createCanvas.SetActive(true);
            BackStackManager.Instance.Push(createCanvas);
        }
    }

    public void TurnOffCreateWindow()
    {
        if (createCanvas.activeSelf)
        {
            BackStackManager.Instance.Pop();
            createCanvas.SetActive(false);
        }
    }

    public void TurnOnItemSetting()
    {
        if (!itemSettingCanvas.activeSelf)
        {
            itemSettingCanvas.SetActive(true);
            BackStackManager.Instance.Push(itemSettingCanvas);
        }
    }   
    
    public void TurnOnItemSetting(ItemSettingData _itemSettingData, string _path)
    {
        Debug.Log(_itemSettingData.settingName);
        if (!itemSettingCanvas.activeSelf)
        {
            itemSettingCanvas.SetActive(true);
            BackStackManager.Instance.Push(itemSettingCanvas);
        }
        itemSettingLogic.SetItems(_itemSettingData, itemImages, inventoryTr, _path);
    }

    public void TurnOffItemSetting()
    {
        if (itemSettingCanvas.activeSelf)
        {
            BackStackManager.Instance.Pop();
            itemSettingCanvas.SetActive(false);
        }
    }

    public void TurnOnTypeSelect()
    {
        if (!typeSelectCanvas.activeSelf)
        {
            typeSelectCanvas.SetActive(true);
            BackStackManager.Instance.Push(typeSelectCanvas);
        }
    }


    public void TurnOffTypeSelect()
    {
        if (typeSelectCanvas.activeSelf)
        {
            BackStackManager.Instance.Pop();
            typeSelectCanvas.SetActive(false);
        }
    }

    public void TurnOnInventoryItemInfo(int index)
    {
        if (index >= itemSettingLogic.GetItemSettingData().Inventory.Count)
            return;

        itemSelectInfoPanel.SetActive(true);
        BackStackManager.Instance.Push(itemSelectInfoPanel);

        var _type = itemSettingLogic.GetItemSettingData().Inventory[index].type;

        itemSelectInfoPanel.GetComponent<ItemInfo>().Init(_type, index, true, true);
    }


    public void TurnOffItemSelectInfo()
    {
        if (itemSelectInfoPanel.activeSelf)
        {
            BackStackManager.Instance.Pop();
            itemSelectInfoPanel.SetActive(false);
        }
    }

    public void TurnOnSetOption()
    {
        if (!setOptionCanvas.activeSelf)
        {
            setOptionCanvas.SetActive(true);
            BackStackManager.Instance.Push(setOptionCanvas);

            setOptionCanvas.GetComponent<SetOptionManager>().UIReset();
        }
    }

    public void TurnOffSetOption()
    {
        if (setOptionCanvas.activeSelf)
        {
            BackStackManager.Instance.Pop();
            setOptionCanvas.SetActive(false);
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

            itemSelectCanvas.SetActive(true);
            BackStackManager.Instance.Push(itemSelectCanvas);
        }
        else
        {
            // 장착중인 장비 정보
            itemSelectInfoPanel.SetActive(true);
            BackStackManager.Instance.Push(itemSelectInfoPanel);

            var _type = itemSettingLogic.GetItemSettingData().items[idx].type;

            itemSelectInfoPanel.GetComponent<ItemInfo>().Init(_type, idx, true, false);
        }
    }



    public void CreateNewItemSetting()
    {
        if(classGroupDropdown.value == 0 || classDropdown.value == 0)
        {
            PopUpManager.Instance.GeneratePopUp("직업을 제대로 고리시오");
            return;
        }

        ItemSettingData itemSettingData = new ItemSettingData(settingName.text
            , (CharacterClassGroup)classGroupDropdown.value, (CharacterClass)(1000 * classGroupDropdown.value + classDropdown.value));
        fileManager.CreateISToJson(itemSettingData);
        TurnOffCreateWindow();
    }
    #endregion
}
