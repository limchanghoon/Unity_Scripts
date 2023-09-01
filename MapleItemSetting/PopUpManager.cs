using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public GameObject popUpPrefab;

    private static PopUpManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public static PopUpManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    public void GeneratePopUp(string _str)
    {
        Instantiate(popUpPrefab, transform).GetComponent<PopUpObject>().text.text = _str;
    }
}
