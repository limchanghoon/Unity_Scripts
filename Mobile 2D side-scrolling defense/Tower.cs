using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour,IHit
{
    [SerializeField] GameObject[] explosions;
    SpriteRenderer[] spriteRenderers;
    [SerializeField] Slider hpbar;
    [SerializeField] TextMeshProUGUI hpText;

    public int maxHP { get; private set; }
    public int currentHP { get; private set; }
    float generateRate = 0f;
    bool isRed = false;
    [SerializeField] Vector3 textOffset;

    private void Awake()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    public void SetMaxHP(int newMaxHP)
    {
        maxHP = newMaxHP;
        currentHP = maxHP;
        UpdateHPBar();
    }

    public bool Hit(int damage)
    {
        if (currentHP <= 0)
            return false;

        currentHP = currentHP - damage < 0 ? 0 : currentHP - damage;
        //var obj = PoolManager.Instance.damageTextPool.CreateOjbect();
        //obj.GetComponent<DamageText>().StartAnim(transform.position + textOffset, damage);
        if (!isRed)
            StartCoroutine(SetRed());
        UpdateHPBar();
        if (currentHP <= 0)
            Die();

        return true;
    }

    public void Die()
    {
        StartCoroutine(ExplosionCoroutine());
        GameManager.Instance.Finish(tag == "Enemy");
    }

    IEnumerator ExplosionCoroutine()
    {
        for (int i = 0; i < explosions.Length; i++)
        {
            explosions[i].SetActive(true);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }

    IEnumerator SetRed()
    {
        isRed = true;
        float t = 0f;
        while (t < 1f)
        {
            foreach (var spriteRenderer in spriteRenderers)
            {
                spriteRenderer.color = Color.Lerp(Color.white, Color.red, t);
            }
            t += Time.deltaTime * 5f;
            yield return null;
        }
        t = 0f;
        while (t < 1f)
        {
            foreach (var spriteRenderer in spriteRenderers)
            {
                spriteRenderer.color = Color.Lerp(Color.red, Color.white, t);
            }
            t += Time.deltaTime * 10f;
            yield return null;
        }
        isRed = false;
    }

    public void SetData(StageData data)
    {
        maxHP = data.maxHP;
        generateRate = data.generateRate;
        currentHP = maxHP;
        UpdateHPBar();
    }

    public void UpdateHPBar()
    {
        hpbar.value = GetHpRatio();
        hpText.text = currentHP.ToString() + " / " + maxHP.ToString();
    }

    public float GetHpRatio()
    {
        if (maxHP <= 0)
            return 0f;
        return currentHP > 0 ? (float)currentHP / maxHP : 0f;
    }
}

[System.Serializable]
public class TowerData
{
    public float generateRate;
    public int generateRateLevel;

    public int maxHP;
    public int maxHPLevel;

    public TowerData(int generateRateLevel = 1, int maxHPLevel = 1)
    {
        this.generateRate = 20f + generateRateLevel - 1;
        this.generateRateLevel = generateRateLevel;
        this.maxHP = 1000 + 50 * (maxHPLevel - 1);
        this.maxHPLevel = maxHPLevel;
    }
}