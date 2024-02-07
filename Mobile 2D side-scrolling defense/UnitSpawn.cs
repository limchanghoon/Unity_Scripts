using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitSpawn : MonoBehaviour
{
    MyObjectPool unitPool;
    int cost;
    [SerializeField] float spawnPositionX;
    [SerializeField] TextMeshProUGUI costText;

    private void Awake()
    {
        unitPool = GetComponent<MyObjectPool>();
    }

    private void Start()
    {
        cost = GameManager.Instance.unitDataDic[unitPool.GetComponent<MyObjectPool>().GetObjectPrefab().GetComponent<Unit>().GetUnitEnum()].cost;
        costText.text = cost.ToString();
    }

    public void Spawn()
    {
        if (!GameManager.Instance.ConsumeResource(cost))
            return;
        var obj = unitPool.CreateOjbect();
        var unit = obj.GetComponent<Unit>();
        obj.transform.position = new Vector3(unit.GetUnitData().spawnPosition.x, unit.GetUnitData().spawnPosition.y, GameManager.Instance.GetNextZ());
        var hpBar = PoolManager.Instance.hpbarPool.CreateOjbect().GetComponent<HPBar>();
        hpBar.SetTarget(obj.GetComponent<IGetHPbarTarget>().GetHPbarTarget());
        unit.BindHpbar(hpBar);
        obj.SetActive(true);
    }
}
