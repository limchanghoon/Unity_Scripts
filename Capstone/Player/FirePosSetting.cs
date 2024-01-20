using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct firepos
{
    public string name;
    public Vector3 localPos;

    public firepos(string _name,Vector3 _localPos)
    {
        name = _name;
        localPos = _localPos;
    }
}

public class FirePosSetting : MonoBehaviour
{

    [SerializeField] List<firepos> fireposes = new List<firepos>();
    [HideInInspector] public int index;

    public void SaveLocalPosition()
    {
        fireposes.Add(new firepos("",transform.localPosition));
        Debug.Log("SaveLocalPosition");
    }

    public void SetLocalPosition(int _index)
    {
        transform.localPosition = fireposes[_index].localPos;
    }
}
