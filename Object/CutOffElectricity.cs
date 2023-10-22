using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutOffElectricity : NextAction
{
    public GameObject electricity;
    public override void Act()
    {
        electricity.SetActive(false);
    }
}
