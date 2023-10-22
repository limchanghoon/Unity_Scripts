using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResolutionFix : MonoBehaviour
{

    const int setWidth = 1920; // 사용자 설정 너비
    const int setHeight = 1080; // 사용자 설정 높이


    private static ResolutionFix instance;

    public static ResolutionFix Instance
    {
        get
        {
            return instance;
        }
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FixResolution(Screen.width, Screen.height, Screen.fullScreen);
    }


    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    public void FixResolution(int _widht, int _height, bool isFullScreen)
    {
        if (isFullScreen)
        {
            _widht = setWidth;
            _height = setHeight;
        }

        int deviceWidth = Screen.width; // 기기 너비 저장
        int deviceHeight = Screen.height; // 기기 높이 저장

        Screen.SetResolution(_widht, (int)(((float)deviceHeight / deviceWidth) * _widht), isFullScreen); // SetResolution 함수 제대로 사용하기


        GameObject[] allCamera = GameObject.FindGameObjectsWithTag("MainCamera");
        if ((float)_widht / _height < (float)deviceWidth / deviceHeight) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = ((float)_widht / _height) / ((float)deviceWidth / deviceHeight); // 새로운 너비
            foreach(var _go in allCamera)
            {
                _go.GetComponent<Camera>().rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
            }
            //Debug.Log("newWidth : " + newWidth);
        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)_widht / _height); // 새로운 높이
            foreach (var _go in allCamera)
            {
                _go.GetComponent<Camera>().rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
            }
            //Debug.Log("newHeight : " + (deviceHeight/2 - newHeight * deviceHeight/2));
        }
    }
}

