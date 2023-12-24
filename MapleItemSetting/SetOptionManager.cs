using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetOptionManager : MonoBehaviour
{
    public ItemSettingLogic itemSettingLogic;

    public GameObject[] setOptionPrefabs;

    public Transform setOptionContent_Tr;

    public ContentSizeFitter[] csfs;

    List<SetName> setNameList = new List<SetName>();
    List<SetOptionObject> snObjList = new List<SetOptionObject>();

    int curPage = 0;

    int[] luckyCheckOrder = { 9, 15, 7, 0, 1, 2, 3, 16 };

    public void SetOptionUpdate()
    {
        var _items = itemSettingLogic.GetItemSettingData().items;

        foreach (var SNObj in snObjList)
            Destroy(SNObj.gameObject);

        setNameList.Clear();
        snObjList.Clear();

        curPage = 0;

        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i].setName == SetName.NULL)
                continue;

            bool check = false;

            for (int j = 0; j < setNameList.Count; j++)
            {
                if (setNameList[j] == _items[i].setName)
                {
                    check = true;

                    snObjList[j].SetItem(_items[i]);

                    break;
                }
            }

            if (check == false)
            {
                SetOptionObject _setOptionObj = Instantiate(setOptionPrefabs[(int)_items[i].setName], setOptionContent_Tr).GetComponent<SetOptionObject>();
                _setOptionObj.SetItem(_items[i]);


                setNameList.Add(_items[i].setName);
                snObjList.Add(_setOptionObj);
            }
        }


        // 4Ä«¶Ò>½ºÄ®·¿ ÀÌ¾î¸µ>½ºÄ®·¿=Á¦³×½Ã½º ¹«±â>½ºÄ®·¿ ¸µ>½ºÄ®·¿ °ßÀå
        bool luckyCheck = false;

        for (int order = 0; order < luckyCheckOrder.Length; order++)
        {
            int N = luckyCheckOrder[order];
            if (_items[N].isLucky == true)
            {
                for (int i = 0; i < snObjList.Count; i++)
                {
                    if (snObjList[i].GetCountExcludingLuckyItem() < 3)
                        continue;
                    for (int j = 0; j < snObjList[i].itemTypes.Length; j++)
                    {
                        if (snObjList[i].itemTypes[j] == itemSettingLogic.TypeFromIndex(N) && snObjList[i].checkArray[j] == false)
                        {
                            snObjList[i].SetLuckyItem(j, _items[N].name);
                            luckyCheck = true;
                            break;
                        }
                    }
                }
                if (luckyCheck) break;
            }
        }
    }

    public void UIReset()
    {
        SetOptionUpdate();


        if (snObjList.Count > 0)
            snObjList[0].gameObject.SetActive(true);

        foreach (var _snObj in snObjList)
        {
            _snObj.SetText();
        }

        foreach (var csf in csfs)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)csf.transform);
        }
    }


    public void ShowNext()
    {
        if (snObjList.Count == 0)
            return;

        snObjList[curPage].gameObject.SetActive(false);
        curPage = curPage + 1 == snObjList.Count ? 0 : curPage + 1;
        snObjList[curPage].gameObject.SetActive(true);

        LayoutRebuilder.ForceRebuildLayoutImmediate(snObjList[curPage].GetComponent<RectTransform>());

    }

    public void ShowPre()
    {
        if (snObjList.Count == 0)
            return;

        snObjList[curPage].gameObject.SetActive(false);
        curPage = curPage - 1 == -1 ? snObjList.Count - 1 : curPage - 1;
        snObjList[curPage].gameObject.SetActive(true);

        LayoutRebuilder.ForceRebuildLayoutImmediate(snObjList[curPage].GetComponent<RectTransform>());

    }

    public List<SetOptionObject> GetsnObjList() { return snObjList; }
}
