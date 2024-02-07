using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneManager : MonoBehaviour
{
    const string inGameSceneName = "InGame";
    CanvasGroup canvasGroup;

    private static LoadSceneManager instance;
    public static LoadSceneManager Instance
    {
        get { return instance; }
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            canvasGroup = GetComponent<CanvasGroup>();
            DontDestroyOnLoad(gameObject);
            //SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadSceneByName(string sceneName)
    {
        StartCoroutine(LoadMyAsyncScene(null, sceneName));
    }


    public void LoadStage(StageData stageData)
    {
        StartCoroutine(LoadMyAsyncScene(stageData));
    }

    IEnumerator LoadMyAsyncScene(StageData stageData, string targetScene = inGameSceneName)
    {
        yield return Fade(false);
        // 중간 로딩씬으로 이동
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Loading");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        if (targetScene == inGameSceneName)
        {
            PlayerPrefs.SetInt("StageNumber", stageData.stageNumber);
            PlayerPrefs.SetInt("StageMaxHP", stageData.maxHP);
            PlayerPrefs.SetFloat("StageGenerateRate", stageData.generateRate);
        }
        // 목표 씬으로 이동
        AsyncOperation asyncLoad2 = SceneManager.LoadSceneAsync(targetScene);
        while (!asyncLoad2.isDone)
        {
            yield return null;
        }
        yield return Fade(true);
    }

    IEnumerator Fade(bool isFadeIn)
    {
        float t = 0f;
        while (t<=1f)
        {
            canvasGroup.alpha = isFadeIn ? Mathf.Lerp(1f, 0f, t) : Mathf.Lerp(0f, 1f, t);
            t += Time.deltaTime * 5;
            yield return null;
        }
        canvasGroup.alpha = isFadeIn ? 0f : 1f;
    }
}
