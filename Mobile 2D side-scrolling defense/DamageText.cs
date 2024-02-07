using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : PoolingObject
{
    Vector3 startPosition;
    TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    public void StartAnim(Vector3 newStartPosition, int damage)
    {
        startPosition = newStartPosition + Vector3.up * Random.Range(0f, 0.5f) + Vector3.right * Random.Range(-0.5f, 0.5f);
        transform.position = startPosition;
        textMeshProUGUI.text = damage.ToString();
        textMeshProUGUI.alpha = 1f;
        StartCoroutine(AnimCoroutine());
    }

    IEnumerator AnimCoroutine()
    {
        float t = 1f;
        while (t < 1.5f)
        {
            transform.localScale = Vector3.one * t * t;
            t += Time.deltaTime * 1.5f;
            yield return null;
        }

        t = 1f;
        while (t > 0f)
        {
            textMeshProUGUI.alpha = t;
            t -= Time.deltaTime;
            yield return null;
        }
        DestroyObject();
    }
}
