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
            myOption = new OptionData();
            CFirebase.Instance.ReadOptionData();

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // only one time at village
    private void Start()
    {
        CursorUpdate();
    }

    private void OnLevelWasLoaded(int level)
    {
        CursorUpdate();
    }

    public OptionData myOption;


    // 3만부터 드롭다운같은 경우 문제 발생한다.
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
            CursorUpdate();
        }
    }

    public void CursorUpdate()
    {
        if (_windowDepth > 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
