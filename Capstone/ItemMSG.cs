using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemMSG : MonoBehaviour
{
    TextMeshProUGUI m_TextMeshProUGUI;
    float scale = 0.2f;
    private void Awake()
    {
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    public void SetMSG(string str)
    {
        StopCoroutine(SetMSGCoroutine());
        m_TextMeshProUGUI.text = str;
        m_TextMeshProUGUI.alpha = 1.0f;
        transform.SetAsFirstSibling();
        StartCoroutine(SetMSGCoroutine());
    }

    IEnumerator SetMSGCoroutine()
    {
        while (m_TextMeshProUGUI.alpha > 0.0f)
        {
            yield return null;
            m_TextMeshProUGUI.alpha -= scale * Time.deltaTime;
        }
        Debug.Log(m_TextMeshProUGUI.alpha);
    }
}
