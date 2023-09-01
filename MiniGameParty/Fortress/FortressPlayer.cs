using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.EventSystems;

public class FortressPlayer : TurnBasedPlayer, IPunObservable
{
    bool m_IsMoveBtnDowning = false;
    public bool m_IsControlBtnDowning = false;
    public bool m_IsFireBtnDowning = false;
    bool canMove = true;
    public bool canSwipe = true;
    int moveDir = -1;
    int cannonDir = -1;
    bool onGround = false;
    public bool isStop = false;
    Vector3 curPos;
    float default_fireGague = 10f;
    float fireGague = 0f;
    float max_fireGague = 90f;
    bool fireGagueUp = true;
    public float maxHp = 100f;
    public float curHp = 100f;
    Rigidbody2D rigidbody;

    public Transform p1, p2, p3, body;
    public Slider hpSlider;
    Slider myHpSlider;
    Slider moveSlider;
    Slider fireSlider;
    public float moveGague = 0f;
    public float moveMaxGague = 1f;
    public float rayLength;
    float dif, dif1, dif3, p11, p22, p33;   // Rotation ���� ����

    public GameObject bobm;
    public GameObject dieBoom;
    public Transform arrow;
    public GameObject myMark;
    public GameObject mid;
    Transform muzzlePos;

    protected override void Start()
    {
        base.Start();
        if (pv.IsMine)
        {
            Camera.main.GetComponent<FortressCamera>().myPlayer = this;
            SetMine();
        }
        else
        {
            arrow.gameObject.SetActive(false);
            myMark.gameObject.SetActive(false);
            Destroy(GetComponent<Rigidbody2D>());
        }
        muzzlePos = arrow.GetChild(0).transform;
    }

    public float x;

    /*
    private void OnDrawGizmos()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(transform.position, new Vector2(x, 0.5f), 0f, Vector2.down, 2f, 1 << 6 | 1<<8);

        Gizmos.color = Color.red;
        if (raycastHit.collider != null)
        {
            Gizmos.DrawRay(transform.position, Vector2.down * raycastHit.distance);
            Gizmos.DrawCube(transform.position + Vector3.down * raycastHit.distance, new Vector2(x, 0.5f));
        }
    }
    */

    private void Update()
    {
        if (!pv.IsMine)
        {
            if ((transform.position - curPos).sqrMagnitude >= 100) transform.position = curPos;
            else transform.position = Vector3.Lerp(transform.position, curPos, Time.deltaTime * 10);
            return;
        }
        if (isDied)
            return;
        
        SetRotation();
        if (isMyTurn)
        {
            Move();
            ControlCannon();
            ControlFireGague();
        }
    }

    private void FixedUpdate()
    {
        if (!pv.IsMine || isDied)
            return;

        RaycastHit2D raycastHit = Physics2D.BoxCast(transform.position, new Vector2(x, 0.5f), 0f, Vector2.down, 2f, 1 << 6 | 1 << 8);
        if (raycastHit.collider == null)
        {
            onGround = false;
            rigidbody.AddForce(3 * 9.81f * Vector2.down);
        }
        else
        {
            onGround = true;
        }

        isStop = rigidbody.velocity.magnitude < 0.01f ? true : false;
    }

