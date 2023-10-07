using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tantacle : Monster
{
    public PhotonView pv;

    public MeshRenderer[] joint_meshs;
    Material material;
    public Octopus octopus;
    public bool b_Attack;
    public bool start_anim;




    public override void Hit(int damage, Vector3 point, bool isCritical = false)
    {
        if (start_anim || isDied)
            return;
        pv.RPC("Hit_RPC", RpcTarget.All, damage, point, isCritical);
    }

    [PunRPC]
    private void Hit_RPC(int damage, Vector3 point, bool isCritical = false)
    {
        base.Hit(damage, point, isCritical);
    }


    protected override void Die()
    {
        isDied = true;
        hpBarObj.SetActive(false);
        octopus.TentacleDestruction(this);

        material = Instantiate(joint_meshs[0].material);
        foreach (var joint in joint_meshs)
        {
            joint.material = material;
        }
        StartCoroutine(Dissolve_Anim());
    }


    public float dissolve_speed = .5f;
    IEnumerator Dissolve_Anim()
    {
        float t = 0.0f;
        while (t < 1f)
        {
            t += Time.deltaTime * dissolve_speed;
            material.SetFloat("_Cutoff", t);
            yield return null;
        }
        //Debug.Log("Tantacle is dissolved!");
        material.SetFloat("_Cutoff", 1);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && b_Attack)
        {
            //Debug.Log(name + " Hit " + other.gameObject.name + " : " + 10);
            other.gameObject.GetComponent<Player_HP>().Hit(20);
        }
    }

}
