using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2GM : GameManager
{
    [SerializeField] ParticleSystem[] waves;
    [SerializeField] Boss2 boss2;
    [SerializeField] Boss2Anim boss2Anim;

    protected new void Start()
    {
        base.Start();
    }

    public override void SetGameComponent()
    {
        Debug.Log("SetGameComponent");
        //targetsDic[targets[i]].GetComponent<Player_Spine>().TurnOnLight();
        foreach(var wave in waves)
        {
            wave.trigger.AddCollider(myPlayer.GetComponent<CapsuleCollider>());
        }
        boss2.patternStart = true;
    }
}
