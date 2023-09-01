using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    [SerializeField] Image dialogBg;
    [SerializeField] TextMeshProUGUI text;

    Coroutine curCoroutine = null;

    private static DialogController instance;

    public static DialogController Instance
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

    private static DialogController Create()
    {
        return Instantiate(Resources.Load<DialogController>("Dialog"));
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

    public void ShowDialog(string str)
    {
        if (curCoroutine != null)
            StopCoroutine(curCoroutine);
        text.text = str;
        dialogBg.color = Color.white;
        text.color = Color.black;
        curCoroutine = StartCoroutine(DialogCoroutine());
    }

    IEnumerator DialogCoroutine()
    {
        Debug.Log("DialogCoroutine");
        yield return new WaitForSeconds(1f);
        float t = 0f;
        while(t <= 1f)
        {
            yield return null;
            t += Time.deltaTime;
            dialogBg.color = Color.white - Color.black * t;
            text.color = Color.black - Color.black * t;
        }
        dialogBg.color = Color.clear;
        text.color = Color.clear;
    }
}
