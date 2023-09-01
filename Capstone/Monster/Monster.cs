using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;
using Unity.VisualScripting;

public class Monster : MonoBehaviour, IHit
{
    // 필요한 컴퍼넌트
    [SerializeField] Transform canvasTf;
    [SerializeField] Transform hpBarTranform;
    [SerializeField] Slider hpBar;
    public NavMeshAgent nav;
    [SerializeField] Collider[] colliders;
    [SerializeField] MeshRenderer[] meshes;

    // 필요한 오브젝트
    [SerializeField] protected GameObject canvasObj;
    [SerializeField] protected GameObject hpBarObj;
    public GameObject[] damageTextObjs;
    [SerializeField] private GameObject[] death_effects;
    [SerializeField] private Popping_Cube[] pops;
    List<GameObject> pop_objs = new List<GameObject>();

    // 변수
    public string monsterName;
    [SerializeField] protected float maxHp;
    [SerializeField] protected float curHp;
    public Camera theCam;
    protected Animator animator;



    public Vector3 respawnPos;
    public Quaternion respawnRot;

    public bool isDied = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        if(GetComponent<Animator>() != null)
            animator = GetComponent<Animator>();
        if (GetComponent<NavMeshAgent>() != null)
            nav = GetComponent<NavMeshAgent>();
        curHp = maxHp;
        hpBar.value = curHp / maxHp;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (isDied)
            return;
        hpBar.value = curHp / maxHp;
        if(canvasTf != null)
            canvasTf.LookAt(theCam.transform);
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
        QuestController.Instance.Notify_Kill(monsterName);
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
            pop_objs.Add(pop.PopCube());
        }

        if (nav != null)
            nav.isStopped = true;

        foreach (GameObject death_effect in death_effects)
        {
            if (!death_effect.activeSelf)
            {
                death_effect.transform.position = transform.position;
                death_effect.SetActive(true);
                break;
            }
        }
        if(pop_objs.Count > 0)
            StartCoroutine(DestroyCoroutine());
    }


    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(8);
        foreach (GameObject obj in pop_objs)
            Destroy(obj);
    }


    public void ResetMonster()
    {
        transform.position = respawnPos;
        transform.rotation = respawnRot;

        foreach (MeshRenderer mesh in meshes)
        {
            mesh.enabled = true;
        }
        foreach (Collider col in colliders)
        {
            col.enabled = true;
        }

        curHp = maxHp;
        hpBar.value = curHp / maxHp;
        hpBarObj.SetActive(true);

        isDied = false;
        if(animator != null)
            animator.Rebind();
    }
}
