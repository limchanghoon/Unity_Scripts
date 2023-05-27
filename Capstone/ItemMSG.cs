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
        //UnityMainThreadDispatcher.Instance().Enqueue(SetMSGCoroutine(str));
        m_TextMeshProUGUI.text = str;
        m_TextMeshProUGUI.alpha = 1.0f;
        transform.SetAsFirstSibling();

        StartCoroutine(SetMSGCoroutine(str));
    }

    IEnumerator SetMSGCoroutine(string str)
    {
        m_TextMeshProUGUI.text = str;
        m_TextMeshProUGUI.alpha = 1.0f;
        transform.SetAsFirstSibling();
        while (m_TextMeshProUGUI.alpha > 0.0f)
        {
            yield return null;
            m_TextMeshProUGUI.alpha -= scale * Time.deltaTime;
        }
        Debug.Log(m_TextMeshProUGUI.alpha);
    }
}
