using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestPlayer : MonoBehaviour, IPunObservable
{
    PhotonView pv;
    Vector3 networkPos;
    Vector3 moveMent;
    float lag;
    public RectTransform textRectTr;
    public TextMeshProUGUI text;

    int direction = 1;
    float speed = 3f;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (pv.IsMine)
        {
            transform.Translate(speed * direction * Vector3.up * Time.deltaTime);
            text.text = transform.position.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (pv.IsMine)
        {
            direction *= -1;
        }
    }

    // 변수 동기화
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(direction);
        }
        else
        {
            networkPos = (Vector3)stream.ReceiveNext();
            direction = (int)stream.ReceiveNext();

            lag = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
            Debug.Log("lag : " + lag.ToString());
            transform.position = networkPos;
            transform.Translate(speed * direction * Vector3.up * lag);

            text.text = transform.position.ToString();
        }
    }
}
