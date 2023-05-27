using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : MonoBehaviour, IInteract
{
    public void Interact()
    {
        QuestController.Instance.canvas.enabled = true;
    }

}
