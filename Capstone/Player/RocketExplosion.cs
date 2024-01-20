using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosion : MonoBehaviour
{
    PhotonView pv;

    static List<IHit> iHitList = new List<IHit>();
    static Dictionary<GameObject, IHit> iHitDic = new Dictionary<GameObject, IHit>();
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
        iHitDic.Clear();

        Collider[] colliders = Physics.OverlapSphere(this.transform.position, radius);

        foreach (Collider col in colliders)
        {
            if (col.tag == "Monster")
            {
                var iHit = col.GetComponentInParent<IHit>();
                var iGetRoot = col.GetComponentInParent<IGetRoot>();
                GameObject root = null;

                if (iGetRoot != null)
                    root = iGetRoot.GetRoot();

                if(root == null)    // 다중 피격 가능성 0
                {
                    if (iHitList.Contains(iHit) == false)
                    {
                        iHitList.Add(iHit);
                    }
                }
                else                // 다중 피격 가능성있음 HitRate가 큰 하나의 피격만 가함
                {
                    if (iHitDic.ContainsKey(root))
                    {
                        if (iHitDic[root].GetHitRate() < iHit.GetHitRate())
                        {
                            iHitDic[root] = iHit;
                        }
                    }
                    else
                    {
                        iHitDic.Add(root, iHit);
                    }
                }
            }
        }

        int dmg =  Player_Info.Instance.attack;
        switch(Player_Info.Instance.gunType)
        {
            case GunType.Rifle:
                dmg *= 10;
                break;
            case GunType.Sniper:
                break;
        }

        for(int i = 0; i < iHitList.Count; i++)
        {
            // 중복 히트 가능성이 없는 것들
            iHitList[i].Hit(dmg, transform.position);
        }

        foreach(var ele in iHitDic)
        {
            // 중복 히트 가능성이 있는 것들
            ele.Value.Hit(dmg, transform.position);
        }

        iHitList.Clear();
        iHitDic.Clear();
    }

}
