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
            if (null == instance)
            {
                return Create();
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
        if (instance == null)
        {
            instance = this;
            txtCount = parentTr.childCount;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Transform parentTr;
    private int txtCount;

    public void UpMSG(string str)
    {
        UnityMainThreadDispatcher.Instance().Enqueue(UpMSGoroutine(str));
    }

    IEnumerator UpMSGoroutine(string str)
    {
        parentTr.GetChild(txtCount - 1).GetComponent<ItemMSG>().SetMSG(str);
        yield return null;
    }
}