    private void LateUpdate()
    {
        if (!pv.IsMine && isMyTurn)
        {
            theCam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }

    private void SetRotation()
    {
        Debug.DrawRay(p1.position, Vector2.down * rayLength, Color.blue, 0.3f);
        Debug.DrawRay(p2.position, Vector2.down * rayLength, Color.blue, 0.3f);
        Debug.DrawRay(p3.position, Vector2.down * rayLength, Color.blue, 0.3f);
        RaycastHit2D hit1 = Physics2D.Raycast(p1.position, Vector2.down, rayLength, 1 << 6);
        RaycastHit2D hit2 = Physics2D.Raycast(p2.position, Vector2.down, rayLength, 1 << 6);
        RaycastHit2D hit3 = Physics2D.Raycast(p3.position, Vector2.down, rayLength, 1 << 6);
        p11 = hit1 ? hit1.point.y : p11;
        p22 = hit2 ? hit2.point.y : p22;
        p33 = hit3 ? hit3.point.y : p33;
        // �ö󰥶��� ����
        // ���������� �߾��� ������ ȸ��?

        if (moveDir == -1) // �������� �̵�
        {
            dif = p11 - p22;
        }
        else if (moveDir == 1) // ���������� �̵�
        {
            dif = p22 - p33;
        }


        if (moveDir * dif < -3.5f)          // ������
        {
            canMove = false;
            return;
        }
        else if(moveDir * dif > 0f)         // ������
        {
            dif1 = p11 - p22;
            float abs1 = Mathf.Abs(dif1);
            dif3 = p22 - p33;
            float abs3 = Mathf.Abs(dif3);
            if (moveDir == -1 && abs1 > abs3) // �������� �̵�, �߾� ������
            {
                dif = dif3;
            }
            else if(moveDir == 1 && abs1 < abs3) // ���������� �̵�, �߾� ������
            {
                dif = dif1;
            }
        }
        body.rotation = Quaternion.Euler(0, 90 + moveDir * 90, moveDir * dif * 22.5f);
        canMove = true;
    }

    private void SetMine()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        moveSlider = GameObject.Find("MoveSlider").GetComponent<Slider>();
        myHpSlider = GameObject.Find("MyHpSlider").GetComponent<Slider>();
        fireSlider = GameObject.Find("FireSlider").GetComponent<Slider>();
        EventTrigger.Entry entry1 = new EventTrigger.Entry();
        entry1.eventID = EventTriggerType.PointerDown;
        entry1.callback.AddListener((eventdata) => { MoveStart(1); });
        GameObject.Find("RightBtn").GetComponent<EventTrigger>().triggers.Add(entry1);

        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerUp;
        entry2.callback.AddListener((eventdata) => { MoveEnd(); });
        GameObject.Find("RightBtn").GetComponent<EventTrigger>().triggers.Add(entry2);

        EventTrigger.Entry entry3 = new EventTrigger.Entry();
        entry3.eventID = EventTriggerType.PointerDown;
        entry3.callback.AddListener((eventdata) => { MoveStart(-1); });
        GameObject.Find("LeftBtn").GetComponent<EventTrigger>().triggers.Add(entry3);

        EventTrigger.Entry entry4 = new EventTrigger.Entry();
        entry4.eventID = EventTriggerType.PointerUp;
        entry4.callback.AddListener((eventdata) => { MoveEnd(); });
        GameObject.Find("LeftBtn").GetComponent<EventTrigger>().triggers.Add(entry4);

        EventTrigger.Entry entry5 = new EventTrigger.Entry();
        entry5.eventID = EventTriggerType.PointerDown;
        entry5.callback.AddListener((eventdata) => { ControlCannonStart(-1); });
        GameObject.Find("UpBtn").GetComponent<EventTrigger>().triggers.Add(entry5);

        EventTrigger.Entry entry6 = new EventTrigger.Entry();
        entry6.eventID = EventTriggerType.PointerUp;
        entry6.callback.AddListener((eventdata) => { ControlCannonEnd(); });
        GameObject.Find("UpBtn").GetComponent<EventTrigger>().triggers.Add(entry6);

        EventTrigger.Entry entry7 = new EventTrigger.Entry();
        entry7.eventID = EventTriggerType.PointerDown;
        entry7.callback.AddListener((eventdata) => { ControlCannonStart(1); });
        GameObject.Find("DownBtn").GetComponent<EventTrigger>().triggers.Add(entry7);

        EventTrigger.Entry entry8 = new EventTrigger.Entry();
        entry8.eventID = EventTriggerType.PointerUp;
        entry8.callback.AddListener((eventdata) => { ControlCannonEnd(); });
        GameObject.Find("DownBtn").GetComponent<EventTrigger>().triggers.Add(entry8);


        EventTrigger.Entry entry9 = new EventTrigger.Entry();
        entry9.eventID = EventTriggerType.PointerDown;
        entry9.callback.AddListener((eventdata) => { FireButtonDown(); });
        GameObject.Find("FireBtn").GetComponent<EventTrigger>().triggers.Add(entry9);

        EventTrigger.Entry entry10 = new EventTrigger.Entry();
        entry10.eventID = EventTriggerType.PointerUp;
        entry10.callback.AddListener((eventdata) => { FireButtonUp(); });
        GameObject.Find("FireBtn").GetComponent<EventTrigger>().triggers.Add(entry10);

        GameObject.Find("BackToMeBtn").GetComponent<Button>().onClick.AddListener((BackToMe));
        ((FortressManager)GM).btn_canvas.SetActive(false);
    }

    private void Move()
    {
        if (m_IsMoveBtnDowning && canMove && moveGague > 0f && onGround)
        {
            transform.Translate(-body.right * Time.deltaTime * 10);
            moveGague -= Time.deltaTime;
            if (moveGague < 0)
                moveGague = 0;
            moveSlider.value = moveGague / moveMaxGague;
        }
    }

    private void ControlCannon()
    {
        if (m_IsControlBtnDowning)
        {
            float z = arrow.localEulerAngles.z + cannonDir * Time.deltaTime * 50;
            if (z < 180f && z > 80f)
                z = 80f;
            else if (z > 180f && z < 280f)
                z = 280f;
            arrow.localRotation = Quaternion.Euler(0, 0, z);
            Debug.DrawRay(arrow.position, -arrow.right * 30, Color.yellow);
        }
    }

