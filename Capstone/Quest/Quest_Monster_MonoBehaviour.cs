using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest_Monster_MonoBehaviour : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void SetMonster(string _name, int _count, int _completed_counts)
    {
        text.text = _name + " " + _count.ToString() + "마리 처치 : " + _completed_counts.ToString() + "/" + _count.ToString();
    }
}
