using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    [SerializeField] string fileName;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("CaptureScreenshot");
            ScreenCapture.CaptureScreenshot(fileName+".png");
        }
    }
}
