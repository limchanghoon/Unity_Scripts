using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spider_Feet : MonoBehaviour
{
    public float distance = 2f;
    public float stepHeight;
    public float speed;
    public LayerMask terrainLayer;

    // ÄÄÆ÷³ÍÆ®
    [SerializeField] private Transform front_center;
    [SerializeField] private Transform front_left;
    [SerializeField] private Transform front_right;
    [SerializeField] private Transform back_center;
    [SerializeField] private Transform back_left;
    [SerializeField] private Transform back_right;

    [SerializeField] private Transform target_FL;
    [SerializeField] private Transform target_FR;
    [SerializeField] private Transform target_BL;
    [SerializeField] private Transform target_BR;

    private Vector3 currentPos_FL;
    private Vector3 currentPos_FR;
    private Vector3 currentPos_BL;
    private Vector3 currentPos_BR;



    // Start is called before the first frame update
    void Start()
    {
        currentPos_FL = target_FL.position;
        currentPos_FR = target_FR.position;
        currentPos_BL = target_BL.position;
        currentPos_BR = target_BR.position;
    }

    // Update is called once per frame
    void Update()
    {
        target_FL.position = currentPos_FL;
        target_FR.position = currentPos_FR;
        target_BL.position = currentPos_BL;
        target_BR.position = currentPos_BR;

        Vector3 a = (target_FL.position + target_FR.position) / 2;
        a.y = 0;
        Vector3 b = front_center.position;
        b.y = 0;
        if (Vector3.Distance(a, b) >= distance)
        {
            Vector3 fl = target_FL.position;
            fl.y = 0;
            Vector3 fr = target_FR.position;
            fr.y = 0;
            if(Vector3.Distance(fl, b) >= Vector3.Distance(fr, b))
            {
                Ray ray = new Ray(front_left.position, Vector3.down);
                Debug.DrawRay(ray.origin, ray.direction * 1000, Color.blue);
                if (Physics.Raycast(ray, out RaycastHit info, 10, terrainLayer.value))
                {
                    StartCoroutine(LerpPos(0, currentPos_FL, info.point, 0));
                }
            }
            else
            {
                Ray ray = new Ray(front_right.position, Vector3.down);
                Debug.DrawRay(ray.origin, ray.direction * 1000, Color.blue);
                if (Physics.Raycast(ray, out RaycastHit info, 10, terrainLayer.value))
                {
                    StartCoroutine(LerpPos(1, currentPos_FR, info.point, 0));
                }
            }
        }

        Vector3 c = (target_BL.position + target_BR.position) / 2;
        c.y = 0;
        Vector3 d = back_center.position;
        d.y = 0;
        if (Vector3.Distance(c, d) >= distance)
        {
            Vector3 bl = target_BL.position;
            bl.y = 0;
            Vector3 br = target_BR.position;
            br.y = 0;
            if (Vector3.Distance(bl, d) >= Vector3.Distance(br, d))
            {
                Ray ray = new Ray(back_left.position, Vector3.down);
                Debug.DrawRay(ray.origin, ray.direction * 1000, Color.blue);
                if (Physics.Raycast(ray, out RaycastHit info, 10, terrainLayer.value))
                {
                    StartCoroutine(LerpPos(2, currentPos_BL, info.point, 0));
                }
            }
            else
            {
                Ray ray = new Ray(back_right.position, Vector3.down);
                Debug.DrawRay(ray.origin, ray.direction * 1000, Color.blue);
                if (Physics.Raycast(ray, out RaycastHit info, 10, terrainLayer.value))
                {
                    StartCoroutine(LerpPos(3, currentPos_BR, info.point, 0));
                }
            }
        }

    }

    IEnumerator LerpPos(int type ,Vector3 oldPos, Vector3 newPos, float lerp)
    {
        if (lerp < 1)
        {
            Vector3 footPosition = Vector3.Lerp(oldPos, newPos, lerp);
            footPosition.y = Mathf.Sin(lerp * Mathf.PI) * stepHeight;

            switch (type)
            {
                case 0:
                    currentPos_FL = footPosition;
                    break;
                case 1:
                    currentPos_FR = footPosition;
                    break;
                case 2:
                    currentPos_BL = footPosition;
                    break;
                case 3:
                    currentPos_BR = footPosition;
                    break;
            }
            lerp += Time.deltaTime * speed;
            yield return null;
            StartCoroutine(LerpPos(type, oldPos, newPos, lerp));
        }
    }

}
