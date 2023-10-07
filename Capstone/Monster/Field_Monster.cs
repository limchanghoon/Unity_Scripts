using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Field_Monster : Monster
{
    public int drop_item_Id = 0;
    public int drop_item_count = 1;

    public Transform target;
    bool isIdle = true;

    protected override void Start()
    {
        base.Start();
    }

    public override void Hit(int damage, Vector3 point, bool isCritical = false)
    {
        if (isIdle)
        {
            isIdle = false;
            nav.isStopped = false;
            StartCoroutine(SetDestination());
        }
        base.Hit(damage, point, isCritical);
    }

    protected override void Die()
    {
        StopAllCoroutines();
        base.Die();
        isIdle = true;
        CFirebase.Instance.GetItem(drop_item_Id, drop_item_count);
    }

    IEnumerator SetDestination()
    {
        while (true)
        {
            nav.SetDestination(new Vector3(target.position.x, 3, target.position.z));
            yield return new WaitForSeconds(0.2f);
        }
    }
}
