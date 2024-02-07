using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : PoolingObject
{
    Transform target;
     
    private void LateUpdate()
    {
        transform.position = target.position;
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
}
