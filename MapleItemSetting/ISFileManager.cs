using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;


public class ISFileManager : MonoBehaviour
{
    public GameObject settingButtonPrefab;
    public Transform contentTr;

    public List<string> files = new List<string>();

    private void Awake()
    {
        files.AddRange(LoadIsList());
    }

    void ReLoadIsList()
    {
        files.Clear();
        foreach(Transform tr in contentTr)
        {
            Destroy(tr.gameObject);
        }
        files.AddRange(LoadIsList());
    }

    public void CreateISToJson(ItemSettingData _itemSettingData)
    {
        
        string path = Path.Combine(Application.persistentDataPath, "ITemSettingFiles");
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        

        for(int i = 100000; i < 999999; i++)
        {
            string _path = Path.Combine(path, i.ToString() + ".json");
            if (!File.Exists(_path))
            {
                if (_itemSettingData.settingName.Length == 1 && _itemSettingData.settingName[0] == 8203)
                    _itemSettingData.settingName = _itemSettingData.charaacterClass.ToString();
                
                string jsonData = JsonUtility.ToJson(_itemSettingData, true);
                File.WriteAllText(_path, jsonData);
                Debug.Log("CreateISToJson 성공");

                GameObject _go = Instantiate(settingButtonPrefab, contentTr);
                var itemSettingObj = _go.GetComponent<ItemSettingObject>();
                itemSettingObj.SetItemSettingData(_itemSettingData, _path);

                files.Add(_path);

                return;
            }
        }
        Debug.Log("CreateISToJson 실패");
    }

    public void SaveIs(ItemSettingData _itemSettingData, string _path)
    {
        string jsonData = JsonUtility.ToJson(_itemSettingData, true);
        File.WriteAllText(_path, jsonData);
        Debug.Log("SaveIs 성공");
    }

    public void DeleteCurFile(string _path)
    {
        File.Delete(_path);
        ReLoadIsList();
    }

    public string[] LoadIsList()
    {
        string path = Path.Combine(Application.persistentDataPath, "ITemSettingFiles");
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        string[] _files = Directory.GetFiles(path);

        foreach(var f in _files)
        {
            string jsonData = File.ReadAllText(f);

            GameObject _go = Instantiate(settingButtonPrefab, contentTr);
            ItemSettingData _itemSettingDataForJson = JsonUtility.FromJson<ItemSettingData>(jsonData);
            var itemSettingObj = _go.GetComponent<ItemSettingObject>();
            itemSettingObj.SetItemSettingData(_itemSettingDataForJson, f);
        }

        return _files;
    }

    public List<string> GetUpPotentialList(OptionGrade _grade, ItemType _type, int _level, int slot)
    {
        string _g;
        if (_grade == OptionGrade.Rare)
            _g = "R";
        else if (_grade == OptionGrade.Epic)
            _g = "E";
        else if (_grade == OptionGrade.Unique)
            _g = "U";
        else if (_grade == OptionGrade.Legendary)
            _g = "L";
        else
            return new List<string> { };

        if (_type == ItemType.Blade || _type == ItemType.Lapis)
            _type = ItemType.Weapon;

        if (_type == ItemType.Shield)
            _type = ItemType.SubWeapon;

        return GetPotentialList(_level, slot, $"UpCube/{_type.ToString()}/{_g}/");
    }


    public List<string> GetDownPotentialList(OptionGrade _grade, ItemType _type, int _level, int slot)
    {
        string _g;
        if (_grade == OptionGrade.Rare)
            _g = "R";
        else if (_grade == OptionGrade.Epic)
            _g = "E";
        else if (_grade == OptionGrade.Unique)
            _g = "U";
        else if (_grade == OptionGrade.Legendary)
            _g = "L";
        else
            return new List<string> { };

        if (_type == ItemType.Blade || _type == ItemType.Lapis)
            _type = ItemType.Weapon;

        if(_type == ItemType.Shield)
            _type = ItemType.SubWeapon;

        return GetPotentialList(_level, slot, $"DownCube/{_type.ToString()}/{_g}/");
    }


    private List<string> GetPotentialList(int _level, int slot, string _path)
    {
        List<string> strList = new List<string>();

        if (_level >= 201)
            _path += "250";
        else if (_level > 110)
            _path += "120";
        else if (_level > 100)
            _path += "110";
        else if (_level > 90)
            _path += "100";
        else if (_level > 80)
            _path += "90";
        else if (_level > 70)
            _path += "80";
        else if (_level > 60)
            _path += "70";
        else if (_level > 50)
            _path += "60";
        else if (_level > 40)
            _path += "50";
        else if (_level > 30)
            _path += "40";
        else if (_level > 20)
            _path += "30";
        else if (_level > 10)
            _path += "20";
        else
            _path += "10";

        TextAsset textFile = Resources.Load(_path) as TextAsset;

        StringReader stringReader = new StringReader(textFile.text);


        while (stringReader != null)
        {
            string line = stringReader.ReadLine();
            if (line == null)
                break;
            if (line == "")
            {
                if (slot-- == 0)
                    break;
                continue;
            }

            if (slot == 0)
                strList.Add(line.Split("\t")[0]);
        }

        // #. 파일 닫기
        stringReader.Close();

        return strList;
    }


}
