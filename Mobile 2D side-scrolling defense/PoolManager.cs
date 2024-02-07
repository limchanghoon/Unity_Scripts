using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    static private PoolManager instance;
    static public PoolManager Instance
    {
        get { return instance; }
    }

    Dictionary<string,MyObjectPool> objectPoolDic = new Dictionary<string,MyObjectPool>();

    public MyObjectPool hpbarPool;
    public MyObjectPool arrowPool;
    public MyObjectPool beanPool;
    public MyObjectPool windPool;
    public MyObjectPool darkAttackPool;
    public MyObjectPool damageTextPool;
    public MyObjectPool[] enemyPool;
    [SerializeField] int enemyPoolindex;

    private void Awake()
    {
        instance = this;
    }
}
