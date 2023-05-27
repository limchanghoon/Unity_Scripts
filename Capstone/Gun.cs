using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

using Random = UnityEngine.Random;

public class Gun : MonoBehaviour
{
    public PhotonView pv;

    // 필요한 컴퍼넌트
    [SerializeField] private Animator animator;
    [SerializeField] private Player_Move player_Move;
    [SerializeField] private Transform fire_pos;
    [SerializeField] private Camera theCam;
    [SerializeField] private Transform magazine_transform;
    [SerializeField] private Transform leftHand_transform;
    [SerializeField] private TextMeshProUGUI bullet_text;

    // 필요한 오브젝트
    GameObject[] hit_effects;
    public GameObject[] muzzleFlash_effects;
    GameObject[] bulletTrails;
    [SerializeField] private GameObject Magazine_prefab;

    // 레이저 충돌 정보 받아옴.
    private RaycastHit hitInfo;
    int layerMask;

    // 변수
    [SerializeField] private float layerTransSpeed;
    public int damage;
    public float range;
    [SerializeField] private bool isReload = false;
    [SerializeField] private bool isDroped = false;
    [SerializeField] private int current_Bullet_cnt;
    [SerializeField] private int remaining_Bullet_cnt;
    [SerializeField] private int magazine_size;

    private void Start()
    {
        GameManager GM = GameObject.Find("GM").GetComponent<GameManager>();
        hit_effects = GM.hit_effects;
        bulletTrails = GM.bulletTrails;
        muzzleFlash_effects = GM.muzzleFlash_effects;
        if (pv && !pv.IsMine)
            return;
        layerMask = (-1) - (1 << LayerMask.NameToLayer("Player"));
        bullet_text = GM.bullet_text;
        theCam = GM.main_camera;
        Cursor.lockState = CursorLockMode.Locked;
        UpdateBulletUI();
    }

