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

                if(root == null)    // ���� �ǰ� ���ɼ� 0
                {
                    if (iHitList.Contains(iHit) == false)
                    {
                        iHitList.Add(iHit);
                    }
                }
                else                // ���� �ǰ� ���ɼ����� HitRate�� ū �ϳ��� �ǰݸ� ����
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
            // �ߺ� ��Ʈ ���ɼ��� ���� �͵�
            iHitList[i].Hit(dmg, transform.position);
        }

        foreach(var ele in iHitDic)
        {
            // �ߺ� ��Ʈ ���ɼ��� �ִ� �͵�
            ele.Value.Hit(dmg, transform.position);
        }

        iHitList.Clear();
        iHitDic.Clear();
    }

}
