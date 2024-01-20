using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : Monster
{
    public GameManager GM;
    public PhotonView pv;
    public BGM bgm;
    [SerializeField] float bgmFadeOut;

    public Transform target;
    protected int target_index = 0;

    [SerializeField]
    protected List<int> rewardIds = new List<int>();
    [SerializeField]
    protected List<int> rewardCounts = new List<int>();

    protected override void Start()
    {
        base.Start();
    }

    public virtual void ReTarget()
    {
        if (PhotonNetwork.IsMasterClient)
            pv.RPC("Change_target_RPC", RpcTarget.All, Gen_target_index());
    }


    public virtual void MasterChanged()
    {
        ReTarget();
    }

    protected override void Die()
    {
        bgm.FadeOut(bgmFadeOut);
    }



    [PunRPC]
    protected void Change_target_RPC(int index)
    {
        if(index == -1)
        {
            target = transform;
            target_index = index;
            return;
        }

        target = GM.targetsDic[GM.actNumberList[index]];
        target_index = index;
    }

    protected int Gen_target_index_not_same()
    {
        if (GM.target_count == 0)
        {
            return -1;
        }
            
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
        if (GM.target_count == 0)
        {
            return -1;
        }

        int _r = Random.Range(0, GM.actNumberList.Count);
        return _r;
    }


    [PunRPC]
    public void DeleteTarget(Player otherPlayer)
    {
        int actorNumber = otherPlayer.ActorNumber;
        if (GM.actNumberList.Find(x => x == actorNumber) == 0)
            return;
        Debug.Log(actorNumber + " DeleteTarget");
        GM.actNumberList.Remove(actorNumber);
        GM.targetsDic.Remove(actorNumber);
        GM.target_count--;
        if(otherPlayer.IsMasterClient)
        {
            if(otherPlayer == PhotonNetwork.LocalPlayer)
            {
                if (GM.target_count > 0)
                {
                    int nextMasterNum = GM.actNumberList[0];
                    foreach (var _player in PhotonNetwork.PlayerListOthers)
                    {
                        if (_player.ActorNumber == nextMasterNum)
                        {
                            PhotonNetwork.SetMasterClient(_player);
                            break;
                        }
                    }
                }
            }
        }
        else
        {
            ReTarget();
        }
    }


    public void View_Reward_UI()
    {
        if (GM.myPlayer.GetComponent<Player_HP>().GetIsDied())
            return;

        RewardController rewardController = Instantiate(Resources.Load<RewardController>("RewardUI"));
        for (int i = 0; i < rewardIds.Count; i++)
        {
            rewardController.AddReward(ItemMaster.item_Dic[rewardIds[i]].itemName, rewardCounts[i]);
            CFirebase.Instance.GetItem(new Other_ItemData(rewardIds[i], rewardCounts[i]));
        }
    }
}