    private void Update()
    {
        if (pv && !pv.IsMine)
            return;
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!checkBottom.isFried)
            {
                animator.SetBool("Jump", true);
                checkBottom.isFried = true;
                myRigidbody.AddForce(new Vector3(0, 500, 0));
            }
        }
        */

        SetRunLayer();

        if (isReload)
            return;

        if (Input.GetKeyDown(KeyCode.R) && remaining_Bullet_cnt > 0 && current_Bullet_cnt < magazine_size)
        {
            isReload = true;
            if (pv)
                pv.RPC("Reload_RPC", RpcTarget.All);
            else
                Reload_RPC();
        }
        else if (Input.GetMouseButton(0))
        {
            if (current_Bullet_cnt <= 0)
            {
                animator.SetBool("Atk", false);
                animator.SetLayerWeight(1, 0);

                if (remaining_Bullet_cnt > 0)
                {
                    isReload = true;
                    if (pv)
                        pv.RPC("Reload_RPC", RpcTarget.All);
                    else
                        Reload_RPC();
                }

                return;
            }
            animator.SetBool("Atk", true);
            animator.SetLayerWeight(1, 1);
            /*
            if (!checkBottom.isFried)
            {
                //photonView.RPC("atkAudioPlay", RpcTarget.All);
                //attackCol.enabled = true;
                animator.SetBool("Atk", true);
                animator.SetLayerWeight(1, 1);
            }
            else
            {
                animator.SetBool("Atk", false);
                animator.SetLayerWeight(1, 0);
            }
            //StartCoroutine("onesec");
            */
        }
        else
        {
            animator.SetBool("Atk", false);
            animator.SetLayerWeight(1, 0);
        }

    }

    public void SetRunLayer()
    {
        if (!isReload)
        {
            animator.SetLayerWeight(1, 0);
            if (animator.GetBool("Run"))
            {
                animator.SetLayerWeight(2, 0);
                animator.SetLayerWeight(3, 1);
            }
            else
            {
                animator.SetLayerWeight(2, 1);
                animator.SetLayerWeight(3, 0);
            }
        }
        else
        {
            if (animator.GetBool("Run"))
            {
                animator.SetLayerWeight(2, Mathf.Clamp(animator.GetLayerWeight(2) - layerTransSpeed * Time.deltaTime, 0, 1));
                animator.SetLayerWeight(3, Mathf.Clamp(animator.GetLayerWeight(3) + layerTransSpeed * Time.deltaTime, 0, 1));
            }
            else
            {
                animator.SetLayerWeight(2, Mathf.Clamp(animator.GetLayerWeight(2) + layerTransSpeed * Time.deltaTime, 0, 1));
                animator.SetLayerWeight(3, Mathf.Clamp(animator.GetLayerWeight(3) - layerTransSpeed * Time.deltaTime, 0, 1));
            }
        }
    }

    public void FinishReload()
    {
        int reloading_count = magazine_size - current_Bullet_cnt;
        if (reloading_count > remaining_Bullet_cnt)
            reloading_count = remaining_Bullet_cnt;

        current_Bullet_cnt += reloading_count;
        remaining_Bullet_cnt -= reloading_count;
        UpdateBulletUI();

        isReload = false;
        isDroped = false;
    }

    public void Drop_magazine()
    {
        if (isDroped)
            return;
        isDroped = true;
        GameObject droped_magazine = Instantiate(Magazine_prefab, magazine_transform.position, magazine_transform.rotation);
        Destroy(droped_magazine, 10f);
    }


    public void Shoot()
    {
        /*
        BulletCtrl bulletCtrl = Instantiate(bullet, fire_pos.position, fire_pos.rotation).GetComponent<BulletCtrl>();
        bulletCtrl.SetDamage(Random.Range(40, 61));
        bulletCtrl.AddForce();
        */
        foreach(GameObject muzzleFlash_effect in muzzleFlash_effects)
        {
            if (!muzzleFlash_effect.activeSelf)
            {
                muzzleFlash_effect.transform.parent = fire_pos;
                muzzleFlash_effect.transform.localPosition= Vector3.zero;
                muzzleFlash_effect.transform.localEulerAngles= Vector3.zero;
                //fire_pos
                muzzleFlash_effect.SetActive(true);
                break;
            }
        }
        if (pv && !pv.IsMine)
            return;

        Shoot_Ray();

        current_Bullet_cnt--;
        UpdateBulletUI();

        bool recoil_right = Random.Range(0f, 1f) < 0.5 ? true : false;
        float recoil_h = Random.Range(0f, 1f);
        float recoil_v = Random.Range(1f, 1.2f);

        player_Move.SetRecoil(recoil_right, recoil_h, recoil_v);
        
    }

    private void UpdateBulletUI()
    {
        if (pv && !pv.IsMine)
            return;
        bullet_text.SetText("<size=30>" + current_Bullet_cnt.ToString() + "</size>/" + remaining_Bullet_cnt.ToString());
    }

    private void Shoot_Ray()
    {
        if(Physics.Raycast(theCam.transform.position, theCam.transform.forward, out hitInfo, range, layerMask))
        {
            //Debug.Log("Ray Hit " + hitInfo.transform.name);
            if(hitInfo.transform.tag == "Monster")
            {
                int minDamage = (int)(Player_Info.Instance.attack * 0.9f);
                int maxDamage = (int)(Player_Info.Instance.attack * 1.1f);
                hitInfo.transform.GetComponent<IHit>().Hit(Random.Range(minDamage, maxDamage), hitInfo.point);
            }
            if (pv)
                pv.RPC("SpawnTrailRPC", RpcTarget.All, hitInfo.point, hitInfo.normal);
            else
                SpawnTrailRPC(hitInfo.point, hitInfo.normal);
        }
    }

    private IEnumerator SpawnTrailCoroutine(Vector3 hit_point)
    {
        Vector3 startPosition = fire_pos.position;

        if (Vector3.Distance(startPosition, hit_point) > 5f)
        {
            float time = 0;
            int i = 0;
            for (; i < bulletTrails.Length; i++)
            {
                if (!bulletTrails[i].activeSelf)
                {
                    bulletTrails[i].transform.position = startPosition;
                    bulletTrails[i].transform.rotation = Quaternion.identity;
                    bulletTrails[i].SetActive(true);
                    break;
                }
            }
            TrailRenderer trail = bulletTrails[i].GetComponent<TrailRenderer>();

            while (time < 1)
            {
                bulletTrails[i].transform.position = Vector3.Lerp(startPosition, hit_point, time);
                time += Time.deltaTime / trail.time;

                yield return null;
            }

            bulletTrails[i].transform.position = hit_point;
            yield return new WaitForSeconds(trail.time);
            bulletTrails[i].SetActive(false);
        }
    }

    [PunRPC]
    private void SpawnTrailRPC(Vector3 hit_point, Vector3 hit_normal)
    {
        foreach (GameObject hit_effect in hit_effects)
        {
            if (!hit_effect.activeSelf)
            {
                hit_effect.transform.position = hit_point;
                hit_effect.transform.rotation = Quaternion.LookRotation(hit_normal);
                hit_effect.SetActive(true);
                break;
            }
        }
        StartCoroutine(SpawnTrailCoroutine(hit_point));
    }

    [PunRPC]
    private void Reload_RPC()
    {
        animator.SetTrigger("Reload");
    }


}
