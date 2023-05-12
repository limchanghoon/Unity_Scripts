using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
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

    private void Awake()
    {
        window = GetComponent<RectTransform>();
        original_parent = transform.parent;
        fix_position = GetComponent<RectTransform>().anchoredPosition;
        itemData_MonoBehaviour = GetComponent<ItemData_MonoBehaviour>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        top_parent.GetComponent<Canvas>().sortingOrder = ETC_Memory.Instance.top_orderLayer++;
        transform.SetParent(top_parent);
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
        transform.SetParent(original_parent);
        window.anchoredPosition = fix_position;

        GameObject result = UIRaycast();
        // 이벤트 처리부분
        if (result != null)
        {
            IDrag_Drop dragDrop = result.GetComponent<IDrag_Drop>();
            if (dragDrop != null)
            {
                dragDrop.Drop(itemData_MonoBehaviour);
            }
            Debug.Log(result.name);
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
