using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBullet : MonoBehaviour
{
    public GameObject portalA_Prefab;
    public GameObject portalB_Prefab;

    [SerializeField] bool isA;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (hit)
            return;
        else
            hit = true;

        if (PhotonNetwork.InRoom)
        {
            if (pv.IsMine)
            {
                if (collision.gameObject.tag == "Ground")
                {

                }
                PhotonNetwork.Destroy(pv);
            }
        }
        else
        {
            if (collision.gameObject.tag == "Ground")
            {
                GameObject _portal = isA ? GameObject.Find("어디로든 문A(Clone)") : GameObject.Find("어디로든 문B(Clone)");
                if(_portal == null)
                {
                    if (isA)
                        _portal = Instantiate(portalA_Prefab);
                    else
                        _portal = Instantiate(portalB_Prefab);
                }
                _portal.transform.position = transform.position;
                _portal.transform.rotation = Quaternion.LookRotation(collision.contacts[0].normal);
                _portal.GetComponentInChildren<MirrorPortal>().FadeIn();
            }
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
