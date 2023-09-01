using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniRocket : MonoBehaviour
{
    public GameObject explosionPrefab;
    PhotonView pv;
    Rigidbody rb;
    Vector3 initial_Pos;
    Vector3 center_Pos;
    int process = 0;
    float t = 0f;

    bool hit = false;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
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
            }
        }
        else if (process == 2)
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 50f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hit)
            return;
        else
            hit = true;

        if (PhotonNetwork.InRoom)
        {
            if (pv.IsMine)
            {
                PhotonNetwork.Instantiate("explosionPrefab", transform.position, Quaternion.identity);
                PhotonNetwork.Destroy(pv);
            }
        }
        else
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
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
