using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Collision : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(name + " Hit " + collision.gameObject.name + " : " + damage);
            collision.gameObject.GetComponent<Player_HP>().Hit(damage);
        }
    }
}
