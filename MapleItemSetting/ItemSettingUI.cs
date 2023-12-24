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
                classOptionList.Add("Á÷¾÷À» ¼±ÅÃÇÏ¼¼¿ä");
                classOptionList.Add("È÷¾î·Î");
                classOptionList.Add("ÆÈ¶óµò");
                classOptionList.Add("´ÙÅ©³ªÀÌÆ®");
                classOptionList.Add("¼Ò¿ï¸¶½ºÅÍ");
                classOptionList.Add("¹ÌÇÏÀÏ");
                classOptionList.Add("ºí·¡½ºÅÍ");
                classOptionList.Add("µ¥¸ó½½·¹ÀÌ¾î");
                classOptionList.Add("µ¥¸ó¾îº¥Á®");
                classOptionList.Add("¾Æ¶õ");
                classOptionList.Add("Ä«ÀÌÀú");
                classOptionList.Add("¾Æµ¨");
                classOptionList.Add("Á¦·Î");
                classDropdown.ClearOptions();
                classDropdown.AddOptions(classOptionList);
                break;

            case CharacterClassGroup.Magician:
                classOptionList.Clear();
                classOptionList.Add("Á÷¾÷À» ¼±ÅÃÇÏ¼¼¿ä");
                classOptionList.Add("¾ÆÅ©¸ÞÀÌÁö(ºÒ,µ¶)");
                classOptionList.Add("¾ÆÅ©¸ÞÀÌÁö(½ã,ÄÝ)");
                classOptionList.Add("ºñ¼ó");
                classOptionList.Add("ÇÃ·¹ÀÓÀ§ÀÚµå");
                classOptionList.Add("¹èÆ²¸ÞÀÌÁö");
                classOptionList.Add("¿¡¹Ý");
                classOptionList.Add("·ç¹Ì³Ê½º");
                classOptionList.Add("ÀÏ¸®¿ò");
                classOptionList.Add("¶ó¶ó");
                classOptionList.Add("Å°³×½Ã½º");
                classDropdown.ClearOptions();
                classDropdown.AddOptions(classOptionList);
                break;

            case CharacterClassGroup.Bowman:
                classOptionList.Clear();
                classOptionList.Add("Á÷¾÷À» ¼±ÅÃÇÏ¼¼¿ä");
                classOptionList.Add("º¸¿ì¸¶½ºÅÍ");
                classOptionList.Add("½Å±Ã");
                classOptionList.Add("ÆÐ½ºÆÄÀÎ´õ");
                classOptionList.Add("À©µåºê·¹ÀÌÄ¿");
                classOptionList.Add("¿ÍÀÏµåÇåÅÍ");
                classOptionList.Add("¸Þ¸£¼¼µ¥½º");
                classOptionList.Add("Ä«ÀÎ");
                classDropdown.ClearOptions();
                classDropdown.AddOptions(classOptionList);
                break;

            case CharacterClassGroup.Thief:
                classOptionList.Clear();
                classOptionList.Add("Á÷¾÷À» ¼±ÅÃÇÏ¼¼¿ä");
                classOptionList.Add("³ªÀÌÆ®·Îµå");
                classOptionList.Add("¼¨µµ¾î");
                classOptionList.Add("µà¾óºí·¹ÀÌµå");
                classOptionList.Add("³ªÀÌÆ®¿öÄ¿");
                classOptionList.Add("ÆÒÅÒ");
                classOptionList.Add("Ä«µ¥³ª");
                classOptionList.Add("Ä®¸®");
                classOptionList.Add("È£¿µ");
                classDropdown.ClearOptions();
                classDropdown.AddOptions(classOptionList);
                break;

            case CharacterClassGroup.Pirate:
                classOptionList.Clear();
                classOptionList.Add("Á÷¾÷À» ¼±ÅÃÇÏ¼¼¿ä");
                classOptionList.Add("¹ÙÀÌÆÛ");
                classOptionList.Add("Ä¸Æ¾");
                classOptionList.Add("Ä³³í½´ÅÍ");
                classOptionList.Add("½ºÆ®¶óÀÌÄ¿");
                classOptionList.Add("¸ÞÄ«´Ð");
                classOptionList.Add("Àº¿ù");
                classOptionList.Add("¿£Á©¸¯¹ö½ºÅÍ");
                classOptionList.Add("¾ÆÅ©");
                classDropdown.ClearOptions();
                classDropdown.AddOptions(classOptionList);
                break;

            case CharacterClassGroup.Hybrid:
                classOptionList.Clear();
                classOptionList.Add("Á÷¾÷À» ¼±ÅÃÇÏ¼¼¿ä");
                classOptionList.Add("Á¦³í");
                classDropdown.ClearOptions();
                classDropdown.AddOptions(classOptionList);
                break;

            default:
                classOptionList.Clear();
                classOptionList.Add("Á÷¾÷À» ¼±ÅÃÇÏ¼¼¿ä");
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
        inputField.text = System.Text.RegularExpressions.Regex.Replace(inputField.text, @"[^0-9a-zA-Z°¡-ÆR¤¡-¤¾¤¿-¤Ó]", "");
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
        classNameInSettingCanvas.text = "Á÷¾÷ : " + _settingClass;
    }


    #region ¹öÆ°°ü·Ã
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
            // Ãß°¡
            ItemType itemType = itemSettingLogic.TypeFromIndex(idx);
            itemClassGroupDropdown.value = 0;

            itemSettingLogic.SearchItems(itemType, itemListTr, idx);

            itemSettingLogic.DisplayCertainItem((CharacterClassGroup)itemClassGroupDropdown.value, itemListTr);

            BackStackManager.Instance.PushAndSetTrue(itemSelectCanvas);
        }
        else
        {
            // ÀåÂøÁßÀÎ Àåºñ Á¤º¸
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
        PopUpManager.Instance.GeneratePopUp("·¹º§ ¹× Ãß°¡ ½ºÅÈÀÌ Àû¿ëµÇ¾ú½À´Ï´Ù.");
    }


    // ÀÏ´Ü Á¦³í, µ¥º¥Á®, Á¦·Î(ÇÑ¹ø È®ÀÎ ÀÛ¾÷ ÇÊ¿äÇÔ) Á¦¿Ü
    public void ShowCombatPower()
    {
        Debug.Log("ÀüÅõ·Â Ã¼Å©!");
        combatPowerText.text = itemSettingLogic.GetCombatPower();
    }

    public void CreateNewItemSetting()
    {
        if(classGroupDropdown.value == 0 || classDropdown.value == 0)
        {
            PopUpManager.Instance.GeneratePopUp("Á÷¾÷À» Á¦´ë·Î °í¸®½Ã¿À");
            return;
        }

        if(settingName.text == string.Empty)
        {
            PopUpManager.Instance.GeneratePopUp("ÀÌ¸§À» ÀÔ·ÂÇÏ½Ã¿À");
            return;
        }

        ItemSettingData itemSettingData = new ItemSettingData(settingName.text
            , (CharacterClassGroup)classGroupDropdown.value, (CharacterClass)(1000 * classGroupDropdown.value + classDropdown.value));
        if(fileManager.CreateISToJson(itemSettingData))
            TurnOffCreateWindow();
    }
    #endregion
}
