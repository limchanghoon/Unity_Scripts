using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    public AudioMixer audioMixer;

    private static SoundController instance;

    public static SoundController Instance
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

    private void Start()
    {
        audioMixer.SetFloat("Master", -80f);
        audioMixer.SetFloat("BGM", -80f);
        audioMixer.SetFloat("SFX", -80f);
    }


    public void SetAudioMixer()
    {
        float _Master = ETC_Memory.Instance.myOption.soundOption.master_Volume == 0 ?
            -80 : Mathf.Lerp(-40, 0, Mathf.Log10(ETC_Memory.Instance.myOption.soundOption.master_Volume) / 2);
        float _BGM = ETC_Memory.Instance.myOption.soundOption.bgm_Volume == 0 ?
            -80 : Mathf.Lerp(-40, 0, Mathf.Log10(ETC_Memory.Instance.myOption.soundOption.bgm_Volume) / 2);
        float _SFX = ETC_Memory.Instance.myOption.soundOption.effect_Volume == 0 ?
            -80 : Mathf.Lerp(-40, 0, Mathf.Log10(ETC_Memory.Instance.myOption.soundOption.effect_Volume) / 2);

        audioMixer.SetFloat("Master", _Master);
        audioMixer.SetFloat("BGM", _BGM);
        audioMixer.SetFloat("SFX", _SFX);
    }
}
