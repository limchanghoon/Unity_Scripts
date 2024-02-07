using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    public Dictionary<int, StageData> stageDatas = new Dictionary<int, StageData>();
    [SerializeField] GameObject[] stageBtnObjs;
    Button[] Stagebuttons;
    LoadSceneButton[] loadSceneButtons;
    [SerializeField] Button preButton;
    [SerializeField] Button nextButton;
    [SerializeField] TextMeshProUGUI startText;
    [SerializeField] TextMeshProUGUI goldText;

    int unlockMax;

    int currentPage = 0;
    int starTotalMax = 0;
    int starTotal = 0;

    private void Awake()
    {
        List<LoadSceneButton> tmp1 = new List<LoadSceneButton> ();
        List<Button> tmp2 = new List<Button> ();
        for(int i =0;i< stageBtnObjs.Length;i++)
        {
            tmp1.Add(stageBtnObjs[i].GetComponent<LoadSceneButton>());
            tmp2.Add(stageBtnObjs[i].GetComponent<Button>());
        }
        loadSceneButtons = tmp1.ToArray();
        Stagebuttons = tmp2.ToArray();
    }

    private void Start()
    {
        unlockMax = MyJsonManager.LoadStageClearMaxData().clearMaxStage + 1;

        Addressables.LoadAssetAsync<TextAsset>("MapDataTable1").Completed += handle =>
        {
            var datas = CSVManager.ParseCSV(handle.Result);
            Addressables.Release(handle.Result);

            starTotalMax = datas.Length * 3;
            starTotal = 0;
            for (int i = 0; i < datas.Length; i++)
            {
                stageDatas.Add(datas[i].stageNumber, datas[i]);
                var stageClearData = MyJsonManager.LoadStageClearData(datas[i].stageNumber.ToString());
                if(stageClearData != null)
                    starTotal += stageClearData.starCount;
            }
            startText.text = starTotal.ToString() + " / " + starTotalMax.ToString();
            SetButtons();
        };

        goldText.text = MyJsonManager.LoadGoldData().ToString()+"G";
    }

    public void ShowPre()
    {
        --currentPage;
        SetButtons();
    }

    public void ShowNext()
    {
        ++currentPage;
        SetButtons();
    }

    public void SetButtons()
    {
        preButton.interactable = currentPage != 0 ? true : false;
        nextButton.interactable = (currentPage + 1) * 10 < stageDatas.Count ? true : false;

        for (int i = 0; i < stageBtnObjs.Length; i++)
        {
            int stageNumber = (stageBtnObjs.Length) * currentPage + i + 1;
            if (stageNumber <= unlockMax)
                Stagebuttons[i].interactable = true;
            else
                Stagebuttons[i].interactable = false;

            var lsb = loadSceneButtons[i];
            lsb.SetStageNumber(stageNumber);
            lsb.SetScaleZero();
            var stageClearData = MyJsonManager.LoadStageClearData(stageNumber.ToString());
            if (stageClearData == null)
                lsb.SetStar(0);
            else
                lsb.SetStar(stageClearData.starCount);
        }
        StopAllCoroutines();
        StartCoroutine(PlayButtonAnimCoroutine());
    }

    public void GoToShop()
    {
        LoadSceneManager.Instance.LoadSceneByName("Shop");
    }

    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    IEnumerator PlayButtonAnimCoroutine()
    {
        for (int i = 0; i < stageBtnObjs.Length; i++)
        {
            int index = (stageBtnObjs.Length) * currentPage + i;
            if (index >= stageDatas.Count)
                yield break;
            yield return new WaitForSeconds(0.1f);
            stageBtnObjs[i].SetActive(true);
            stageBtnObjs[i].GetComponent<LoadSceneButton>().PlayOpenAnim();
        }
    }
}
