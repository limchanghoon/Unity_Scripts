using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricAdapter : MonoBehaviour
{
    bool isCharged = false;
    [SerializeField] GameObject redLight;
    [SerializeField] GameObject greenLight;
    [SerializeField] NextAction[] nextActions;

    public bool Charge()
    {
        if (isCharged)
            return false;

        isCharged = true;

        redLight.SetActive(false);
        greenLight.SetActive(true);
        foreach(var _action in nextActions)
            _action.Act();

        return true;
    }
}
