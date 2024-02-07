using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyExtension : MonoBehaviour
{
    static int DIGIT = 3;

    public static string Int2StageString(int stageNumber)
    {
        string result = stageNumber.ToString();
        string prefix = "";
        for (int i = 0; i < DIGIT - result.Length; ++i)
        {
            prefix += "0";
        }
        return prefix + result;
    }
}
