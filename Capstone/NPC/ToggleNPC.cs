using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleNPC : MonoBehaviour, IInteract
{
    public GameObject[] objs;
    public NextAction[] actions;
    int idx = 0;

    float animSpeed = 10f;

    [SerializeField] Vector3 initialPos;
    [SerializeField] Vector3 finistPos;

    public void Interact()
    {
        objs[idx].SetActive(false);

        IndexUp();

        objs[idx].SetActive(true);

        if (actions.Length >= idx && actions[idx] != null)
            actions[idx].Act();

        StopAllCoroutines();
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
        }

        t = 0f;
        while (t <= 1f)
        {
            yield return null;
            t += Time.deltaTime * animSpeed;
            transform.localPosition = Vector3.Lerp(finistPos, initialPos, t);
        }
    }

    void IndexUp()
    {
        idx = idx + 1 == objs.Length ? 0 : idx + 1;
    }
}
