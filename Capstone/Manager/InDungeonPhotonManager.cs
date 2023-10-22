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
        int actorNumber = otherPlayer.ActorNumber;
        if (GM.actNumberList.Find(x => x == actorNumber) == 0)
            return;
        Debug.Log(actorNumber + " �������ϴ�");
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
