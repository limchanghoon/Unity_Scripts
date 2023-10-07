using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public Vector3[] points;
    public float movingSpeed;

    int curPoint = 0;
    int nextPoint = 0;
    float t = 0f;

    private void Update()
    {
        t += Time.deltaTime * movingSpeed;
        transform.position = Vector3.Lerp(points[curPoint], points[nextPoint], t);
        if (t >= 1)
        {
            t = 0;
            curPoint = nextPoint;
            nextPoint = nextPoint + 1 == points.Length ? 0 : nextPoint + 1;
        }
    }
}
