using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MyJsonManager : MonoBehaviour
{
    public static void SaveStageClearMaxData(StageClearMaxData stageClearMaxData)
    {
        string path = Path.Combine(Application.persistentDataPath, "StageClearData");
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        path = Path.Combine(path, "StageClearMax.json");

        // 저장하기
        string json = JsonUtility.ToJson(stageClearMaxData);
        File.WriteAllText(path, json);
    }

    public static StageClearMaxData LoadStageClearMaxData()
    {
        string path = Path.Combine(Application.persistentDataPath, "StageClearData");
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        path = Path.Combine(path, "StageClearMax.json");
        // 불러오기
        if (!File.Exists(path))
            return new StageClearMaxData();
        string loadJson = File.ReadAllText(path);
        var loadedData = JsonUtility.FromJson<StageClearMaxData>(loadJson);
        return loadedData;
    }

    public static void SaveStageClearData(string mapName, StageClearData stageClearData)
    {
        string path = Path.Combine(Application.persistentDataPath, "StageClearData");
        if(!Directory.Exists(path))
            Directory.CreateDirectory(path);
        path = Path.Combine(path, mapName + ".json");

        // 저장하기
        string json = JsonUtility.ToJson(stageClearData);
        File.WriteAllText(path, json);
    }

    public static StageClearData LoadStageClearData(string mapName)
    {
        string path = Path.Combine(Application.persistentDataPath, "StageClearData");
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        path = Path.Combine(path, mapName + ".json");
        // 불러오기
        if (!File.Exists(path))
            return new StageClearData();
        string loadJson = File.ReadAllText(path);
        var loadedData = JsonUtility.FromJson<StageClearData>(loadJson);
        return loadedData;
    }

    public static void SaveUnitData(string unitName, UnitData unitData)
    {
        string path = Path.Combine(Application.persistentDataPath, "UnitData");
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        path = Path.Combine(path, unitName + ".json");

        // 저장하기
        string json = JsonUtility.ToJson(unitData);
        File.WriteAllText(path, json);
    }

    public static UnitData LoadUnitData(string unitName)
    {
        string path = Path.Combine(Application.persistentDataPath, "UnitData");
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        path = Path.Combine(path, unitName + ".json");
        // 불러오기
        if (!File.Exists(path))
            return new UnitData(Resources.Load<UnitScriptableObject>(unitName + "BaseData"));
        string loadJson = File.ReadAllText(path);
        var loadedData = JsonUtility.FromJson<UnitData>(loadJson);
        return loadedData;
    }

    public static void SaveTowerData(TowerData towerData)
    {
        string path = Path.Combine(Application.persistentDataPath, "TowerData");
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        path = Path.Combine(path, "Tower.json");

        // 저장하기
        string json = JsonUtility.ToJson(towerData);
        File.WriteAllText(path, json);
    }

    public static TowerData LoadTowerData()
    {
        string path = Path.Combine(Application.persistentDataPath, "TowerData");
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        path = Path.Combine(path, "Tower.json");
        // 불러오기
        if (!File.Exists(path))
            return new TowerData();
        string loadJson = File.ReadAllText(path);
        var loadedData = JsonUtility.FromJson<TowerData>(loadJson);
        return loadedData;
    }

    public static void SaveGoldData(GoldData goldData)
    {
        string path = Path.Combine(Application.persistentDataPath, "GoldData");
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        path = Path.Combine(path, "Gold.json");

        // 저장하기
        string json = JsonUtility.ToJson(goldData);
        File.WriteAllText(path, json);
    }

    public static GoldData LoadGoldData()
    {
        string path = Path.Combine(Application.persistentDataPath, "GoldData");
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        path = Path.Combine(path, "Gold.json");
        // 불러오기
        if (!File.Exists(path))
            return new GoldData();
        string loadJson = File.ReadAllText(path);
        var loadedData = JsonUtility.FromJson<GoldData>(loadJson);
        return loadedData;
    }
}

[System.Serializable]
public class StageClearMaxData
{
    public int clearMaxStage;

    public StageClearMaxData(int clearMaxStage = 0)
    {
        this.clearMaxStage = clearMaxStage;
    }
}


[System.Serializable]
public class StageClearData
{
    public byte starCount;

    public StageClearData(byte starCount = 0)
    {
        this.starCount = starCount;
    }
}

[System.Serializable]
public class GoldData
{
    public int gold;

    public GoldData(int gold = 0)
    {
        this.gold = gold;
    }

    public static implicit operator int(GoldData goldData)
    {
        return goldData.gold;
    }

    public override string ToString()
    {
        return gold.ToString();
    }
}
