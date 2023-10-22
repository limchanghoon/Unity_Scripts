using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricAdapter : MonoBehaviour
{
    bool isCharged = false;
    AudioSource audioSource;
    [SerializeField] GameObject redLight;
    [SerializeField] GameObject greenLight;
    [SerializeField] NextAction[] nextActions;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public bool Charge()
    {
        if (isCharged)
            return false;

        isCharged = true;

        audioSource.Play();
        redLight.SetActive(false);
        greenLight.SetActive(true);
        foreach(var _action in nextActions)
            _action.Act();

        return true;
    }
}
