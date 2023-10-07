using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlarmController : MonoBehaviour
{
    private static AlarmController instance = null;
    public static AlarmController Instance
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

    private static AlarmController Create()
    {
        return Instantiate(Resources.Load<AlarmController>("Alarm_UI"));
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            registedQuest = new QuestData[maxCount];
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public Canvas canvas;
    public QuestListParent questListParent;
    private const int maxCount = 5;
    public int curCount = 0;
    public QuestData[] registedQuest;
    public GameObject[] alarmObjs;

    public ContentSizeFitter[] csfs;

    public void RegistAlarm(QuestData _quest)
    {
        if (curCount == maxCount)
            return;

        for (int i = 0; i < maxCount; i++)
        {
            if (_quest == registedQuest[i])
                return;
        }

        int canIndex = -1;
        for (int i = 0; i < maxCount; i++)
        {
            if (registedQuest[i] == null)
            {
                canIndex = i;
                break;
            }
        }

        questListParent.currentQuest.isAlarmRegisted = true;
        registedQuest[canIndex] = _quest;
        alarmObjs[canIndex].transform.SetAsLastSibling();
        UpdateAlarm(canIndex);
        alarmObjs[canIndex].SetActive(true);

        curCount++;
    }

    public void UnRegistAlarm(QuestData _quest)
    {
        if (curCount == 0)
            return;

        for (int i = 0; i < maxCount; i++)
        {
            if (_quest == registedQuest[i])
            {
                UnRegistAlarm(i);
                break;
            }
        }
    }

    public void UnRegistAlarm(int idx)
    {
        if (registedQuest[idx] == null)
            return;

        registedQuest[idx].isAlarmRegisted = false;
        registedQuest[idx] = null;
        alarmObjs[idx].SetActive(false);
        curCount--;

        foreach (var csf in csfs)
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)csf.transform);
    }


    public void UpdateAlarm(int idx)
    {
        QuestData _Quest = registedQuest[idx];
        alarmObjs[idx].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _Quest.questName;


        string txt = "";
        for (int i = 0; i < _Quest.monsters.Length; i++)
            txt += _Quest.monsters[i] + " " + _Quest.monster_counts[i].ToString() + "마리 처치 : " + _Quest.completed_monster_counts[i].ToString() + "/" + _Quest.monster_counts[i].ToString() + "\n";
        

        for (int i = 0; i < _Quest.materials.Length; i++)
            txt += " " + _Quest.materials[i] + " " + _Quest.material_counts[i].ToString() + "개 : " + _Quest.completed_material_counts[i].ToString() + "/" + _Quest.material_counts[i].ToString() + "\n";
        

        alarmObjs[idx].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = txt;

        foreach(var csf in csfs)
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)csf.transform);
    }

    public void UpdateAlarm(QuestData _questData)
    {

        QuestData _Quest = _questData;
        int idx = -1;
        for(int i = 0; i < maxCount; i++)
        {
            if(registedQuest[i] == _Quest)
            {
                idx = i;
                break;
            }
        }

        if(idx == -1)
            return;

        alarmObjs[idx].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _Quest.questName;


        string txt = "";
        for (int i = 0; i < _Quest.monsters.Length; i++)
            txt += _Quest.monsters[i] + " " + _Quest.monster_counts[i].ToString() + "마리 처치 : " + _Quest.completed_monster_counts[i].ToString() + "/" + _Quest.monster_counts[i].ToString() + "\n";


        for (int i = 0; i < _Quest.materials.Length; i++)
            txt += " " + _Quest.materials[i] + " " + _Quest.material_counts[i].ToString() + "개 : " + _Quest.completed_material_counts[i].ToString() + "/" + _Quest.material_counts[i].ToString() + "\n";


        alarmObjs[idx].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = txt;

        foreach (var csf in csfs)
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)csf.transform);
    }


    public void CloseAlarm()
    {
        canvas.enabled = false;
    }
}
