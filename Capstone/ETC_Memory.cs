using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETC_Memory : MonoBehaviour
{
    private static ETC_Memory instance;

    public static ETC_Memory Instance
    {
        get
        {
            var obj = FindObjectOfType<ETC_Memory>();
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

    private static ETC_Memory Create()
    {
        return Instantiate(Resources.Load<ETC_Memory>("ETC_Memory"));
    }

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public int top_orderLayer = 0;
}
