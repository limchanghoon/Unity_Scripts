using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButtonForDie : MonoBehaviour
{
    [SerializeField] string map_name;

    public void LoadScene_Or_LoadLevel()
    {
        ETC_Memory.Instance.windowDepth--;

        if (PhotonNetwork.InRoom)
            LoadingLevelController.Instance.LoadLevel(map_name);
        else
            LoadingSceneController.Instance.LoadScene(map_name);
    }
}
