using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    const int UNITCOUNT = 5;
    GoldData m_GoldData;
    int currentPage = 0;
    ShopPageType currentShopPageType = ShopPageType.Tower;
    [SerializeField] Animator animator;

    [SerializeField] Sprite bar;
    [SerializeField] Sprite bar_box;
    [SerializeField] UnitEnum[] unitEnums;
    List<UnitData> unitDataList = new List<UnitData>();
    TowerData m_TowerData;

    [Header("ªÛ¡° ≥ª∫Œ UI")]
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI currentNameText;
    [SerializeField] TextMeshProUGUI currentInfoText;

    [SerializeField] Image towerButtonImage;
    [SerializeField] Image unitButtonImage;
    [SerializeField] Button preButton;
    [SerializeField] Button nextButton;

    [SerializeField] Transform renderTextureTransform;

    [SerializeField] Button towerBtn1;
    [SerializeField] Button towerBtn2;
    [SerializeField] Button towerBtn3;

    [SerializeField] Button unitBtn1;
    [SerializeField] Button unitBtn2;
    [SerializeField] Button unitBtn3;

    [SerializeField] TextMeshProUGUI infoText1;
    [SerializeField] TextMeshProUGUI infoText2;
    [SerializeField] TextMeshProUGUI infoText3;

    [SerializeField] TextMeshProUGUI goldText1;
    [SerializeField] TextMeshProUGUI goldText2;
    [SerializeField] TextMeshProUGUI goldText3;

    [SerializeField] TextMeshProUGUI figureText1;
    [SerializeField] TextMeshProUGUI figureText2;
    [SerializeField] TextMeshProUGUI figureText3;

    private void Awake()
    {
        m_GoldData = MyJsonManager.LoadGoldData();
    }

    private void Start()
    {
        m_TowerData = MyJsonManager.LoadTowerData();

        for (int i = 0; i < unitEnums.Length; ++i)
        {
            string str = unitEnums[i].ToString();
            var data = MyJsonManager.LoadUnitData(str);
            unitDataList.Add(data);
        }

        SwitchUI();
    }

    public void UpdateGoldText()
    {
        goldText.text = m_GoldData.ToString()+"G";
    }

    public void SwitchWithTower()
    {
        if (currentShopPageType == ShopPageType.Tower)
            return;
        currentShopPageType = ShopPageType.Tower;
        towerButtonImage.sprite = bar_box;
        unitButtonImage.sprite = bar;
        SetUI();
    }

    public void SwitchWithUnit()
    {
        if (currentShopPageType == ShopPageType.Unit)
            return;
        currentShopPageType = ShopPageType.Unit;
        towerButtonImage.sprite = bar;
        unitButtonImage.sprite = bar_box;
        currentPage = 0;
        SetUI();
    }

    public void ShowPre()
    {
        --currentPage;
        SetUI();
    }

    public void ShowNext()
    {
        ++currentPage;
        SetUI();
    }


    public void SetUI()
    {
        animator.SetTrigger("Appear");
        SetCurrentInfoText();
        if (currentShopPageType == ShopPageType.Tower)
        {
            renderTextureTransform.position = new Vector3(4000, 3901, -1);
            preButton.interactable = false;
            nextButton.interactable = false;
            return;
        }
        renderTextureTransform.position = new Vector3(4000 + currentPage * 5, 4001, -1);
        preButton.interactable = true;
        nextButton.interactable = true;
        if (currentPage == 0)
            preButton.interactable = false;
        else if(currentPage == UNITCOUNT-1)
            nextButton.interactable = false;
    }

    public void SwitchUI()
    {
        UpdateGoldText();
        SetCurrentInfoText();
        if (currentShopPageType == ShopPageType.Tower)
        {
            towerBtn1.gameObject.SetActive(true);
            towerBtn2.gameObject.SetActive(true);
            towerBtn3.gameObject.SetActive(true);

            unitBtn1.gameObject.SetActive(false);
            unitBtn2.gameObject.SetActive(false);
            unitBtn3.gameObject.SetActive(false);

            infoText1.text = "Increase Resource Acquisition";
            infoText2.text = "Increase Tower MaxHP";
            infoText3.text = "";

            goldText1.text = (m_TowerData.generateRateLevel*100).ToString();
            goldText2.text = (m_TowerData.maxHPLevel * 100).ToString();
            goldText3.text = "";

            figureText1.text = "+1";
            figureText2.text = "+50";
            figureText3.text = "";
        }
        else if(currentShopPageType == ShopPageType.Unit)
        {
            var unitData = GetCurrentUnitData();

            towerBtn1.gameObject.SetActive(false);
            towerBtn2.gameObject.SetActive(false);
            towerBtn3.gameObject.SetActive(false);

            unitBtn1.gameObject.SetActive(true);
            unitBtn2.gameObject.SetActive(true);
            unitBtn3.gameObject.SetActive(true);

            infoText1.text = "Increase Attack Power";
            infoText2.text = "Increase MaxHP";
            infoText3.text = "Increase Movement Speed";

            goldText1.text = (unitData.powerLevel * 100).ToString();
            goldText2.text = (unitData.maxHPLevel * 100).ToString();
            goldText3.text = (unitData.moveSpeedLevel * 100).ToString();

            figureText1.text = "+1";
            figureText2.text = "+5";
            figureText3.text = "+0.05";
        }
    }


    public void UpgradeResourceAcquisition()
    {
        if (m_TowerData.generateRateLevel * 100 > m_GoldData)
        {
            Debug.Log("µ∑ ∫Œ¡∑!");
            return;
        }
        m_GoldData.gold -= m_TowerData.generateRateLevel * 100;
        ++m_TowerData.generateRateLevel;
        m_TowerData.generateRate = 20f + m_TowerData.generateRateLevel - 1;

        MyJsonManager.SaveTowerData(m_TowerData);
        MyJsonManager.SaveGoldData(m_GoldData);

        SwitchUI();
    }

    public void UpgradeTowerMaxHP()
    {
        if (m_TowerData.maxHPLevel * 100 > m_GoldData)
        {
            Debug.Log("µ∑ ∫Œ¡∑!");
            return;
        }
        m_GoldData.gold -= m_TowerData.maxHPLevel * 100;
        ++m_TowerData.maxHPLevel;
        m_TowerData.maxHP = 1000 + 50 * (m_TowerData.maxHPLevel - 1);

        MyJsonManager.SaveTowerData(m_TowerData);
        MyJsonManager.SaveGoldData(m_GoldData);

        SwitchUI();
    }

    public void UpgradeUnitPower()
    {
        string curUnitName = GetCurrentUnitName();
        var unitData = GetCurrentUnitData();

        if (unitData.powerLevel * 100 > m_GoldData)
        {
            Debug.Log("µ∑ ∫Œ¡∑!");
            return;
        }
        m_GoldData.gold -= unitData.powerLevel * 100;
        ++unitData.powerLevel;
        ++unitData.power;

        MyJsonManager.SaveUnitData(curUnitName,unitData);
        MyJsonManager.SaveGoldData(m_GoldData);

        SwitchUI();
    }

    public void UpgradeUnitMaxHP()
    {
        string curUnitName = GetCurrentUnitName();
        var unitData = GetCurrentUnitData();

        if (unitData.maxHPLevel * 100 > m_GoldData)
        {
            Debug.Log("µ∑ ∫Œ¡∑!");
            return;
        }
        m_GoldData.gold -= unitData.maxHPLevel * 100;
        ++unitData.maxHPLevel;
        unitData.maxHP += 5;

        MyJsonManager.SaveUnitData(curUnitName, unitData);
        MyJsonManager.SaveGoldData(m_GoldData);

        SwitchUI();
    }

    public void UpgradeUnitMoveSpeed()
    {
        string curUnitName = GetCurrentUnitName();
        var unitData = GetCurrentUnitData();

        if (unitData.moveSpeedLevel * 100 > m_GoldData)
        {
            Debug.Log("µ∑ ∫Œ¡∑!");
            return;
        }
        m_GoldData.gold -= unitData.moveSpeedLevel * 100;
        ++unitData.moveSpeedLevel;
        unitData.moveSpeed += 0.05f;

        MyJsonManager.SaveUnitData(curUnitName, unitData);
        MyJsonManager.SaveGoldData(m_GoldData);

        SwitchUI();
    }

    public void SetCurrentInfoText()
    {
        if (currentShopPageType == ShopPageType.Tower)
        {
            currentNameText.text = "Tower";
            currentInfoText.text = "*Resource Rate : " + m_TowerData.generateRate.ToString() + "\n*MaxHP : " + m_TowerData.maxHP.ToString();
            return;
        }
        currentNameText.text = GetCurrentUnitName();
        currentInfoText.text = "*Attack Power : " + unitDataList[currentPage].power.ToString() + "\n*MaxHP : " + unitDataList[currentPage].maxHP.ToString() 
            + "\n*Movement Speed : " + unitDataList[currentPage].moveSpeed.ToString("F2");
    }

    public UnitData GetCurrentUnitData()
    {
        return unitDataList[currentPage];
    }

    public string GetCurrentUnitName()
    {
        return ((UnitEnum)currentPage).ToString();
    }

    public void GetGoldCheat()
    {
        m_GoldData.gold += 1000;
        UpdateGoldText();
        MyJsonManager.SaveGoldData(m_GoldData);
    }
}

enum ShopPageType
{
    Tower,
    Unit
}