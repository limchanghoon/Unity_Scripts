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
using static UnityEditor.Progress;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;

public class CFirebase : MonoBehaviour
{
    private static CFirebase instance;
    public static CFirebase Instance
    {
        get
        {
            var obj = FindObjectOfType<CFirebase>();
            if (obj != null)
            {
                instance = obj;
            }
            else
            {
                instance = Create();
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
        itemMSGController = ItemMSGController.Instance;
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    private DatabaseReference m_Reference;

    public string userID;
    public ItemMSGController itemMSGController;
    public void ReadUserData()
    {
        FirebaseDatabase.DefaultInstance.GetReference("users")
            .GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                // Do something with snapshot...
            for ( int i = 0; i < snapshot.ChildrenCount; i++)
                Debug.Log(snapshot.Child(i.ToString()).Child("username").Value);
              
            }
        });
    }

    public void WriteUserData(string itemName, int count)
    {
        Debug.Log("WriteUserData First");
        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
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
                    Debug.Log("WriteUserData null");
                    m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                    .Child(itemName).SetValueAsync(count);
                }
                else
                {
                    Debug.Log("WriteUserData not null");
                    if(snapshot.Child(itemName).Value != null)
                        Debug.Log(snapshot.Child(itemName).Value.GetType());
                    m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                    .Child(itemName).SetValueAsync(Convert.ToInt64(snapshot.Child(itemName).Value) + count);
                }
            }
        });
    }

    public void WriteAccountInfo(string uid, string firstThing)
    {
        // 첫번째 파라미터가 유저 닉네임
        m_Reference.Child("account").Child(uid).Child("first Character").SetValueAsync(firstThing);
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

    public void GetWeapon(int _id, string _name, int _level, int _power)
    {
        Weapon_ItemData test_Item = new Weapon_ItemData(_id, _name, '0', _level, _power);

        string json = JsonUtility.ToJson(test_Item);
        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
        .Child("인벤토리").Child("장비").Child(test_Item.itemName).SetRawJsonValueAsync(json);

        itemMSGController.UpMSG("+" + _level.ToString() + " " + test_Item.itemName + " 획득");
        ReadEquipments();
    }

    public void GetArmor(int _id, string _name, char _part,int _level, int _defense)
    {
        Equipment_ItemData test_Item = new Equipment_ItemData(_id, _name, _part, _level);

        string json = JsonUtility.ToJson(test_Item);
        m_Reference.Child("users").Child(Player_Info.Instance.nickName)
        .Child("인벤토리").Child("장비").Child(test_Item.itemName).SetRawJsonValueAsync(json);

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

    public void WearWeapon(string _name, ItemData_MonoBehaviour itemData_MonoBehaviour)
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("인벤토리").Child("장비").Child(_name)
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

                   int idx = Convert.ToInt32(snapshot.Child("part").Value) - 48;
                   EquipmentWindowController.Instance.cells[idx].gameObject.SetActive(true);

                   Weapon_ItemData test_Item = new Weapon_ItemData(Convert.ToInt32(snapshot.Child("id").Value)
                            , Convert.ToString(snapshot.Child("itemName").Value)
                            , '0'
                            , Convert.ToInt32(snapshot.Child("level").Value)
                            , Convert.ToInt32(snapshot.Child("power").Value));
                   string json = JsonUtility.ToJson(test_Item);
                   m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                   .Child("인벤토리").Child("착용중").Child(test_Item.itemName).SetRawJsonValueAsync(json);

                   m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                    .Child("인벤토리").Child("장비").Child(test_Item.itemName)
                    .SetValueAsync(null).ContinueWithOnMainThread(task => { ReadEquipments(); });

                   EquipmentWindowController.Instance.equipments[idx] = test_Item;
                   itemData_MonoBehaviour.itemData = test_Item;

                   EquipmentWindowController.Instance.cells[idx].sprite
                            = Resources.Load("Images/Items/" + Convert.ToString(snapshot.Child("itemName").Value), typeof(Sprite)) as Sprite;
               }

           });
    }

    public void WearArmor()
    {

    }

    public void TakeOffWeapon(string _name)
    {
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("인벤토리").Child("착용중").Child(_name)
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
                   Weapon_ItemData test_Item = new Weapon_ItemData(Convert.ToInt32(snapshot.Child("id").Value)
                     , Convert.ToString(snapshot.Child("itemName").Value)
                     , Convert.ToChar(snapshot.Child("part").Value)
                     , Convert.ToInt32(snapshot.Child("level").Value)
                     , Convert.ToInt32(snapshot.Child("power").Value));

                   string json = JsonUtility.ToJson(test_Item);
                   m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                       .Child("인벤토리").Child("착용중").Child(_name).SetValueAsync(null);

                   m_Reference.Child("users").Child(Player_Info.Instance.nickName)
                       .Child("인벤토리").Child("장비").Child(_name).SetRawJsonValueAsync(json)
                       .ContinueWithOnMainThread(tast => { ReadEquipments(); });

                   int idx = Convert.ToInt32(test_Item.part) - 48;
                   var weapon_data = new Weapon_ItemData();
                   EquipmentWindowController.Instance.equipments[idx] = weapon_data;
                   EquipmentWindowController.Instance.cells[idx].gameObject.GetComponent<ItemData_MonoBehaviour>().itemData = weapon_data;
                   EquipmentWindowController.Instance.cells[idx].sprite
                    = Resources.Load("Images/Items/pistol1_back", typeof(Sprite)) as Sprite;
               }
           });
    }

    public void TakeOffArmor(string _name)
    {
       
    }

    public void SwitchEquipment()
    {

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
        InventoryController inventory = InventoryController.Instance;
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("인벤토리").Child("기타")
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    // Handle the error...
                }
                else if (task.IsCompleted)
                {
                    Debug.Log("ReadItems");
                    DataSnapshot snapshot = task.Result;
                    int i = 0;
                    foreach(var item in snapshot.Children)
                    {
                        inventory.etcs[i++] = 
                            new ETC_ItemData(Convert.ToString(item.Child("itemName").Value), Convert.ToInt32(item.Child("count").Value));
                    }
                    for(; i < inventory.cells.Length; i++)
                    {
                        inventory.etcs[i] = null;
                    }
                    if(InventoryController.Instance.curWindow == 2)
                        InventoryController.Instance.Update_ETC_Inventory();
                }
            });
    }

    public void ReadEquipments()
    {
        InventoryController inventory = InventoryController.Instance;
        m_Reference.Child("users").Child(Player_Info.Instance.nickName).Child("인벤토리").Child("장비")
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    // Handle the error...
                }
                else if (task.IsCompleted)
                {
                    Debug.Log("ReadEquipment");
                    DataSnapshot snapshot = task.Result;
                    int i = 0;
                    foreach (var item in snapshot.Children)
                    {
                        if (Convert.ToChar(item.Child("part").Value) == '0')
                        {
                            inventory.equipments[i++]
                                = new Weapon_ItemData(Convert.ToInt32(item.Child("id").Value)
                                , Convert.ToString(item.Child("itemName").Value)
                                , Convert.ToChar(item.Child("part").Value)
                                , Convert.ToInt32(item.Child("level").Value)
                                , Convert.ToInt32(item.Child("power").Value));
                        }
                        else
                        {
                            inventory.equipments[i++]
                                = new Armor_ItemData(Convert.ToInt32(item.Child("id").Value)
                                , Convert.ToString(item.Child("itemName").Value)
                                , Convert.ToChar(item.Child("part").Value)
                                , Convert.ToInt32(item.Child("level").Value)
                                , Convert.ToInt32(item.Child("defense").Value));
                        }
                    }
                    for (; i < inventory.cells.Length; i++)
                    {
                        inventory.equipments[i] = null;
                    }
                    if (InventoryController.Instance.curWindow == 0)
                        InventoryController.Instance.Update_Equipment_Inventory();
                }
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
}