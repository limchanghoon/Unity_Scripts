using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMSGController : MonoBehaviour
{
    private static ItemMSGController instance;
    public static ItemMSGController Instance
    {
        get
        {
            var obj = FindObjectOfType<ItemMSGController>();
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

    private static ItemMSGController Create()
    {
        return Instantiate(Resources.Load<ItemMSGController>("ItemMSGController"));
    }

    private void Awake()
    {
        txtCount = parentTr.childCount;
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    public Transform parentTr;
    private int txtCount;

    public void UpMSG(string str)
    {
        parentTr.GetChild(txtCount - 1).GetComponent<ItemMSG>().SetMSG(str);
    }
}
