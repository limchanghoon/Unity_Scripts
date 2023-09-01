using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosion : MonoBehaviour
{
    PhotonView pv;

    static List<IHit> iHitList = new List<IHit>();
    float radius = 2f;

    private void Start()
    {
        if (PhotonNetwork.InRoom)
        {
            pv = GetComponent<PhotonView>();
            if (!pv.IsMine)
                return;
        }

        iHitList.Clear();

        Collider[] colliders = Physics.OverlapSphere(this.transform.position, radius);

        foreach (Collider col in colliders)
        {
            if (col.tag == "Monster")
            {
                var iHit = col.GetComponentInParent<IHit>();
                if (iHitList.Contains(iHit) == false)
                {
                    iHitList.Add(iHit);
                }
            }
        }

        int dmg = 10 * Player_Info.Instance.attack;

        for(int i = 0; i < iHitList.Count; i++)
        {
            iHitList[i].Hit(dmg, transform.position);
        }

        iHitList.Clear();
    }

}
