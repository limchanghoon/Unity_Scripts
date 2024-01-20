using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

using Random = UnityEngine.Random;

public enum GunType : byte
{
    Rifle=0,
    Sniper
}

public class Gun : MonoBehaviour
{
    [SerializeField] PhotonView pv;

    // 필요한 컴퍼넌트
    [SerializeField] Animator animator;
    [SerializeField] private Player_Move player_Move;
    public Transform fire_pos;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioClip RocketSound;
    [SerializeField] AudioClip portalGunSound;
    [SerializeField] AudioClip[] reloadSounds;
    [SerializeField] private Camera theCam;
    [SerializeField] private Camera uiCam;
    [SerializeField] private Transform magazine_transform;
    [SerializeField] private Transform leftHand_transform;
    [SerializeField] private TextMeshProUGUI bullet_text;
    [SerializeField] private Skill_Cooldown rocketCooldown;


    // 필요한 오브젝트
    public GameObject miniRocketPrefab;
    public GameObject portalBulletA;
    public GameObject portalBulletB;
    GameObject[] hit_effects;
    public GameObject[] muzzleFlash_effects;
    GameObject[] bulletTrails;
    [SerializeField] private RectTransform[] crossHair;
    [SerializeField] GameObject[] Magazine_prefabs;
    Transform center_TR;


    // 레이저 충돌 정보 받아옴.
    private RaycastHit hitInfo;
    int layerMask;


    // 변수
    [SerializeField] private float layerTransSpeed;
    public float range;
    [SerializeField] private bool isReload = false;
    [SerializeField] private bool isDroped = false;
    [SerializeField] private int current_Bullet_cnt;
    [SerializeField] private int remaining_Bullet_cnt;
    [SerializeField] private int magazine_size;
    [SerializeField] private bool canPortalGun;

    [SerializeField] private bool isQCoolDown;

    bool isZoomed = false;


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
        uiCam = GM.ui_camera;
        center_TR = GM.center_TR;

        crossHair[0] = GameObject.Find("CrossHairUp").GetComponent<RectTransform>();
        crossHair[1] = GameObject.Find("CrossHairRight").GetComponent<RectTransform>();
        crossHair[2] = GameObject.Find("CrossHairDown").GetComponent<RectTransform>();
        crossHair[3] = GameObject.Find("CrossHairLeft").GetComponent<RectTransform>();

        UpdateBulletUI();

