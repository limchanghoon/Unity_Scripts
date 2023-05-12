using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farming_World_Entry : MonoBehaviour, IInteract
{
    public string map_name = "Farming World";
    public void Interact()
    {
        LoadingSceneController.Instance.LoadScene(map_name);
    }

}
