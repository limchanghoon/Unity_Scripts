using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    Unit unit;

    private void Awake()
    {
        unit = GetComponent<Unit>();
    }

    public void MagicAttack()
    {
        GameObject obj = tag == "Player" ? PoolManager.Instance.windPool.CreateOjbect() : PoolManager.Instance.darkAttackPool.CreateOjbect();
        var hit = unit.GetHitTarget();
        if (hit)
            obj.transform.position = new Vector3(hit.point.x, transform.position.y + 1.2f, 0);
        else
            obj.transform.position = transform.position + Vector3.right * unit.GetRayDistance() + Vector3.up * 1.2f;

        var rangeAttackCheck = obj.GetComponent<RangeAttackCheck>();
        rangeAttackCheck.StartAttack();
    }
}
