using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TuningNPC : MonoBehaviour, IInteract
{
    public GameObject tuningShop_UI;
    public Drag_Drop_To_Tuning ddtt;

    //public Dictionary<int, TuningRecipe> recipeList;
    //public Dictionary<int, int> probability;

    bool isActive = false;

    /*
    private void Awake()
    {
        recipeList = new Dictionary<int, TuningRecipe>();
        probability = new Dictionary<int, int>();
        GenerateData();
    }
    */

    private void OnDestroy()
    {
        if(isActive)
            ETC_Memory.Instance.windowDepth--;
    }

    public void Interact()
    {
        if (tuningShop_UI.activeSelf)
            return;
        Debug.Log("TuningShop Interaction!");
        tuningShop_UI.SetActive(true);
        isActive = true;
        tuningShop_UI.GetComponent<Canvas>().sortingOrder = ETC_Memory.Instance.top_orderLayer++;
        ETC_Memory.Instance.windowDepth++;
    }

    public void Close_UI()
    {
        tuningShop_UI.SetActive(false);
        isActive = false;
        ETC_Memory.Instance.windowDepth--;
        ddtt.TurnOffTuningMode();
    }

    // part 0 : 무기
    // 1 : 목걸이, 2 : 장갑, 3 : 모자, 4 : 갑옷, 5 : 신발
    // 100단위로 무기 아이템 코드
    /*
    public void GenerateData()
    {
        probability.Add(0, 100);
        probability.Add(1, 80);
        probability.Add(2, 80);
        probability.Add(3, 60);
        probability.Add(4, 60);
        probability.Add(5, 40);
        probability.Add(6, 40);
        probability.Add(7, 30);
        probability.Add(8, 20);
        probability.Add(9, 15);

        recipeList.Add(0, new TuningRecipe("M16", 0
            , new string[] {"Stone_0" }
            , new int[] {1}));
        recipeList.Add(1, new TuningRecipe("M16", 1
            , new string[] { "Stone_0", "Stone_1" }
            , new int[] { 2, 2}));
        recipeList.Add(2, new TuningRecipe("M16", 2
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 3, 3, 3 }));
        recipeList.Add(3, new TuningRecipe("M16", 4
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 4, 4, 4 }));
        recipeList.Add(4, new TuningRecipe("M16", 5
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 5, 5, 5 }));
        recipeList.Add(5, new TuningRecipe("M16", 6
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 6, 6, 6 }));
        recipeList.Add(6, new TuningRecipe("M16", 7
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 7, 7, 7 }));
        recipeList.Add(7, new TuningRecipe("M16", 8
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 8, 8, 8 }));
        recipeList.Add(8, new TuningRecipe("M16", 9
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 9, 9, 9 }));
        recipeList.Add(9, null);

        recipeList.Add(100, new TuningRecipe("AK-47", 0
            , new string[] { "Stone_0" }
            , new int[] { 1 }));
        recipeList.Add(101, new TuningRecipe("AK-47", 1
            , new string[] { "Stone_0", "Stone_1" }
            , new int[] { 2, 2 }));
        recipeList.Add(102, new TuningRecipe("AK-47", 2
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 3, 3, 3 }));
        recipeList.Add(103, new TuningRecipe("AK-47", 4
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 4, 4, 4 }));
        recipeList.Add(104, new TuningRecipe("AK-47", 5
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 5, 5, 5 }));
        recipeList.Add(105, new TuningRecipe("AK-47", 6
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 6, 6, 6 }));
        recipeList.Add(106, new TuningRecipe("AK-47", 7
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 7, 7, 7 }));
        recipeList.Add(107, new TuningRecipe("AK-47", 8
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 8, 8, 8 }));
        recipeList.Add(108, new TuningRecipe("AK-47", 9
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 9, 9, 9 }));
        recipeList.Add(109, null);

        recipeList.Add(10000, new TuningRecipe("Rusty_Pendant", 0
            , new string[] { "Stone_0" }
            , new int[] { 1 }));
        recipeList.Add(10001, new TuningRecipe("Rusty_Pendant", 1
            , new string[] { "Stone_0", "Stone_1" }
            , new int[] { 2, 2 }));
        recipeList.Add(10002, new TuningRecipe("Rusty_Pendant", 2
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 3, 3, 3 }));
        recipeList.Add(10003, new TuningRecipe("Rusty_Pendant", 4
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 4, 4, 4 }));
        recipeList.Add(10004, new TuningRecipe("Rusty_Pendant", 5
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 5, 5, 5 }));
        recipeList.Add(10005, new TuningRecipe("Rusty_Pendant", 6
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 6, 6, 6 }));
        recipeList.Add(10006, new TuningRecipe("Rusty_Pendant", 7
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 7, 7, 7 }));
        recipeList.Add(10007, new TuningRecipe("Rusty_Pendant", 8
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 8, 8, 8 }));
        recipeList.Add(10008, new TuningRecipe("Rusty_Pendant", 9
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 9, 9, 9 }));
        recipeList.Add(10009, null);

        recipeList.Add(20000, new TuningRecipe("Rusty_Gloves", 0
            , new string[] { "Stone_0" }
            , new int[] { 1 }));
        recipeList.Add(20001, new TuningRecipe("Rusty_Gloves", 1
            , new string[] { "Stone_0", "Stone_1" }
            , new int[] { 2, 2 }));
        recipeList.Add(20002, new TuningRecipe("Rusty_Gloves", 2
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 3, 3, 3 }));
        recipeList.Add(20003, new TuningRecipe("Rusty_Gloves", 4
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 4, 4, 4 }));
        recipeList.Add(20004, new TuningRecipe("Rusty_Gloves", 5
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 5, 5, 5 }));
        recipeList.Add(20005, new TuningRecipe("Rusty_Gloves", 6
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 6, 6, 6 }));
        recipeList.Add(20006, new TuningRecipe("Rusty_Gloves", 7
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 7, 7, 7 }));
        recipeList.Add(20007, new TuningRecipe("Rusty_Gloves", 8
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 8, 8, 8 }));
        recipeList.Add(20008, new TuningRecipe("Rusty_Gloves", 9
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 9, 9, 9 }));
        recipeList.Add(20009, null);

        recipeList.Add(30000, new TuningRecipe("Rusty_Helmet", 0
            , new string[] { "Stone_0" }
            , new int[] { 1 }));
        recipeList.Add(30001, new TuningRecipe("Rusty_Helmet", 1
            , new string[] { "Stone_0", "Stone_1" }
            , new int[] { 2, 2 }));
        recipeList.Add(30002, new TuningRecipe("Rusty_Helmet", 2
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 3, 3, 3 }));
        recipeList.Add(30003, new TuningRecipe("Rusty_Helmet", 4
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 4, 4, 4 }));
        recipeList.Add(30004, new TuningRecipe("Rusty_Helmet", 5
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 5, 5, 5 }));
        recipeList.Add(30005, new TuningRecipe("Rusty_Helmet", 6
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 6, 6, 6 }));
        recipeList.Add(30006, new TuningRecipe("Rusty_Helmet", 7
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 7, 7, 7 }));
        recipeList.Add(30007, new TuningRecipe("Rusty_Helmet", 8
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 8, 8, 8 }));
        recipeList.Add(30008, new TuningRecipe("Rusty_Helmet", 9
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 9, 9, 9 }));
        recipeList.Add(30009, null);

        recipeList.Add(40000, new TuningRecipe("Rusty_Breastplate", 0
            , new string[] { "Stone_0" }
            , new int[] { 1 }));
        recipeList.Add(40001, new TuningRecipe("Rusty_Breastplate", 1
            , new string[] { "Stone_0", "Stone_1" }
            , new int[] { 2, 2 }));
        recipeList.Add(40002, new TuningRecipe("Rusty_Breastplate", 2
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 3, 3, 3 }));
        recipeList.Add(40003, new TuningRecipe("Rusty_Breastplate", 4
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 4, 4, 4 }));
        recipeList.Add(40004, new TuningRecipe("Rusty_Breastplate", 5
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 5, 5, 5 }));
        recipeList.Add(40005, new TuningRecipe("Rusty_Breastplate", 6
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 6, 6, 6 }));
        recipeList.Add(40006, new TuningRecipe("Rusty_Breastplate", 7
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 7, 7, 7 }));
        recipeList.Add(40007, new TuningRecipe("Rusty_Breastplate", 8
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 8, 8, 8 }));
        recipeList.Add(40008, new TuningRecipe("Rusty_Breastplate", 9
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 9, 9, 9 }));
        recipeList.Add(40009, null);
        
        recipeList.Add(50000, new TuningRecipe("Rusty_Boots", 0
            , new string[] { "Stone_0" }
            , new int[] { 1 }));
        recipeList.Add(50001, new TuningRecipe("Rusty_Boots", 1
            , new string[] { "Stone_0", "Stone_1" }
            , new int[] { 2, 2 }));
        recipeList.Add(50002, new TuningRecipe("Rusty_Boots", 2
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 3, 3, 3 }));
        recipeList.Add(50003, new TuningRecipe("Rusty_Boots", 4
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 4, 4, 4 }));
        recipeList.Add(50004, new TuningRecipe("Rusty_Boots", 5
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 5, 5, 5 }));
        recipeList.Add(50005, new TuningRecipe("Rusty_Boots", 6
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 6, 6, 6 }));
        recipeList.Add(50006, new TuningRecipe("Rusty_Boots", 7
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 7, 7, 7 }));
        recipeList.Add(50007, new TuningRecipe("Rusty_Boots", 8
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 8, 8, 8 }));
        recipeList.Add(50008, new TuningRecipe("Rusty_Boots", 9
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 9, 9, 9 }));
        recipeList.Add(50009, null);
    }
*/
}
