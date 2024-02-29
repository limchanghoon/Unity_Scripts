using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_CPU : MonoBehaviour
{

    public EnemyAI enemyAI;
    public UnitSpawn unitSpawn;


    private void Start()
    {
        GameManager.Instance.PlusResource(100000000);
        for (int i = 0; i < 200; ++i)
        {
            enemyAI.SpawnEnemy(1);
            unitSpawn.Spawn();
        }

        enemyAI.enabled = true;
    }
}
