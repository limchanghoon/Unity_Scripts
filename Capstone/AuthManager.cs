using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

public class AuthManager : MonoBehaviour
{

    [SerializeField] TMP_InputField idField;
    [SerializeField] TMP_InputField pwField;
    [SerializeField] Button sign_in_btn;
    [SerializeField] Button sign_up_btn;
    [SerializeField] Canvas ui_Canvas;

    [SerializeField] bool isLogined = false;
    [SerializeField] bool reset = false;
    [SerializeField] bool focusID = true;
    [SerializeField] bool isLoggingin = false;

    string first_Map_Name = "SciFi_Warehouse";

    // ������ ������ ��ü
    Firebase.Auth.FirebaseAuth auth;

    void Awake()
    {
        // ��ü �ʱ�ȭ
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }

    private void Start()
    {
        idField.ActivateInputField();
    }



    private void Update()
    {
        if (isLoggingin)
        {
            return;
        }

        if (isLogined)
        {
            LoadingSceneController.Instance.LoadScene(first_Map_Name);
            isLoggingin = true;
        }

        if (reset)
        {
            Set_UI_enabled(true);

            if (focusID)
                idField.ActivateInputField();
            else
                pwField.ActivateInputField();

            reset = false;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (idField.isFocused)
            {
                pwField.ActivateInputField();
                focusID = false;
            }
            else
            {
                idField.ActivateInputField();
                focusID = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            PressEnter();
        }

        if (pwField.isFocused)
        {
            Input.imeCompositionMode = IMECompositionMode.Off;
        }
    }

    public void PressEnter()
    {
        Set_UI_enabled(false);
        isLoggingin = true;
        login();
    }

    public void Set_UI_enabled(bool boolean)
    {
        idField.enabled = boolean;
        pwField.enabled = boolean;
        sign_in_btn.enabled = boolean;
        sign_up_btn.enabled = boolean;
    }

    public void login()
    {
        // �����Ǵ� �Լ� : �̸��ϰ� ��й�ȣ�� �α��� ���� ��
        auth.SignInWithEmailAndPasswordAsync(idField.text, pwField.text).ContinueWith(
            task => {
                if (task.IsCompleted && !task.IsFaulted && !task.IsCanceled)
                {
                    Debug.Log(idField.text + " �� �α��� �ϼ̽��ϴ�.");
                    isLogined = true;
                }
                else
                {
                    Debug.Log("�α��ο� �����ϼ̽��ϴ�.");
                    reset = true;
                }
                isLoggingin = false;
                
            }
        );
    }

    public void register()
    {
        // �����Ǵ� �Լ� : �̸��ϰ� ��й�ȣ�� ȸ������ ���� ��
        auth.CreateUserWithEmailAndPasswordAsync(idField.text, pwField.text).ContinueWith(
            task => {
                if (!task.IsCanceled && !task.IsFaulted)
                {
                    Debug.Log(idField.text + "�� ȸ������\n");
                }
                else
                    Debug.Log("ȸ������ ����\n");
            }
            );
    }

    [ContextMenu("��Ŀ�� ���?")]
    public void WhatIsFocused()
    {

        Debug.Log("idField.isFocused : " + idField.isFocused);
        Debug.Log("pwField.isFocused : " + pwField.isFocused);
    }
}