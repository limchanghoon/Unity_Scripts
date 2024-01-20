using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Drag_Item : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private ItemData_MonoBehaviour itemData_MonoBehaviour;

    public Vector3 fix_position;

    private RectTransform window;
    private Vector2 downPosition;

    private Transform original_parent;
    public Transform top_parent;
    public Canvas canvas;

    public bool isDragging = false;

    private void Awake()
    {
        window = GetComponent<RectTransform>();
        original_parent = transform.parent;
        fix_position = GetComponent<RectTransform>().anchoredPosition;
        itemData_MonoBehaviour = GetComponent<ItemData_MonoBehaviour>();
    }

    // 드래그 시작
    public void OnPointerDown(PointerEventData eventData)
    {
        if (itemData_MonoBehaviour.itemData.type == ItemType.None)
            return;
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isDragging = true;
            top_parent.GetComponent<Canvas>().sortingOrder = 32767;
            transform.SetParent(top_parent);
            downPosition = eventData.position;
        }
    }

    // 드래그 중
    public void OnDrag(PointerEventData eventData)
    {
        if (itemData_MonoBehaviour.itemData.type == ItemType.None || !isDragging)
            return;
        Vector2 offset = eventData.position - downPosition;
        downPosition = eventData.position;

        window.anchoredPosition += offset / canvas.scaleFactor;
    }

    // 드래그 끝
    public void OnPointerUp(PointerEventData eventData)
    {
        if (itemData_MonoBehaviour.itemData.type == ItemType.None || !isDragging)
            return;

        ReturnToFixPosition();

        GameObject result = UIRaycast();
        // 이벤트 처리부분 : 드래그 끝(마우스 포인터)에 위치한 UI가 IDrag_Drop를 구현했으면
        if (result != null)
        {
            IDrag_Drop dragDrop = result.GetComponent<IDrag_Drop>();
            if (dragDrop != null)
            {
                Debug.Log(result.name);
                dragDrop.Drop(itemData_MonoBehaviour);
            }
        }
    }

    public void ReturnToFixPosition()
    {
        if (isDragging)
        {
            isDragging = false;
            transform.SetParent(original_parent);
            window.anchoredPosition = fix_position;
        }
    }

    private GameObject UIRaycast()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
        if (results.Count < 1 || results[0].gameObject.layer != LayerMask.NameToLayer("UI"))
            return null;
        else
            return results[0].gameObject;
    }
}
