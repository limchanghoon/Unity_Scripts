using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll_CutOff : MonoBehaviour
{
    [SerializeField] Material material_joint;
    [SerializeField] Material material_surf;

    private void Start()
    {
        transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material = Instantiate(material_joint);
        transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = Instantiate(material_surf);
        StartCoroutine(CutOff());
    }


    IEnumerator CutOff()
    {
        yield return new WaitForSeconds(6f);
        // CutOff
        float t = 0f;
        Material myJoint = transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material;
        Material mySurf = transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
        while (t < 3f)
        {
            yield return null;
            t += Time.deltaTime;
            float dividedT = t / 3f;
            myJoint.SetFloat("_Cutoff", dividedT);
            mySurf.SetFloat("_Cutoff", dividedT);
        }

        gameObject.SetActive(false);
    }
}
