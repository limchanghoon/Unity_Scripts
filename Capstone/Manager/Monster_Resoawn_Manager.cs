using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Resoawn_Manager : MonoBehaviour
{
    public Monster[] monsters;

    private void Start()
    {
        StartCoroutine(Respawn_Coroutine());
    }

    IEnumerator Respawn_Coroutine()
    {
        yield return new WaitForSeconds(10);
        foreach (Monster monster in monsters)
        {
            if (monster.isDied)
                monster.ResetMonster();
        }
        StartCoroutine(Respawn_Coroutine());
    }
}
