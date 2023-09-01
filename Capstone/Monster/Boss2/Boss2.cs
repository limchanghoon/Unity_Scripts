using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Boss2 : BossMonster
{
    [SerializeField] Boss2Anim boss2Anim;

    [SerializeField] Transform target;

    [SerializeField] Transform[] dashTargets;
    GameManager GM;

    public bool patternStart = false;

    protected override void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.isStopped = true;
        base.Start();
        GM = GameObject.Find("GM").GetComponent<Boss2GM>();
    }

    protected override void Update()
    {
        base.Update();
        if (PhotonNetwork.IsMasterClient && patternStart)
        {
            patternStart = false;
            float r = Random.Range(0f, 1f);
            if (r < 0.02f)
            {
                boss2Anim.Dash(dashTargets[0].position);
            }
            else if (r < 0.04f)
            {
                boss2Anim.Dash(dashTargets[1].position);
            }
            else if (r < 0.06f)
            {
                boss2Anim.Dash(dashTargets[2].position);
            }
            else if (r < 0.08f)
            {
                boss2Anim.Dash(dashTargets[3].position);
            }
            else if (r < 0.10f)
            {
                boss2Anim.Dash(dashTargets[4].position);
            }
            else if (r < 0.12f)
            {
                boss2Anim.Dash(dashTargets[5].position);
            }
            else if (r < 0.14f)
            {
                boss2Anim.Dash(dashTargets[6].position);
            }
            else if (r < 0.16f)
            {
                boss2Anim.Dash(dashTargets[7].position);
            }
            else if (r < 0.20f)
            {
                boss2Anim.Dash(dashTargets[8].position);
            }
            else if (r < 0.45f)
            {
                boss2Anim.Shoot1();
            }
            else if (r < 1f)
            {
                boss2Anim.DashAtk1();
            }
        }
    }

    public void SetTarget(Transform _tr)
    {
        target = _tr;
    }
}
