using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static private GameManager instance;
    static public GameManager Instance
    {
        get { return instance; }
    }

    const int DEPTHMAX = 100000;

    [SerializeField] GameObject resultCanvas;
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] float generateRate;
    [SerializeField] int myResource;
    float timer = 0f;
    int depth = DEPTHMAX;

    [SerializeField] Tower playerTower;
    [SerializeField] Tower enemyTower;
    public StageData stageData { get; private set; }
    public GameState gameState { get; private set; } = GameState.Ready;

    public Dictionary<UnitEnum, UnitData> unitDataDic = new Dictionary<UnitEnum, UnitData>();
    [SerializeField] UnitEnum[] unitEnums;



    private void Awake()
    {
        instance = this;
        stageData = GetStageDataFromPlayerPrefs();
        enemyTower.SetData(stageData);
        gameState = GameState.Play;

        TowerData towerData = MyJsonManager.LoadTowerData();
        generateRate = towerData.generateRate;
        playerTower.SetMaxHP(towerData.maxHP);

        foreach (UnitEnum unitEnum in unitEnums)
        {
            string str = unitEnum.ToString();
            var data = MyJsonManager.LoadUnitData(str);
            unitDataDic.Add(unitEnum, data);
        }
    }

    private void Update()
    {
        if (gameState != GameState.Play)
            return;
        timer += Time.deltaTime * generateRate;
        if (timer >= 1f)
        {
            int tmp = Mathf.FloorToInt(timer);
            timer -= tmp;
            myResource += tmp;
            UpdateCostText();
        }
    }

    public void Finish(bool isPlayerWin)
    {
        gameState = isPlayerWin ? GameState.Win : GameState.Lose;
        GameObject obj = Instantiate(resultCanvas);
        var goldData = MyJsonManager.LoadGoldData();
        int rewardGold = 10;
        byte star = 0;
        if (isPlayerWin)
        {
            star = 2;
            if (playerTower.maxHP == playerTower.currentHP)
                ++star;

            var preStageClearData = MyJsonManager.LoadStageClearData(stageData.stageNumber.ToString());
            if(preStageClearData.starCount < star)
                MyJsonManager.SaveStageClearData(stageData.stageNumber.ToString(), new StageClearData(star));

            if (stageData.stageNumber > MyJsonManager.LoadStageClearMaxData().clearMaxStage)
                MyJsonManager.SaveStageClearMaxData(new StageClearMaxData(stageData.stageNumber));

            rewardGold = 100 + star * stageData.stageNumber * 5;
        }

        var resultPanel = obj.GetComponent<ResultPanel>();
        resultPanel.SetStar(star);
        resultPanel.SetGold(rewardGold);
        resultPanel.SetStageNumber(stageData.stageNumber);

        goldData.gold += rewardGold;
        MyJsonManager.SaveGoldData(goldData);
    }

    public void UpdateCostText()
    {
        costText.text = myResource.ToString();
    }

    public bool ConsumeResource(int cost)
    {
        if (cost > myResource)
            return false;
        myResource -= cost;
        return true;
    }

    public int GetNextZ()
    {
        depth = depth - 1 < 0 ? DEPTHMAX : depth - 1;
        return depth;
    }

    public StageData GetStageDataFromPlayerPrefs()
    {
        StageData stageData = new StageData(PlayerPrefs.GetInt("StageNumber"), PlayerPrefs.GetInt("StageMaxHP"), PlayerPrefs.GetFloat("StageGenerateRate"));
        return stageData;
    }
}


public enum GameState
{
    Ready,
    Play,
    Pause,
    Win,
    Lose
}