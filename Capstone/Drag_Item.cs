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
    [SerializeField] Canvas canvas;

    public bool isDragging = false;

    private void Awake()
    {
        window = GetComponent<RectTransform>();
        original_parent = transform.parent;
        fix_position = GetComponent<RectTransform>().anchoredPosition;
        itemData_MonoBehaviour = GetComponent<ItemData_MonoBehaviour>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (itemData_MonoBehaviour.itemData.type == '-')
            return;
        isDragging = true;
        top_parent.GetComponent<Canvas>().sortingOrder = ETC_Memory.Instance.top_orderLayer++;
        transform.SetParent(top_parent);
        downPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (itemData_MonoBehaviour.itemData.type == '-' || !isDragging)
            return;
        Vector2 offset = eventData.position - downPosition;
        downPosition = eventData.position;

        window.anchoredPosition += offset / canvas.scaleFactor;
        //window.anchoredPosition += eventData.delta;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (itemData_MonoBehaviour.itemData.type == '-' || !isDragging)
            return;

        ReturnToFixPosition();

        GameObject result = UIRaycast();
        // 이벤트 처리부분
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
