using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Firebase.Database;

public class Player_Info : MonoBehaviour
{
    private static Player_Info instance = null;

    public static Player_Info Instance
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

    private static Player_Info Create()
    {
        return Instantiate(Resources.Load<Player_Info>("Player_Info"));
    }


    private string _nickName = string.Empty;

    public string nickName
    {
        get
        {
            return _nickName;
        }
        set
        {
            if(_nickName == string.Empty)
            {
                _nickName = value;
                StatsWindowController.Instance.nickName_text.text = "캐릭터명 : " + _nickName;
            }
        }
    }
    public int attack = 0;
    public int additionalHP = 0;

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

    [ContextMenu("장비 스텟 가져오기!")]
    public void UpdateStats()
    {
        EquipmentWindowController.Instance.GetEquipmentStats(ref attack, ref additionalHP);
        GameObject.Find("GM").GetComponent<GameManager>().myPlayer.GetComponent<Player_HP>().UpdateHpBar();
        StatsWindowController.Instance.UpdateStats();
    }

}
