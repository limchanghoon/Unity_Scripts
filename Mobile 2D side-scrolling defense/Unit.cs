using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Unit : PoolingObject, IHit, IGetHPbarTarget
{
    [SerializeField] UnitEnum unitEnum;
    Animator animator;
    HPBar hpbar;
    Slider hpbarSlider;
    Collider2D myCollider;

    [SerializeField] Transform hpbarTr;

    [SerializeField] int currentHP;
    UnitData unitData;



    SpriteRenderer[] spriteRenderers;

    bool isMine;
    bool isDie = true;
    bool canAttack = true;
    bool isRed = false;
    bool isFinishingPose = false;
    RaycastHit2D hit;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        isMine = (tag == "Player") ? true : false;
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    public override void ReInit()
    {
        if (unitData == null)
            unitData = GameManager.Instance.unitDataDic[unitEnum];
        animator.Rebind();
        myCollider.enabled = true;
        currentHP = unitData.maxHP;

        isDie = false;
        canAttack = true;
        isRed = false;
        foreach (var spriteRenderer in spriteRenderers)
        {
            spriteRenderer.color = Color.white;
        }
    }


    private void Update()
    {
        if (isDie)  return;
        if (GameManager.Instance.gameState == GameState.Win || GameManager.Instance.gameState == GameState.Lose)
        {
            if (!isFinishingPose)
                StartCoroutine(SetFinishingPoseCoroutine());
            return;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("move"))
            transform.Translate(Time.deltaTime * unitData.moveSpeed, 0f, 0f);
    }

    private void FixedUpdate()
    {
        if (isDie || GameManager.Instance.gameState != GameState.Play) return;
        if (isMine)
            hit = Physics2D.Raycast((Vector2)transform.position + unitData.rayOffset, Vector2.right, unitData.rayDistance, 1 << LayerMask.NameToLayer("Enemy"));
        else
            hit = Physics2D.Raycast((Vector2)transform.position + unitData.rayOffset, Vector2.right, unitData.rayDistance, 1 << LayerMask.NameToLayer("Player"));

        if (hit)
        {
            animator.SetBool("Move", false);
            if (canAttack)
                StartCoroutine(CooldownCoroutine());
        }
        else
        {

            animator.SetBool("Move", true);
        }
    }

    IEnumerator CooldownCoroutine()
    {
        canAttack = false;
        yield return new WaitForSeconds(Random.Range(0.01f, 0.05f));
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(unitData.cooltime + Random.Range(0f, 0.1f));
        canAttack = true;
    }

    public void Attack()
    {
        if (isMine)
            hit = Physics2D.Raycast((Vector2)transform.position + unitData.rayOffset, Vector2.right, unitData.rayDistance, 1 << LayerMask.NameToLayer("Enemy"));
        else
            hit = Physics2D.Raycast((Vector2)transform.position + unitData.rayOffset, Vector2.right, unitData.rayDistance, 1 << LayerMask.NameToLayer("Player"));

        if(hit)
            hit.transform.GetComponent<IHit>().Hit(unitData.power);
    }

    IEnumerator SetFinishingPoseCoroutine()
    {
        isFinishingPose = true;
        yield return new WaitForSeconds(Random.Range(0f, 0.5f));
        if (tag == "Player")
        {
            if (GameManager.Instance.gameState == GameState.Win)
                animator.SetBool("Victory", true);
            else
                animator.SetTrigger("Die");
        }
        else if (tag == "Enemy")
        {
            if (GameManager.Instance.gameState == GameState.Lose)
                animator.SetBool("Victory", true);
            else
                animator.SetTrigger("Die");
        }
    }

    public void BindHpbar(HPBar _newHPBar)
    {
        hpbar = _newHPBar;
        hpbarSlider = hpbar.GetComponent<Slider>();
        currentHP = unitData.maxHP;
        UpdateHPBar();
    }

    public void UpdateHPBar()
    {
        hpbarSlider.value = GetHpRatio();
    }

    public float GetHpRatio()
    {
        if (unitData.maxHP <= 0)
            return 0f;
        return currentHP > 0 ? (float)currentHP / unitData.maxHP : 0f;
    }

    public bool Hit(int damage)
    {
        if (currentHP <= 0)
            return false;

        currentHP -= damage;
        var obj = PoolManager.Instance.damageTextPool.CreateOjbect();
        obj.GetComponent<DamageText>().StartAnim((Vector2)transform.position + unitData.textOffset, damage);
        if(!isRed)
            StartCoroutine(SetRed());
        UpdateHPBar();
        if (currentHP <= 0)
            Die();
        
        return true;
    }

    public void Die()
    {
        isDie = true;
        myCollider.enabled = false;
        hpbar.DestroyObject();
        animator.SetTrigger("Die");
        Invoke("DestroyObject", 3f);
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
            t += Time.deltaTime*5f;
            yield return null;
        }
        t = 0f;
        while (t < 1f)
        {
            foreach (var spriteRenderer in spriteRenderers)
            {
                spriteRenderer.color = Color.Lerp(Color.red, Color.white, t);
            }
            t += Time.deltaTime*10f;
            yield return null;
        }
        isRed = false;
    }

    public Transform GetHPbarTarget()
    {
        return hpbarTr;
    }

    public RaycastHit2D GetHitTarget()
    {
        return hit;
    }

    public float GetRayDistance()
    {
        return unitData.rayDistance;
    }

    public int GetPower()
    {
        return unitData.power;
    }

    public UnitData GetUnitData()
    {
        return unitData;
    }

    public UnitEnum GetUnitEnum()
    {
        return unitEnum;
    }

    void OnDrawGizmos()
    {
        if (unitData == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + (Vector3)unitData.rayOffset, Vector3.right * unitData.rayDistance);
    }
}

[System.Serializable]
public enum UnitEnum
{
    Soldier,
    Knight,
    Archer,
    Thief,
    Priest,
    UnitCount,
    Monster1,
    Monster2,
    Monster3,
    Monster4
}


[System.Serializable]
public class UnitData
{
    public UnitEnum unitenum;
    public int cost;
    public int power;

    public int maxHP;

    public float cooltime;
    public float moveSpeed;
    public float rayDistance;
    public Vector2 textOffset;
    public Vector2 rayOffset;
    public Vector2 spawnPosition;

    public int powerLevel = 1;
    public int maxHPLevel = 1;
    public int moveSpeedLevel = 1;

    public UnitData() { }

    public UnitData(UnitScriptableObject unitData)
    {
        this.unitenum = unitData.unitenum;
        this.cost = unitData.cost;
        this.power = unitData.power;

        this.maxHP = unitData.maxHP;

        this.cooltime = unitData.cooltime;
        this.moveSpeed = unitData.moveSpeed;
        this.rayDistance = unitData.rayDistance;
        this.textOffset = unitData.textOffset;
        this.rayOffset = unitData.rayOffset;
        this.spawnPosition = unitData.spawnPosition;
    }
}