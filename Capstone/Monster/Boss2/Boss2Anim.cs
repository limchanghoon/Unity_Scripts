using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Anim : MonoBehaviour
{
    [SerializeField] Boss2 boss2;

    AudioSource audioSource;
    [SerializeField] AudioClip thudSound;
    [SerializeField] AudioClip bigThudSound;
    [SerializeField] AudioClip lagerCanonSound;

    //public float stride;
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

    //float l1 = 1f;
    //float l2 = 1f;

    Coroutine legCoroutine;

    [SerializeField] CameraShake cameraShake;
    [SerializeField] GameObject[] waves;
    [SerializeField] GameObject missile;
    [SerializeField] GameObject explosionPrefab;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        curRLegPos = rightLegTarget.position;
        nextRLegPos = curRLegPos;
        curLLegPos = leftLegTarget.position;
        nextLLegPos = curLLegPos;
        center.position = (rightLegTarget.position + leftLegTarget.position) / 2f;
    }

    public void Shoot1()
    {
        if (legCoroutine != null)
            StopCoroutine(legCoroutine);
        legCoroutine = StartCoroutine(LeftLegStart(4f));
        StartCoroutine(ShootCoroutine());
    }

    IEnumerator ShootCoroutine()
    {
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
            dir = boss2.target.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), t);
            yield return null;
        }
        for (int i = 0; i < 5; i++)
        {
            audioSource.PlayOneShot(lagerCanonSound, 1f);
            for (int k = 0; k < 3; k++)
            {
                Vector3 des1 = boss2.target.position;
                des1 += boss2.target.right * boss2.Get_r_array(i * 3 + k) + boss2.target.forward * boss2.Get_r_array(30 + i * 3 + k);
                des1.y = 0;
                Vector3 des2 = boss2.target.position;
                des2 += boss2.target.right * boss2.Get_r_array(15 + i * 3 + k) + boss2.target.forward * boss2.Get_r_array(45 + i * 3 + k);
                des2.y = 0;
                Instantiate(missile, leftArmTarget.position, Quaternion.identity).GetComponent<Boss2Missile>().SetDes(des1);
                Instantiate(missile, rightArmTarget.position, Quaternion.identity).GetComponent<Boss2Missile>().SetDes(des2);
            }
            curLArmPos = leftArmTarget.position;
            curRArmPos = rightArmTarget.position;
            t = 0f;
            while (t < 0.7f)
            {
                t += Time.deltaTime * 5;
                leftArmTarget.position = Vector3.Lerp(curLArmPos, shootL2.position, t);
                rightArmTarget.position = Vector3.Lerp(curRArmPos, shootR2.position, t);
                dir = boss2.target.position - transform.position;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), t);
                yield return null;
            }
            audioSource.PlayOneShot(lagerCanonSound, 1f);
            for (int k = 0; k < 3; k++)
            {
                Vector3 des1 = boss2.target.position;
                des1 += boss2.target.right * boss2.Get_r_array(30 + i * 3 + k) + boss2.target.forward * boss2.Get_r_array(i * 3 + k);
                des1.y = 0;
                Vector3 des2 = boss2.target.position;
                des2 += boss2.target.right * boss2.Get_r_array(45 + i * 3 + k) + boss2.target.forward * boss2.Get_r_array(15 + i * 3 + k);
                des2.y = 0;
                Instantiate(missile, leftArmTarget.position, Quaternion.identity).GetComponent<Boss2Missile>().SetDes(des2);
                Instantiate(missile, rightArmTarget.position, Quaternion.identity).GetComponent<Boss2Missile>().SetDes(des1);
            }

            while (t < 1f)
            {
                t += Time.deltaTime * 5;
                leftArmTarget.position = Vector3.Lerp(curLArmPos, shootL2.position, t);
                rightArmTarget.position = Vector3.Lerp(curRArmPos, shootR2.position, t);
                dir = boss2.target.position - transform.position;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), t);
                yield return null;
            }



            // 발사 후 뒤로 간 팔 원위치로
            curLArmPos = leftArmTarget.position;
            curRArmPos = rightArmTarget.position;
            t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime /2;
                leftArmTarget.position = Vector3.Lerp(curLArmPos, shootL1.position, t);
                rightArmTarget.position = Vector3.Lerp(curRArmPos, shootR1.position, t);
                dir = boss2.target.position - transform.position;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), t);
                yield return null;
            }
        }
        boss2.patternStart = true;
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
        if (PhotonNetwork.IsMasterClient)
            boss2.patternStart = true;
    }

    IEnumerator Atk1Coroutine()
    {
        bool onShot = true;
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

        // 왼손 공격 ON
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
            if (t > 0.7f && onShot)
            {
                audioSource.PlayOneShot(bigThudSound, 0.8f);
                onShot = false;
            }
            yield return null;
        }
        curLArmPos = des;
        curRArmPos = atk1right2.position;
        leftAtkScrip.b_Attack = false;
        rArmHint.position = atk1ArmHint.position;
        GenerateWave(des);


        // 오른손 공격 ON
        onShot = true;
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
            if (t > 0.7f && onShot)
            {
                audioSource.PlayOneShot(bigThudSound, 0.8f);
                onShot = false;
            }
            yield return null;
        }
        leftArmTarget.position = originLArm.position;
        curRArmPos = des;
        rightAtkScrip.b_Attack = false;
        lArmHint.position = originLArmHint.position;
        GenerateWave(des);


        // 팔 위치 복귀
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
            dir = boss2.target.position - transform.position;
            dir.y = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), t);
            yield return null;
        }

        while ((boss2.target.position - transform.position).magnitude > 40f)
        {
            dir = boss2.target.position - transform.position;
            dir.y = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), t);
            transform.Translate(40 * Time.deltaTime * dir.normalized, Space.World);
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

        //StopCoroutine(legCoroutine);
        //legCoroutine = StartCoroutine(LeftLegStart(1f));
        boss2.patternStart = true;
    }

    IEnumerator LeftLegStart(float speed)
    {
        bool onShot = true;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime* speed;
            leftLegTarget.position = Vector3.Lerp(curLLegPos, lf.position, t) + 2f * Vector3.up * Mathf.Sin(t * Mathf.PI);
            rightLegTarget.position = Vector3.Lerp(curRLegPos, rb.position, t);
            if(t > 0.8f && onShot)
            {
                audioSource.PlayOneShot(thudSound, 0.6f);
                onShot = false;
            }
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
        bool onShot = true;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime* speed;
            leftLegTarget.position = Vector3.Lerp(curLLegPos, lb.position, t);
            rightLegTarget.position = Vector3.Lerp(curRLegPos, rf.position, t) + 2f * Vector3.up * Mathf.Sin(t * Mathf.PI);
            if (t > 0.8f && onShot)
            {
                audioSource.PlayOneShot(thudSound, 0.6f);
                onShot = false;
            }
            yield return null;
        }
        leftLegTarget.position = lb.position;
        curLLegPos = leftLegTarget.position;

        rightLegTarget.position = rf.position;
        curRLegPos = rightLegTarget.position;

        legCoroutine = StartCoroutine(LeftLegStart(speed));
    }



    public void PlayDieAnim()
    {
        StopAllCoroutines();

        StartCoroutine(PlayDieAnimCoroutine());
    }

    IEnumerator PlayDieAnimCoroutine()
    {
        yield return new WaitForSeconds(3f);
        Popping_Cube[] pops = boss2.GetPops();

        PopAndExplosion(41);
        PopAndExplosion(40, false);
        PopAndExplosion(39, false);
        PopAndExplosion(38, false);
        PopAndExplosion(37, false);
        PopAndExplosion(36, false);
        PopAndExplosion(35, false);
        yield return new WaitForSeconds(1f);
        PopAndExplosion(34);
        yield return new WaitForSeconds(0.8f);
        PopAndExplosion(33);
        yield return new WaitForSeconds(0.7f);
        PopAndExplosion(32);
        yield return new WaitForSeconds(0.6f);
        PopAndExplosion(31);
        yield return new WaitForSeconds(0.4f);
        PopAndExplosion(30);
        yield return new WaitForSeconds(0.3f);

        for(int i = 53; i >= 42; --i)
        {
            PopAndExplosion(i);
            yield return new WaitForSeconds(0.1f);
        }

        PopAndExplosion(1);
        yield return new WaitForSeconds(0.1f);

        PopAndExplosion(29);
        yield return new WaitForSeconds(0.1f);

        PopAndExplosion(0);
        yield return new WaitForSeconds(0.1f);

        PopAndExplosion(2);
        yield return new WaitForSeconds(0.1f);

        for (int i = 3; i <= 15; i++)
        {
            PopAndExplosion(i);
            PopAndExplosion(i + 13);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(3f);

        boss2.View_Reward_UI();
    }

    private void PopAndExplosion(int index, bool sound = true)
    {
        Popping_Cube[] pops = boss2.GetPops();

        pops[index].PopCube(false);
        GameObject _go = Instantiate(explosionPrefab, pops[index].transform.position, Quaternion.identity);
        if (sound == false)
            _go.GetComponent<AudioSource>().enabled = false;
    }
}
