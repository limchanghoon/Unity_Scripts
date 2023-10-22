using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : Observer
{
    public string questName;
    public string dialogs;
    public string[] monsters;
    public int[] monster_counts;
    public int[] completed_monster_counts;
    public int[] materials_id;
    public int[] material_counts;
    public int[] reward_materials_id;
    public int[] reward_material_counts;

    public bool isAlarmRegisted;

    public QuestData()
    {
        monsters = new string[] { };
        monster_counts = new int[] { };
        completed_monster_counts = new int[] { };
        materials_id = new int[] { };
        material_counts = new int[] { };
        reward_materials_id = new int[] { };
        reward_material_counts = new int[] { };
    }

    public QuestData(string _questName, string _dialogs
        , string[] _monsters, int[] _monster_counts, int[] _completed_monster_counts
        , int[] _materials_id, int[] _material_counts
        , int[] _reward_materials_id, int[] _reward_material_counts)
    {
        questName = _questName;
        dialogs = _dialogs;
        monsters = _monsters;
        monster_counts = _monster_counts;
        completed_monster_counts = _completed_monster_counts;
        materials_id = _materials_id;
        material_counts = _material_counts;
        reward_materials_id = _reward_materials_id;
        reward_material_counts = _reward_material_counts;
    }

    public override void OnNotify(string name, bool isMonster)
    {
        if (isMonster)
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                if (monsters[i] == name)
                {
                    if (completed_monster_counts[i] < monster_counts[i])
                    {
                        completed_monster_counts[i]++;
                        CFirebase.Instance.Set_Quest_Completed_Monster(this, i);
                    }
                    Debug.Log(name + " " + completed_monster_counts[i] + "마리 처치");
                    if (QuestController.Instance.canvas.enabled && QuestController.Instance.questListParent.currentQuest == this)
                        UpdateCurQuestDialog();
                    if (isAlarmRegisted)
                        AlarmController.Instance.UpdateAlarm(this);
                }
            }
        }
        else
        {
            for (int i = 0; i < materials_id.Length; i++)
            {
                if (ItemMaster.Instance.etcItem_Dic[materials_id[i]].itemName == name)
                {
                    if (QuestController.Instance.canvas.enabled && QuestController.Instance.questListParent.currentQuest == this)
                        UpdateCurQuestDialog();
                    if (isAlarmRegisted)
                        AlarmController.Instance.UpdateAlarm(this);
                }
            }
        }
    }

    private void UpdateCurQuestDialog()
    {
        for (int i = 0; i < monsters.Length; i++)
        {
            QuestController.Instance.questListParent.materials_list.GetChild(i).GetComponent<Quest_Monster_MonoBehaviour>()
                .SetMonster(monsters[i], monster_counts[i], completed_monster_counts[i]);
        }

        for (int i = 0; i < materials_id.Length; i++)
        {

            if (materials_id[i] < 100000)  // 장비
            {
                if (materials_id[i] < 10000) // 무기
                    QuestController.Instance.questListParent.materials_list.GetChild(i)
                        .GetComponent<Quest_Material_MonoBehaviour>().SetEquiment(
                            ItemMaster.Instance.weapon_Dic[materials_id[i]]
                            , material_counts[i]);
                else                                        // 방어구
                    QuestController.Instance.questListParent.materials_list.GetChild(i)
                        .GetComponent<Quest_Material_MonoBehaviour>().SetEquiment(
                            ItemMaster.Instance.armor_Dic[materials_id[i]]
                            , material_counts[i]);
            }
            else  // 기타
            {
                QuestController.Instance.questListParent.materials_list.GetChild(i)
                    .GetComponent<Quest_Material_MonoBehaviour>().SetETC(
                        ItemMaster.Instance.etcItem_Dic[materials_id[i]]
                        , material_counts[i]);
            }
        }

    }
}
