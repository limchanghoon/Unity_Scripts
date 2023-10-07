using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalHit : MonoBehaviour, IHit, IGetRoot
{
    public Monster rootMonster;
    [SerializeField] GameObject root;

    public void Hit(int damage, Vector3 point, bool isCritical = true)
    {
        rootMonster.Hit(damage * 2, point, true);
    }

    public int GetHitRate()
    {
        return 2;
    }


    public GameObject GetRoot()
    {
        return root;
    }
}