        rocketCooldown = GM.rocketCooldown;
    }

    private void Update()
    {
        if (pv && !pv.IsMine)
            return;
               
        SetRunLayer();

        if (ETC_Memory.Instance.windowDepth > 0)
            return;

        if (Input.GetMouseButton(1))
        {
            if (!isZoomed)
            {
                isZoomed = true;
                crossHair[0].anchoredPosition = new Vector3(0f, 20f, 0f);
                crossHair[1].anchoredPosition = new Vector3(20f, 0f, 0f);
                crossHair[2].anchoredPosition = new Vector3(0f, -20f, 0f);
                crossHair[3].anchoredPosition = new Vector3(-20f, 0f, 0f);
                player_Move.SetMoveSpeed(4f);
            }
            float fov = theCam.fieldOfView;
            fov = Mathf.Clamp(fov - Time.deltaTime * 100f, 30f, 60f);
            theCam.fieldOfView = fov;
            uiCam.fieldOfView = fov;
        }
        else
        {
            if (isZoomed)
            {
                isZoomed = false;
                crossHair[0].anchoredPosition = new Vector3(0f, 30f, 0f);
                crossHair[1].anchoredPosition = new Vector3(30f, 0f, 0f);
                crossHair[2].anchoredPosition = new Vector3(0f, -30f, 0f);
                crossHair[3].anchoredPosition = new Vector3(-30f, 0f, 0f);
                player_Move.SetMoveSpeed(8f);
            }

            float fov = theCam.fieldOfView;
            fov = Mathf.Clamp(fov + Time.deltaTime * 100f, 30f, 60f);
            theCam.fieldOfView = fov;
            uiCam.fieldOfView = fov;
        }

        if (isReload)
            return;

        if (Input.GetKeyDown(ETC_Memory.Instance.myOption.keyOption.GetKeyCode(KeySetting.RELOAD)) && remaining_Bullet_cnt > 0 && current_Bullet_cnt < magazine_size)
        {
            animator.SetBool("Atk", false);
            isReload = true;
            if (pv)
                pv.RPC("Reload_RPC", RpcTarget.All);
            else
                Reload_RPC();
        }
        else if (Input.GetKeyDown(ETC_Memory.Instance.myOption.keyOption.GetKeyCode(KeySetting.ROCKET)) && isQCoolDown == false)
        {
            StartCoroutine(ShotRocket());
            if (PhotonNetwork.InRoom)
                PhotonNetwork.Instantiate("Mini Rocket", fire_pos.position, theCam.transform.rotation, 0, new object[] { center_TR.position });
            else
                Instantiate(miniRocketPrefab, fire_pos.position, theCam.transform.rotation);

            audioSource.PlayOneShot(RocketSound, 0.7f);
        }
        else if (Input.GetKeyDown(ETC_Memory.Instance.myOption.keyOption.GetKeyCode(KeySetting.PORTAL_RED)) && canPortalGun)
        {
            if (PhotonNetwork.InRoom)
                PhotonNetwork.Instantiate("Portal Bullet A", fire_pos.position, theCam.transform.rotation);
            else
                Instantiate(portalBulletA, fire_pos.position, theCam.transform.rotation);

            audioSource.PlayOneShot(portalGunSound, 0.7f);
        }
        else if (Input.GetKeyDown(ETC_Memory.Instance.myOption.keyOption.GetKeyCode(KeySetting.PORTAL_BLUE)) && canPortalGun)
        {
            if (PhotonNetwork.InRoom)
                PhotonNetwork.Instantiate("Portal Bullet B", fire_pos.position, theCam.transform.rotation);
            else
                Instantiate(portalBulletB, fire_pos.position, theCam.transform.rotation);

            audioSource.PlayOneShot(portalGunSound, 0.7f);
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
            if (!animator.GetBool("Atk"))
            {
                animator.SetBool("Atk", true);
            }
            animator.SetLayerWeight(1, 1);
        }
        else
        {
            if (animator.GetBool("Atk"))
            {
                animator.SetBool("Atk", false);
            }
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
        //remaining_Bullet_cnt -= reloading_count;
        UpdateBulletUI();

        isReload = false;
        isDroped = false;
    }

    public void Drop_magazine()
    {
        if (isDroped)
            return;
        isDroped = true;
        GameObject droped_magazine = Instantiate(Magazine_prefabs[(int)Player_Info.Instance.gunType], magazine_transform.position, magazine_transform.rotation);
        Destroy(droped_magazine, 10f);
    }


    public void Shoot()
    {
        foreach(GameObject muzzleFlash_effect in muzzleFlash_effects)
        {
            if (!muzzleFlash_effect.activeSelf)
            {
                muzzleFlash_effect.transform.parent = fire_pos;
                muzzleFlash_effect.transform.localPosition= Vector3.zero;
                muzzleFlash_effect.transform.localEulerAngles= Vector3.zero;
                //fire_pos
                muzzleFlash_effect.SetActive(true);
                audioSource.PlayOneShot(shootSound, 0.1f);
                break;
            }
        }
        if (pv && !pv.IsMine)
            return;

        Shoot_Ray();

        current_Bullet_cnt--;
        UpdateBulletUI();

        bool recoil_right = Random.Range(0f, 1f) < 0.5 ? true : false;
        float recoil_h = isZoomed ? Random.Range(0f, 1f) : Random.Range(0f, 2f);
        float recoil_v = isZoomed ? Random.Range(1f, 1.2f) : Random.Range(2f, 2.4f);

        player_Move.SetRecoil(recoil_right, recoil_h, recoil_v);
    }

    private void UpdateBulletUI()
    {
        if (pv && !pv.IsMine)
            return;
        bullet_text.SetText("<size=30>" + current_Bullet_cnt.ToString() + "</size>/∞");
        //bullet_text.SetText("<size=30>" + current_Bullet_cnt.ToString() + "</size>/" + remaining_Bullet_cnt.ToString());
    }

    private void Shoot_Ray()
    {
        if(Physics.Raycast(theCam.transform.position, theCam.transform.forward, out hitInfo, range, layerMask))
        {
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

    private IEnumerator SpawnTrailCoroutine(Vector3 hit_point, Vector3 hit_normal)
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

            foreach (GameObject hit_effect in hit_effects)
            {
                if (!hit_effect.activeSelf)
                {
                    hit_effect.transform.position = hit_point;
                    hit_effect.transform.rotation = Quaternion.LookRotation(hit_normal);
                    hit_effect.SetActive(true);
                    hit_effect.GetComponent<AudioSource>().Play();
                    break;
                }
            }

            bulletTrails[i].transform.position = hit_point;
            yield return new WaitForSeconds(trail.time);
            bulletTrails[i].SetActive(false);
        }
        else
        {
            foreach (GameObject hit_effect in hit_effects)
            {
                if (!hit_effect.activeSelf)
                {
                    hit_effect.transform.position = hit_point;
                    hit_effect.transform.rotation = Quaternion.LookRotation(hit_normal);
                    hit_effect.SetActive(true);
                    hit_effect.GetComponent<AudioSource>().Play();
                    break;
                }
            }
        }
    }

    [PunRPC]
    private void SpawnTrailRPC(Vector3 hit_point, Vector3 hit_normal)
    {
        StartCoroutine(SpawnTrailCoroutine(hit_point, hit_normal));
    }

    [PunRPC]
    private void Reload_RPC()
    {
        animator.SetTrigger("Reload");
    }

    public void PlayReloadSound(int idx)
    {
        audioSource.PlayOneShot(reloadSounds[idx]);
    }


    IEnumerator ShotRocket()
    {
        isQCoolDown = true;
        yield return rocketCooldown.CooldownCoroutine(5f);
        isQCoolDown = false;
    }


}
