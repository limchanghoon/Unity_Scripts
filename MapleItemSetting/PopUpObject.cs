using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpObject : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI text;

    float alpha = 1f;
    private void Start()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1f);

        while(alpha > 0)
        {
            alpha -= Time.deltaTime;
            image.color -= Color.black* Time.deltaTime;
            text.color -= Color.black* Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
