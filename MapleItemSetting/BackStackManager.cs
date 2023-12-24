using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackStackManager : MonoBehaviour
{
    Stack<GameObject> stack;

    private static BackStackManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            stack = new Stack<GameObject>();
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public static BackStackManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (stack.Count > 0)
            {
                GameObject _go = stack.Pop();
                _go.SetActive(false);
            }
            else
            {
                Scene _scene = SceneManager.GetActiveScene();
                if (_scene.name == "Main")
                {
                    GameObject _go = GameObject.Find("ExitCanvas").transform.GetChild(0).gameObject;
                    _go.SetActive(true);
                    stack.Push(_go);
                }
                else if(_scene.name == "ITemSetting")
                {
                    SceneManager.LoadScene("Main");
                }
            }
        }
    }

    public void PushAndSetTrue(GameObject _go)
    {
        _go.SetActive(true);
        stack.Push(_go);
    }

    public void PopAndSetFalse()
    {
        GameObject _go = stack.Pop();
        _go.SetActive(false);
    }

}
