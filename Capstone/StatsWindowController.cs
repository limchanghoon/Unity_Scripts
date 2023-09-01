using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsWindowController : MonoBehaviour
{
    public Canvas canvas;
    public TextMeshProUGUI nickName_text;
    public TextMeshProUGUI attack_text;
    public TextMeshProUGUI defense_text;

    private static StatsWindowController instance;

    public static StatsWindowController Instance
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

    private static StatsWindowController Create()
    {
        return Instantiate(Resources.Load<StatsWindowController>("StatsWindow_UI"));
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

    public void CloseStatsUI()
    {
        ETC_Memory.Instance.windowDepth--;
        canvas.enabled = false;
    }

    public void UpdateStats()
    {
        attack_text.text = "공격력 : "+Player_Info.Instance.attack.ToString();
        defense_text.text = "방어력 : "+Player_Info.Instance.defense.ToString();
    }
}
