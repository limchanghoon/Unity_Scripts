using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] Button goNextStageButton;
    [SerializeField] TextMeshProUGUI goldText;
    Animator animator;
    StageData nextStageData;

    [SerializeField] Image[] stageNumberImages;
    [SerializeField] Sprite[] numberSprite;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        GetNextStageData();
    }

    void OpenUI()
    {
        animator.SetTrigger("Open");
    }

    public void SetStar(byte starCount)
    {
        if (starCount == 0)
            goNextStageButton.interactable = false;
        animator.SetInteger("Star", starCount);
    }

    public void SetGold(int rewardGold)
    {
        goldText.text = "+" + rewardGold.ToString() + "G";
    }

    public void SetStageNumber(int stageNumber)
    {
        for (int i = stageNumberImages.Length - 1; i >= 0; --i)
        {
            if (stageNumber == 0)
            {
                stageNumberImages[i].sprite = numberSprite[0];
                continue;
            }
            int remainder = stageNumber % 10;
            stageNumber /= 10;
            stageNumberImages[i].sprite =numberSprite[remainder];
        }
    }

    public void GetNextStageData()
    {
        Addressables.LoadAssetAsync<TextAsset>("MapDataTable1").Completed += handle =>
        {
            var data = CSVManager.GetStageDataFromCSV(handle.Result, GameManager.Instance.stageData.stageNumber + 1);
            Addressables.Release(handle.Result);
            nextStageData = data;
            if(nextStageData == null)
                goNextStageButton.interactable = false;
            Invoke("OpenUI", 3f);
        };
    }

    public void Restart()
    {
        LoadSceneManager.Instance.LoadStage(GameManager.Instance.stageData);
    }

    public void GoNextStage()
    {
        LoadSceneManager.Instance.LoadStage(nextStageData);
    }

    public void GoToLobby()
    {
        LoadSceneManager.Instance.LoadSceneByName("Lobby");
    }
}
