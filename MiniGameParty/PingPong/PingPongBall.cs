using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PingPongBall : MonoBehaviour//, IPunObservable
{
    PhotonView pv;
    Rigidbody2D rid;
    PingPongManager GM;

    public Vector2 dirVector;
    const float barLength = 1f;
    const float hlafBarLength = barLength/2f;
    Vector2 MINVEC = new Vector2(-Mathf.Cos(10 * Mathf.Deg2Rad), Mathf.Sin(80 * Mathf.Deg2Rad));
    Vector2 MAXVEC = new Vector2(Mathf.Cos(10 * Mathf.Deg2Rad), Mathf.Sin(80 * Mathf.Deg2Rad));

    float speed = 10f;
    float speed_Plus = 0f;
    float networkDelay = 0f;
    float preDelay = 0f;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
        rid = GetComponent<Rigidbody2D>();
        GM = GameObject.Find("GM").GetComponent<PingPongManager>();
    }

    private void Update()
    {
        if (GM.gameEnd)
            return;
        if (networkDelay > 0f)
        {
            speed_Plus = speed;
            networkDelay -= speed_Plus * Time.deltaTime;
        }
        else
        {
            speed_Plus = 0f;
        }
        //transform.Translate((speed + speed_Plus) * Time.deltaTime * dirVector.normalized);
    }

    private void FixedUpdate()
    {
        if (GM.gameEnd)
            return;
        rid.velocity = (speed + speed_Plus) * dirVector.normalized;
    }

    [PunRPC]
    public void Smash(Vector2 _pos, Vector2 _dirV, PhotonMessageInfo info)
    {
        Debug.Log("Delay : " + (float)(PhotonNetwork.Time - info.SentServerTime));
        networkDelay = (float)(PhotonNetwork.Time - info.SentServerTime) * 2 * speed;
        preDelay = networkDelay;
        transform.position = _pos;
        dirVector = _dirV;
    }

    [PunRPC]
    public void Serve(int _camp)
    {
        if (_camp == 1)
        {
            transform.position = 4f * Vector3.up;
            dirVector = Vector2.down;
            if (_camp != GM.camp)
                networkDelay = preDelay;
        }
        else
        {
            transform.position = -4 * Vector3.up;
            dirVector = Vector2.up;
            if (_camp != GM.camp)
                networkDelay = preDelay;
        }

        if (_camp == GM.camp)
            ++GM.awayPoint;
        else
            ++GM.homePoint;
        if (GM.UpdateScore())
            GM.gameEnd = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "IsMine")
        {
            float ratio = (collision.contacts[0].point.x - collision.transform.position.x + hlafBarLength) / barLength;
            dirVector = Vector2.Lerp(MINVEC, MAXVEC, ratio);
            dirVector.y *= -GM.camp;
            pv.RPC("Smash", RpcTarget.Others, new Vector2(transform.position.x, transform.position.y), dirVector);
            PhotonNetwork.SendAllOutgoingCommands();
        }

        if (collision.transform.tag == "Wall")
        {
            dirVector.x *= -1;
        }

        if (collision.gameObject.name == "UpBorder" && GM.camp == 1)
        {
            pv.RPC("Serve", RpcTarget.All, GM.camp);
            PhotonNetwork.SendAllOutgoingCommands();
        }

        if (collision.gameObject.name == "DownBorder" && GM.camp == -1)
        {
            pv.RPC("Serve", RpcTarget.All, GM.camp);
            PhotonNetwork.SendAllOutgoingCommands();
        }
    }
}
