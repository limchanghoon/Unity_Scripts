using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneCardPlayer : TurnBasedPlayer
{
    
    public override void StartMyTurn()
    {
        Debug.Log(pv.ViewID + " : StartMyTurn");
        base.StartMyTurn();
    }
}
