using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackCheck : PoolingObject
{
    Animator animator;
    [SerializeField] Vector2 myCubeSize;
    [SerializeField] UnitScriptableObject unitScriptableObject;
    [SerializeField] string opponentTag;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void AttackCheck()
    {
        var colliders = Physics2D.OverlapBoxAll(transform.position, myCubeSize, 0);
        foreach(var col in colliders)
        {
            if (col.tag == opponentTag)
            {
                var hit = col.GetComponent<IHit>();
                hit?.Hit(unitScriptableObject.power);
            }
        }
    }

    public void StartAttack()
    {
        animator.SetTrigger("Attack");
        Invoke("DestroyObject", 3f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, myCubeSize);
    }
}
