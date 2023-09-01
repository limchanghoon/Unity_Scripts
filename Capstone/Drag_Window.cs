using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag_Window : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public Vector3 fix_position;

    public RectTransform window;
    private Vector2 downPosition;

    public bool isItem;
    [SerializeField] Canvas canvas;

    private void Awake()
    {
        fix_position = GetComponent<RectTransform>().anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        canvas.sortingOrder = ETC_Memory.Instance.top_orderLayer++;
        downPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 offset = eventData.position - downPosition;
        downPosition = eventData.position;

        window.anchoredPosition += offset / canvas.scaleFactor;
        //window.anchoredPosition += eventData.delta;
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
