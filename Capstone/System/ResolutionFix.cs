using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionFix : MonoBehaviour
{
    private void Start()
    {
        //FixResolution();
    }

    void FixResolution()
    {
        int setWidth = 1920;
        int setHeight = 1080;
        Screen.SetResolution(setWidth, setHeight, true);
    }
}
