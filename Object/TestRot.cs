using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRot : MonoBehaviour
{
    float t = 0f;

    private void Update()
    {
        t += Time.deltaTime;

        if (1 >= 1f)
        {
            t = 0f;
            Debug.Log(transform.rotation.eulerAngles.x);
        }
    }
}
