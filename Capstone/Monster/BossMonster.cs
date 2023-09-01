using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : Monster
{
    [SerializeField]
    protected List<string> rewardNames = new List<string>();
    [SerializeField]
    protected List<int> rewardCounts = new List<int>();
    public virtual void ReTarget() { }
}
