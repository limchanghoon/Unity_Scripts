using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2AtkCol : MonoBehaviour
{
    public bool b_Attack = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + ", " + other.gameObject.name);
        if (other.gameObject.tag == "Player" && b_Attack)
        {
            Debug.Log(name + " Hit " + other.gameObject.name + " : " + 10);
            other.gameObject.GetComponent<Player_HP>().Hit(10);
        }
    }
}
