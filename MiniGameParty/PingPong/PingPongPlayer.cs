using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongPlayer : MonoBehaviour, IPunObservable, IPunInstantiateMagicCallback
{
    PhotonView pv;
    float speed = 3.5f;
    int direction = 1;

    public bool isLeftBtnDowning = false;
    public bool isRightBtnDowning = false;

    // awake -> OnPhotonInstantiate -> start
    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        direction = (int)info.photonView.InstantiationData[0];

        pv = GetComponent<PhotonView>();
        PingPongManager GM = GameObject.Find("GM").GetComponent<PingPongManager>();
        if (pv.IsMine)
        {
            gameObject.tag = "IsMine";
            GetComponent<SpriteRenderer>().color = Color.red;
            GM.myPlayer = this;
        }
        GM.playerCount++;
    }


    private void Update()
    {
        if (pv.IsMine)
        {
            if (isLeftBtnDowning && direction * transform.position.x > -3f)
            {
                transform.Translate(direction * speed * Time.deltaTime * Vector3.left);
            }
            if (isRightBtnDowning && direction * transform.position.x < 3f)
            {
                transform.Translate(direction * speed * Time.deltaTime * Vector3.right);
            }
        }
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position.x);
        }
        else
        {
            float _x = (float)stream.ReceiveNext();
            transform.position = new Vector3(_x, transform.position.y, transform.position.z);
        }
    }
}
