using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Player_Spine : MonoBehaviour
{
    public PhotonView pv;
    public GameObject spine1;

    public Camera theCam;
    public Camera uiCam;

    public float rox = 0;

    private void LateUpdate()
    {
        if (!pv || pv.IsMine)
        {
            theCam.transform.rotation = transform.rotation;
            uiCam.transform.rotation = transform.rotation;
        }

        /*
        // axisVec을 축으로 하여 dirVec을 45도 회전
        Vector3 rotatedDirVec = Quaternion.AngleAxis(45f, axisVec) * dirVec;
        */

        spine1.transform.Rotate(transform.right, rox, Space.World);

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void Send_Rox(float _rox)
    {
        pv.RPC("Send_Rox_RPC", RpcTarget.Others, _rox);
    }

    [PunRPC]
    private void Send_Rox_RPC(float _rox)
    {
        rox = _rox;
    }
}
