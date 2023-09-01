using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;   // ����Ƽ�� ���� ������Ʈ��
using Photon.Realtime;  // ���� ���� ���� ���̺귯��

public class InDungeonPhotonManager : MonoBehaviourPunCallbacks
{
    public GameManager GM;
    public BossMonster bossMonster;

    // �ٸ� �÷��̾ ����
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log((otherPlayer.ActorNumber) + " �������ϴ�");
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
