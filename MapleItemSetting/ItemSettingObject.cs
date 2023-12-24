using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ItemSettingObject : MonoBehaviour
{

    TextMeshProUGUI nameText;
    TextMeshProUGUI classText;

    string path;


    private void Awake()
    {
        nameText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        classText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }


    public void ShowItemSetting()
    {
        var itemSettingManager = GameObject.Find("ItemSettingUIManager").GetComponent<ItemSettingUI>();
        var itemSettingFileManager = GameObject.Find("ItemSettingFileManager").GetComponent<ISFileManager>();
        itemSettingManager.SetSettingName(nameText.text, classText.text);
        itemSettingManager.TurnOnItemSetting(itemSettingFileManager.GetItemSettingData(path), path);
        itemSettingManager.SetPlusStatTexts();
        itemSettingManager.ShowCombatPower();
    }

    public void SetItemSettingData(string _path, ItemSettingData _itemSettingData)
    {
        path = _path;

        nameText.text = _itemSettingData.settingName;
        classText.text = _itemSettingData.charaacterClass.ToFriendlyString();
    }
}
