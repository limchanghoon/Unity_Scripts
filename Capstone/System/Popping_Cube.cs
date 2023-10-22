using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popping_Cube : MonoBehaviour
{
    [SerializeField] private GameObject fragments_prefab;
    [SerializeField] private float force = 0f;
    [SerializeField] private Vector3 offset = Vector3.zero;


    public GameObject PopCube(bool active = true)
    {
        GameObject clone = Instantiate(fragments_prefab, transform.position, Quaternion.identity);
        clone.transform.localScale = transform.lossyScale;
        MeshRenderer[] meshRenderers = clone.GetComponentsInChildren<MeshRenderer>();
        Rigidbody[] rigidbodies = clone.GetComponentsInChildren<Rigidbody>();


        for(int i =0; i < rigidbodies.Length; i++)
        {
            meshRenderers[i].material = gameObject.GetComponent<MeshRenderer>().material;
            rigidbodies[i].AddExplosionForce(force, transform.position + offset, 10);
        }
        if (active == false)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
        }
        return clone;
    }


}
