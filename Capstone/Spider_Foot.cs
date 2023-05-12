using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spider_Foot : MonoBehaviour
{
    [SerializeField] Transform body;

    [SerializeField] Vector3 footSpacing;
    [SerializeField] float stepDistance;
    [SerializeField] float stepHeight;
    [SerializeField] float speed;
    
    public LayerMask terrainLayer;

    [SerializeField] private Vector3 oldPos;
    [SerializeField] private Vector3 newPos;
    [SerializeField] private Vector3 currentPos;
    [SerializeField] private float lerp = 0;

    private void Start()
    {
        /*
        Ray ray = new Ray(body.position + footSpacing, Vector3.down);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.blue);
        if (Physics.Raycast(ray, out RaycastHit info, 10, terrainLayer.value))
        {
            transform.position = info.point;
            currentPos = transform.position;
            newPos = currentPos;
            oldPos = currentPos;
        }
        */
        currentPos = transform.position;
        newPos = currentPos;
        oldPos = currentPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = currentPos;
        Vector3 local_footSpacing = transform.right * footSpacing.x + transform.up * footSpacing.y+ transform.forward * footSpacing.z;

        Ray ray = new Ray(body.position + local_footSpacing, Vector3.down);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.blue);
        if (Physics.Raycast(ray, out RaycastHit info, 10, terrainLayer.value))
        {
            if (Vector3.Distance(newPos, info.point) > stepDistance)
            {
                lerp = 0;
                newPos = info.point;
            }
        }
        if (lerp < 1)
        {
            Vector3 footPosition = Vector3.Lerp(oldPos, newPos, lerp);
            footPosition.y = Mathf.Sin(lerp * Mathf.PI) * stepHeight;

            currentPos = footPosition;
            lerp += Time.deltaTime * speed;
        }
        else
        {
            oldPos = newPos;
        }

        //transform.position = fixPos;

    }
}
