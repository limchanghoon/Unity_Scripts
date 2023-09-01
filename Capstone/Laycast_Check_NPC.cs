using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laycast_Check_NPC : MonoBehaviour
{
    // 레이저 충돌 정보 받아옴.
    private RaycastHit hitInfo;
    int layerMask;
    public float range;

    public GameObject keyboard_help;

    Camera theCam;
    public Outline curOutline = null;

    private void Awake()
    {
        layerMask = 1 << LayerMask.NameToLayer("NPC");
        theCam = Camera.main;
    }

    private void Update()
    {
        if (Physics.Raycast(theCam.transform.position, theCam.transform.forward, out hitInfo, range, layerMask))
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
                        keyboard_help.SetActive(true);
                    curOutline = _outline;
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

        if (Input.GetKeyDown(KeyCode.F) && curOutline != null)
        {
            curOutline.GetComponent<IInteract>().Interact();
        }
    }
}
