using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisPlayer : MonoBehaviour
{

    TetrisManager GM;
    private void Start()
    {
        GM = GameObject.Find("GM").GetComponent<TetrisManager>();
        GM.playerCount++;
    }
}
