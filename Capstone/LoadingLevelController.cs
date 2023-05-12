using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using System;

public class LoadingLevelController : MonoBehaviour
{
    private static LoadingLevelController instance;
    public static LoadingLevelController Instance
    {
        get
        {
            var obj = FindObjectOfType<LoadingLevelController>();
            if (obj != null)
            {
                instance = obj;
            }
            else
            {
                instance = Create();
            }
            return instance;
        }

    }

    private static LoadingLevelController Create()
    {
        return Instantiate(Resources.Load<LoadingLevelController>("LoadingUI_Pun"));
    }

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    [SerializeField]
    private CanvasGroup canvasGroup;

    [SerializeField]
    private Image progessBar;

    private string loadSceneName;

    public void LoadLevel(string sceneName)
    {
        gameObject.SetActive(true);
        loadSceneName = sceneName;
        StartCoroutine(LoadLevelProcess());
    }

    private IEnumerator LoadLevelProcess()
    {
        progessBar.fillAmount = 0f;
        yield return StartCoroutine(Fade(true));

        PhotonNetwork.LoadLevel(loadSceneName);

        int loopNum = 0;
        float timer = 0f;
        while (true)
        {
            yield return null;
            if (PhotonNetwork.LevelLoadingProgress < 0.9f)
            {
                progessBar.fillAmount = PhotonNetwork.LevelLoadingProgress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progessBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if (progessBar.fillAmount >= 1f)
                {
                    break;
                }
            }
            if (loopNum++ > 100000)
                throw new Exception("Infinite Loop");
        }
        yield return StartCoroutine(Fade(false));
    }

    private IEnumerator Fade(bool isFadeIn)
    {
        float timer = 0f;
        while (timer <= 1f)
        {
            yield return null;
            timer += Time.unscaledDeltaTime * 3f;
            canvasGroup.alpha = isFadeIn ? Mathf.Lerp(0f, 1f, timer) : Mathf.Lerp(1f, 0f, timer);
        }

        if (!isFadeIn)
        {
            gameObject.SetActive(false);
        }
    }
}
