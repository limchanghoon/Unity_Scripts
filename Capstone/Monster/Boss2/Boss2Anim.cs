using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Anim : MonoBehaviour
{
    [SerializeField] Boss2 boss2;

    public float stride;
    [SerializeField] Transform rArmHint;
    [SerializeField] Transform lArmHint;
    [SerializeField] Transform originRArmHint;
    [SerializeField] Transform originLArmHint;
    [SerializeField] Transform atk1ArmHint;

    [SerializeField] Transform originRArm;
    [SerializeField] Transform originLArm;

    [SerializeField] Transform rightLegTarget;
    [SerializeField] Transform leftLegTarget;

    [SerializeField] Transform rightArmTarget;
    [SerializeField] Transform leftArmTarget;
    [SerializeField] Transform center;

    [SerializeField] Transform rf;
    [SerializeField] Transform rb;
    [SerializeField] Transform lf;
    [SerializeField] Transform lb;

    [SerializeField] Transform atk1LeftStart;
    [SerializeField] Transform atk1LeftEnd;    
    [SerializeField] Transform atk1right1;
    [SerializeField] Transform atk1right2;
    [SerializeField] Transform atk1right3;
    
    [SerializeField] Transform shootR1;    
    [SerializeField] Transform shootR2;
    [SerializeField] Transform shootL1;
    [SerializeField] Transform shootL2;

    [SerializeField] Vector3 curRLegPos;
    [SerializeField] Vector3 nextRLegPos;
    [SerializeField] Vector3 curLLegPos;
    [SerializeField] Vector3 nextLLegPos;

    [SerializeField] Vector3 curRArmPos;
    [SerializeField] Vector3 nextRArmPos;
    [SerializeField] Vector3 curLArmPos;
    [SerializeField] Vector3 nextLArmPos;

    [SerializeField] Boss2AtkCol leftAtkScrip;
    [SerializeField] Boss2AtkCol rightAtkScrip;

    public float preRotY = 0f;

    float l1 = 1f;
    float l2 = 1f;

    [SerializeField] Transform target;
    Coroutine legCoroutine;

    [SerializeField] CameraShake cameraShake;
    [SerializeField] GameObject[] waves;

    private void Start()
    {
        curRLegPos = rightLegTarget.position;
        nextRLegPos = curRLegPos;
        curLLegPos = leftLegTarget.position;
        nextLLegPos = curLLegPos;
        center.position = (rightLegTarget.position + leftLegTarget.position) / 2f;
    }

    public void DashAtk1()
    {
        if (legCoroutine != null)
            StopCoroutine(legCoroutine);
        legCoroutine = StartCoroutine(LeftLegStart(4f));
        StartCoroutine(DashAtk1Coroutine());
    }

    IEnumerator DashAtk1Coroutine()
    {
        yield return StartCoroutine(DashCoroutine());
        yield return StartCoroutine(Atk1Coroutine());
        if(PhotonNetwork.IsMasterClient)
            boss2.patternStart = true;
    }

    public void Shoot1()
    {
        StartCoroutine(ShootCoroutine());
    }

    IEnumerator ShootCoroutine()
    {
        if (legCoroutine != null)
            StopCoroutine(legCoroutine);
        legCoroutine = StartCoroutine(LeftLegStart(4f));
        yield return StartCoroutine(DashCoroutine());
        curLArmPos = leftArmTarget.position;
        curRArmPos = rightArmTarget.position;
        float t = 0f;
        Vector3 dir;
        while (t < 1f)
        {
            t += Time.deltaTime * 2;
            
            leftArmTarget.position = Vector3.Lerp(curLArmPos, shootL1.position, t);
            rightArmTarget.position = Vector3.Lerp(curRArmPos, shootR1.position, t);
            dir = target.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), t);
            yield return null;
        }

        for (int i = 0; i < 5; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                Vector3 des1 = target.position;
                des1 += target.right * Random.Range(-10f, 20f) + target.forward * Random.Range(-10f, 10f);
                des1.y = 0;
                Vector3 des2 = target.position;
                des2 += target.right * Random.Range(-10f, 20f) + target.forward * Random.Range(-10f, 10f);
                des2.y = 0;
                PhotonNetwork.Instantiate("Boss2Missile", rightArmTarget.position, Quaternion.identity, 0, new object[] { des1 });
                PhotonNetwork.Instantiate("Boss2Missile", leftArmTarget.position, Quaternion.identity, 0, new object[] { des2 });
            }
            curLArmPos = leftArmTarget.position;
            curRArmPos = rightArmTarget.position;
            t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime * 10;
                leftArmTarget.position = Vector3.Lerp(curLArmPos, shootL2.position, t);
                rightArmTarget.position = Vector3.Lerp(curRArmPos, shootR2.position, t);
                dir = target.position - transform.position;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), t);
                yield return null;
            }

            curLArmPos = leftArmTarget.position;
            curRArmPos = rightArmTarget.position;
            t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime /2;
                leftArmTarget.position = Vector3.Lerp(curLArmPos, shootL1.position, t);
                rightArmTarget.position = Vector3.Lerp(curRArmPos, shootR1.position, t);
                dir = target.position - transform.position;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), t);
                yield return null;
            }
        }
        boss2.patternStart = true;
    }

    public void Atk1()
    {
        StartCoroutine(Atk1Coroutine());
    }

    IEnumerator Atk1Coroutine()
    {
        curLArmPos = leftArmTarget.position;
        curRArmPos = rightArmTarget.position;
        Vector3 curLHintPos = lArmHint.position;
        Vector3 curRHintPos = rArmHint.position;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime*2;
            leftArmTarget.position = Vector3.Lerp(curLArmPos, atk1LeftStart.position, t);
            rightArmTarget.position = Vector3.Lerp(curRArmPos, atk1right1.position, t);
            lArmHint.position = Vector3.Lerp(curLHintPos, atk1ArmHint.position, t);
            yield return null;
        }
        curLArmPos = atk1LeftStart.position;
        curRArmPos = atk1right1.position;
        lArmHint.position = atk1ArmHint.position;

        // ¿Þ¼Õ °ø°Ý ON
        leftAtkScrip.b_Attack = true;
        //Vector3 des = (target.position - transform.position).magnitude < 20f ? target.position : atk1LeftEnd.position;
        Vector3 des = atk1LeftEnd.position;
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 2f;
            leftArmTarget.position = Vector3.Lerp(curLArmPos, des, t) + 10 * transform.up * Mathf.Sin(t * Mathf.PI);
            rightArmTarget.position = Vector3.Lerp(curRArmPos, atk1right2.position, t);
            rArmHint.position = Vector3.Lerp(curRHintPos, atk1ArmHint.position, t);
            yield return null;
        }
        curLArmPos = des;
        curRArmPos = atk1right2.position;
        leftAtkScrip.b_Attack = false;
        rArmHint.position = atk1ArmHint.position;
        GenerateWave(des);

        // ¿À¸¥¼Õ °ø°Ý ON
        rightAtkScrip.b_Attack = true;
        des = atk1right3.position;
        curLHintPos = lArmHint.position;
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 2f;
            leftArmTarget.position = Vector3.Lerp(curLArmPos, originLArm.position, t);
            rightArmTarget.position = Vector3.Lerp(curRArmPos, des, t) + 10 * transform.up * Mathf.Sin(t * Mathf.PI);
            lArmHint.position = Vector3.Lerp(curLHintPos, originLArmHint.position, t);
            yield return null;
        }
        leftArmTarget.position = originLArm.position;
        curRArmPos = des;
        rightAtkScrip.b_Attack = false;
        lArmHint.position = originLArmHint.position;
        GenerateWave(des);

        // ÆÈ À§Ä¡ º¹±Í
        curRHintPos = rArmHint.position;
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / 2;
            rightArmTarget.position = Vector3.Lerp(curRArmPos, originRArm.position, t);
            rArmHint.position = Vector3.Lerp(curRHintPos, originRArmHint.position, t);
            yield return null;
        }
        rightArmTarget.position = originRArm.position;
        rArmHint.position = originRArmHint.position;
    }

    void GenerateWave(Vector3 _pos)
    {
        cameraShake.Shake();
        _pos.y += 1f;
        for (int i =0; i < waves.Length; i++)
        {
            if (!waves[i].activeSelf)
            {
                waves[i].transform.position = _pos;
                waves[i].SetActive(true);
                break;
            }
        }
    }

    public void Dash()
    {
        if (legCoroutine != null)
            StopCoroutine(legCoroutine);
        legCoroutine = StartCoroutine(LeftLegStart(4f));
        StartCoroutine(DashCoroutine());
    }

    IEnumerator DashCoroutine()
    {
        float t = 0f;
        Vector3 dir;
        while (t < 1f)
        {
            t += Time.deltaTime * 2;
            dir = target.position - transform.position;
            dir.y = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), t);
            yield return null;
        }

        while ((target.position - transform.position).magnitude > 40f)
        {
            dir = target.position - transform.position;
            dir.y = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), t);
            transform.Translate(0.2f * dir.normalized, Space.World);
            yield return null;
        }
        StopCoroutine(legCoroutine);
        legCoroutine = StartCoroutine(LeftLegStart(1f));
    }

    public void Dash(Vector3 _pos)
    {
        if (legCoroutine != null)
            StopCoroutine(legCoroutine);
        legCoroutine = StartCoroutine(LeftLegStart(4f));
        StartCoroutine(DashCoroutine(_pos));
    }

    IEnumerator DashCoroutine(Vector3 _pos)
    {
        float t = 0f;
        _pos.y = transform.position.y;
        Vector3 dir = _pos - transform.position;
        while (t < 1f)
        {
            t += Time.deltaTime * 2;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), t);
            yield return null;
        }

        t = 0f;
        Vector3 startPos = transform.position;
        float L = dir.magnitude;
        while (t <= L)
        {
            t += Time.deltaTime * 40;
            transform.position = Vector3.Lerp(startPos, _pos, t/L);
            yield return null;
        }

        StopCoroutine(legCoroutine);
        legCoroutine = StartCoroutine(LeftLegStart(1f));
        boss2.patternStart = true;
    }

    IEnumerator LeftLegStart(float speed)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime* speed;
            leftLegTarget.position = Vector3.Lerp(curLLegPos, lf.position, t) + 2f * Vector3.up * Mathf.Sin(t * Mathf.PI);
            rightLegTarget.position = Vector3.Lerp(curRLegPos, rb.position, t);
            yield return null;
        }
        leftLegTarget.position = lf.position;
        curLLegPos = leftLegTarget.position;

        rightLegTarget.position = rb.position;
        curRLegPos = rightLegTarget.position;

        legCoroutine = StartCoroutine(RightLegStart(speed));
    }

    IEnumerator RightLegStart(float speed)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime* speed;
            leftLegTarget.position = Vector3.Lerp(curLLegPos, lb.position, t);
            rightLegTarget.position = Vector3.Lerp(curRLegPos, rf.position, t) + 2f * Vector3.up * Mathf.Sin(t * Mathf.PI);
            yield return null;
        }
        leftLegTarget.position = lb.position;
        curLLegPos = leftLegTarget.position;

        rightLegTarget.position = rf.position;
        curRLegPos = rightLegTarget.position;

        legCoroutine = StartCoroutine(LeftLegStart(speed));
    }

    public void SetTarget(Transform _tr)
    {
        target = _tr;
    }
}
