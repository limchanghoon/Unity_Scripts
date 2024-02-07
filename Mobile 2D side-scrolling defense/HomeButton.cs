using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButton : MonoBehaviour
{
    public void GoToLobby()
    {
        LoadSceneManager.Instance.LoadSceneByName("Lobby");
    }
}
