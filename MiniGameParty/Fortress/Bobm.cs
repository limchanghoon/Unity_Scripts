using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Bobm : MonoBehaviour, IPunInstantiateMagicCallback
{
    public LayerMask whatisPlatform;
    public LayerMask whatisPlayer;
    public CircleCollider2D bobmAreaCol;
    public GameObject explosion;

    public float power;
    PhotonView pv;
    Camera theCam;
    FortressManager fortressManager;

    private bool first = true;
    // awake -> OnPhotonInstantiate -> start
    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        theCam = Camera.main;
        pv = GetComponent<PhotonView>();
        GetComponent<Rigidbody2D>().velocity = -transform.right * (float)info.photonView.InstantiationData[0];
        fortressManager = GameObject.Find("GM").GetComponent<FortressManager>();
        fortressManager.PlayClip(0);
    }


    private void LateUpdate()
    {
        theCam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (first)
            first = false;
        else
            return;
        Debug.Log("OnCollisionEnter2D : " + collision.transform.name);
        if (pv.IsMine)
            pv.RPC("Boooom", RpcTarget.All, transform.position);
    }

    [PunRPC]
    public void Boooom(Vector3 _pos)
    {
        fortressManager.PlayClip(1);

        Collider2D[] overCollider2D = Physics2D.OverlapCircleAll(_pos, bobmAreaCol.radius, whatisPlayer);
        foreach (var col in overCollider2D)
        {
            col.transform.root.GetComponent<FortressPlayer>().Hit(power);
        }

        Destroy(Instantiate(explosion, _pos, Quaternion.identity), 5f);

        int radius = Mathf.RoundToInt(bobmAreaCol.radius);
        for (int i = 0; i <= radius; i++)
        {
            int d = Mathf.RoundToInt(Mathf.Sqrt(radius * radius - i * i));
            for(int j = 0; j <= d; j++)
            {
                InnerBoooom(_pos, i, j);
                InnerBoooom(_pos, i, -j);
                InnerBoooom(_pos, -i, j);
                InnerBoooom(_pos, -i, -j);
            }
        }
        if (PhotonNetwork.IsMasterClient)
            GameObject.Find("GM").GetComponent<FortressManager>().TurnToNext();

        Destroy(gameObject);
    }

    void InnerBoooom(Vector3 _pos, int _i, int _j)
    {
        Vector2 checkPos = new Vector2(_pos.x + _i, _pos.y + _j);
        Collider2D overCollider2D = Physics2D.OverlapCircle(checkPos, 0.01f, whatisPlatform);
        if (overCollider2D != null)
        {
            overCollider2D.transform.GetComponent<Bricks>().MakeDot(checkPos);
        }
    }
}
