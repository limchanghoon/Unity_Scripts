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
    public string[] materials;
    public int[] material_counts;
    public int[] completed_material_counts;
    public string[] reward_materials;
    public int[] reward_material_counts;

    public QuestData(string _questName, string _dialogs
        , string[] _monsters, int[] _monster_counts, int[] _completed_monster_counts
        , string[] _materials, int[] _material_counts, int[] _completed_material_counts
        , string[] _reward_materials, int[] _reward_material_counts)
    {
        questName = _questName;
        dialogs = _dialogs;
        monsters = _monsters;
        monster_counts = _monster_counts;
        completed_monster_counts = _completed_monster_counts;
        materials = _materials;
        material_counts = _material_counts;
        completed_material_counts = _completed_material_counts;
        reward_materials = _reward_materials;
        reward_material_counts = _reward_material_counts;
    }

    public override void OnNotify(string name)
    {
        for(int i = 0; i < monsters.Length; i++)
        {
            if (monsters[i] == name)
            {
                if (completed_monster_counts[i] < monster_counts[i])
                {
                    completed_monster_counts[i]++;
                    CFirebase.Instance.Set_Quest_Completed_Monster(this, i);
                }
                Debug.Log(name + " " + completed_monster_counts[i] + "마리 처치");
                break;
            }
        }
    }
}
