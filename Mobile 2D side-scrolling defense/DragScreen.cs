using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragScreen : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] float minX,maxX;
    [SerializeField] float speed;
    Transform mainCamTr;
    float prePointX;
    float curPointX;

    private void Awake()
    {
        mainCamTr = Camera.main.transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        prePointX = eventData.position.x;
    }

    public void OnDrag(PointerEventData eventData)
    {
        curPointX = eventData.position.x;
        float newPosX = Mathf.Clamp((prePointX - curPointX) * speed + mainCamTr.transform.position.x, minX, maxX);
        mainCamTr.position = new Vector3(newPosX, mainCamTr.position.y, mainCamTr.position.z);
        prePointX = curPointX;
    }

}
