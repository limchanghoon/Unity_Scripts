using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndReturn : NextAction
{
    [SerializeField] Vector3 initialPos;

    [SerializeField] float retrunSpeed;
    [SerializeField] float waitSpeed;
    [SerializeField] float moveSpeed;

    bool move = true;

    private void Update()
    {
        if (transform.localPosition.z >= 100f)
            move = false;

        if (move)
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.Self);
    }

    public override void Act()
    {
        StartCoroutine(ReturnTpInitial());
    }

    IEnumerator ReturnTpInitial()
    {
        move = false;

        float t = 0f;
        Vector3 prePos = transform.localPosition;
        while (t <= 1f)
        {
            yield return null;
            t += Time.deltaTime * retrunSpeed;
            transform.localPosition = Vector3.Lerp(prePos, initialPos, t);
        }

        t = 0f;
        while (t <= 1f)
        {
            yield return null;
            t += Time.deltaTime * waitSpeed;
        }

        move = true;
    }
}
