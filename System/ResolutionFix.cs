using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResolutionFix : MonoBehaviour
{

    const int setWidth = 1920; // ����� ���� �ʺ�
    const int setHeight = 1080; // ����� ���� ����


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

        int deviceWidth = Screen.width; // ��� �ʺ� ����
        int deviceHeight = Screen.height; // ��� ���� ����

        Screen.SetResolution(_widht, (int)(((float)deviceHeight / deviceWidth) * _widht), isFullScreen); // SetResolution �Լ� ����� ����ϱ�


        GameObject[] allCamera = GameObject.FindGameObjectsWithTag("MainCamera");
        if ((float)_widht / _height < (float)deviceWidth / deviceHeight) // ����� �ػ� �� �� ū ���
        {
            float newWidth = ((float)_widht / _height) / ((float)deviceWidth / deviceHeight); // ���ο� �ʺ�
            foreach(var _go in allCamera)
            {
                _go.GetComponent<Camera>().rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // ���ο� Rect ����
            }
            //Debug.Log("newWidth : " + newWidth);
        }
        else // ������ �ػ� �� �� ū ���
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)_widht / _height); // ���ο� ����
            foreach (var _go in allCamera)
            {
                _go.GetComponent<Camera>().rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // ���ο� Rect ����
            }
            //Debug.Log("newHeight : " + (deviceHeight/2 - newHeight * deviceHeight/2));
        }
    }
}

