using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
    int stageNumber;
    [SerializeField] Animator animator;
    [SerializeField] LobbyManager lobbyManager;
    [SerializeField] TextMeshProUGUI stageNumberText;
    [SerializeField] Image[] stars;
    [SerializeField] Sprite starSprite;
    [SerializeField] Sprite blankStarSprite;

    public void SetStageNumber(int num)
    {
        stageNumber = num;
        stageNumberText.text = MyExtension.Int2StageString(stageNumber);
        animator.Rebind();
    }

    public void SetScaleZero()
    {
        GetComponent<RectTransform>().localScale = Vector3.zero;
    }

    public void SetStar(byte star)
    {
        for (int i = 0; i < 3; ++i)
        {
            stars[i].sprite = i < star ? starSprite : blankStarSprite;
        }
    }

    public void PlayOpenAnim()
    {
        animator.SetTrigger("Open");
    }

    public void Load()
    {
        LoadSceneManager.Instance.LoadStage(lobbyManager.stageDatas[stageNumber]);
    }
}
