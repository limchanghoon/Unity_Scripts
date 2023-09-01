using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTest : MonoBehaviour
{
    ParticleSystem ps;

    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

    bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void OnParticleTrigger()
    {
        Debug.Log("OnParticleCollision : " + ps.trigger.colliderCount + "°³ " + ps.trigger.GetCollider(0).gameObject.name);
        ps.trigger.GetCollider(0).GetComponent<Player_HP>().Hit(10);
    }
}
