using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    AudioSource audioSource;
    float fadeInTime = 5f;
    float curFadeInTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        while(curFadeInTime < fadeInTime)
        {
            curFadeInTime += Time.deltaTime;
            audioSource.volume = (curFadeInTime / fadeInTime)*0.5f;
            yield return null;
        }
        audioSource.volume = 0.5f;
    }
}
