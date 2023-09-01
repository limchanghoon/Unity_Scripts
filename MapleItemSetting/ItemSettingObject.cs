using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemSettingObject : MonoBehaviour
{
    ItemSettingData itemSettingData;
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
        itemSettingManager.SetSettingName(nameText.text, classText.text);
        itemSettingManager.TurnOnItemSetting(itemSettingData, path);
    }

    public void SetItemSettingData(ItemSettingData _itemSettingData, string _path)
    {
        itemSettingData = _itemSettingData;
        nameText.text = itemSettingData.settingName;
        classText.text = itemSettingData.charaacterClass.ToFriendlyString();

        path = _path;
    }
}
