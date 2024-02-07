using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CSVManager : MonoBehaviour
{
    public static StageData GetStageDataFromCSV(TextAsset csvData, int stageNum)
    {
        string[] data = csvData.text.Split('\n');
        if (data.Length <= stageNum)
            return null;
        string[] elements = data[stageNum].Split(',');
        StageData _stageData = new StageData(int.Parse(elements[0]), int.Parse(elements[1]), float.Parse(elements[2]));
        return _stageData;
    }

    public static StageData[] ParseCSV(TextAsset csvData)
    {
        List<StageData> stageDatas = new List<StageData>();
        string[] data = csvData.text.Split('\n');
        for (int i = 1; i < data.Length; ++i)
        {
            string[] elements = data[i].Split(',');
            StageData _stageData = new StageData(int.Parse(elements[0]), int.Parse(elements[1]), float.Parse(elements[2]));
            stageDatas.Add(_stageData);
        }
        return stageDatas.ToArray();
    }
}

[System.Serializable]
public class StageData
{
    public int stageNumber;
    public int maxHP;
    public float generateRate;

    public StageData(int stageNumber, int maxHP, float generateRate)
    {
        this.stageNumber = stageNumber;
        this.maxHP = maxHP;
        this.generateRate = generateRate;
    }
}
