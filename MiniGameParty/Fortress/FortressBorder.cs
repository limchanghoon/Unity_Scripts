using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class FortressBorder : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.root.tag == "Player" && collision.transform.root.GetComponent<PhotonView>().IsMine)
        {
            Debug.Log(collision.transform.name);
            collision.transform.root.GetComponent<FortressPlayer>().Hit(999999);
        }
    }
}
