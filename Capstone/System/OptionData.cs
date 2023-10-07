using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionData
{
    public SoundOption soundOption;
    public MouseOption mouseOption;

    public OptionData()
    {
        soundOption = new SoundOption();
        mouseOption = new MouseOption();
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
