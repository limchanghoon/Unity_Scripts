using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject myPlayer;
    public Skill_Cooldown dashCooldown;
    public ParticleSystem dashParticle;
    public Transform dashParticleContainer;
    public Slider hpBar;
    public TextMeshProUGUI bullet_text;
    public Camera main_camera;
    public Camera ui_camera;
    public CameraShake cameraShake;
    public List<int> targets = new List<int>();
    public Dictionary<int, Transform> targetsDic = new Dictionary<int, Transform>();
    public int target_count = 0;
    public GameObject[] hit_effects;
    public GameObject[] bulletTrails;
    public GameObject[] muzzleFlash_effects;

    public PhotonView pv;
    protected void Start()
    {
        if (pv == null)
            return;
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(CheckAllPlayerConnected());
        }
    }

    IEnumerator CheckAllPlayerConnected()
    {
        while (true)
        {
            yield return null;
            if(PhotonNetwork.CurrentRoom.PlayerCount == target_count)
            {
                pv.RPC("SortList",RpcTarget.All);
                yield break;
            }
        }
    }

    [PunRPC]
    protected void SortList()
    {
        targets.Sort();
        SetGameComponent();
    }

    public virtual void SetGameComponent() { }
}
