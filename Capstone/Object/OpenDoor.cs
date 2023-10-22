using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : NextAction
{
    [SerializeField] Vector3 des;
    [SerializeField] float openSpeed;

    public override void Act()
    {
        StartCoroutine(Open());
    }

    IEnumerator Open()
    {
        float t = 0f;
        while (t <= 1f)
        {
            yield return null;
            t += Time.deltaTime * openSpeed;
            transform.localPosition = Vector3.Lerp(transform.localPosition, des, t);
        }
    }
}
