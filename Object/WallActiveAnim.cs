using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallActiveAnim : NextAction
{
    [SerializeField] Vector3 initialPos;
    [SerializeField] Vector3 initialScale;

    [SerializeField] Vector3 finistPos;
    [SerializeField] Vector3 finishScale;

    [SerializeField] float animSpeed;

    public override void Act()
    {
        StopAllCoroutines();

        transform.localPosition = initialPos;
        transform.localScale = initialScale;

        StartCoroutine(Anim());
    }

    IEnumerator Anim()
    {
        float t = 0f;
        while (t <= 1f)
        {
            yield return null;
            t += Time.deltaTime * animSpeed;
            transform.localPosition = Vector3.Lerp(initialPos, finistPos, t);
            transform.localScale = Vector3.Lerp(initialScale, finishScale, t);
        }
    }

}
