using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TuningShop : MonoBehaviour, IInteract
{
    public GameObject tuningShop_UI;
    public Drag_Drop_To_Tuning ddi;

    public Dictionary<int, TuningRecipe> recipeList;
    public Dictionary<int, int> probability;

    private void Awake()
    {
        recipeList = new Dictionary<int, TuningRecipe>();
        probability = new Dictionary<int, int>();
        GenerateData();
    }

    public void Interact()
    {
        Debug.Log("TuningShop Interaction!");
        tuningShop_UI.SetActive(true);
        tuningShop_UI.GetComponent<Canvas>().sortingOrder = ETC_Memory.Instance.top_orderLayer++;
    }

    public void Close_UI()
    {
        tuningShop_UI.SetActive(false);
        ddi.TurnOffTuningMode();
    }

    // 10000 부터 무기 아이템 코드
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

        recipeList.Add(10000, new TuningRecipe("Rifle_0", 0
            , new string[] {"Stone_0" }
            , new int[] {10}));
        recipeList.Add(10001, new TuningRecipe("Rifle_0", 1
            , new string[] { "Stone_0", "Stone_1" }
            , new int[] { 50, 10}));
        recipeList.Add(10002, new TuningRecipe("Rifle_0", 2
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 100, 50, 10 }));
        recipeList.Add(10003, new TuningRecipe("Rifle_0", 3
            , new string[] { "Stone_0", "Stone_1", "Stone_2" }
            , new int[] { 200, 100, 20 }));
    }

    [ContextMenu("Get_rifle_0")]
    public void Get_rifle_0()
    {
        CFirebase.Instance.GetWeapon(10000, "Rifle_0", 0, 10);
    }

    [ContextMenu("Get_AK-47")]
    public void Get_AK_47()
    {
        CFirebase.Instance.GetWeapon(10100, "AK-47", 0, 20);
    }
}
