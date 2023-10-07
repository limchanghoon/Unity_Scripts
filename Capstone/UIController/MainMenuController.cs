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
    public Slider[] sliders;
    public TextMeshProUGUI[] texts;
    public Button[] downBtns;
    public Button[] upBtns;

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

        SetSliders();
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
        ETC_Memory.Instance.windowDepth--;
        gameObject.SetActive(false);
    }


    public void OpenOption()
    {
        mainMenuPanel.SetActive(false);
        optionPanel.SetActive(true);
        SetSliders();
    }

    public void CloseOption()
    {
        optionPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }


    public void SelectWhichOption(int idx)
    {
        for(int i = 0; i < optionBtns.Length; i++)
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


    public void Apply()
    {
        var _myOption = ETC_Memory.Instance.myOption;

        _myOption.soundOption.master_Volume = (int)(sliders[0].value * 100);
        _myOption.soundOption.bgm_Volume = (int)(sliders[1].value * 100); ;
        _myOption.soundOption.effect_Volume = (int)(sliders[2].value * 100); ;

        _myOption.mouseOption.v_Sensitivity = (int)(sliders[3].value * 100); ;
        _myOption.mouseOption.h_Sensitivity = (int)(sliders[4].value * 100); ;

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
