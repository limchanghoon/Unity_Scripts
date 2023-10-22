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
    public CameraShake cameraShake;
    public Camera uiCam;

    public float rox = 0;

    private void LateUpdate()
    {
        if (!pv || pv.IsMine)
        {
            theCam.transform.rotation = transform.rotation * cameraShake.m_Rot;
            uiCam.transform.rotation = transform.rotation;
        }

        spine1.transform.Rotate(transform.right, rox, Space.World);

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
