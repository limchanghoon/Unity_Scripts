using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/UnitScriptable")]
public class UnitScriptableObject : ScriptableObject
{
    public UnitEnum unitenum;
    public int cost;
    public int power;

    public int maxHP;

    public float cooltime;
    public float moveSpeed;
    public float rayDistance;
    public Vector2 textOffset;
    public Vector2 rayOffset;
    public Vector2 spawnPosition;
}
