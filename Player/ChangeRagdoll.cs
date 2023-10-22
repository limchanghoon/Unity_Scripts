using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRagdoll : MonoBehaviour
{
    [SerializeField] PhotonView pv;
    [SerializeField] GameObject player;
    [SerializeField] Transform gunTr;
    [SerializeField] BoxCollider gunCollider;
    [SerializeField] Rigidbody gunRigid;
    [SerializeField] GameObject ragdollPrefab;

    [SerializeField] GameObject ragdoll;

    private void Awake()
    {
        ragdoll = Instantiate(ragdollPrefab);
        ragdoll.GetComponent<DeathCam>().SetYouDied(pv);
    }


    public void ChangeToRagdoll()
    {
        ragdoll.transform.position = transform.position;
        ragdoll.transform.rotation = transform.rotation;

        var deathCam = ragdoll.GetComponent<DeathCam>();

        if (pv == null || pv.IsMine)
        {
            var _player_Spine = GetComponent<Player_Spine>();
            _player_Spine.theCam.transform.parent = null;
            _player_Spine.uiCam.transform.parent = null;
            deathCam.theCam = _player_Spine.theCam;
            deathCam.uiCam = _player_Spine.theCam;

            GameObject.Find("InDungeonUI").SetActive(false);
        }
        else
            deathCam.enabled = true;

        gunTr.parent = null;
        gunCollider.enabled = true;
        gunRigid.useGravity = true;
        gunRigid.isKinematic = false;
        gunRigid.AddForce(new Vector3(0f, 0f, -50f), ForceMode.Impulse);


        CopyTransformToRagdoll(player.transform, ragdoll.transform);

        player.SetActive(false);
        ragdoll.SetActive(true);

        if (pv == null || pv.IsMine || PhotonNetwork.InLobby)
        {
            deathCam.youDiedCanvas.SetActive(true);
            deathCam.FarAway();
        }

        ragdoll.transform.GetChild(2).GetChild(2).GetChild(0).GetChild(0).GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, 300f), ForceMode.Impulse);
    }


    void CopyTransformToRagdoll(Transform source, Transform target)
    {
        if (source.childCount == 0 || source == GetComponent<Gun>().fire_pos)
            return;
        for(int i = 0; i < source.childCount; ++i)
        {
            target.GetChild(i).localPosition = source.GetChild(i).localPosition;
            target.GetChild(i).localRotation = source.GetChild(i).localRotation;

            CopyTransformToRagdoll(source.GetChild(i), target.GetChild(i));
        }
    }


}
