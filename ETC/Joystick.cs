using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    [SerializeField] GameObject joyStickHandleOut;
    [SerializeField] GameObject joyStickHandleIn;
    RectTransform joyStickOutTr;
    RectTransform joyStickInTr;

    Vector2 startPos;
    Vector2 curPos;

    float radius;

    public Vector2 dir;
    public bool isDragging;

    private void Awake()
    {
        joyStickOutTr = joyStickHandleOut.GetComponent<RectTransform>();
        joyStickInTr = joyStickHandleIn.GetComponent<RectTransform>();

        radius = joyStickOutTr.sizeDelta.y / 2 - joyStickInTr.sizeDelta.y / 2;

        dir = Vector2.zero;
    }

    public void OnPointerDown()
    {
        startPos = Input.mousePosition;
        curPos = Input.mousePosition;
        dir = Vector2.zero;
        joyStickOutTr.position = startPos;
        joyStickInTr.position = curPos;
        isDragging = true;

        joyStickHandleOut.SetActive(true);
    }

    public void OnDrag()
    {
        curPos = Input.mousePosition;
        float dis = Vector2.Distance(curPos,startPos);
        dir = (curPos - startPos).normalized;

        if (dis <= radius)
            joyStickInTr.position = curPos;
        else
            joyStickInTr.position = startPos + dir * radius;

    }

    public void OnPointerUp()
    {
        joyStickHandleOut.SetActive(false);
        isDragging = false;
        dir = Vector2.zero;
    }
}
