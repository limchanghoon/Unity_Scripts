using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject exitPanel;


    public void GoToITemSetting()
    {
        SceneManager.LoadScene("ITemSetting");
    }

    public void TurnOnExitBox()
    {
        exitPanel.SetActive(true);
        BackStackManager.Instance.Push(exitPanel);
    }

    public void TurnOffExitBox()
    {
        BackStackManager.Instance.Pop();
        exitPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    #region ฤÝน้
    void OnApplicationPause(bool pauseStatus)
    {
        Debug.Log("OnApplicationPause : " + pauseStatus);
    }

    #endregion
}
