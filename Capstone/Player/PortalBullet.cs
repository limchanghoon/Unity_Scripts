using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBullet : MonoBehaviour
{
    public GameObject portalA_Prefab;
    public GameObject portalB_Prefab;

    PortalMapManager portalMapManager;

    [SerializeField] bool isA;
    PhotonView pv;
    Rigidbody rb;
    Vector3 initial_Pos;
    Vector3 center_Pos;
    int process = 0;
    float t = 0f;

    Vector3 prePos;
    Vector3 curPos;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();

        portalMapManager = GameObject.Find("PortalManager").GetComponent<PortalMapManager>();

        initial_Pos = transform.position;
        center_Pos = GameObject.Find("Center_TR").transform.position;
        process = 1;

        StartCoroutine(DestroyCoroutine());
        if (PhotonNetwork.InRoom)
        {
            if (pv.IsMine)
                StartCoroutine(DestroyCoroutine());
        }
        else
            Destroy(gameObject, 10f);
    }

    private void FixedUpdate()
    {
        if (process == 1)
        {
            t += Time.deltaTime * 50f;
            rb.MovePosition(Vector3.Lerp(initial_Pos, center_Pos, t));
            if (t >= 1f)
            {
                rb.MovePosition(center_Pos);
                t = 1;
                process = 2;
                prePos = transform.position;
            }
        }
        else if (process == 2)
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 50f);

            curPos = transform.position;
            RaycastHit hitData;
            if (Physics.Raycast(prePos, curPos - prePos, out hitData, (curPos - prePos).magnitude))
            {
                transform.position = hitData.point;
                if (PhotonNetwork.InRoom)
                {
                    if (pv.IsMine)
                    {
                        if (hitData.transform.tag == "Ground")
                        {
                            // 멀티에 사용하려면 구현하자
                        }
                        PhotonNetwork.Destroy(pv);
                    }
                }
                else
                {
                    if (hitData.transform.tag == "Ground")
                    {
                        GameObject _portal = isA ? portalMapManager.Portal_A : portalMapManager.Portal_B;
                        if (_portal == null)
                        {
                            if (isA)
                            {
                                portalMapManager.Portal_A = Instantiate(portalA_Prefab);
                                _portal = portalMapManager.Portal_A;
                            }
                            else
                            {
                                portalMapManager.Portal_B = Instantiate(portalB_Prefab);
                                _portal = portalMapManager.Portal_B;
                            }
                        }
                        _portal.transform.position = transform.position;
                        _portal.transform.rotation = Quaternion.LookRotation(hitData.normal);
                        _portal.GetComponentInChildren<MirrorPortal>().FadeIn(hitData.transform);
                    }
                    Destroy(gameObject);
                }
                process = 3;
            }
            prePos = curPos;
        }
    }

    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(10f);
        if (PhotonNetwork.InRoom)
        {
            if (pv.IsMine)
                PhotonNetwork.Destroy(pv);
        }
    }
}
