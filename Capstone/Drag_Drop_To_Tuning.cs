using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Drag_Drop_To_Tuning : MonoBehaviour, IDrag_Drop
{
    public TuningShop tuningShop;
    Image drop_Panel;
    public Image item_to_tune;
    private Sprite item_to_tune_basic;

    public GameObject tuningPage;
    public GameObject inputPage;
    public Button tune_Btn;

    public TextMeshProUGUI infoText;
    public GameObject[] panels;

    public Equipment_ItemData curItem = new Equipment_ItemData();

    private void Awake()
    {
        drop_Panel = GetComponent<Image>();
        item_to_tune_basic = item_to_tune.sprite;
    }

    public void Drop(ItemData_MonoBehaviour itemData_Mono)
    {
        TurnOnTuningMode(itemData_Mono.itemData);
    }

    private void TurnOnTuningMode(ItemData _itemData)
    {
        bool ok = true;
        tune_Btn.interactable = false;
        if (_itemData.type != '0')
            return;
        if (((Equipment_ItemData)_itemData).part != '0')    // 일단 임시로 무기만
            return;
        curItem.Set(((Weapon_ItemData)_itemData));
        inputPage.SetActive(false);
        drop_Panel.enabled = false;
        tuningPage.SetActive(true);
        item_to_tune.sprite = Resources.Load<Sprite>("Images/Items/" + curItem.itemName);

        infoText.text ="+ " + curItem.level.ToString() + " " + curItem.itemName
            + "\r\n강화 등급 상승 확률 : " + tuningShop.probability[curItem.level].ToString()
            + "%\r\n강화 등급 유지 확률 : " + (100 - tuningShop.probability[curItem.level]).ToString() + "%";

        var recipe = tuningShop.recipeList[curItem.id];
        int i = 0;
        for(; i < recipe.material_count.Length; i++)
        {
            panels[i].SetActive(true);
            panels[i].transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/" + recipe.material_name[i]);
            var my_material = InventoryController.Instance.Find_Item(recipe.material_name[i]);
            string str;
            Color clr = new Color(0, 1, 0);
            if (my_material == null)
            {
                str = "0/\r\n" + recipe.material_count[i].ToString();
                Debug.Log("NULLLLLLLLLLLLLLLLLLLLLL");
            }
            else
            {
                if (my_material.count < recipe.material_count[i])
                {
                    clr = new Color(1, 0, 0);
                    ok = false;
                }
                str = my_material.count.ToString() + "/\r\n" + recipe.material_count[i].ToString();
            }
            panels[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = str;
            panels[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = clr;
        }
        for(; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
        if(ok)
            tune_Btn.interactable = true;
    }

    public void TurnOffTuningMode()
    {
        inputPage.SetActive(true);
        drop_Panel.enabled = true;
        tuningPage.SetActive(false);
        item_to_tune.sprite = item_to_tune_basic;
    }

    public void Tune()
    {
        Debug.Log("강화를 시도합니다");
        var inventoryController = InventoryController.Instance;
        var recipe = tuningShop.recipeList[curItem.id];
        // 재료 확인 후 return;
        for(int i = 0; i < recipe.material_count.Length; i++)
        {
            foreach(var v in inventoryController.etcs)
            {
                if(v.itemName == recipe.material_name[i])
                {
                    CFirebase.Instance.LoseItem(recipe.material_name[i], recipe.material_count[i]);
                    Debug.Log(v.count - recipe.material_count[i]);
                    break;
                }
            }
        }
        CFirebase.Instance.LoseEquipment(curItem.id, curItem.itemName, curItem.level);
        curItem.id++;
        curItem.level++;
        CFirebase.Instance.GetWeapon(curItem.id, curItem.itemName, curItem.level, ((Weapon_ItemData)curItem).power + 2);

        TurnOnTuningMode(curItem);
    }

}
