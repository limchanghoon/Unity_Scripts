using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetOptionObject : MonoBehaviour
{
    public string setName;
    public string[] itemNames;
    public ItemType[] itemTypes;
    public bool[] choose1Array;
    public bool[] checkArray;

    int luckyIndex = -1;
    string luckyItemName = "NULL";

    public TextMeshProUGUI setNameText;
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemTypeText;

    public TextMeshProUGUI[] optionTexts;
    public int[] setCounts;

    public int GetCountExcludingLuckyItem()
    {
        int count = 0;
        for(int i = 0;i < checkArray.Length; i++)
        {
            if (checkArray[i] == true)
                count++;
        }
        return count;
    }

    public void SetItem(Item _item)
    {
        for(int i =0; i < itemNames.Length; i++)
        {
            if(itemNames[i] == _item.name || (choose1Array[i] && itemTypes[i] == _item.type))
            {
                checkArray[i] = true;
                break;
            }
        }
    }

    public void SetLuckyItem(int _luckyIndex, string _luckyItemName)
    {
        luckyIndex = _luckyIndex;
        luckyItemName = _luckyItemName;
    }

    public void SetText()
    {
        int count = 0;

        setNameText.text = setName + "\n\n";

        itemNameText.text = "";
        itemTypeText.text = "";
        for (int i = 0; i < itemNames.Length; i++)
        {
            if (checkArray[i])
            {
                itemNameText.text += "<color=#FFFFFF>" + itemNames[i] + "</color>\n";
                itemTypeText.text += "<color=#FFFFFF>(" + itemTypes[i].ToFriendlyString() + ")</color>\n";
                count++;
            }
            else if(luckyIndex == i)
            {
                itemNameText.text += "<color=#FFB200>" + luckyItemName + "</color>\n";
                itemTypeText.text += "<color=#FFB200>(" + itemTypes[i].ToFriendlyString() + ")</color>\n";
                count++;
            }
            else
            {
                itemNameText.text += "<color=#787878>" + itemNames[i] + "</color>\n";
                itemTypeText.text += "<color=#787878>(" + itemTypes[i].ToFriendlyString() + ")</color>\n";
            }
        }
        itemNameText.text += "----------------------------------------";

        for(int i = 0; i < optionTexts.Length; i++)
        {
            if (setCounts[i] <= count)
                optionTexts[i].color = Color.white;
            else
                break;
        }
    }
}
