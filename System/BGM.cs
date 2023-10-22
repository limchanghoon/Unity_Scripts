using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] BGMs;

    [SerializeField] float volume;
    int current = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        FadeIn();
    }

    public void FadeIn(float _t = 0.5f)
    {
        StartCoroutine(FadeInCoroutine(1/_t));
    }

    IEnumerator FadeInCoroutine(float factor = 2f)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * factor;
            audioSource.volume = Mathf.Lerp(0f, volume, t);
            yield return null;
        }

        audioSource.volume = volume;
    }


    public void FadeOut(float _t = 0.5f)
    {
        StartCoroutine(FadeOutCoroutine(1/_t));
    }

    IEnumerator FadeOutCoroutine(float factor = 2f)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * factor;
            audioSource.volume = Mathf.Lerp(volume, 0f, t);
            yield return null;
        }

        audioSource.volume = 0f;
    }

    public void PlayNextBGM()
    {
        StartCoroutine(PlayNextBGMCoroutine());
    }

    IEnumerator PlayNextBGMCoroutine()
    {
        yield return null;
        yield return StartCoroutine(FadeOutCoroutine());
        if (++current == BGMs.Length)
            current = 0;
        audioSource.clip = BGMs[current];
        audioSource.Play();
        yield return StartCoroutine(FadeInCoroutine());
    }
}
