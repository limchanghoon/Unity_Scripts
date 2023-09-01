using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;
using Firebase.Extensions;

public class AuthManager : MonoBehaviour
{
    bool isLoginPage = true;

    [SerializeField] GameObject login_page;
    [SerializeField] GameObject register_page;

    [SerializeField] TMP_InputField idField;
    [SerializeField] TMP_InputField pwField;
    [SerializeField] Button sign_in_btn;
    [SerializeField] Button go_to_sign_up_btn;
    [SerializeField] GameObject login_Obj;

    [SerializeField] bool focusID = true;
    [SerializeField] bool isLoggingin = false;


    [SerializeField] TMP_InputField idField_register;
    [SerializeField] TMP_InputField pwField_register;
    [SerializeField] TMP_InputField pwField_register2;
    public TMP_InputField nickName_Field_register;
    [SerializeField] Button sign_up_btn;
    [SerializeField] Button go_to_login_btn;
    [SerializeField] GameObject register_Obj;

    public bool isRegistering = false;

    string first_Map_Name = "Village";

    // 인증을 관리할 객체
    Firebase.Auth.FirebaseAuth auth;

    void Awake()
    {
        // 객체 초기화
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        idField.ActivateInputField();
    }

    private void Update()
    {
        if (isLoginPage)
        {
            if (isLoggingin)
            {
                return;
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

            if (pwField.isFocused || idField.isFocused)
            {
                Input.imeCompositionMode = IMECompositionMode.Off;
            }
        }
        else
        {
            if (isRegistering)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (idField_register.isFocused)
                {
                    pwField_register.ActivateInputField();
                }
                else if (pwField_register.isFocused)
                {
                    pwField_register2.ActivateInputField();
                }
                else if (pwField_register2.isFocused)
                {
                    nickName_Field_register.ActivateInputField();
                }
            }

            if (pwField_register.isFocused || pwField_register2.isFocused || idField_register.isFocused)
            {
                Input.imeCompositionMode = IMECompositionMode.Off;
            }
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
        go_to_sign_up_btn.enabled = boolean;
    }

    public void Set_UI_enabled_Re(bool boolean)
    {
        idField_register.enabled = boolean;
        pwField_register.enabled = boolean;
        pwField_register2.enabled = boolean;
        sign_up_btn.enabled = boolean;
        go_to_login_btn.enabled = boolean;
        nickName_Field_register.enabled = boolean;
    }

    public void Go_To_Register()
    {
        login_page.SetActive(false);
        register_page.SetActive(true);
        idField_register.text = string.Empty;
        pwField_register.text = string.Empty;
        pwField_register2.text = string.Empty;
        nickName_Field_register.text = string.Empty;
        idField_register.ActivateInputField();
        isLoginPage = false;
    }

    public void Go_To_Login()
    {
        register_page.SetActive(false);
        login_page.SetActive(true);
        idField.text = string.Empty;
        pwField.text = string.Empty;
        idField.ActivateInputField();
        isLoginPage = true;
    }

    public void login()
    {
        // 제공되는 함수 : 이메일과 비밀번호로 로그인 시켜 줌
        auth.SignInWithEmailAndPasswordAsync(idField.text, pwField.text).ContinueWithOnMainThread(
            task => {
                if (task.IsCompleted && !task.IsFaulted && !task.IsCanceled)
                {
                    Firebase.Auth.FirebaseUser newUser = task.Result;
                    Debug.Log(idField.text + " 로 로그인 하셨습니다.");
                    Debug.Log(newUser.UserId + "은 UserId입니다.");

                    CFirebase.Instance.userID = newUser.UserId;
                    CFirebase.Instance.ReadNickName();
                    StartCoroutine(ReadNickName_Coroutine());
                }
                else
                {
                    DialogController.Instance.ShowDialog("로그인에 실패하셨습니다.");
                    Debug.Log("로그인에 실패하셨습니다.");
                    Set_UI_enabled(true);

                    if (focusID)
                        idField.ActivateInputField();
                    else
                        pwField.ActivateInputField();

                    isLoggingin = false;
                }
            }
        );
    }

    public void register()
    {
        // 비밀번호 일치 여부와 닉네임 중복 여부 확인 -> 통과하면 register2() 호출
        if (pwField_register.text != pwField_register2.text)
        {
            DialogController.Instance.ShowDialog("비밀번호가 일치하지 않습니다!");
            Debug.Log(pwField_register.text + "비번 1");
            Debug.Log(pwField_register2.text + "비번 2");
            Debug.Log("비밀번호가 일치하지 않습니다!");
            pwField_register.ActivateInputField();
            return;
        }
        Set_UI_enabled_Re(false);
        CFirebase.Instance.CheckNickName(nickName_Field_register.text, this);

    }

    public void Register2()
    {
        // 제공되는 함수 : 이메일과 비밀번호로 회원가입 시켜 줌
        auth.CreateUserWithEmailAndPasswordAsync(idField_register.text, pwField_register.text).ContinueWithOnMainThread(
            task => {
                if (!task.IsCanceled && !task.IsFaulted)
                {
                    Firebase.Auth.FirebaseUser newUser = task.Result;
                    Debug.Log(idField_register.text + "로 회원가입\n");
                    Debug.Log(newUser.UserId + "은 UserId입니다.");

                    CFirebase.Instance.WriteAccountInfo(newUser.UserId, nickName_Field_register.text);
                    Go_To_Login();
                }
                else
                {
                    DialogController.Instance.ShowDialog("회원가입 실패\n");
                    Debug.Log("회원가입 실패\n");
                }
                Set_UI_enabled_Re(true);
                isRegistering = false;
            }
            );
    }

    IEnumerator ReadNickName_Coroutine()
    {
        int loopNum = 0;
        while (true)
        {
            yield return null;
            if (Player_Info.Instance.nickName != "")
            {
                Debug.Log("loopNum = " + loopNum);
                break;
            }
            if (loopNum++ >= 99999)
            {
                Debug.Log("Exception Infinite Loop");
                

                Set_UI_enabled(true);

                if (focusID)
                    idField.ActivateInputField();
                else
                    pwField.ActivateInputField();

                isLoggingin = false;
            }
        }
        Debug.Log("ReadNickName_Coroutine -> LoadScene");
        Cursor.lockState = CursorLockMode.Locked;
        LoadingSceneController.Instance.LoadScene(first_Map_Name);
    }

    public void Quit_Game()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit(); // 어플리케이션 종료
        #endif
    }

    public void Retry()
    {
        StopAllCoroutines();
        Set_UI_enabled(true);

        if (focusID)
            idField.ActivateInputField();
        else
            pwField.ActivateInputField();

        isLoggingin = false;
    }
}