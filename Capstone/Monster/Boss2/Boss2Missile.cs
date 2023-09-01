using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Missile : MonoBehaviour, IPunInstantiateMagicCallback
{
    Vector3 origin;
    Vector3 des;
    float dis;

    float speed = 50f;

    // destination ¹ÞÀ½
    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        SetDes((Vector3)info.photonView.InstantiationData[0]);
    }

    [ContextMenu("Test")]
    public void Test()
    {
        SetDes(Vector3.zero);
    }

    public void SetDes(Vector3 _des)
    {
        origin = transform.position;
        des = _des;
        dis = (des - transform.position).magnitude;
        StartCoroutine(GoToDes());
    }

    IEnumerator GoToDes()
    {
        float t = 0;
        while(t < dis)
        {
            t += speed*Time.deltaTime;
            transform.position = Vector3.Lerp(origin, des, t / dis) + 10 * Vector3.up * Mathf.Sin(t / dis * Mathf.PI);
            yield return null;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponent<Player_Move>().pv.IsMine)
            {
                Debug.Log(name + " Hit " + other.gameObject.name + " : " + 10);
                other.gameObject.GetComponent<Player_HP>().Hit(10);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
