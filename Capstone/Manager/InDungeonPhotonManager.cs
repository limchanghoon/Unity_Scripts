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
        Debug.Log((otherPlayer.ActorNumber) + " 나갔습니다");
        for(int i =0; i < GM.targets.Count; i++)
        {
            if(GM.targets[i] == otherPlayer.ActorNumber)
            {
                GM.targets.Remove(i);
                GM.targetsDic.Remove(otherPlayer.ActorNumber);
                break;
            }
        }
        GM.target_count--;
        bossMonster.ReTarget();
    }
}
