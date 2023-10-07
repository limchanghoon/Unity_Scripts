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
        for(int i =0; i < GM.actNumberList.Count; i++)
        {
            if(GM.actNumberList[i] == otherPlayer.ActorNumber)
            {
                GM.actNumberList.Remove(i);
                GM.targetsDic.Remove(otherPlayer.ActorNumber);
                break;
            }
        }
        GM.target_count--;
        bossMonster.ReTarget();
    }
}
