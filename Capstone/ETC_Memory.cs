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
            if (null == instance)
            {
                return Create();
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
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int top_orderLayer = 0;
    private int _windowDepth = 0;
    public int windowDepth
    {
        get
        {
            return _windowDepth;
        }

        set
        {
            _windowDepth = value;
            if(_windowDepth > 0)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