    private void ControlFireGague()
    {
        if (m_IsFireBtnDowning)
        {
            if (fireGagueUp)
            {
                fireGague = fireGague + 100 * Time.deltaTime;
                if(fireGague >= max_fireGague)
                {
                    fireGague = max_fireGague;
                    fireGagueUp = false;
                }
            }
            else
            {
                fireGague = fireGague - 100 * Time.deltaTime;
                if (fireGague <= 0)
                {
                    fireGague = 0;
                    fireGagueUp = true;
                    m_IsFireBtnDowning = false;
                }
            }
            fireSlider.value = fireGague / max_fireGague;
        }
    }

    public void Hit(float damage)
    {
        Debug.Log("Hit : " + damage);
        curHp = curHp - damage < 0f ? 0f : curHp - damage;
        hpSlider.value = curHp / maxHp;
        if(myHpSlider != null)
            myHpSlider.value = hpSlider.value;
        if (curHp <= 0f)
            Die();
    }

    public void Die()
    {
        isDied = true;
        isStop = true;
        pv.RPC("DieRPC", RpcTarget.All, transform.position);
    }

    [PunRPC]
    void DieRPC(Vector3 _pos)
    {
        mid.SetActive(false);
        isDied = true;
        isStop = true;
        Destroy(Instantiate(dieBoom, _pos, Quaternion.identity), 10f);
        if (isMyTurn) // �̵��� �������� �״� ���
        {
            isMyTurn = false;
            ((FortressManager)GM).btn_canvas.SetActive(false);
            if(PhotonNetwork.IsMasterClient)
                GameObject.Find("GM").GetComponent<FortressManager>().TurnToNext();
        }
    }

    public override void StartMyTurn()
    {
        Debug.Log(pv.ViewID + " : StartMyTurn");
        ((FortressManager)GM).btn_canvas.SetActive(true);
        moveGague = moveMaxGague;
        moveSlider.value = moveGague / moveMaxGague;
        base.StartMyTurn();
    }

    // (�̵� ��Ŭ�� ���� r : +1 ������, -1 ����)
    public void MoveStart(int r)
    {
        if (isMyTurn)
        {
            moveDir = r;
            m_IsMoveBtnDowning = true;
        }
    }

    // (�̵� ��Ŭ�� ����)
    public void MoveEnd()
    {
        m_IsMoveBtnDowning = false;
    }

    // (���� ���� ���� ��Ŭ�� ���� r : +1 �Ʒ���, -1 ����)
    public void ControlCannonStart(int r)
    {
        if (isMyTurn)
        {
            cannonDir = r;
            m_IsControlBtnDowning = true;
        }
    }

    // (���� ���� ���� ��Ŭ�� ����)
    public void ControlCannonEnd()
    {
        m_IsControlBtnDowning = false;
    }

    // (���� ��Ŭ�� ����)
    public void FireButtonDown()
    {
        if (isMyTurn)
        {
            m_IsFireBtnDowning = true;
            canSwipe = false;
        }
    }

    // (���� ��Ŭ�� ����)
    public void FireButtonUp()
    {
        if (m_IsFireBtnDowning && isMyTurn)
        {
            Fire();
        }
        canSwipe = true;
    }



    void Fire()
    {
        if (isMyTurn)
        {
            ((FortressManager)GM).btn_canvas.SetActive(false);
            PhotonNetwork.Instantiate("Bobm", muzzlePos.position, arrow.rotation, 0, new object[] { default_fireGague + fireGague });
            fireGague = 0f;
            fireSlider.value = 0f;
            fireGagueUp = true;
            m_IsFireBtnDowning = false;
            pv.RPC("ChangeIsMyTurn", RpcTarget.All, false);
            moveGague = 0f;
        }
    }

    void BackToMe()
    {
        theCam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

    [PunRPC]
    public override void SetInitial(int idx)
    {
        transform.position = ((FortressManager)GM).spawnPoints[idx].position;
        if (pv.IsMine)
            StartCoroutine(InitialCamera(transform.position));
    }

    IEnumerator InitialCamera(Vector3 _pos)
    {
        float x = _pos.x;
        float y = _pos.y;
        float z = 0;
        while (z > -10f)
        {
            z -= 10 * Time.deltaTime;
            theCam.transform.position = new Vector3(x, y, z);
            yield return null;
        }
        theCam.transform.position = new Vector3(x, y, -10);
    }

    // ���� ����ȭ
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(body.rotation);
            stream.SendNext(hpSlider.value);
            stream.SendNext(isStop);
        }
        else
        {
            curPos = (Vector3)stream.ReceiveNext();
            body.rotation = (Quaternion)stream.ReceiveNext();
            hpSlider.value = (float)stream.ReceiveNext();
            isStop = (bool)stream.ReceiveNext();
        }
    }

}
