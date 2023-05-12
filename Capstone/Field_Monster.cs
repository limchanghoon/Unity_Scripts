using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field_Monster : Monster
{
    public string drop_item_name = "Stone_0";
    public int drop_item_count = 1;
    protected override void Die()
    {
        base.Die();
        CFirebase.Instance.GetItem(drop_item_name, drop_item_count);
    }
}
