using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : Monster
{
    public GameManager GM;
    public PhotonView pv;

    public Transform target;
    protected int target_index = 0;

    [SerializeField]
    protected List<int> rewardIds = new List<int>();
    [SerializeField]
    protected List<int> rewardCounts = new List<int>();

    public virtual void ReTarget()
    {
        if (PhotonNetwork.IsMasterClient)
            pv.RPC("Change_target_RPC", RpcTarget.All, Gen_target_index());
    }


    [PunRPC]
    protected void Change_target_RPC(int index)
    {
        target = GM.targetsDic[GM.actNumberList[index]];
        target_index = index;
    }

    protected int Gen_target_index_not_same()
    {
        if (GM.target_count == 1)
            return 0;

        int _r;
        while (true)
        {
            _r = Gen_target_index();

            if (_r != target_index)
                return _r;
        }
    }

    protected int Gen_target_index()
    {
        int _r = UnityEngine.Random.Range(0, GM.actNumberList.Count);
        return _r;
    }


    public void View_Reward_UI()
    {
        RewardController rewardController = Instantiate(Resources.Load<RewardController>("RewardUI"));
        for (int i = 0; i < rewardIds.Count; i++)
        {
            rewardController.AddReward(ItemMaster.Instance.etcItem_Dic[rewardIds[i]], rewardCounts[i]);
            CFirebase.Instance.GetItem(rewardIds[i], rewardCounts[i]);
        }
    }
}
