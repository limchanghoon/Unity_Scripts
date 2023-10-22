using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionData
{
    // 화면 옵션의 경우 로컬 디바이스 기준으로 적용한다.
    public SoundOption soundOption;
    public MouseOption mouseOption;
    public KeyOption keyOption;

    public OptionData()
    {
        soundOption = new SoundOption();
        mouseOption = new MouseOption();
        keyOption = new KeyOption();
    }
}

[Serializable]
public class SoundOption
{
    public int master_Volume, bgm_Volume, effect_Volume;

    public SoundOption()
    {
        master_Volume = 50;
        bgm_Volume = 50;
        effect_Volume = 50;
    }
}

[Serializable]
public class MouseOption
{
    public int v_Sensitivity, h_Sensitivity;

    public MouseOption()
    {
        v_Sensitivity = 50;
        h_Sensitivity = 50;
    }
}

public enum KeySetting
{
    FORWARD, BACK, RIGHT, LEFT, JUMP, DASH, RELOAD, INTERACT, ROCKET, PORTAL_RED, PORTAL_BLUE
        , QUEST, QUEST_NOTICE, INVENTORY, EQUIPMENT_WINDOW, STATE_WINDOW, TOTAL_COUNT
}

[Serializable]
public class KeyOption
{
    [HideInInspector]
    public KeyCode[] keyList = {
        KeyCode.W, KeyCode.S, KeyCode.D, KeyCode.A, KeyCode.Space, KeyCode.LeftShift, KeyCode.R, KeyCode.F, KeyCode.Q, KeyCode.Alpha1, KeyCode.Alpha2
            , KeyCode.Tab, KeyCode.L, KeyCode.I, KeyCode.O, KeyCode.P };

    public KeyOption()
    {

    }

    public KeyCode GetKeyCode(KeySetting _keySetting)
    {
        return keyList[(int)_keySetting];
    }
}
