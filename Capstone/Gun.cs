using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private GameObject hit_effect;
    [SerializeField] private GameObject muzzleFlash_effect;
    [SerializeField] private GameObject bulletTrail;
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
        if (!pv.IsMine)
            return;
        layerMask = (-1) - (1 << LayerMask.NameToLayer("Player"));
        GameManager GM = GameObject.Find("GM").GetComponent<GameManager>();
        if (GM != null)
        {
            bullet_text = GM.bullet_text;
            theCam = GM.main_camera;
        }
        Cursor.lockState = CursorLockMode.Locked;
        UpdateBulletUI();
    }

    private void Update()
    {
        if (!pv.IsMine)
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
            pv.RPC("Reload_RPC", RpcTarget.All);
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
                    pv.RPC("Reload_RPC", RpcTarget.All);
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
        GameObject muzzleFlash_effect_clone = Instantiate(muzzleFlash_effect, fire_pos.position, fire_pos.rotation, fire_pos);
        Destroy(muzzleFlash_effect_clone, 2f);

        if (pv.IsMine)
        {
            Shoot_Ray();

            current_Bullet_cnt--;
            UpdateBulletUI();

            bool recoil_right = Random.Range(0f, 1f) < 0.5 ? true : false;
            float recoil_h = Random.Range(0f, 1f);
            float recoil_v = Random.Range(1f, 1.2f);

            player_Move.SetRecoil(recoil_right, recoil_h, recoil_v);
        }
    }

    private void UpdateBulletUI()
    {
        if (pv.IsMine)
        {
            bullet_text.SetText("<size=30>" + current_Bullet_cnt.ToString() + "</size>/" + remaining_Bullet_cnt.ToString());
        }
    }

    private void Shoot_Ray()
    {
        if(Physics.Raycast(theCam.transform.position, theCam.transform.forward, out hitInfo, range, layerMask))
        {
            //Debug.Log("Ray Hit " + hitInfo.transform.name);
            if(hitInfo.transform.tag == "Monster")
            {
                int minDamage = damage - 10 >= 0 ? damage : 0;
                int maxDamage = damage + 11;
                hitInfo.transform.GetComponent<IHit>().Hit(Random.Range(minDamage, maxDamage), hitInfo.point);
            }

            pv.RPC("SpawnTrailRPC", RpcTarget.All, hitInfo.point, hitInfo.normal);
        }
    }

    private IEnumerator SpawnTrailCoroutine(Vector3 hit_point)
    {
        Vector3 startPosition = fire_pos.position;

        if (Vector3.Distance(startPosition, hit_point) > 5f)
        {
            float time = 0;
            GameObject trail_obj = Instantiate(bulletTrail, startPosition, Quaternion.identity);
            TrailRenderer trail = trail_obj.GetComponent<TrailRenderer>();

            while (time < 1)
            {
                trail_obj.transform.position = Vector3.Lerp(startPosition, hit_point, time);
                time += Time.deltaTime / trail.time;

                yield return null;
            }

            trail_obj.transform.position = hit_point;
            Destroy(trail_obj, trail.time);
        }
    }

    [PunRPC]
    private void SpawnTrailRPC(Vector3 hit_point, Vector3 hit_normal)
    {
        //GameObject hit_effect_clone = Instantiate(hit_effect, hit_point, Quaternion.LookRotation(hit_normal), _tr);
        GameObject hit_effect_clone = Instantiate(hit_effect, hit_point, Quaternion.LookRotation(hit_normal));
        Destroy(hit_effect_clone, 5f);
        StartCoroutine(SpawnTrailCoroutine(hit_point));
    }

    [PunRPC]
    private void Reload_RPC()
    {
        animator.SetTrigger("Reload");
    }


}
