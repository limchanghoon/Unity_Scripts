using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{
    private static QuestController instance = null;
    public static QuestController Instance
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

    private static QuestController Create()
    {
        return Instantiate(Resources.Load<QuestController>("Quest_UI"));
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            dialog = questListParent.dialog;
            materials_list = questListParent.materials_list;
            reward_list = questListParent.reward_list;
            CFirebase.Instance.ReadAvailableQuests();
            CFirebase.Instance.ReadQuestInProgress();
            CFirebase.Instance.ReadCompletedQuests();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<QuestData> availabeQuests = new List<QuestData>();
    public List<QuestData> inProgressQuests = new List<QuestData>();
    public List<QuestData> completedQuests = new List<QuestData>();

    public QuestListParent questListParent;
    public Canvas canvas;
    public Transform questList_Tr;
    public GameObject accept_btn;
    public GameObject giveUp_btn;
    public GameObject complete_btn;
    public GameObject regist_btn;
    public GameObject unregist_btn;

    public Button[] showBtns;

    TextMeshProUGUI dialog;
    Transform materials_list;
    Transform reward_list;

    public delegate void KillNotiHandler(string monsterName, bool isMonster);
    public KillNotiHandler _killNotiHandler;

    public bool isNPC;

    QuestState curQuestState = QuestState.NULL;

    enum QuestState
    {
        Available = 0,
        InProgress,
        Completed,
        NULL
    }

    public void Close_Quest_UI()
    {
        canvas.enabled = false;
        ETC_Memory.Instance.windowDepth--;
    }

    public void ShowAvailableQuest()
    {
        ChangeShowBtnColor(0);

        ReSetQuestWindow();
        curQuestState = QuestState.Available;
        foreach (Transform child in questList_Tr)
        {
            Destroy(child.gameObject);
        }

        foreach (var QD in availabeQuests)
        {
            var quest_obj = Instantiate(Resources.Load("Quest_Block"), questList_Tr);
            quest_obj.GetComponent<QuestData_MonoBehaviour>().SetQuest(QD);
        }

        if (!isNPC)
        {
            SetBtnAllFalse();
            return;
        }
    }

    public void ShowQuestInProgress()
    {
        ChangeShowBtnColor(1);

        ReSetQuestWindow();
        curQuestState = QuestState.InProgress;
        foreach (Transform child in questList_Tr)
        {
            Destroy(child.gameObject);
        }

        foreach (var QD in inProgressQuests)
        {
            var quest_obj = Instantiate(Resources.Load("Quest_Block"), questList_Tr);
            quest_obj.GetComponent<QuestData_MonoBehaviour>().SetQuest(QD);
        }

        if (!isNPC)
        {
            SetBtnAllFalse();
            return;
        }
    }

    public void ShowCompletedQuest()
    {
        ChangeShowBtnColor(2);

        ReSetQuestWindow();
        curQuestState = QuestState.Completed;
        foreach (Transform child in questList_Tr)
        {
            Destroy(child.gameObject);
        }

        foreach (var QD in completedQuests)
        {
            var quest_obj = Instantiate(Resources.Load("Quest_Block"), questList_Tr);
            quest_obj.GetComponent<QuestData_MonoBehaviour>().SetQuest(QD);
        }

        if (!isNPC)
        {
            SetBtnAllFalse();
            return;
        }

    }

    private void ReSetQuestWindow()
    {
        dialog.text = string.Empty;
        questListParent.currentQuest = null;
        foreach (Transform child in materials_list)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in reward_list)
        {
            Destroy(child.gameObject);
        }

        SetBtnAllFalse();
    }

    public void Accept_Quest()
    {
        if (questListParent.currentQuest == null)
        {
            Debug.Log("NULL �Դϵ�!");
            return;
        }
        availabeQuests.Remove(questListParent.currentQuest);
        inProgressQuests.Add(questListParent.currentQuest);
        foreach (Transform child in questList_Tr)
        {
            if(child.GetComponent<QuestData_MonoBehaviour>().questData == questListParent.currentQuest)
            {
                Destroy(child.gameObject);
                break;
            }
        }
        _killNotiHandler += new KillNotiHandler(questListParent.currentQuest.OnNotify);
        CFirebase.Instance.Accept_Quest(questListParent.currentQuest);
        Debug.Log("����Ʈ �����Դϵ�~");
        ReSetQuestWindow();
    }

    public void Complete_Quest()
    {
        if (questListParent.currentQuest == null)
        {
            Debug.Log("NULL �Դϵ�!");
            return;
        }
        if (!CheckMaterials())
        {
            Debug.Log("��� ����!");
            return;
        }
        inProgressQuests.Remove(questListParent.currentQuest);
        completedQuests.Add(questListParent.currentQuest);
        foreach (Transform child in questList_Tr)
        {
            if (child.GetComponent<QuestData_MonoBehaviour>().questData == questListParent.currentQuest)
            {
                Destroy(child.gameObject);
                break;
            }
        }
        _killNotiHandler -= new KillNotiHandler(questListParent.currentQuest.OnNotify);
        AlarmController.Instance.UnRegistAlarm(questListParent.currentQuest);
        CFirebase.Instance.Complete_Quest(questListParent.currentQuest);
        Debug.Log("����Ʈ �Ϸ��Դϵ�~");
        ReSetQuestWindow();
    }

    public void GiveUp_Quest()
    {
        if (questListParent.currentQuest == null)
        {
            Debug.Log("NULL �Դϵ�!");
            return;
        }
        for(int i = 0; i < questListParent.currentQuest.completed_monster_counts.Length; i++)
        {
            questListParent.currentQuest.completed_monster_counts[i] = 0;
        }
        availabeQuests.Add(questListParent.currentQuest);
        inProgressQuests.Remove(questListParent.currentQuest);
        foreach (Transform child in questList_Tr)
        {
            if (child.GetComponent<QuestData_MonoBehaviour>().questData == questListParent.currentQuest)
            {
                Destroy(child.gameObject);
                break;
            }
        }
        _killNotiHandler -= new KillNotiHandler(questListParent.currentQuest.OnNotify);
        AlarmController.Instance.UnRegistAlarm(questListParent.currentQuest);
        CFirebase.Instance.GiveUp_Quest(questListParent.currentQuest);

        Debug.Log("����Ʈ �����Դϵ�~");
        ReSetQuestWindow();
    }

    public void Regist_Alarm()
    {
        AlarmController.Instance.RegistAlarm(questListParent.currentQuest);
        OnClickQuestBlock();
    }

    public void UnRegist_Alarm()
    {
        AlarmController.Instance.UnRegistAlarm(questListParent.currentQuest);
        OnClickQuestBlock();
    }

    public void Notify_Kill(string monsterName)
    {
        if(_killNotiHandler != null)
            _killNotiHandler(monsterName, true);
    }

    public void Notify_GetItem(string itemName)
    {
        if (_killNotiHandler != null)
            _killNotiHandler(itemName, false);
    }

    private bool CheckMaterials()
    {
        for (int i = 0; i < questListParent.currentQuest.monster_counts.Length; i++)
        {
            if (questListParent.currentQuest.completed_monster_counts[i] < questListParent.currentQuest.monster_counts[i])
                return false;
        }

        for (int i = 0; i < questListParent.currentQuest.materials_id.Length; i++)
        {
            if (InventoryController.Instance.Find_Count_From_Name(ItemMaster.item_Dic[questListParent.currentQuest.materials_id[i]].itemName)
                < questListParent.currentQuest.material_counts[i])
                return false;
        }

        return true;
    }

    public void OnClickQuestBlock()
    {
        QuestData curQuest = questListParent.currentQuest;
        switch (curQuestState)
        {
            case QuestState.Available:
                accept_btn.SetActive(true);
                break;

            case QuestState.InProgress:
                giveUp_btn.SetActive(true);
                complete_btn.SetActive(true);
                if (curQuest.isAlarmRegisted)
                {
                    regist_btn.SetActive(false);
                    unregist_btn.SetActive(true);
                }
                else
                {
                    regist_btn.SetActive(true);
                    unregist_btn.SetActive(false);
                }
                break;

            case QuestState.Completed:
                break;

            default:
                break;
        }
    }

    public void SetBtnAllFalse()
    {
        accept_btn.SetActive(false);
        giveUp_btn.SetActive(false);
        complete_btn.SetActive(false);
        regist_btn.SetActive(false);
        unregist_btn.SetActive(false);
    }

    private void ChangeShowBtnColor(int idx)
    {
        for (int i = 0; i < showBtns.Length; i++)
        {
            ColorBlock colorBlock = showBtns[i].colors;

            if (i == idx)
            {
                colorBlock.normalColor = new Color(0.7451f, 0.7451f, 1f);
            }
            else
            {
                colorBlock.normalColor = new Color(1f, 1f, 1f);
            }

            showBtns[i].colors = colorBlock;

        }
    }

}
