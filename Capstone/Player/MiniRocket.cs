using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniRocket : MonoBehaviour, IPunInstantiateMagicCallback
{
    public GameObject explosionPrefab;
    PhotonView pv;
    Rigidbody rb;
    Vector3 initial_Pos;
    Vector3 center_Pos;
    int process = 0;
    float t = 0f;

    Vector3 prePos;
    Vector3 curPos;

    // awake -> OnPhotonInstantiate -> start
    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        pv = GetComponent<PhotonView>();
        center_Pos = (Vector3)info.photonView.InstantiationData[0];
    }


    private void Start()
    {
        if(pv == null)
        {
            center_Pos = GameObject.Find("Center_TR").transform.position;
        }
        rb = GetComponent<Rigidbody>();
        initial_Pos = transform.position;
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
                prePos = transform.position;
                process = 2;
            }
        }
        else if (process == 2)
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 50f);
            if (pv != null && pv.IsMine == false)
                return;
            curPos = transform.position;
            RaycastHit hitData;
            if (Physics.Raycast(prePos, curPos - prePos, out hitData, (curPos - prePos).magnitude))
            {
                transform.position = hitData.point + (prePos - curPos).normalized * 0.3f;
                if (PhotonNetwork.InRoom)
                {
                    if (pv.IsMine)
                    {
                        PhotonNetwork.Instantiate("RocketExplosionPrefab", transform.position, Quaternion.identity);
                        PhotonNetwork.Destroy(pv);
                    }
                }
                else
                {
                    Instantiate(explosionPrefab, transform.position, Quaternion.identity);
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
