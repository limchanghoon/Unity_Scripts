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
                classOptionList.Add("������ �����ϼ���");
                classOptionList.Add("�����");
                classOptionList.Add("�ȶ��");
                classOptionList.Add("��ũ����Ʈ");
                classOptionList.Add("�ҿ︶����");
                classOptionList.Add("������");
                classOptionList.Add("������");
                classOptionList.Add("���󽽷��̾�");
                classOptionList.Add("������");
                classOptionList.Add("�ƶ�");
                classOptionList.Add("ī����");
                classOptionList.Add("�Ƶ�");
                classOptionList.Add("����");
                classDropdown.ClearOptions();
                classDropdown.AddOptions(classOptionList);
                break;

            case CharacterClassGroup.Magician:
                classOptionList.Clear();
                classOptionList.Add("������ �����ϼ���");
                classOptionList.Add("��ũ������(��,��)");
                classOptionList.Add("��ũ������(��,��)");
                classOptionList.Add("���");
                classOptionList.Add("�÷������ڵ�");
                classOptionList.Add("��Ʋ������");
                classOptionList.Add("����");
                classOptionList.Add("��̳ʽ�");
                classOptionList.Add("�ϸ���");
                classOptionList.Add("���");
                classOptionList.Add("Ű�׽ý�");
                classDropdown.ClearOptions();
                classDropdown.AddOptions(classOptionList);
                break;

            case CharacterClassGroup.Bowman:
                classOptionList.Clear();
                classOptionList.Add("������ �����ϼ���");
                classOptionList.Add("���츶����");
                classOptionList.Add("�ű�");
                classOptionList.Add("�н����δ�");
                classOptionList.Add("����극��Ŀ");
                classOptionList.Add("���ϵ�����");
                classOptionList.Add("�޸�������");
                classOptionList.Add("ī��");
                classDropdown.ClearOptions();
                classDropdown.AddOptions(classOptionList);
                break;

            case CharacterClassGroup.Thief:
                classOptionList.Clear();
                classOptionList.Add("������ �����ϼ���");
                classOptionList.Add("����Ʈ�ε�");
                classOptionList.Add("������");
                classOptionList.Add("�����̵�");
                classOptionList.Add("����Ʈ��Ŀ");
                classOptionList.Add("����");
                classOptionList.Add("ī����");
                classOptionList.Add("Į��");
                classOptionList.Add("ȣ��");
                classDropdown.ClearOptions();
                classDropdown.AddOptions(classOptionList);
                break;

            case CharacterClassGroup.Pirate:
                classOptionList.Clear();
                classOptionList.Add("������ �����ϼ���");
                classOptionList.Add("������");
                classOptionList.Add("ĸƾ");
                classOptionList.Add("ĳ����");
                classOptionList.Add("��Ʈ����Ŀ");
                classOptionList.Add("��ī��");
                classOptionList.Add("����");
                classOptionList.Add("������������");
                classOptionList.Add("��ũ");
                classDropdown.ClearOptions();
                classDropdown.AddOptions(classOptionList);
                break;

            case CharacterClassGroup.Hybrid:
                classOptionList.Clear();
                classOptionList.Add("������ �����ϼ���");
                classOptionList.Add("����");
                classDropdown.ClearOptions();
                classDropdown.AddOptions(classOptionList);
                break;

            default:
                classOptionList.Clear();
                classOptionList.Add("������ �����ϼ���");
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
        classNameInSettingCanvas.text = "���� : " + _settingClass;
    }


    #region ��ư����
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
            // �߰�
            ItemType itemType = itemSettingLogic.TypeFromIndex(idx);
            itemClassGroupDropdown.value = 0;

            itemSettingLogic.SearchItems(itemType, itemListTr, idx);

            itemSettingLogic.DisplayCertainItem((CharacterClassGroup)itemClassGroupDropdown.value, itemListTr);

            itemSelectCanvas.SetActive(true);
            BackStackManager.Instance.Push(itemSelectCanvas);
        }
        else
        {
            // �������� ��� ����
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
            PopUpManager.Instance.GeneratePopUp("������ ����� ���ÿ�");
            return;
        }

        ItemSettingData itemSettingData = new ItemSettingData(settingName.text
            , (CharacterClassGroup)classGroupDropdown.value, (CharacterClass)(1000 * classGroupDropdown.value + classDropdown.value));
        fileManager.CreateISToJson(itemSettingData);
        TurnOffCreateWindow();
    }
    #endregion
}
