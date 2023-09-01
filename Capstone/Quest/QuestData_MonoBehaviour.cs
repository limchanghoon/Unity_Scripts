using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuestData_MonoBehaviour : MonoBehaviour
{
    public QuestData questData;
    public TextMeshProUGUI text;
    TextMeshProUGUI dialog;
    Transform materials_list;
    Transform reward_list;

    private void Awake()
    {
        dialog = GetComponentInParent<QuestListParent>().dialog;
        materials_list = GetComponentInParent<QuestListParent>().materials_list;
        reward_list = GetComponentInParent<QuestListParent>().reward_list;
    }

    public void OnButtonClick()
    {
        dialog.text = questData.dialogs;
        GetComponentInParent<QuestListParent>().currentQuest = questData;
        foreach (Transform child in materials_list)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in reward_list)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < questData.monsters.Length; i++)
        {
            var material_obj = Instantiate(Resources.Load("Quest_Monster_Block"), materials_list);
            material_obj.GetComponent<Quest_Monster_MonoBehaviour>()
                .SetMonster(questData.monsters[i], questData.monster_counts[i], questData.completed_monster_counts[i]);
        }

        for (int i = 0; i < questData.materials.Length; i++)
        {
            var material_obj = Instantiate(Resources.Load("Quest_Material_Block"), materials_list);
            material_obj.GetComponent<Quest_Material_MonoBehaviour>()
                .SetMaterial(questData.materials[i], questData.material_counts[i]);
        }
    }

    public void SetQuest(QuestData QD)
    {
        questData = QD;
        text.text = questData.questName;
    }
}
