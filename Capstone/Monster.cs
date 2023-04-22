using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

public class Monster : MonoBehaviour, IHit
{
    // 필요한 컴퍼넌트
    [SerializeField] Transform canvasTf;
    [SerializeField] Transform hpBarTranform;
    [SerializeField] Slider hpBar;
    [SerializeField] NavMeshAgent nav;
    [SerializeField] Collider[] colliders;
    [SerializeField] MeshRenderer[] meshes;

    // 필요한 오브젝트
    [SerializeField] protected GameObject canvasObj;
    [SerializeField] protected GameObject hpBarObj;
    public GameObject[] damageTextObjs;
    [SerializeField] private GameObject death_effect;
    [SerializeField] private Popping_Cube[] pops;

    // 변수
    [SerializeField] protected float maxHp;
    [SerializeField] protected float curHp;
    [SerializeField] float damageTextUpLength;
    public Camera theCam;
    protected Animator animator;



    public Vector3 respawnPos;
    public Quaternion respawnRot;

    protected bool isChased = false;
    protected bool isDied = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        hpBar.value = curHp / maxHp;
        curHp = maxHp;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (isDied)
            return;
        hpBar.value = curHp / maxHp;

        canvasTf.LookAt(theCam.transform);

        /*
        Quaternion q_hp = Quaternion.LookRotation(hpBarTranform.position - Camera.main.transform.position);

        Vector3 hp_angle = Quaternion.RotateTowards(canvasTf.rotation, q_hp, 200).eulerAngles;

        canvasTf.rotation = Quaternion.Euler(0, hp_angle.y, 0);
        */
    }


    public virtual void Hit(int damage, Vector3 point)
    {
        if (isDied)
            return;
        curHp -= damage;
        foreach(GameObject textObj in damageTextObjs)
        {
            if(!textObj.activeSelf)
            {
                textObj.GetComponent<DamageText>().text.text = damage.ToString();
                textObj.transform.position = point;
                textObj.SetActive(true);
                break;
            }
        }
        if(curHp <= 0)
        {
            Die();
        }
    }


    protected virtual void Die()
    {
        isDied = true;
        hpBarObj.SetActive(false);
        foreach(Collider col in colliders)
        {
            col.enabled = false;
        }        
        foreach(MeshRenderer mesh in meshes)
        {
            mesh.enabled = false;
        }
        foreach (Popping_Cube pop in pops)
        {
            pop.PopCube();
        }

        if (nav != null)
            nav.isStopped = true;

        if (death_effect!=null)
            death_effect.SetActive(true);

        Destroy(gameObject,10f);
    }


    public void ResetMonster()
    {
        transform.position = respawnPos;
        transform.rotation = respawnRot;
        isChased = false;
        isDied = false;

        curHp = maxHp;
        hpBarObj.SetActive(true);

        animator.Rebind();
    }
}
