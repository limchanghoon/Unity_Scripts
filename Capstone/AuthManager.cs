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

    // 인증을 관리할 객체
    Firebase.Auth.FirebaseAuth auth;

    void Awake()
    {
        // 객체 초기화
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
        // 제공되는 함수 : 이메일과 비밀번호로 로그인 시켜 줌
        auth.SignInWithEmailAndPasswordAsync(idField.text, pwField.text).ContinueWith(
            task => {
                if (task.IsCompleted && !task.IsFaulted && !task.IsCanceled)
                {
                    Debug.Log(idField.text + " 로 로그인 하셨습니다.");
                    isLogined = true;
                }
                else
                {
                    Debug.Log("로그인에 실패하셨습니다.");
                    reset = true;
                }
                isLoggingin = false;
                
            }
        );
    }

    public void register()
    {
        // 제공되는 함수 : 이메일과 비밀번호로 회원가입 시켜 줌
        auth.CreateUserWithEmailAndPasswordAsync(idField.text, pwField.text).ContinueWith(
            task => {
                if (!task.IsCanceled && !task.IsFaulted)
                {
                    Debug.Log(idField.text + "로 회원가입\n");
                }
                else
                    Debug.Log("회원가입 실패\n");
            }
            );
    }

    [ContextMenu("포커스 어디?")]
    public void WhatIsFocused()
    {

        Debug.Log("idField.isFocused : " + idField.isFocused);
        Debug.Log("pwField.isFocused : " + pwField.isFocused);
    }
}