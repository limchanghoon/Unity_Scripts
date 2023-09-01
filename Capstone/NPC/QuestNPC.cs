using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : MonoBehaviour , IInteract
{
    bool isActive = false;

    public void Interact()
    {
        QuestController.Instance.canvas.enabled = true;
        isActive = true;
        QuestController.Instance.canvas.sortingOrder = ETC_Memory.Instance.top_orderLayer++;
        ETC_Memory.Instance.windowDepth++;
    }

    private void OnDestroy()
    {
        if (isActive && QuestController.Instance.canvas.enabled)
        {
            QuestController.Instance.canvas.enabled = false;
            ETC_Memory.Instance.windowDepth--;
        }
    }
}
