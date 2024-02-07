using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : PoolingObject
{
    [SerializeField,Range(0,10)] float speed;
    [SerializeField] string opponentTag;
    Vector3 start;
    Quaternion startR;
    [SerializeField] Quaternion endR;
    [HideInInspector] public Vector3 destination;
    bool entered = false;

    int power;

    public void Shoot(int newPower)
    {
        power = newPower;
        StartCoroutine(GoToTarget());
    }

    IEnumerator GoToTarget()
    {
        entered = false;
        float t = 0f;
        start = transform.position;
        startR = transform.rotation;
        while (t < 1f)
        {
            transform.position = Vector3.Lerp(start, destination, t);
            transform.position += Vector3.up * Mathf.Sin(180*t*Mathf.Deg2Rad);
            transform.rotation = Quaternion.Lerp(startR, endR, t);
            yield return null;
            t += Time.deltaTime * speed;
        }
        DestroyObject();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == opponentTag && !entered)
        {
            if (collision.GetComponent<IHit>().Hit(power))
            {
                entered = true;
                DestroyObject();
            }
        }
    }
}
