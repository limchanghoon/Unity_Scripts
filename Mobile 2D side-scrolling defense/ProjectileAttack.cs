using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    Unit unit;
    [SerializeField] Transform startTr;

    private void Awake()
    {
        unit = GetComponent<Unit>();
    }

    public void ActiveProjectile()
    {
        GameObject obj = tag == "Player" ? PoolManager.Instance.arrowPool.CreateOjbect() : PoolManager.Instance.beanPool.CreateOjbect();
        obj.transform.position = startTr.position;
        obj.transform.rotation = startTr.rotation;
        var hit = unit.GetHitTarget();
        var arrow = obj.GetComponent<Projectile>();
        if (hit)
            arrow.destination = hit.point;
        else
            arrow.destination = transform.position + Vector3.right * unit.GetRayDistance() + Vector3.up * 1.2f;
        arrow.Shoot(unit.GetPower());
    }
}
