using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Boss2 : BossMonster
{
    [SerializeField] Boss2Anim boss2Anim;

    [SerializeField] Transform[] dashTargets;

    public bool patternStart = false;

    float[] r_array = new float[60];


    protected override void Start()
    {
        base.Start();
        nav.isStopped = true;
        GM = GameObject.Find("GM").GetComponent<Boss2GM>();
    }

    protected override void Update()
    {
        if (isDied)
            return;

        base.Update();
        if (PhotonNetwork.IsMasterClient && patternStart)
        {
            patternStart = false;
            float r = Random.Range(0f, 1f);
            if (r < 0.05f)
                pv.RPC("DashAttack", RpcTarget.All, 0);
            else if (r < 0.10f)
                pv.RPC("DashAttack", RpcTarget.All, 1);
            else if (r < 0.15f)
                pv.RPC("DashAttack", RpcTarget.All, 2);
            else if (r < 0.20f)
                pv.RPC("DashAttack", RpcTarget.All, 3);
            else if (r < 0.25f)
                pv.RPC("DashAttack", RpcTarget.All, 4);
            else if (r < 0.30f)
                pv.RPC("DashAttack", RpcTarget.All, 5);
            else if (r < 0.35f)
                pv.RPC("DashAttack", RpcTarget.All, 6);
            else if (r < 0.40f)
                pv.RPC("DashAttack", RpcTarget.All, 7);
            else if (r < 0.45f)
                pv.RPC("DashAttack", RpcTarget.All, 8);
            else if (r < 0.70f)
            {
                pv.RPC("Change_target_RPC", RpcTarget.All, Gen_target_index());
                for(int i = 0; i < 30; ++i)
                {
                    r_array[i] = Random.Range(-10f, 20f);
                    r_array[i + 30] = Random.Range(-10f, 10f);
                }
                pv.RPC("Shoot1Attack", RpcTarget.All, r_array);
            }
            else if (r < 1.00f)
            {
                pv.RPC("Change_target_RPC", RpcTarget.All, Gen_target_index());
                pv.RPC("DashAndHammerAttack", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    void DashAttack(int point)
    {
        boss2Anim.Dash(dashTargets[point].position);
    }

    [PunRPC]
    void Shoot1Attack(float[] _r_array)
    {
        for (int i = 0; i < _r_array.Length; ++i)
            r_array[i] = _r_array[i];
        boss2Anim.Shoot1();
    }

    [PunRPC]
    void DashAndHammerAttack()
    {
        boss2Anim.DashAtk1();
    }

    public override void Hit(int damage, Vector3 point, bool isCritical = false)
    {
        if (isDied)
            return;
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
        hpBarObj.SetActive(false);

        boss2Anim.PlayDieAnim();
    }

    public void SetTarget(Transform _tr)
    {
        target = _tr;
    }

    public float Get_r_array(int index)
    {
        return r_array[index];
    }

}
