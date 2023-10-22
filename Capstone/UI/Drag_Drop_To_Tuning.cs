using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Drag_Drop_To_Tuning : MonoBehaviour, IDrag_Drop
{
    public TuningNPC tuningShop;
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

    public bool Drop(ItemData_MonoBehaviour itemData_Mono)
    {
        if (itemData_Mono.itemWindow != ItemData_MonoBehaviour.ItemWindow.Inventory)
            return false;
        return TurnOnTuningMode(itemData_Mono.itemData);
    }

    private bool TurnOnTuningMode(ItemData _itemData)
    {
        Debug.Log("TurnOnTuningMode");
        if (_itemData.type != '0')
        {
            DialogController.Instance.ShowDialog("장비 아이템이 아닙니다!");
            TurnOffTuningMode();
            return false;
        }
        /*
        int _id = ((Equipment_ItemData)_itemData).id;
        if (!tuningShop.recipeList.ContainsKey(_id))
        {
            DialogController.Instance.ShowDialog("해당 아이템은 강화 불가입니다!");
            Debug.Log("해당 아이템은 강화 불가입니다!");
            TurnOffTuningMode();
            return false;
        }
        if (tuningShop.recipeList[_id] == null)
        {
            DialogController.Instance.ShowDialog("해당 아이템은 강화 수치가 최대입니다!");
            Debug.Log("해당 아이템은 강화 수치가 최대입니다!");
            TurnOffTuningMode();
            return false;
        }
        */
        if (InventoryController.Instance.curWindow == 2)
            InventoryController.Instance.Update_ETC_Inventory();

        bool ok = true;
        tune_Btn.interactable = false;
        curItem = ((Equipment_ItemData)_itemData).part == 0 ? (Weapon_ItemData)_itemData : (Armor_ItemData)_itemData;
        inputPage.SetActive(false);
        drop_Panel.enabled = false;
        tuningPage.SetActive(true);

        string path = "Images/Items/" + InventoryController.part_names[curItem.part] + "/" + curItem.itemName;
        item_to_tune.sprite = Resources.Load<Sprite>(path);

        infoText.text ="+ " + curItem.level.ToString() + " " + curItem.itemName
            + "\r\n강화 등급 상승 확률 : " + GetProbability(curItem.level).ToString()
            + "%\r\n강화 등급 유지 확률 : " + (100 - GetProbability(curItem.level)).ToString() + "%";

        TuningRecipe recipe = GetTuningRecipe(curItem.level);
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
                clr = new Color(1, 0, 0);
                ok = false;
                str = "0/\r\n" + recipe.material_count[i].ToString();
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
        return true;
    }

    public void TurnOffTuningMode()
    {
        inputPage.SetActive(true);
        drop_Panel.enabled = true;
        tuningPage.SetActive(false);
        item_to_tune.sprite = item_to_tune_basic;
    }

    /* 강화시도 => 재료 개수확인 => 재료 소비 => 강화 결과 출력 => 아이템 결과 적용 => 다음 강화 출력
     */
    public void Tune()
    {
        Inner_Tune();
    }

    private async void Inner_Tune()
    {
        Debug.Log("강화를 시도합니다");
        tune_Btn.interactable = false;
        TuningRecipe recipe = GetTuningRecipe(curItem.level);

        Task<bool> resultTask = Task.Run(() => CFirebase.Instance.CheckMaterials(recipe));
        await resultTask;

        if (!resultTask.Result)
        {
            DialogController.Instance.ShowDialog("재료가 부족해요!");
            Debug.Log("재료가 부족해요!");
            TurnOnTuningMode(curItem);
            return;
        }

        CFirebase.Instance.ConsumeMaterials(recipe);

        if (Random.Range(0, 100) > GetProbability(curItem.level))
        {
            DialogController.Instance.ShowDialog("강화 실패");
            Debug.Log("강화 실패!~!");
            if (InventoryController.Instance.curWindow == 2)
                InventoryController.Instance.Update_ETC_Inventory();
            TurnOnTuningMode(curItem);
            return;
        }

        curItem.level++;
        Task _tast;
        if (curItem.part == 0)
        {
            ((Weapon_ItemData)curItem).attack += 2;
            _tast = Task.Run(() =>
            CFirebase.Instance.GetWeapon(curItem.uuid, curItem.id, curItem.itemName, curItem.level, ((Weapon_ItemData)curItem).attack));
        }
        else
        {
            ((Armor_ItemData)curItem).defense += 2;
            _tast = Task.Run(() =>
            CFirebase.Instance.GetArmor(curItem.uuid, curItem.id, curItem.itemName, curItem.part, curItem.level, ((Armor_ItemData)curItem).defense));
        }
        await _tast;

        DialogController.Instance.ShowDialog("강화 성공!");
        Debug.Log("강화 성공!");
        if (InventoryController.Instance.curWindow == 2)
            InventoryController.Instance.Update_ETC_Inventory();
        TurnOnTuningMode(curItem);
    }


    private int GetProbability(int _level)
    {
        if (_level < 10)
            return 90;
        else if (_level < 20)
            return 70;
        else if (_level < 30)
            return 60;
        else if (_level < 40)
            return 50;
        else
            return 40;
    }

    private TuningRecipe GetTuningRecipe(int _level)
    {
        TuningRecipe recipe = new TuningRecipe(_level);
        return recipe;
    }

}
