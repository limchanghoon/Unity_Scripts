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

    // ������ ������ ��ü
    Firebase.Auth.FirebaseAuth auth;

    void Awake()
    {
        // ��ü �ʱ�ȭ
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
        // �����Ǵ� �Լ� : �̸��ϰ� ��й�ȣ�� �α��� ���� ��
        auth.SignInWithEmailAndPasswordAsync(idField.text, pwField.text).ContinueWithOnMainThread(
            task => {
                if (task.IsCompleted && !task.IsFaulted && !task.IsCanceled)
                {
                    Firebase.Auth.FirebaseUser newUser = task.Result;
                    Debug.Log(idField.text + " �� �α��� �ϼ̽��ϴ�.");
                    Debug.Log(newUser.UserId + "�� UserId�Դϴ�.");

                    CFirebase.Instance.userID = newUser.UserId;
                    CFirebase.Instance.ReadNickName();
                    StartCoroutine(ReadNickName_Coroutine());
                }
                else
                {
                    DialogController.Instance.ShowDialog("�α��ο� �����ϼ̽��ϴ�.");
                    Debug.Log("�α��ο� �����ϼ̽��ϴ�.");
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
        // ��й�ȣ ��ġ ���ο� �г��� �ߺ� ���� Ȯ�� -> ����ϸ� register2() ȣ��
        if (pwField_register.text != pwField_register2.text)
        {
            DialogController.Instance.ShowDialog("��й�ȣ�� ��ġ���� �ʽ��ϴ�!");
            Debug.Log(pwField_register.text + "��� 1");
            Debug.Log(pwField_register2.text + "��� 2");
            Debug.Log("��й�ȣ�� ��ġ���� �ʽ��ϴ�!");
            pwField_register.ActivateInputField();
            return;
        }
        Set_UI_enabled_Re(false);
        CFirebase.Instance.CheckNickName(nickName_Field_register.text, this);

    }

    public void Register2()
    {
        // �����Ǵ� �Լ� : �̸��ϰ� ��й�ȣ�� ȸ������ ���� ��
        auth.CreateUserWithEmailAndPasswordAsync(idField_register.text, pwField_register.text).ContinueWithOnMainThread(
            task => {
                if (!task.IsCanceled && !task.IsFaulted)
                {
                    Firebase.Auth.FirebaseUser newUser = task.Result;
                    Debug.Log(idField_register.text + "�� ȸ������\n");
                    Debug.Log(newUser.UserId + "�� UserId�Դϴ�.");

                    CFirebase.Instance.WriteAccountInfo(newUser.UserId, nickName_Field_register.text);
                    Go_To_Login();
                }
                else
                {
                    DialogController.Instance.ShowDialog("ȸ������ ����\n");
                    Debug.Log("ȸ������ ����\n");
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
                Application.Quit(); // ���ø����̼� ����
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