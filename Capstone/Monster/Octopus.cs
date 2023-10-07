using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

public class Octopus : BossMonster
{
    public CameraShake cameraShake;

    public List<Transform> t_Targets = new List<Transform>();
    public List<Tantacle> tantacles = new List<Tantacle>();

    public Material material;
    public GameObject[] bigdangerAreas;
    public GameObject[] bigflags;
    public GameObject[] bigExplosions;

    public GameObject[] sunken_Areas;
    public GameObject[] sunkens;
    [SerializeField] private Transform[] sunkensTr;

    public GameObject hammer;
    public Transform hammerTarget;
    public MeshRenderer[] hammerMeshRenderers;
    private Material hammer_material;
    private int hammerCnt = 0;

    public ParticleSystem[] explosions;
    private int curExplosion = 0;
    public GameObject dangerArea;

    [SerializeField] private int current_tantacle = 0;
    [SerializeField] private float t_lerp;
    [SerializeField] private Vector3 t_oldPos;
    [SerializeField] private Vector3 t_newPos;

    [SerializeField]  private bool dont_update = true;
    private bool invincibility = true;
    public bool b_tAtk;
    public bool b_tAtk_reset = false;
    public bool b_jump_Atk;
    public bool b_body_Atk;
    public bool chase;
    //[SerializeField] private Vector3 oldPos;
    //[SerializeField] private Vector3 newPos;
    //[SerializeField] private float lerp;
    [SerializeField] private float speed1;
    [SerializeField] private float speed2;
    [SerializeField] private float stepHeight;
    // chase => 7f, 정적인 경우 => 10f
    [SerializeField] private float cor;
    [SerializeField] private float moveSpeed;

    private int phase = 1;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hammer_material = Instantiate(material);
        foreach (MeshRenderer mr in hammerMeshRenderers)
        {
            mr.material = hammer_material;
        }
        sunkensTr = new Transform[sunkens.Length];
        for (int i = 0; i < sunkens.Length; i++)
        {
            sunkensTr[i] = sunkens[i].GetComponent<Transform>();
        }

        StartCoroutine(start_Anim());
        
        //chase = true;
        //lerp = 10;
        //b_tAtk = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (dont_update)
            return;

