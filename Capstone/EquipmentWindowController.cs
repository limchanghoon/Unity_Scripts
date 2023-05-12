using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentWindowController : MonoBehaviour
{
    public Image[] cells;
    public Equipment_ItemData[] equipments;
    public Canvas canvas;


    private static EquipmentWindowController instance;
    public static EquipmentWindowController Instance
    {
        get
        {
            var obj = FindObjectOfType<EquipmentWindowController>();
            if (obj != null)
            {
                instance = obj;
            }
            else
            {
                instance = Create();
            }
            return instance;
        }
    }

    private static EquipmentWindowController Create()
    {
        return Instantiate(Resources.Load<EquipmentWindowController>("EquipmentWindow_UI"));
    }

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        equipments = new Equipment_ItemData[cells.Length];
    }

    public void Close_Equipment_Window_UI()
    {
        canvas.enabled = false;
    }
}
