using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_In_Village : MonoBehaviour
{
    private bool entering = false;
    private void OnTriggerEnter(Collider other)
    {
        if (entering)
            return;

        Debug.Log("OnTriggerEnter : " + other.name);
        if (other.tag == "Portal")
        {
            Debug.Log("Portal : " + other.name);
            entering = true;
            LoadingSceneController.Instance.LoadScene("SampleScene");
        }
    }
}
