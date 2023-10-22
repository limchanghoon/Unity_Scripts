using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{
    private static MainMenuController instance;

    public static MainMenuController Instance
    {
        get
        {
            if (null == instance)
            {
                return Create();
            }
            return instance;
        }
    }

    private static MainMenuController Create()
    {
        return Instantiate(Resources.Load<MainMenuController>("MainMenu"));
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            tempKeySetting = new KeyCode[keySettingBtns.Length];
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public GameObject mainMenuPanel;
    public GameObject optionPanel;
    public GameObject[] optionElePanels;

    public Button[] optionBtns;
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullScreenToggle;
    public Slider[] sliders;
    public TextMeshProUGUI[] texts;
    public Button[] downBtns;
    public Button[] upBtns;

    public Button[] keySettingBtns;
    TextMeshProUGUI[] keySettingTexts;
    KeyCode[] tempKeySetting;

    private void Start()
    {
        for(int i = 0; i < sliders.Length; i++)
        {
            int tmp = i;
            sliders[tmp].onValueChanged.AddListener((float a) => { texts[tmp].text = ((int)(a * 100)).ToString(); });
        }

        for (int i = 0; i < downBtns.Length; i++)
        {
            int tmp = i;
            downBtns[tmp].onClick.AddListener(() => { sliders[tmp].value -= 0.01f; });
        }

        for (int i = 0; i < upBtns.Length; i++)
        {
            int tmp = i;
            upBtns[tmp].onClick.AddListener(() => { sliders[tmp].value += 0.01f; });
        }

        keySettingTexts = new TextMeshProUGUI[keySettingBtns.Length];
        for(int i =0; i < keySettingBtns.Length; ++i)
        {
            keySettingTexts[i] = keySettingBtns[i].GetComponentInChildren<TextMeshProUGUI>();
        }

        SetScreenSettingUI();
        SetSliders();
        SetKeySettingTexts();
    }

    private void OnGUI()
    {
        if(currentKey != -1)
        {
            Event keyEvent = Event.current;

            if (keyEvent.isKey)
            {
                KeyCode _input = keyEvent.keyCode;
                for (int i = 0; i < tempKeySetting.Length; i++)
                {
                    if (tempKeySetting[i] == _input && i != currentKey)
                        return;
                }
                keySettingTexts[currentKey].text = _input.ToString();
                tempKeySetting[currentKey] = _input;
                SelectKeySetting(-1);
            }
        }
    }

    void SetScreenSettingUI()
    {
        switch (Screen.width)
        {
            case 1280:
                resolutionDropdown.value = 0;
                break;

            case 1366:
                resolutionDropdown.value = 1;
                break;

            case 1600:
                resolutionDropdown.value = 2;
                break;

            case 1920:
                resolutionDropdown.value = 3;
                break;

            default:
                resolutionDropdown.value = 3;
                break;
        }
        fullScreenToggle.isOn = Screen.fullScreen;
    }

    void SetSliders()
    {
        var _myOption = ETC_Memory.Instance.myOption;

        sliders[0].value = _myOption.soundOption.master_Volume / 100f;
        sliders[1].value = _myOption.soundOption.bgm_Volume / 100f;
        sliders[2].value = _myOption.soundOption.effect_Volume / 100f;

        sliders[3].value = _myOption.mouseOption.v_Sensitivity / 100f;
        sliders[4].value = _myOption.mouseOption.h_Sensitivity / 100f;
    }


    void SetKeySettingTexts()
    {
        var _myOption = ETC_Memory.Instance.myOption;

        for (int i = 0; i < keySettingTexts.Length; ++i)
        {
            keySettingTexts[i].text = _myOption.keyOption.keyList[i].ToString();
            tempKeySetting[i] = _myOption.keyOption.keyList[i];
        }

        SelectKeySetting(-1);
    }

    private void GetResolutionFromDropdown(out int _width, out int _height)
    {
        switch (resolutionDropdown.value)
        {
            case 0:
                _width = 1280;
                _height = 720;
                break;

            case 1:
                _width = 1366;
                _height = 768;
                break;

            case 2:
                _width = 1600;
                _height = 900;
                break;

            case 3:
                _width = 1920;
                _height = 1080;
                break;

            default:
                _width = 1920;
                _height = 1920;
                break;
        }
    }



    public void KeyDownEscape()
    {
        if (optionPanel.activeSelf)
        {
            CloseOption();
        }
        else
        {
            CloseMainMenu();
        }
    }


    public void Init()
    {
        CloseOption();
    }


    public void CloseMainMenu()
    {
        GameObject.Find("GM").GetComponent<GameManager>().myPlayer.GetComponent<Player_Move>().dontMove--;
        ETC_Memory.Instance.windowDepth--;
        gameObject.SetActive(false);
    }


    public void OpenOption()
    {
        mainMenuPanel.SetActive(false);
        optionPanel.SetActive(true);
        SetScreenSettingUI();
        SetSliders();
        SetKeySettingTexts();
    }

    public void CloseOption()
    {
        optionPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }


    public void SelectWhichOption(int idx)
    {
        SelectKeySetting(-1);

        for (int i = 0; i < optionBtns.Length; i++)
        {
            ColorBlock colorBlock = optionBtns[i].colors;

            if (i == idx)
            {
                colorBlock.normalColor = new Color(0.7451f, 0.7451f, 1f);
                optionElePanels[i].SetActive(true);
            }
            else
            {
                colorBlock.normalColor = new Color(1f, 1f, 1f);
                optionElePanels[i].SetActive(false);
            }

            optionBtns[i].colors = colorBlock;

        }
    }

    int currentKey = -1;
    public void SelectKeySetting(int idx)
    {
        if (currentKey != -1)
        {
            keySettingTexts[currentKey].text = tempKeySetting[currentKey].ToString();

            ColorBlock colorBlock = keySettingBtns[currentKey].colors;
            colorBlock.normalColor = new Color(1f, 1f, 1f);
            keySettingBtns[currentKey].colors = colorBlock;
        }

        currentKey = idx;

        if (currentKey != -1)
        {
            keySettingTexts[currentKey].text = "";

            ColorBlock colorBlock = keySettingBtns[currentKey].colors;
            colorBlock.normalColor = new Color(0.667f, 0.667f, 0.667f);
            keySettingBtns[currentKey].colors = colorBlock;
        }
    }


    public void Apply()
    {
        SelectKeySetting(-1);

        var _myOption = ETC_Memory.Instance.myOption;

        int _width, _height;
        GetResolutionFromDropdown(out _width, out _height);
        ResolutionFix.Instance.FixResolution(_width, _height, fullScreenToggle.isOn);


        _myOption.soundOption.master_Volume = (int)(sliders[0].value * 100);
        _myOption.soundOption.bgm_Volume = (int)(sliders[1].value * 100); ;
        _myOption.soundOption.effect_Volume = (int)(sliders[2].value * 100);
        SoundController.Instance.SetAudioMixer();


        for (int i = 0; i < tempKeySetting.Length; ++i)
        {
            _myOption.keyOption.keyList[i] = tempKeySetting[i];
        }


        _myOption.mouseOption.v_Sensitivity = (int)(sliders[3].value * 100);
        _myOption.mouseOption.h_Sensitivity = (int)(sliders[4].value * 100);



        CFirebase.Instance.WriteOptionData();
    }


    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); // 어플리케이션 종료
        #endif
    }
}
