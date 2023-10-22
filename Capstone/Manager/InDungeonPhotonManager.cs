using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;   // 유니티용 포톤 컴포넌트들
using Photon.Realtime;  // 포톤 서비스 관련 라이브러리

public class InDungeonPhotonManager : MonoBehaviourPunCallbacks
{
    public GameManager GM;
    public BossMonster bossMonster;

    // 다른 플레이어가 나감
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int actorNumber = otherPlayer.ActorNumber;
        if (GM.actNumberList.Find(x => x == actorNumber) == 0)
            return;
        Debug.Log(actorNumber + " 나갔습니다");
        GM.actNumberList.Remove(actorNumber);
        GM.targetsDic.Remove(actorNumber);
        GM.target_count--;
        bossMonster.ReTarget();
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        Debug.Log("OnMasterClientSwitched");
        if (PhotonNetwork.IsMasterClient)
        {
            bossMonster.MasterChanged();
        }
    }
}
