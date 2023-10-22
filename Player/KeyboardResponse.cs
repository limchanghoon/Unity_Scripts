using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardResponse : MonoBehaviour
{
    PhotonView pv;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
        if(pv != null && pv.IsMine == false)
        {
            enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!MainMenuController.Instance.gameObject.activeSelf)
            {
                GetComponent<Player_Move>().dontMove++;

                ETC_Memory.Instance.windowDepth++;
                MainMenuController.Instance.gameObject.SetActive(true);
                MainMenuController.Instance.Init();
            }
            else
            {
                MainMenuController.Instance.KeyDownEscape();
            }
        }

        if (MainMenuController.Instance.gameObject.activeSelf)
            return;


        if (Input.GetKeyDown(ETC_Memory.Instance.myOption.keyOption.GetKeyCode(KeySetting.INVENTORY)))
        {
            if (!InventoryController.Instance.gameObject.activeSelf)
            {
                ETC_Memory.Instance.windowDepth++;
                InventoryController.Instance.canvas.sortingOrder = ETC_Memory.Instance.top_orderLayer++;
                InventoryController.Instance.gameObject.SetActive(true);
                InventoryController.Instance.Read_Inventory();
            }
            else
            {
                InventoryController.Instance.Close_Inventory_UI();
            }
        }


        if (Input.GetKeyDown(ETC_Memory.Instance.myOption.keyOption.GetKeyCode(KeySetting.EQUIPMENT_WINDOW)))
        {
            if (!EquipmentWindowController.Instance.canvas.enabled)
            {
                ETC_Memory.Instance.windowDepth++;
                EquipmentWindowController.Instance.canvas.sortingOrder = ETC_Memory.Instance.top_orderLayer++;
                CFirebase.Instance.ReadWearingEquipment();
                EquipmentWindowController.Instance.canvas.enabled = true;
            }
            else
            {
                EquipmentWindowController.Instance.Close_Equipment_Window_UI();
            }
        }


        if (Input.GetKeyDown(ETC_Memory.Instance.myOption.keyOption.GetKeyCode(KeySetting.STATE_WINDOW)))
        {
            if (!StatsWindowController.Instance.canvas.enabled)
            {
                ETC_Memory.Instance.windowDepth++;
                StatsWindowController.Instance.canvas.sortingOrder = ETC_Memory.Instance.top_orderLayer++;
                Player_Info.Instance.UpdateStats();
                StatsWindowController.Instance.canvas.enabled = true;
            }
            else
            {
                StatsWindowController.Instance.CloseStatsUI();
            }
        }


        if (Input.GetKeyDown(ETC_Memory.Instance.myOption.keyOption.GetKeyCode(KeySetting.QUEST)))
        {
            if (!QuestController.Instance.canvas.enabled)
            {
                ETC_Memory.Instance.windowDepth++;
                QuestController.Instance.canvas.sortingOrder = ETC_Memory.Instance.top_orderLayer++;
                QuestController.Instance.isNPC = false;
                QuestController.Instance.ShowQuestInProgress();
                QuestController.Instance.canvas.enabled = true;
            }
            else
            {
                QuestController.Instance.Close_Quest_UI();
            }
        }


        if (Input.GetKeyDown(ETC_Memory.Instance.myOption.keyOption.GetKeyCode(KeySetting.QUEST_NOTICE)))
        {
            if (!AlarmController.Instance.canvas.enabled)
            {
                AlarmController.Instance.canvas.sortingOrder = ETC_Memory.Instance.top_orderLayer++;
                AlarmController.Instance.canvas.enabled = true;
            }
            else
            {
                AlarmController.Instance.CloseAlarm();
            }
        }
    }

}
