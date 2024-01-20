using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;
using TMPro;
using Google.MiniJSON;
using Unity.VisualScripting;
using ExitGames.Client.Photon.StructWrapping;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Linq;
using static QuestController;
using UnityEditor;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CFirebase : MonoBehaviour
{
    private static CFirebase instance = null;
    public static CFirebase Instance
    {
        get
        {
            if(null == instance)
            {
                return Create();
            }
            return instance;
        }
    }

    private static CFirebase Create()
    {
        return Instantiate(Resources.Load<CFirebase>("DataBase"));
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            itemMSGController = ItemMSGController.Instance;
            m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    private DatabaseReference m_Reference;

    public string userID;
    public ItemMSGController itemMSGController;

    public event Action gunSwapAction;

    // 아이템 획득 인터페이스
    public void GetItem(ItemData itemData)
    {
        switch(itemData.type)
        {
            case ItemType.None:
                break;
            case ItemType.Other:
                GetOtherItems((Other_ItemData)itemData);
                break;
            case ItemType.Equipment:
                if (((Equipment_ItemData)itemData).part == Equipment_Part.Gun)
                {
                    GetWeapon((Weapon_ItemData)itemData);
                }
                else
                {
                    GetArmor((Armor_ItemData)itemData);
                }
                break;
        }
    }

    #region 아이템 획득 로직
    private void GetOtherItems(Other_ItemData itemData)
    {
        int _id = itemData.id;
        int _count = itemData.count;
        Other_ItemData test_Item = new Other_ItemData(_id, ItemMaster.item_Dic[_id].itemName, _count);

        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("인벤토리").Child("기타").Child(test_Item.itemName)
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    // Handle the error...
                    Debug.Log("IsFaulted");
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    //Debug.Log("IsCompleted " + (int)snapshot.Child(itemName).Value);
                    if (snapshot.Value == null)
                    {
                        string json = JsonUtility.ToJson(test_Item);
                        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                        .Child("인벤토리").Child("기타").Child(test_Item.itemName).SetRawJsonValueAsync(json);
                    }
                    else
                    {
                        test_Item.count += Convert.ToInt32(snapshot.Child("count").Value);
                        string json = JsonUtility.ToJson(test_Item);
                        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                        .Child("인벤토리").Child("기타").Child(test_Item.itemName).SetRawJsonValueAsync(json);
                    }
                    itemMSGController.UpMSG(test_Item.itemName + " " + _count.ToString() + "개 획득");
                    ReadItems(test_Item.itemName);
                }
            });
    }

    private void GetWeapon(Weapon_ItemData weapon_ItemData)
    {
        GetWeapon(weapon_ItemData.uuid, weapon_ItemData.id, weapon_ItemData.itemName, weapon_ItemData.gunType, weapon_ItemData.level, weapon_ItemData.attack);
    }

    private void GetWeapon(string _uuid, int _id, string _name, GunType _gunType, int _level, int _attack)
    {
        Weapon_ItemData test_Item;
        if (_uuid == string.Empty)
            test_Item = new Weapon_ItemData(Guid.NewGuid().ToString(), _id, _name, Equipment_Part.Gun, _gunType, _level, _attack);
        else
            test_Item = new Weapon_ItemData(_uuid, _id, _name, Equipment_Part.Gun, _gunType, _level, _attack);

        string json = JsonUtility.ToJson(test_Item);
        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
        .Child("인벤토리").Child("장비").Child(test_Item.uuid).SetRawJsonValueAsync(json);

        itemMSGController.UpMSG("+" + _level.ToString() + " " + test_Item.itemName + " 획득");
        ReadEquipments();
    }

    private void GetArmor(Armor_ItemData armor_ItemData)
    {
        GetArmor(armor_ItemData.uuid, armor_ItemData.id, armor_ItemData.itemName, armor_ItemData.part, armor_ItemData.level, armor_ItemData.defense);
    }

    private void GetArmor(string _uuid,int _id, string _name, Equipment_Part _part,int _level, int _defense)
    {
        Armor_ItemData test_Item;
        if(_uuid == string.Empty)
            test_Item = new Armor_ItemData(Guid.NewGuid().ToString(), _id, _name, _part, _level, _defense);
        else
            test_Item = new Armor_ItemData(_uuid, _id, _name, _part, _level, _defense);
        string json = JsonUtility.ToJson(test_Item);
        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
        .Child("인벤토리").Child("장비").Child(test_Item.uuid).SetRawJsonValueAsync(json);

        itemMSGController.UpMSG("+" + _level.ToString() + " " + test_Item.itemName + " 획득");
        ReadEquipments();
    }
    #endregion


    // 아이템 버리기 인터페이스
    public void DiscardItem(ItemData itemData)
    {
        string _uuid = "";
        ItemType itemType = itemData.type;

        if (itemType == ItemType.Equipment)
            _uuid = ((Equipment_ItemData)itemData).uuid;
        else if (itemType == ItemType.Other)
            _uuid = itemData.itemName;

        switch (itemType)
        {
            case ItemType.None:
                break;
            case ItemType.Other:
                DiscardOtherItem(_uuid);
                break;
            case ItemType.Equipment:
                DiscardEquipment(_uuid);
                break;
        }
    }

    #region 아이템 버리기 로직
    private void DiscardOtherItem(string _name)
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
        .Child("인벤토리").Child("기타").Child(_name).SetValueAsync(null);

        ReadItems(_name);
    }

    private void DiscardEquipment(string _uuid)
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
        .Child("인벤토리").Child("장비").Child(_uuid).SetValueAsync(null);

        ReadEquipments();
    }
    #endregion


    // 장비 착용 인터페이스
    public void WearEquipment(Equipment_ItemData itemData, ItemData_MonoBehaviour itemData_MonoBehaviour)
    {
        if (itemData_MonoBehaviour.itemData.type == ItemType.None)
        {
            Debug.Log(itemData.itemName + "을 장비창으로 옮깁니다!");
            Inner_WearEquipment(itemData, itemData_MonoBehaviour);
        }
        else
        {
            Debug.Log(itemData.itemName + "으로 스위칭합니다!");
            SwitchEquipment(itemData, itemData_MonoBehaviour);
        }
    }

    #region 장비 착용 로직
    private void Inner_WearEquipment(Equipment_ItemData itemData, ItemData_MonoBehaviour itemData_MonoBehaviour)
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("인벤토리").Child("장비").Child(itemData.uuid)
        .GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                Debug.Log("WearEquipment");
                DataSnapshot snapshot = task.Result;

                int idx = Convert.ToInt32(snapshot.Child("part").Value);
                Equipment_ItemData test_Item;
                if (itemData.part == Equipment_Part.Gun)
                    test_Item = JsonUtility.FromJson<Weapon_ItemData>(snapshot.GetRawJsonValue());
                else
                    test_Item = JsonUtility.FromJson<Armor_ItemData>(snapshot.GetRawJsonValue());

                string json = JsonUtility.ToJson(test_Item);
                m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                .Child("인벤토리").Child("착용중").Child(test_Item.uuid).SetRawJsonValueAsync(json)
                .ContinueWithOnMainThread(task => { ReadWearingEquipment(); });

                m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                 .Child("인벤토리").Child("장비").Child(test_Item.uuid)
                 .SetValueAsync(null).ContinueWithOnMainThread(task => { ReadEquipments(); });
            }

        });
    }

    private void SwitchEquipment(Equipment_ItemData itemData, ItemData_MonoBehaviour itemData_MonoBehaviour)
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
        .Child("인벤토리").Child("착용중").Child(((Equipment_ItemData)itemData_MonoBehaviour.itemData).uuid).SetRawJsonValueAsync(null);

        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
        .Child("인벤토리").Child("장비").Child(itemData.uuid).SetRawJsonValueAsync(null);



        string json1;
        // 장비 => 착용중
        if (itemData.part == Equipment_Part.Gun)
            json1 = JsonUtility.ToJson((Weapon_ItemData)itemData);
        else
            json1 = JsonUtility.ToJson((Armor_ItemData)itemData);

        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
        .Child("인벤토리").Child("착용중").Child(itemData.uuid).SetRawJsonValueAsync(json1)
        .ContinueWithOnMainThread(task => { ReadWearingEquipment(); });



        string json2;
        // 착용중 => 장비
        if (((Equipment_ItemData)itemData_MonoBehaviour.itemData).part == Equipment_Part.Gun)
            json2 = JsonUtility.ToJson((Weapon_ItemData)itemData_MonoBehaviour.itemData);
        else
            json2 = JsonUtility.ToJson((Armor_ItemData)itemData_MonoBehaviour.itemData);

        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
        .Child("인벤토리").Child("장비").Child(((Equipment_ItemData)itemData_MonoBehaviour.itemData).uuid).SetRawJsonValueAsync(json2)
        .ContinueWithOnMainThread(task => { ReadEquipments(); });
    }
    #endregion


    // 장비 탈착 인터페이스
    public void TakeOffEquipment(Equipment_ItemData itemData)
    {
        Debug.Log(itemData.itemName + "을 인벤토리로 옮깁니다!");
        Inner_TakeOffEquipment(itemData);
    }

    #region 장비 탈착 로직
    private void Inner_TakeOffEquipment(Equipment_ItemData itemData)
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("인벤토리").Child("착용중").Child(itemData.uuid)
        .GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
                Debug.Log("IsFaulted");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                Equipment_ItemData test_Item;
                if (itemData.part == Equipment_Part.Gun)
                    test_Item = JsonUtility.FromJson<Weapon_ItemData>(snapshot.GetRawJsonValue());
                else
                    test_Item = JsonUtility.FromJson<Armor_ItemData>(snapshot.GetRawJsonValue());

                string json = JsonUtility.ToJson(test_Item);
                m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                    .Child("인벤토리").Child("착용중").Child(test_Item.uuid).SetValueAsync(null);

                m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                    .Child("인벤토리").Child("장비").Child(test_Item.uuid).SetRawJsonValueAsync(json)
                    .ContinueWithOnMainThread(tast => { ReadEquipments(); });

                int idx = (int)test_Item.part;
                EquipmentWindowController.Instance.equipments[idx] = null;
                EquipmentWindowController.Instance.cells[idx].gameObject.GetComponent<ItemData_MonoBehaviour>().itemData = new ItemData();
                EquipmentWindowController.Instance.CellToEmpty(idx);

                Player_Info.Instance.UpdateStats();
            }
        });
    }
    #endregion



    #region 테스트 관련 코드
    [ContextMenu("랭킹 테스트")]
    public void RankTest()
    {
        for (int i = 0; i < 10000; ++i)
        {
            m_Reference.Child("포탈랭킹").Child(i.ToString())
                .Child("TimeRecord").SetValueAsync(i * 0.01f + 0.005f);
        }
    }


    [ContextMenu("DB에 퀘스트 등록")]
    public void QuestTest()
    {
        WriteAllQuest(Player_Info.Instance.nickName);
    }
    #endregion


    #region 퀘스트 관련 코드
    public void WriteAllQuest(string _nickName)
    {
        QuestData quest = new QuestData("첫번째 심부름", "사이퍼 월드에 오신 것을 환영합니다. 앞으로의 활약을 기대합니다. 곧바로 첫번째 퀘스트를 드리겠습니다."
            , new string[] { "Box Dragon" }, new int[] { 10 }, new int[1]
            , new int[] { 100000 }, new int[] { 10 }
            , new int[] { 100002 }, new int[] { 10 });
        string json = JsonUtility.ToJson(quest);
        m_Reference.Child("users").Child(_nickName).Child("퀘스트").Child("시작가능")
            .Child(quest.questName).SetRawJsonValueAsync(json);

        quest = new QuestData("박스 드래곤 슬레이어", "최근들어 박스 드래곤이 많이 출몰합니다. 대량의 박스 드래곤을 학살해주세요!"
            , new string[] { "Box Dragon" }, new int[] { 30 }, new int[1]
            , null, null
            , new int[] { 100000, 100001, 100002 }, new int[] { 100, 50, 10 });
        json = JsonUtility.ToJson(quest);
        m_Reference.Child("users").Child(_nickName).Child("퀘스트").Child("시작가능")
            .Child(quest.questName).SetRawJsonValueAsync(json);

        quest = new QuestData("문어 사냥", "대왕 문어를 토벌해주세요! 대왕 문어를 모두 잡아주시면 쓸만한 장비 세트를 드릴게요!"
            , new string[] { "SuperOctopus" }, new int[] { 1 }, new int[1]
            , null, null
            , new int[] { 10001, 20001, 30001, 40001, 50001 }, new int[] { 1, 1, 1, 1, 1 });
        json = JsonUtility.ToJson(quest);
        m_Reference.Child("users").Child(_nickName).Child("퀘스트").Child("시작가능")
            .Child(quest.questName).SetRawJsonValueAsync(json);

        quest = new QuestData("로봇과의 전쟁", "대형 로봇과의 뜨거운 한판승부!"
            , new string[] { "SuperRobot" }, new int[] { 1 }, new int[1]
            , null, null
            , new int[] { 100 }, new int[] { 1 });
        json = JsonUtility.ToJson(quest);
        m_Reference.Child("users").Child(_nickName).Child("퀘스트").Child("시작가능")
            .Child(quest.questName).SetRawJsonValueAsync(json);

    }

    public void Accept_Quest(QuestData quest)
    {
        string json = JsonUtility.ToJson(quest);
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("퀘스트").Child("진행중")
            .Child(quest.questName).SetRawJsonValueAsync(json);

        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("퀘스트").Child("시작가능")
            .Child(quest.questName).SetValueAsync(null);
    }

    public void GiveUp_Quest(QuestData quest)
    {
        string json = JsonUtility.ToJson(quest);
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("퀘스트").Child("시작가능")
            .Child(quest.questName).SetRawJsonValueAsync(json);

        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("퀘스트").Child("진행중")
            .Child(quest.questName).SetValueAsync(null);
    }

    public void Complete_Quest(QuestData quest)
    {
        string json = JsonUtility.ToJson(quest);
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("퀘스트").Child("완료")
            .Child(quest.questName).SetRawJsonValueAsync(json);

        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("퀘스트").Child("진행중")
            .Child(quest.questName).SetValueAsync(null);

        for (int i = 0; i < quest.reward_materials_id.Length; i++)
        {
            ItemType itemType = ItemMaster.item_Dic[quest.reward_materials_id[i]].type;
            switch (itemType)
            {
                case ItemType.None:
                    break;
                case ItemType.Other:
                    GetItem(new Other_ItemData(quest.reward_materials_id[i], quest.reward_material_counts[i]));
                    break;
                case ItemType.Equipment:
                    GetItem(ItemMaster.item_Dic[quest.reward_materials_id[i]]);
                    break;
            }
        }
    }

    public void Set_Quest_Completed_Monster(QuestData quest, int index)
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("퀘스트").Child("진행중")
            .Child(quest.questName).Child("completed_monster_counts")
            .Child(index.ToString()).SetValueAsync(quest.completed_monster_counts[index]);
    }


    public void ReadAvailableQuests()
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("퀘스트").Child("시작가능")
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    // Handle the error...
                }
                else if (task.IsCompleted)
                {
                    Debug.Log("Read Available Quests");
                    DataSnapshot snapshot = task.Result;
                    foreach (var quest in snapshot.Children)
                    {
                        QuestData QD = JsonUtility.FromJson<QuestData>(quest.GetRawJsonValue());
                        QuestController.Instance.availabeQuests.Add(QD);
                    }
                }
            });
    }

    public void ReadQuestInProgress()
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("퀘스트").Child("진행중")
          .GetValueAsync().ContinueWithOnMainThread(task =>
          {
              if (task.IsFaulted)
              {
                  // Handle the error...
              }
              else if (task.IsCompleted)
              {
                  Debug.Log("Read Available Quests");
                  DataSnapshot snapshot = task.Result;
                  foreach (var quest in snapshot.Children)
                  {
                      QuestData QD = JsonUtility.FromJson<QuestData>(quest.GetRawJsonValue());
                      QuestController.Instance.inProgressQuests.Add(QD);
                      QuestController.Instance._killNotiHandler += new KillNotiHandler(QD.OnNotify);
                  }
              }
          });
    }

    public void ReadCompletedQuests()
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("퀘스트").Child("완료")
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    // Handle the error...
                }
                else if (task.IsCompleted)
                {
                    Debug.Log("Read Available Quests");
                    DataSnapshot snapshot = task.Result;
                    foreach (var quest in snapshot.Children)
                    {
                        QuestData QD = JsonUtility.FromJson<QuestData>(quest.GetRawJsonValue());
                        QuestController.Instance.completedQuests.Add(QD);
                    }
                }
            });
    }

    public void WriteAccountInfo(string uid, string nickName)
    {
        m_Reference.Child("account").Child(uid).Child("first Character").SetValueAsync(nickName);
    }


    public async Task<bool> CheckMaterials(TuningRecipe recipe)
    {
        for (int i = 0; i < recipe.material_count.Length; i++)
        {
            Task<DataSnapshot> resultTask =
                m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("인벤토리").Child("기타")
                .Child(recipe.material_name[i]).GetValueAsync();
            await resultTask;
            if (recipe.material_count[i] > Convert.ToInt32(resultTask.Result.Child("count").Value))
                return false;
        }
        return true;
    }

    public void ConsumeMaterials(TuningRecipe recipe)
    {
        for (int i = 0; i < recipe.material_count.Length; i++)
        {
            var etc_item = InventoryController.Instance.Find_Item(recipe.material_name[i]);
            int cnt = etc_item.count - recipe.material_count[i];
            if (cnt == 0)
            {
                m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("인벤토리")
                    .Child("기타").Child(recipe.material_name[i]).SetValueAsync(null);

                InventoryController.Instance.etcs[InventoryController.Instance.Find_Item_Index(recipe.material_name[i])] = null;
            }
            else
            {
                m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("인벤토리")
                    .Child("기타").Child(recipe.material_name[i]).Child("count").SetValueAsync(cnt);
                etc_item.count = cnt;
                Debug.Log("cnt 업데이트");
            }

        }
    }
    #endregion


    #region DB에서 데이터 가져오는 함수들
    public void ReadNickName()
    {
        FirebaseDatabase.DefaultInstance.GetReference("account")
        .GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
                Debug.Log("ReadNickName IsFaulted");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                Player_Info.Instance.nickName = snapshot.Child(userID).Child("first Character").Value.ToString();
                Debug.Log("ReadNickName : " + Player_Info.Instance.nickName);
            }
        });
    }

    public void ReadItems(string _itemName = "")
    {
        Debug.Log("ReadItems");
        InventoryController inventory = InventoryController.Instance;

        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("인벤토리")
        .Child("기타").GetValueAsync().ContinueWithOnMainThread(task =>
        {

            DataSnapshot snapshot = task.Result;

            int i = 0;
            foreach (var item in snapshot.Children)
            {
                if (i == inventory.etcs.Count)
                    inventory.AddCell();

                inventory.etcs[i++] = JsonUtility.FromJson<Other_ItemData>(item.GetRawJsonValue());
            }
            for (; i < inventory.cells.Count; i++)
            {
                inventory.etcs[i] = null;
            }
            if (inventory.curWindow == 2)
                inventory.Update_ETC_Inventory();

            if (_itemName != "")
                QuestController.Instance.Notify_GetItem(_itemName);

        });
    }

    public void ReadEquipments()
    {
        Debug.Log("ReadEquipments");
        InventoryController inventory = InventoryController.Instance;
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("인벤토리")
            .Child("장비").GetValueAsync().ContinueWithOnMainThread(task => 
            {
                DataSnapshot snapshot = task.Result;

                int i = 0;
                foreach (var item in snapshot.Children)
                {
                    if (i == inventory.equipments.Count)
                        inventory.AddCell();

                    if (Convert.ToInt32(item.Child("part").Value) == 0)
                        inventory.equipments[i++] = JsonUtility.FromJson<Weapon_ItemData>(item.GetRawJsonValue());
                    else
                        inventory.equipments[i++] = JsonUtility.FromJson<Armor_ItemData>(item.GetRawJsonValue());
                    
                }
                for (; i < inventory.cells.Count; i++)
                {
                    inventory.equipments[i] = null;
                }
                if (inventory.curWindow == 0)
                    inventory.Update_Equipment_Inventory();
            });
    }

    public void ReadWearingEquipment()
    {
        Debug.Log("ReadWearingEquipment");

        EquipmentWindowController equipment_window = EquipmentWindowController.Instance;
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("인벤토리")
            .Child("착용중").GetValueAsync().ContinueWithOnMainThread(task =>
            {
                DataSnapshot snapshot = task.Result;

                for (int i = 0; i < equipment_window.cells.Length; i++)
                {
                    equipment_window.equipments[i] = null;
                }
                foreach (var item in snapshot.Children)
                {
                    int part = Convert.ToInt32(item.Child("part").Value);
                    if (part == 0)
                    {
                        equipment_window.equipments[part] = JsonUtility.FromJson<Weapon_ItemData>(item.GetRawJsonValue());
                    }
                    else
                        equipment_window.equipments[part] = JsonUtility.FromJson<Armor_ItemData>(item.GetRawJsonValue());
                }
                equipment_window.Update_Equipment_Window();
                Player_Info.Instance.UpdateStats();
                gunSwapAction();
            });
    }

    public void CheckNickName(string _nickName, AuthManager authManager)
    {
        authManager.isRegistering = true;

        FirebaseDatabase.DefaultInstance.GetReference("account")
        .GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
                authManager.Set_UI_enabled_Re(true);
                authManager.isRegistering = false;
            }
            else if (task.IsCompleted)
            {

                DataSnapshot snapshot = task.Result;
                // Do something with snapshot...
                foreach (DataSnapshot child in snapshot.Children)
                {
                    foreach (DataSnapshot child_child in child.Children)
                    {
                        if (child_child.Value.ToString() == _nickName)
                        {
                            Debug.Log("해당 닉네임이 이미 존재합니다!");
                            authManager.Set_UI_enabled_Re(true);
                            authManager.nickName_Field_register.ActivateInputField();
                            authManager.isRegistering = false;
                            return;
                        }
                    }
                }
                authManager.Register2();
            }
        });


    }
    #endregion


    #region 옵션 저장/가져오기
    public void WriteOptionData()
    {
        string json = JsonUtility.ToJson(ETC_Memory.Instance.myOption);
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("옵션").SetRawJsonValueAsync(json);

    }


    public void ReadOptionData()
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("옵션")
           .GetValueAsync().ContinueWithOnMainThread(task =>
           {
               if (task.IsFaulted)
               {
                   //
               }
               else if (task.IsCompleted)
               {
                   DataSnapshot snapshot = task.Result;
                   ETC_Memory.Instance.myOption = JsonUtility.FromJson<OptionData>(task.Result.GetRawJsonValue());
                   if(ETC_Memory.Instance.myOption == null)
                       ETC_Memory.Instance.myOption = new OptionData();

                   SoundController.Instance.SetAudioMixer();
               }
           });
    }
    #endregion


    #region 타임어택 모드 관련
    public void GetMyPrePortalRecord(TimerManager _TimerManager)
    {
        m_Reference.Child("포탈랭킹").Child(Player_Info.Instance.nickName).Child("TimeRecord")
          .GetValueAsync().ContinueWithOnMainThread(task =>
          {
              if (task.IsFaulted)
              {
                  //
              }
              else if (task.IsCompleted)
              {
                  DataSnapshot snapshot = task.Result;
                  if (snapshot.Value == null)
                  {
                      Debug.Log("NULL");
                      _TimerManager.SetPreRecord(double.MaxValue);
                  }
                  else
                  {
                      Debug.Log((double)snapshot.Value);
                      _TimerManager.SetPreRecord((double)snapshot.Value);
                  }

              }
          });
    }

    public void SetAndGetPortalRecord(PortalMapFinishNPC _portalMapFinishNPC, double _currentRecord)
    {
        m_Reference.Child("포탈랭킹").Child(Player_Info.Instance.nickName)
            .Child("TimeRecord").SetValueAsync(_currentRecord);

        m_Reference.Child("포탈랭킹").OrderByChild("TimeRecord")
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    //
                }
                else if (task.IsCompleted)
                {
                    Debug.Log("SetAndGetPortalRecord");
                    DataSnapshot snapshot = task.Result;

                    _portalMapFinishNPC.RankSet(snapshot);
                }
            });
    }

    public void GetPortalRecord(PortalMapFinishNPC _portalMapFinishNPC)
    {

        m_Reference.Child("포탈랭킹").OrderByChild("TimeRecord")
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    //
                }
                else if (task.IsCompleted)
                {
                    Debug.Log("GetPortalRecord");
                    DataSnapshot snapshot = task.Result;

                    _portalMapFinishNPC.RankSet(snapshot);
                }
            });
    }
    #endregion
}