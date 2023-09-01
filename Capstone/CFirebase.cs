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

    public void WriteAccountInfo(string uid, string nickName)
    {
        m_Reference.Child("account").Child(uid).Child("first Character").SetValueAsync(nickName);
    }

    [ContextMenu("DB에 퀘스트 등록")]
    public void WriteAllQuest()
    {
        QuestData quest = new QuestData("첫번째 심부름", "사이퍼 월드에 오신 것을 환영합니다. 앞으로의 활약을 기대합니다. 곧바로 첫번째 퀘스트를 드리겠습니다."
            , new string[] { "Box Dragon" }, new int[] { 10 }, new int[1] 
            , new string[] { "Stone_1" }, new int[] { 10 }, new int[1]
            , null, null);
        string json = JsonUtility.ToJson(quest);
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("퀘스트").Child("시작가능")
            .Child(quest.questName).SetRawJsonValueAsync(json);

        quest = new QuestData("두번째 심부름", "두번째 내용은 귀찮으니까 스킵할게! 그럼 이만 ^^7"
            , new string[] { "Box Dragon", "Box Dragon2" }, new int[] { 20, 20 }, new int[2]
            , null, null, null
            , null, null);
        json = JsonUtility.ToJson(quest);
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("퀘스트").Child("시작가능")
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
    }

    public void Set_Quest_Completed_Monster(QuestData quest, int index)
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("퀘스트").Child("진행중")
            .Child(quest.questName).Child("completed_monster_counts")
            .Child(index.ToString()).SetValueAsync(quest.completed_monster_counts[index]);
    }

    public void GetItem(string _name, int _count)
    {
        ETC_ItemData test_Item = new ETC_ItemData(_name, _count);

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
                    ReadItems();
                }
            });
    }

    public void LoseItem(string _name, int _count)
    {
        ETC_ItemData test_Item = new ETC_ItemData(_name, 0);

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
                        Debug.Log(test_Item.itemName + "의 개수가 부족합니다! 이러면 안돼!!");
                    }
                    else
                    {
                        test_Item.count = Convert.ToInt32(snapshot.Child("count").Value) - _count;
                        if (test_Item.count < 0)
                        {
                            Debug.Log(test_Item.itemName + "의 개수가 부족합니다! 이러면 안돼!!");
                            return;
                        }
                        string json = JsonUtility.ToJson(test_Item);
                        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                        .Child("인벤토리").Child("기타").Child(test_Item.itemName).SetRawJsonValueAsync(json);
                        itemMSGController.UpMSG(test_Item.itemName + " " + _count.ToString() + "개 잃음");
                        ReadItems();
                    }
                }
            });
    }

    public void GetWeapon(Weapon_ItemData weapon_ItemData)
    {
        GetWeapon(weapon_ItemData.uuid, weapon_ItemData.id, weapon_ItemData.itemName, weapon_ItemData.level, weapon_ItemData.attack);
    }

    public void GetWeapon(string _uuid, int _id, string _name, int _level, int _attack)
    {
        Weapon_ItemData test_Item;
        if (_uuid == string.Empty)
            test_Item = new Weapon_ItemData(Guid.NewGuid().ToString(), _id, _name, 0, _level, _attack);
        else
            test_Item = new Weapon_ItemData(_uuid, _id, _name, 0, _level, _attack);

        string json = JsonUtility.ToJson(test_Item);
        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
        .Child("인벤토리").Child("장비").Child(test_Item.uuid).SetRawJsonValueAsync(json);

        itemMSGController.UpMSG("+" + _level.ToString() + " " + test_Item.itemName + " 획득");
        ReadEquipments();
    }

    public void GetArmor(Armor_ItemData armor_ItemData)
    {
        GetArmor(armor_ItemData.uuid, armor_ItemData.id, armor_ItemData.itemName, armor_ItemData.part, armor_ItemData.level, armor_ItemData.defense);
    }

    public void GetArmor(string _uuid,int _id, string _name, int _part,int _level, int _defense)
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

    public void LoseEquipment(int _id, string _name, int _level)
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
        .Child("인벤토리").Child("장비").Child(_name).SetValueAsync(null);

        itemMSGController.UpMSG("+" + _level.ToString() + " " + _name + " 잃음");
        ReadEquipments();
    }

    public void WearEquipment(Equipment_ItemData itemData, ItemData_MonoBehaviour itemData_MonoBehaviour)
    {
        if ((itemData).part == 0)
            WearWeapon(itemData.uuid, itemData_MonoBehaviour);
        else
            WearArmor(itemData.uuid, itemData_MonoBehaviour);
    }

    private void WearWeapon(string _uuid, ItemData_MonoBehaviour itemData_MonoBehaviour)
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("인벤토리").Child("장비").Child(_uuid)
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

                   Weapon_ItemData test_Item = new Weapon_ItemData(Convert.ToString(snapshot.Child("uuid").Value)
                            , Convert.ToInt32(snapshot.Child("id").Value)
                            , Convert.ToString(snapshot.Child("itemName").Value)
                            , 0
                            , Convert.ToInt32(snapshot.Child("level").Value)
                            , Convert.ToInt32(snapshot.Child("attack").Value));
                   string json = JsonUtility.ToJson(test_Item);
                   m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                   .Child("인벤토리").Child("착용중").Child(test_Item.uuid).SetRawJsonValueAsync(json);

                   m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                    .Child("인벤토리").Child("장비").Child(test_Item.uuid)
                    .SetValueAsync(null).ContinueWithOnMainThread(task => { ReadEquipments(); });

                   EquipmentWindowController.Instance.equipments[idx] = test_Item;
                   itemData_MonoBehaviour.itemData = test_Item;

                   EquipmentWindowController.Instance.cells[idx].sprite
                            = Resources.Load("Images/Items/Gun/" + Convert.ToString(snapshot.Child("itemName").Value), typeof(Sprite)) as Sprite;
                   EquipmentWindowController.Instance.SetLevel(idx);

                   Player_Info.Instance.UpdateStats();
               }

           });
    }

    private void WearArmor(string _uuid, ItemData_MonoBehaviour itemData_MonoBehaviour)
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("인벤토리").Child("장비").Child(_uuid)
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

                Armor_ItemData test_Item = new Armor_ItemData(Convert.ToString(snapshot.Child("uuid").Value)
                         , Convert.ToInt32(snapshot.Child("id").Value)
                         , Convert.ToString(snapshot.Child("itemName").Value)
                         , Convert.ToInt32(snapshot.Child("part").Value)
                         , Convert.ToInt32(snapshot.Child("level").Value)
                         , Convert.ToInt32(snapshot.Child("defense").Value));
                string json = JsonUtility.ToJson(test_Item);
                m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                .Child("인벤토리").Child("착용중").Child(test_Item.uuid).SetRawJsonValueAsync(json);

                m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                 .Child("인벤토리").Child("장비").Child(test_Item.uuid)
                 .SetValueAsync(null).ContinueWithOnMainThread(task => { ReadEquipments(); });

                EquipmentWindowController.Instance.equipments[idx] = test_Item;
                itemData_MonoBehaviour.itemData = test_Item;

                string path = "Images/Items/" + InventoryController.part_names[test_Item.part] + "/" 
                    + Convert.ToString(snapshot.Child("itemName").Value);
                EquipmentWindowController.Instance.cells[idx].sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
                EquipmentWindowController.Instance.SetLevel(idx);

                Player_Info.Instance.UpdateStats();
            }

        });
    }

    public void TakeOffWeapon(string _uuid)
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("인벤토리").Child("착용중").Child(_uuid)
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
                   Weapon_ItemData test_Item = new Weapon_ItemData(Convert.ToString(snapshot.Child("uuid").Value)
                     , Convert.ToInt32(snapshot.Child("id").Value)
                     , Convert.ToString(snapshot.Child("itemName").Value)
                     , Convert.ToInt32(snapshot.Child("part").Value)
                     , Convert.ToInt32(snapshot.Child("level").Value)
                     , Convert.ToInt32(snapshot.Child("attack").Value));

                   string json = JsonUtility.ToJson(test_Item);
                   m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                       .Child("인벤토리").Child("착용중").Child(test_Item.uuid).SetValueAsync(null);

                   m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                       .Child("인벤토리").Child("장비").Child(test_Item.uuid).SetRawJsonValueAsync(json)
                       .ContinueWithOnMainThread(tast => { ReadEquipments(); });

                   int idx = test_Item.part;
                   EquipmentWindowController.Instance.equipments[idx] = null;
                   EquipmentWindowController.Instance.cells[idx].gameObject.GetComponent<ItemData_MonoBehaviour>().itemData = new ItemData();
                   EquipmentWindowController.Instance.CellToEmpty(idx);

                   Player_Info.Instance.UpdateStats();
               }
           });
    }

    public void TakeOffArmor(string _uuid)
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("인벤토리").Child("착용중").Child(_uuid)
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
                Armor_ItemData test_Item = new Armor_ItemData(Convert.ToString(snapshot.Child("uuid").Value)
                  , Convert.ToInt32(snapshot.Child("id").Value)
                  , Convert.ToString(snapshot.Child("itemName").Value)
                  , Convert.ToInt32(snapshot.Child("part").Value)
                  , Convert.ToInt32(snapshot.Child("level").Value)
                  , Convert.ToInt32(snapshot.Child("defense").Value));

                string json = JsonUtility.ToJson(test_Item);
                m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                    .Child("인벤토리").Child("착용중").Child(test_Item.uuid).SetValueAsync(null);

                m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                    .Child("인벤토리").Child("장비").Child(test_Item.uuid).SetRawJsonValueAsync(json)
                    .ContinueWithOnMainThread(tast => { ReadEquipments(); });

                int idx = test_Item.part;
                EquipmentWindowController.Instance.equipments[idx] = null;
                EquipmentWindowController.Instance.cells[idx].gameObject.GetComponent<ItemData_MonoBehaviour>().itemData = new ItemData();
                EquipmentWindowController.Instance.CellToEmpty(idx);

                Player_Info.Instance.UpdateStats();
            }
        });
    }

    public void SwitchEquipment()
    {
        Debug.Log("CFirebase SwitchEquipment 일단 행동 없음");
        Player_Info.Instance.UpdateStats();
    }

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

    public void ReadItems()
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
                inventory.etcs[i++] =
                    new ETC_ItemData(Convert.ToString(item.Child("itemName").Value), Convert.ToInt32(item.Child("count").Value));
            }
            for (; i < inventory.cells.Length; i++)
            {
                inventory.etcs[i] = null;
            }
            if (inventory.curWindow == 2)
                inventory.Update_ETC_Inventory();
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
                    if (Convert.ToInt32(item.Child("part").Value) == 0)
                    {
                        inventory.equipments[i++]
                            = new Weapon_ItemData(Convert.ToString(item.Child("uuid").Value)
                            , Convert.ToInt32(item.Child("id").Value)
                            , Convert.ToString(item.Child("itemName").Value)
                            , Convert.ToInt32(item.Child("part").Value)
                            , Convert.ToInt32(item.Child("level").Value)
                            , Convert.ToInt32(item.Child("attack").Value));
                    }
                    else
                    {
                        inventory.equipments[i++]
                            = new Armor_ItemData(Convert.ToString(item.Child("uuid").Value)
                            , Convert.ToInt32(item.Child("id").Value)
                            , Convert.ToString(item.Child("itemName").Value)
                            , Convert.ToInt32(item.Child("part").Value)
                            , Convert.ToInt32(item.Child("level").Value)
                            , Convert.ToInt32(item.Child("defense").Value));
                    }
                }
                for (; i < inventory.cells.Length; i++)
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
                        equipment_window.equipments[part]
                            = new Weapon_ItemData(Convert.ToString(item.Child("uuid").Value)
                            , Convert.ToInt32(item.Child("id").Value)
                            , Convert.ToString(item.Child("itemName").Value)
                            , Convert.ToInt32(item.Child("part").Value)
                            , Convert.ToInt32(item.Child("level").Value)
                            , Convert.ToInt32(item.Child("attack").Value));
                    }
                    else
                    {
                        equipment_window.equipments[part]
                            = new Armor_ItemData(Convert.ToString(item.Child("uuid").Value)
                            , Convert.ToInt32(item.Child("id").Value)
                            , Convert.ToString(item.Child("itemName").Value)
                            , Convert.ToInt32(item.Child("part").Value)
                            , Convert.ToInt32(item.Child("level").Value)
                            , Convert.ToInt32(item.Child("defense").Value));
                    }
                }
                equipment_window.Update_Equipment_Window();
                Player_Info.Instance.UpdateStats();
            });
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
                    foreach(var quest in snapshot.Children)
                    {
                        QuestData QD = new QuestData(Convert.ToString(quest.Child("questName").Value)
                            , Convert.ToString(quest.Child("dialogs").Value)
                            , MyConvert_To_StringArray(quest.Child("monsters").Children)
                            , MyConvert_To_IntArray(quest.Child("monster_counts").Children)
                            , MyConvert_To_IntArray(quest.Child("completed_monster_counts").Children)
                            , MyConvert_To_StringArray(quest.Child("materials").Children)
                            , MyConvert_To_IntArray(quest.Child("material_counts").Children)
                            , MyConvert_To_IntArray(quest.Child("completed_material_counts").Children)
                            , MyConvert_To_StringArray(quest.Child("reward_materials").Children)
                            , MyConvert_To_IntArray(quest.Child("reward_material_counts").Children));
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
                      QuestData QD = new QuestData(Convert.ToString(quest.Child("questName").Value)
                        , Convert.ToString(quest.Child("dialogs").Value)
                        , MyConvert_To_StringArray(quest.Child("monsters").Children)
                        , MyConvert_To_IntArray(quest.Child("monster_counts").Children)
                        , MyConvert_To_IntArray(quest.Child("completed_monster_counts").Children)
                        , MyConvert_To_StringArray(quest.Child("materials").Children)
                        , MyConvert_To_IntArray(quest.Child("material_counts").Children)
                        , MyConvert_To_IntArray(quest.Child("completed_material_counts").Children)
                        , MyConvert_To_StringArray(quest.Child("reward_materials").Children)
                        , MyConvert_To_IntArray(quest.Child("reward_material_counts").Children));
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
                        QuestData QD = new QuestData(Convert.ToString(quest.Child("questName").Value)
                            , Convert.ToString(quest.Child("dialogs").Value)
                            , MyConvert_To_StringArray(quest.Child("monsters").Children)
                            , MyConvert_To_IntArray(quest.Child("monster_counts").Children)
                            , MyConvert_To_IntArray(quest.Child("completed_monster_counts").Children)
                            , MyConvert_To_StringArray(quest.Child("materials").Children)
                            , MyConvert_To_IntArray(quest.Child("material_counts").Children)
                            , MyConvert_To_IntArray(quest.Child("completed_material_counts").Children)
                            , MyConvert_To_StringArray(quest.Child("reward_materials").Children)
                            , MyConvert_To_IntArray(quest.Child("reward_material_counts").Children));
                        QuestController.Instance.completedQuests.Add(QD);
                    }
                }
            });
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

    private string[] MyConvert_To_StringArray(IEnumerable<DataSnapshot> mobj)
    {
        string[] returnData = new string[mobj.Count()];
        int i = 0;
        foreach (var item in mobj)
        {
            returnData[i++] = Convert.ToString(item.Value);
        }
        return returnData;
    }

    private int[] MyConvert_To_IntArray(IEnumerable<DataSnapshot> mobj)
    {
        int[] returnData = new int[mobj.Count()];
        int i = 0;
        foreach (var item in mobj)
        {
            returnData[i++] = Convert.ToInt32(item.Value);
        }
        return returnData;
    }
}