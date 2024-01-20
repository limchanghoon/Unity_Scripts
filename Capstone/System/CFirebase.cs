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

    // ������ ȹ�� �������̽�
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

    #region ������ ȹ�� ����
    private void GetOtherItems(Other_ItemData itemData)
    {
        int _id = itemData.id;
        int _count = itemData.count;
        Other_ItemData test_Item = new Other_ItemData(_id, ItemMaster.item_Dic[_id].itemName, _count);

        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("�κ��丮").Child("��Ÿ").Child(test_Item.itemName)
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
                        .Child("�κ��丮").Child("��Ÿ").Child(test_Item.itemName).SetRawJsonValueAsync(json);
                    }
                    else
                    {
                        test_Item.count += Convert.ToInt32(snapshot.Child("count").Value);
                        string json = JsonUtility.ToJson(test_Item);
                        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                        .Child("�κ��丮").Child("��Ÿ").Child(test_Item.itemName).SetRawJsonValueAsync(json);
                    }
                    itemMSGController.UpMSG(test_Item.itemName + " " + _count.ToString() + "�� ȹ��");
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
        .Child("�κ��丮").Child("���").Child(test_Item.uuid).SetRawJsonValueAsync(json);

        itemMSGController.UpMSG("+" + _level.ToString() + " " + test_Item.itemName + " ȹ��");
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
        .Child("�κ��丮").Child("���").Child(test_Item.uuid).SetRawJsonValueAsync(json);

        itemMSGController.UpMSG("+" + _level.ToString() + " " + test_Item.itemName + " ȹ��");
        ReadEquipments();
    }
    #endregion


    // ������ ������ �������̽�
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

    #region ������ ������ ����
    private void DiscardOtherItem(string _name)
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
        .Child("�κ��丮").Child("��Ÿ").Child(_name).SetValueAsync(null);

        ReadItems(_name);
    }

    private void DiscardEquipment(string _uuid)
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
        .Child("�κ��丮").Child("���").Child(_uuid).SetValueAsync(null);

        ReadEquipments();
    }
    #endregion


    // ��� ���� �������̽�
    public void WearEquipment(Equipment_ItemData itemData, ItemData_MonoBehaviour itemData_MonoBehaviour)
    {
        if (itemData_MonoBehaviour.itemData.type == ItemType.None)
        {
            Debug.Log(itemData.itemName + "�� ���â���� �ű�ϴ�!");
            Inner_WearEquipment(itemData, itemData_MonoBehaviour);
        }
        else
        {
            Debug.Log(itemData.itemName + "���� ����Ī�մϴ�!");
            SwitchEquipment(itemData, itemData_MonoBehaviour);
        }
    }

    #region ��� ���� ����
    private void Inner_WearEquipment(Equipment_ItemData itemData, ItemData_MonoBehaviour itemData_MonoBehaviour)
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("�κ��丮").Child("���").Child(itemData.uuid)
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
                .Child("�κ��丮").Child("������").Child(test_Item.uuid).SetRawJsonValueAsync(json)
                .ContinueWithOnMainThread(task => { ReadWearingEquipment(); });

                m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                 .Child("�κ��丮").Child("���").Child(test_Item.uuid)
                 .SetValueAsync(null).ContinueWithOnMainThread(task => { ReadEquipments(); });
            }

        });
    }

    private void SwitchEquipment(Equipment_ItemData itemData, ItemData_MonoBehaviour itemData_MonoBehaviour)
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
        .Child("�κ��丮").Child("������").Child(((Equipment_ItemData)itemData_MonoBehaviour.itemData).uuid).SetRawJsonValueAsync(null);

        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
        .Child("�κ��丮").Child("���").Child(itemData.uuid).SetRawJsonValueAsync(null);



        string json1;
        // ��� => ������
        if (itemData.part == Equipment_Part.Gun)
            json1 = JsonUtility.ToJson((Weapon_ItemData)itemData);
        else
            json1 = JsonUtility.ToJson((Armor_ItemData)itemData);

        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
        .Child("�κ��丮").Child("������").Child(itemData.uuid).SetRawJsonValueAsync(json1)
        .ContinueWithOnMainThread(task => { ReadWearingEquipment(); });



        string json2;
        // ������ => ���
        if (((Equipment_ItemData)itemData_MonoBehaviour.itemData).part == Equipment_Part.Gun)
            json2 = JsonUtility.ToJson((Weapon_ItemData)itemData_MonoBehaviour.itemData);
        else
            json2 = JsonUtility.ToJson((Armor_ItemData)itemData_MonoBehaviour.itemData);

        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
        .Child("�κ��丮").Child("���").Child(((Equipment_ItemData)itemData_MonoBehaviour.itemData).uuid).SetRawJsonValueAsync(json2)
        .ContinueWithOnMainThread(task => { ReadEquipments(); });
    }
    #endregion


    // ��� Ż�� �������̽�
    public void TakeOffEquipment(Equipment_ItemData itemData)
    {
        Debug.Log(itemData.itemName + "�� �κ��丮�� �ű�ϴ�!");
        Inner_TakeOffEquipment(itemData);
    }

    #region ��� Ż�� ����
    private void Inner_TakeOffEquipment(Equipment_ItemData itemData)
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("�κ��丮").Child("������").Child(itemData.uuid)
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
                    .Child("�κ��丮").Child("������").Child(test_Item.uuid).SetValueAsync(null);

                m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                    .Child("�κ��丮").Child("���").Child(test_Item.uuid).SetRawJsonValueAsync(json)
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



    #region �׽�Ʈ ���� �ڵ�
    [ContextMenu("��ŷ �׽�Ʈ")]
    public void RankTest()
    {
        for (int i = 0; i < 10000; ++i)
        {
            m_Reference.Child("��Ż��ŷ").Child(i.ToString())
                .Child("TimeRecord").SetValueAsync(i * 0.01f + 0.005f);
        }
    }


    [ContextMenu("DB�� ����Ʈ ���")]
    public void QuestTest()
    {
        WriteAllQuest(Player_Info.Instance.nickName);
    }
    #endregion


    #region ����Ʈ ���� �ڵ�
    public void WriteAllQuest(string _nickName)
    {
        QuestData quest = new QuestData("ù��° �ɺθ�", "������ ���忡 ���� ���� ȯ���մϴ�. �������� Ȱ���� ����մϴ�. ��ٷ� ù��° ����Ʈ�� �帮�ڽ��ϴ�."
            , new string[] { "Box Dragon" }, new int[] { 10 }, new int[1]
            , new int[] { 100000 }, new int[] { 10 }
            , new int[] { 100002 }, new int[] { 10 });
        string json = JsonUtility.ToJson(quest);
        m_Reference.Child("users").Child(_nickName).Child("����Ʈ").Child("���۰���")
            .Child(quest.questName).SetRawJsonValueAsync(json);

        quest = new QuestData("�ڽ� �巡�� �����̾�", "�ֱٵ�� �ڽ� �巡���� ���� ����մϴ�. �뷮�� �ڽ� �巡���� �л����ּ���!"
            , new string[] { "Box Dragon" }, new int[] { 30 }, new int[1]
            , null, null
            , new int[] { 100000, 100001, 100002 }, new int[] { 100, 50, 10 });
        json = JsonUtility.ToJson(quest);
        m_Reference.Child("users").Child(_nickName).Child("����Ʈ").Child("���۰���")
            .Child(quest.questName).SetRawJsonValueAsync(json);

        quest = new QuestData("���� ���", "��� ��� ������ּ���! ��� ��� ��� ����ֽø� ������ ��� ��Ʈ�� �帱�Կ�!"
            , new string[] { "SuperOctopus" }, new int[] { 1 }, new int[1]
            , null, null
            , new int[] { 10001, 20001, 30001, 40001, 50001 }, new int[] { 1, 1, 1, 1, 1 });
        json = JsonUtility.ToJson(quest);
        m_Reference.Child("users").Child(_nickName).Child("����Ʈ").Child("���۰���")
            .Child(quest.questName).SetRawJsonValueAsync(json);

        quest = new QuestData("�κ����� ����", "���� �κ����� �߰ſ� ���ǽº�!"
            , new string[] { "SuperRobot" }, new int[] { 1 }, new int[1]
            , null, null
            , new int[] { 100 }, new int[] { 1 });
        json = JsonUtility.ToJson(quest);
        m_Reference.Child("users").Child(_nickName).Child("����Ʈ").Child("���۰���")
            .Child(quest.questName).SetRawJsonValueAsync(json);

    }

    public void Accept_Quest(QuestData quest)
    {
        string json = JsonUtility.ToJson(quest);
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("����Ʈ").Child("������")
            .Child(quest.questName).SetRawJsonValueAsync(json);

        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("����Ʈ").Child("���۰���")
            .Child(quest.questName).SetValueAsync(null);
    }

    public void GiveUp_Quest(QuestData quest)
    {
        string json = JsonUtility.ToJson(quest);
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("����Ʈ").Child("���۰���")
            .Child(quest.questName).SetRawJsonValueAsync(json);

        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("����Ʈ").Child("������")
            .Child(quest.questName).SetValueAsync(null);
    }

    public void Complete_Quest(QuestData quest)
    {
        string json = JsonUtility.ToJson(quest);
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("����Ʈ").Child("�Ϸ�")
            .Child(quest.questName).SetRawJsonValueAsync(json);

        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("����Ʈ").Child("������")
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
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("����Ʈ").Child("������")
            .Child(quest.questName).Child("completed_monster_counts")
            .Child(index.ToString()).SetValueAsync(quest.completed_monster_counts[index]);
    }


    public void ReadAvailableQuests()
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("����Ʈ").Child("���۰���")
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
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("����Ʈ").Child("������")
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
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("����Ʈ").Child("�Ϸ�")
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
                m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("�κ��丮").Child("��Ÿ")
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
                m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("�κ��丮")
                    .Child("��Ÿ").Child(recipe.material_name[i]).SetValueAsync(null);

                InventoryController.Instance.etcs[InventoryController.Instance.Find_Item_Index(recipe.material_name[i])] = null;
            }
            else
            {
                m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("�κ��丮")
                    .Child("��Ÿ").Child(recipe.material_name[i]).Child("count").SetValueAsync(cnt);
                etc_item.count = cnt;
                Debug.Log("cnt ������Ʈ");
            }

        }
    }
    #endregion


    #region DB���� ������ �������� �Լ���
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

        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("�κ��丮")
        .Child("��Ÿ").GetValueAsync().ContinueWithOnMainThread(task =>
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
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("�κ��丮")
            .Child("���").GetValueAsync().ContinueWithOnMainThread(task => 
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
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("�κ��丮")
            .Child("������").GetValueAsync().ContinueWithOnMainThread(task =>
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
                            Debug.Log("�ش� �г����� �̹� �����մϴ�!");
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


    #region �ɼ� ����/��������
    public void WriteOptionData()
    {
        string json = JsonUtility.ToJson(ETC_Memory.Instance.myOption);
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("�ɼ�").SetRawJsonValueAsync(json);

    }


    public void ReadOptionData()
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("�ɼ�")
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


    #region Ÿ�Ӿ��� ��� ����
    public void GetMyPrePortalRecord(TimerManager _TimerManager)
    {
        m_Reference.Child("��Ż��ŷ").Child(Player_Info.Instance.nickName).Child("TimeRecord")
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
        m_Reference.Child("��Ż��ŷ").Child(Player_Info.Instance.nickName)
            .Child("TimeRecord").SetValueAsync(_currentRecord);

        m_Reference.Child("��Ż��ŷ").OrderByChild("TimeRecord")
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

        m_Reference.Child("��Ż��ŷ").OrderByChild("TimeRecord")
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