        switch (phase)
        {
            case 1:
                //jump_Atk_In_Update();                    
                t_Atk_In_Update();
                chase_In_Update();
                break;
            case 2:
                if (PhotonNetwork.IsMasterClient)
                    Phase2RandomAttack();
                break;
            default:
                Debug.Log("phase : " + phase);
                break;

        }
    }

    /*
    private void jump_Atk_In_Update() 
    {
        if (b_jump_Atk)
        {
            if (lerp < 1)
            {
                Vector3 pos = Vector3.Lerp(oldPos, newPos, lerp);
                pos.y += Mathf.Sin(lerp * Mathf.PI) * stepHeight;

                transform.position = pos;
                lerp += Time.deltaTime * speed1;
            }
            else
            {
                oldPos = newPos;
                b_body_Atk = false;
            }
        }
    }
    */

    private void t_Atk_In_Update()
    {
        if (b_tAtk)
        {
            if (b_tAtk_reset)
            {
                b_tAtk_reset = false;
                if (tantacles.Count == 0)
                {
                    b_tAtk = false;
                    return;
                }
                else
                {
                    current_tantacle = (++current_tantacle) % tantacles.Count;
                    t_lerp = 11f;
                }
            }
            if (t_lerp < 1)
            {
                Vector3 pos = Vector3.Lerp(t_oldPos, t_newPos, t_lerp);
                pos.y += Mathf.Sin(t_lerp * Mathf.PI) * stepHeight;

                t_Targets[current_tantacle].position = pos;
                t_lerp += Time.deltaTime * speed2;
            }
            else
            {
                t_oldPos = t_newPos;
                b_tAtk = false;
                tantacles[current_tantacle].b_Attack = false;
                //current_tantacle = (++current_tantacle) % tantacles.Count;
                StartCoroutine(test2());
            }
        }
    }

    private void chase_In_Update() 
    {
        if (chase && Vector3.Distance(target.position, transform.position) > 25f)
        {
            Vector3 v3 = target.position - transform.position;
            v3.y = 0;
            v3 = moveSpeed * (v3.normalized);
            transform.Translate(v3);
        }
    }

    /*
    IEnumerator test()
    {
        yield return new WaitForSeconds(3f);
        Vector3 pre = target.position;
        yield return new WaitForFixedUpdate();
        Vector3 post = target.position;

        SetNewPos((post - pre).normalized);
        if(b_jump_Atk)
            StartCoroutine(test());
    }
    */

    IEnumerator test2()
    {
        //yield return new WaitForSeconds(3f);
        Vector3 pre = target.position;
        yield return new WaitForFixedUpdate();
        Vector3 post = target.position;
        TantacleAttack((post - pre).normalized);
    }


    public float appear_speed = .5f;
    IEnumerator start_Anim()
    {
        float t = 1.0f;
        while (t > 0f)
        {
            t -= Time.deltaTime* appear_speed;
            material.SetFloat("_Cutoff", t);
            yield return null;
        }
        if (PhotonNetwork.IsMasterClient)
            pv.RPC("Change_target_RPC", RpcTarget.All, Gen_target_index());
        Debug.Log("Start Anim FIN");
        material.SetFloat("_Cutoff", 0);
        chase = true;
        //lerp = 10;
        b_tAtk = true;
        dont_update = false;
        foreach(Tantacle tt in tantacles)
        {
            tt.start_anim = false;
        }
    }

    IEnumerator Phase2Coroutine()
    {
        chase = false;
        Vector3 _oldPos = transform.position;
        Vector3 _newPos = new Vector3(0, 20, 0);
        float lerp = 0.0f;
        while (lerp < 1f)
        {
            lerp += Time.deltaTime * 0.3f;
            transform.position = Vector3.Lerp(_oldPos, _newPos, lerp);
            yield return null;
        }
        animator.Play("Phase2");
    }

    public void Phase2_Starting_Anim_End()
    {
        invincibility = false;
        phase = 2;
    }

    /*
    public void SetNewPos(Vector3 correction)
    {
        b_body_Atk = true;
        //lerp = 0;
        newPos = target.position + correction * cor;
        oldPos = transform.position;
    }
    */

    public void TantacleAttack(Vector3 correction)
    {
        b_tAtk = true;
        t_lerp = 0;
        t_newPos = target.position + correction * cor;
        t_newPos.y = 0.1f;
        if (tantacles.Count == 0)
            return;
        current_tantacle = (++current_tantacle) % tantacles.Count;
        t_oldPos = t_Targets[current_tantacle].position;
        tantacles[current_tantacle].b_Attack = true;

        if (PhotonNetwork.IsMasterClient && GM.target_count != 1)
        {
            int _ran = UnityEngine.Random.Range(0, 10);
            if (_ran == 0)
                pv.RPC("Change_target_RPC", RpcTarget.All, Gen_target_index_not_same());
        }
    }

    private void Phase2RandomAttack()
    {
        dont_update = true;

        int pattern = UnityEngine.Random.Range(0, 100);
        if(pattern < 40)
        {
            int r1 = UnityEngine.Random.Range(0, 4);
            int r2;
            while (true)
            {
                r2 = UnityEngine.Random.Range(0, 4);
                if (r1 != r2)
                    break;
            }
            pv.RPC("ElectricExplosion_RPC", RpcTarget.All, r1, r2);
        }
        else if(pattern < 80)
        {
            int r3 = UnityEngine.Random.Range(0, 2);
            pv.RPC("Sunken_Stab_RPC", RpcTarget.All, r3);
        }
        else
        {
            pv.RPC("HammerAppear_RPC", RpcTarget.All, Gen_target_index());
        }
       
    }

    [PunRPC]
    private void ElectricExplosion_RPC(int p1, int p2)
    {
        StartCoroutine(ElectricExplosion(p1, p2));
    }

    IEnumerator ElectricExplosion(int p1, int p2)
    {
        int[] values = { p1, p2 };
        foreach(int i in values)
        {
            bigdangerAreas[i].SetActive(true);
        }
        yield return new WaitForSeconds(3f);
        foreach (int i in values)
        {
            bigflags[i].SetActive(false);
            bigdangerAreas[i].SetActive(false);
            ParticleSystem[] particleSystems = bigExplosions[i].GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem particleSystem in particleSystems)
            {
                particleSystem.Play();
            }
            Collider[] colliders = Physics.OverlapBox(bigdangerAreas[i].transform.position, new Vector3(20, 20, 20));
            foreach (Collider col in colliders)
            {
                if (col.tag == "Player")
                {
                    col.GetComponent<Player_HP>().Hit(30);
                }
            }
        }
        dont_update = false;
    }

    [PunRPC]
    private void Sunken_Stab_RPC(int num)
    {
        StartCoroutine(Sunken_Stab(num));
    }

    IEnumerator Sunken_Stab(int num)
    {
        sunken_Areas[num].SetActive(true);
        yield return new WaitForSeconds(2f);
        sunken_Areas[num].SetActive(false);

        sunkens[num].SetActive(true);
        Vector3 _pos1 = new Vector3(0, 0, 0);
        Vector3 _pos2 = new Vector3(0, 11, 0);
        float lerp = 0.0f;
        while (lerp < 1f)
        {
            lerp += Time.deltaTime * 1f;
            sunkensTr[num].position = Vector3.Lerp(_pos1, _pos2, lerp);
            yield return null;
        }
        lerp = 0.0f;
        while (lerp < 1f)
        {
            lerp += Time.deltaTime * 1f;
            sunkensTr[num].position = Vector3.Lerp(_pos2, _pos1, lerp);
            yield return null;
        }
        sunkens[num].SetActive(false);
        dont_update = false;
    }

    IEnumerator HammerShot()
    {
        Vector3 _oldPos = hammerTarget.position;
        Vector3 _newPos = new Vector3(0f,100f,0f);
        float lerp = 0.0f;
        while (lerp < 1f)
        {
            lerp += Time.deltaTime*0.5f;
            hammerTarget.position = Vector3.Lerp(_oldPos, _newPos, lerp);
            yield return null;
        }
        _oldPos = hammerTarget.position;
        _newPos = target.position;

        if (PhotonNetwork.IsMasterClient)
            pv.RPC("Change_target_RPC", RpcTarget.All, Gen_target_index());


        lerp = 0.0f;
        while (lerp < 1f)
        {
            lerp += Time.deltaTime * 2f;
            hammerTarget.position = Vector3.Lerp(_oldPos, _newPos, lerp);
            yield return null;
        }
        cameraShake.Shake();

        if (--hammerCnt > 0)
            StartCoroutine(HammerShot());
        else
            StartCoroutine(HammerDissolve());
    }

    [PunRPC]
    private void HammerAppear_RPC(int index)
    {
        target = GM.targetsDic[GM.actNumberList[index]];
        StartCoroutine(HammerAppear());
    }

    public float hammer_appear_speed = .5f;
    IEnumerator HammerAppear() 
    {
        hammerCnt = 5;
        hammer.SetActive(true);
        float t = 1.0f;
        while (t > 0f)
        {
            t -= Time.deltaTime * hammer_appear_speed;
            hammer_material.SetFloat("_Cutoff", t);
            yield return null;
        }
        hammer_material.SetFloat("_Cutoff", 0);
        StartCoroutine(HammerShot());
    }

    IEnumerator HammerDissolve()
    {
        float t = 0.0f;
        while (t < 1f)
        {
            t += Time.deltaTime * hammer_appear_speed;
            hammer_material.SetFloat("_Cutoff", t);
            yield return null;
        }
        hammer_material.SetFloat("_Cutoff", 1);
        hammer.SetActive(false);
        hammerTarget.position = new Vector3(0f, 100f, 0f);
        if(!isDied)
            dont_update = false;
    }

    public override void Hit(int damage, Vector3 point, bool isCritical = false)
    {
        if (isDied)
            return;
        if (invincibility)
            damage = 0;
        pv.RPC("Hit_RPC", RpcTarget.All, damage, point, isCritical);
    }

    [PunRPC]
    private void Hit_RPC(int damage, Vector3 point, bool isCritical = false)
    {
        base.Hit(damage, point, isCritical);//문제면 여기가 문제!!
    }

    protected override void Die()
    {
        isDied = true;
        dangerArea.SetActive(false);
        hpBarObj.SetActive(false);

        StopAllCoroutines();
        StartCoroutine(HammerDissolve());
        dont_update = true;
        animator.Play("Die");
    }

    public void Explosion()
    {
        explosions[curExplosion].Play();
        curExplosion = (++curExplosion) % explosions.Length;
    }

    public void TentacleDestruction(Tantacle tantacle)
    {
        int index = tantacles.IndexOf(tantacle);
        tantacles.RemoveAt(index);
        t_Targets.RemoveAt(index);
        b_tAtk_reset = true;

        if (tantacles.Count == 0)
        {
            b_tAtk = false;
            StartCoroutine(Phase2Coroutine());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && b_body_Atk)
        {
            Debug.Log(name + "Hit You : " + 50);
            other.gameObject.GetComponent<Player_HP>().Hit(50);
        }
    }


}
