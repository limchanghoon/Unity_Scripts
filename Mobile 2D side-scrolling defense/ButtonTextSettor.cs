using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonTextSettor : MonoBehaviour
{
    [ContextMenu("SetButtonText")]
    public void SetButtonText()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            string newName = "";
            int digit = 100, num = i + 1;
            while (digit > num)
            {
                newName += "0";
                digit /= 10;
            }
            newName += num.ToString();
            transform.GetChild(i).name = newName;
            transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = newName;
            transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        }
    }
}
