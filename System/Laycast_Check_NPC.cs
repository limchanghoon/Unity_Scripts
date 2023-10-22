using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Laycast_Check_NPC : MonoBehaviour
{
    // 레이저 충돌 정보 받아옴.
    private RaycastHit hitInfo;
    public float range;

    public GameObject keyboard_help;

    Camera theCam;
    public Outline curOutline = null;

    private Player_Move player_Move;
    private PhotonView pv;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
        if (pv != null && pv.IsMine == false)
            enabled = false;

        player_Move = GetComponent<Player_Move>();

        theCam = Camera.main;
        if (keyboard_help == null)
            keyboard_help = GameObject.Find("GM").GetComponent<GameManager>().keyboardHelper;
    }

    private void Update()
    {
        if (Physics.Raycast(theCam.transform.position, theCam.transform.forward, out hitInfo, range))
        {
            if (hitInfo.transform.tag == "NPC")
            {
                Outline _outline = hitInfo.transform.GetComponent<Outline>();
                if (curOutline != hitInfo.transform.GetComponent<Outline>())
                {
                    _outline.On_Outline();
                    if (curOutline != null)
                        curOutline.Off_Outline();
                    else
                    {
                        keyboard_help.SetActive(true);
                        keyboard_help.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text
                            = ETC_Memory.Instance.myOption.keyOption.GetKeyCode(KeySetting.INTERACT).ToString();
                    }
                    curOutline = _outline;
                }
            }
            else
            {
                if (curOutline != null)
                {
                    curOutline.Off_Outline();
                    curOutline = null;
                    keyboard_help.SetActive(false);
                }
            }
        }
        else
        {
            if (curOutline != null)
            {
                curOutline.Off_Outline();
                curOutline = null;
                keyboard_help.SetActive(false);
            }
        }

        if (player_Move.dontMove > 0)
            return;

        if (Input.GetKeyDown(ETC_Memory.Instance.myOption.keyOption.GetKeyCode(KeySetting.INTERACT)) && curOutline != null)
        {
            curOutline.GetComponent<IInteract>().Interact();
        }
    }
}
