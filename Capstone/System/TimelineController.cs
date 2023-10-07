using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public GameManager GM;
    public MonoBehaviour[] monoBehaviours;
    public PlayableDirector playableDirector;
    public CinemachineBrain cinemachineBrain;

    public GameObject[] enableObjs;

    public RectTransform topBlack;
    public RectTransform BottomBlack;


    public void StartTimeline()
    {
        foreach (var _monoBehaviour in GM.disableScripts)
        {
            _monoBehaviour.enabled = false;
        }

        foreach (var _monoBehaviour in monoBehaviours)
        {
            _monoBehaviour.enabled = false;
        }

        foreach (var _go in enableObjs)
        {
            _go.SetActive(false);
        }
    }

    public void EndOfStartTimeline()
    {
        Debug.Log("EndOfStartTimeline");

        cinemachineBrain.enabled = false;

        foreach (var _monoBehaviour in GM.disableScripts)
        {
            _monoBehaviour.enabled = true;
        }

        foreach (var _monoBehaviour in monoBehaviours)
        {
            _monoBehaviour.enabled = true;
        }

        foreach (var _go in enableObjs)
        {
            _go.SetActive(true);
        }

        GameObject.Find("GM").GetComponent<GameManager>().myPlayer.GetComponent<Player_Move>().SetCamera();

        StartCoroutine(FadeOutBlack());
    }

    IEnumerator FadeOutBlack()
    {
        float t = 0f;
        while (t <= 1f)
        {
            yield return null;
            t += Time.deltaTime;
            topBlack.sizeDelta = new Vector2(topBlack.sizeDelta.x, Mathf.Lerp(50, 0, t));
            BottomBlack.sizeDelta = new Vector2(BottomBlack.sizeDelta.x, Mathf.Lerp(50, 0, t));
        }
        gameObject.SetActive(false);
    }
}
