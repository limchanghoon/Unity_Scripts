using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBottom : MonoBehaviour
{
    public bool isFried = false;
    public GameObject player;
    public Animator animator;
    private void OnTriggerExit(Collider other)
    {
        isFried = true;

        //animator.SetBool("Fry", true);
        //animator.SetBool("Jump", true);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
            return;
        //if (other.name == "Out")
        //    player.transform.position = new Vector3(0,10,0);
        //Debug.Log(other);

        //animator.SetBool("Jump", false);
        //animator.SetBool("Fry", false);
        isFried = false;
    }
}
