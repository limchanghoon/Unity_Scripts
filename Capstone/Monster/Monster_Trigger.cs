using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Trigger : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(name + " Hit " + other.gameObject.name + " : " + damage);
            other.gameObject.GetComponent<Player_HP>().Hit(damage);
        }
    }
}
