using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_Player : MonoBehaviour
{
    private void Awake()
    {
        PhotonNetwork.Instantiate("Player", new Vector3(5 * Random.Range(1, 5), 1, -5 * Random.Range(1, 5)), Quaternion.identity);
    }
}
