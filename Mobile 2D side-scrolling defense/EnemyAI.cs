using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    int count;
    public float[] timer;
    [SerializeField] float[] generateCost;
    private void Start()
    {
        count = PoolManager.Instance.enemyPool.Length;
        timer = new float[count];
        generateCost = new float[count];

        for(int i = 0; i < count; i++)
        {
            generateCost[i] = GameManager.Instance.unitDataDic[PoolManager.Instance.enemyPool[i].GetObjectPrefab().GetComponent<Unit>().GetUnitEnum()].cost;
        }
    }

    private void Update()
    {
        if (GameManager.Instance.gameState != GameState.Play)
            return;
        for (int i = 0; i < count; i++)
        {
            timer[i] += Time.deltaTime * GameManager.Instance.stageData.generateRate;
            while (timer[i] >= generateCost[i])
            {
                timer[i] -= generateCost[i];
                SpawnEnemy(i);
            }
        }
    }


    public void SpawnEnemy(int i)
    {
        var obj = PoolManager.Instance.enemyPool[i].CreateOjbect();
        var unit = obj.GetComponent<Unit>();
        obj.transform.position = new Vector3(unit.GetUnitData().spawnPosition.x + Random.Range(-0.3f, 0.3f), unit.GetUnitData().spawnPosition.y, GameManager.Instance.GetNextZ());
        var hpBar = PoolManager.Instance.hpbarPool.CreateOjbect().GetComponent<HPBar>();
        hpBar.SetTarget(obj.GetComponent<IGetHPbarTarget>().GetHPbarTarget());
        unit.BindHpbar(hpBar);
        obj.SetActive(true);
    }
}
