using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player_Info : MonoBehaviour
{
    private static Player_Info instance;
    public static Player_Info Instance
    {
        get
        {
            var obj = FindObjectOfType<Player_Info>();
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

    private static Player_Info Create()
    {
        return Instantiate(Resources.Load<Player_Info>("Player_Info"));
    }

    public string nickName = "";

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

}
