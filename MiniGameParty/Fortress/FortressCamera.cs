using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressCamera : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public float minX170;
    public float maxX170;
    public float minY170;
    public float maxY170;

    float curMinX;
    float curMaxX;
    float curMinY;
    float curMaxY;

    float fieldOfViewMin = 135f;
    float fieldOfViewMax = 170f;

    float m_fSpeed = 0.1f;
    float m_fFieldOfView = 135f;

    Vector3 clickPoint;
    public float dragSpeed = 5.0f;

    public FortressPlayer myPlayer;

    private void Start()
    {
        curMinX = minX;
        curMaxX = maxX;
        curMinY = minY;
        curMaxY = maxY;
    }

    private void Update()
    {
        CheckTouch();
        if (myPlayer == null || !myPlayer.isMyTurn || myPlayer.m_IsControlBtnDowning || !myPlayer.canSwipe)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            clickPoint = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 deltaPos = Input.mousePosition - clickPoint;

            Vector3 move = deltaPos * (Time.deltaTime * dragSpeed);

            transform.Translate(-move);
            clickPoint += move;
        }
    }

    private void LateUpdate()
    {
        Vector3 _pos = transform.position;
        if (transform.position.x < curMinX)
            _pos.x = curMinX;
        if (transform.position.x > curMaxX)
            _pos.x = curMaxX;
        if (transform.position.y < curMinY)
            _pos.y = curMinY;
        if (transform.position.y > curMaxY)
            _pos.y = curMaxY;
        transform.position = _pos;
    }

    void CheckTouch()
    {
        if (Input.touchCount == 2)
        {
            Vector2 vecPreTouchPos0 = Input.touches[0].position - Input.touches[0].deltaPosition;
            Vector2 vecPreTouchPos1 = Input.touches[1].position - Input.touches[1].deltaPosition;

            // 이전 두 터치의 차이 
            float fPreDis = (vecPreTouchPos0 - vecPreTouchPos1).magnitude;
            // 현재 두 터치의 차이
            float fToucDis = (Input.touches[0].position - Input.touches[1].position).magnitude;


            // 이전 두 터치의 거리와 지금 두 터치의 거리의 차이
            float fDis = fPreDis - fToucDis;

            // 이전 두 터치의 거리와 지금 두 터치의 거리의 차이를 FleldOfView를 차감합니다.
            m_fFieldOfView += (fDis * m_fSpeed);

            // 최대는 170.0f, 최소는 135.0f 더이상 증가 혹은 감소가 되지 않도록 합니다.
            m_fFieldOfView = Mathf.Clamp(m_fFieldOfView, 135.0f, 170.0f);

            Camera.main.fieldOfView = m_fFieldOfView;
            float t = (m_fFieldOfView - fieldOfViewMin) / (fieldOfViewMax - fieldOfViewMin);
            curMinX = Mathf.Lerp(minX, minX170, t);
            curMaxX = Mathf.Lerp(maxX, maxX170, t);
            curMinY = Mathf.Lerp(minY, minY170, t);
            curMaxY = Mathf.Lerp(maxY, maxY170, t);
        }
    }
}
