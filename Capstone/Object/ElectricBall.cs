using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBall : MonoBehaviour
{
    [SerializeField] Vector3 initialPos;
    [SerializeField] Vector3 initialRot;
    [SerializeField] float finishScale;

    [SerializeField] float movingSpeed;

    [SerializeField] NextAction nextAction;

    float scale_xyz = 0f;
    byte scaling = 0; // 유지, 키우기, 줄이기

    private void Update()
    {
        if(scaling == 0)
        {
            transform.Translate(transform.forward * Time.deltaTime * movingSpeed, Space.World);
        }
        else if (scaling == 1)
        {
            scale_xyz += Time.deltaTime / 3f;
            if (scale_xyz >= finishScale)
            {
                scale_xyz = finishScale;
                scaling = 0;
            }
            transform.localScale = Vector3.one * scale_xyz;
        }
        else if (scaling == 2)
        {
            if (scale_xyz <= 0)
            {
                scaling = 0;

                transform.localPosition = initialPos;
                transform.localRotation = Quaternion.Euler(initialRot);
                scale_xyz = 0f;
            }


            scale_xyz -= Time.deltaTime * 2f;
            if (scale_xyz <= 0)
            {
                scale_xyz = 0f;
                scaling = 1;

                transform.localPosition = initialPos;
                transform.localRotation = Quaternion.Euler(initialRot);
            }
            transform.localScale = Vector3.one * scale_xyz;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "PortalDoor")
        {
            if(other.tag == "ElectricAdapter")
                other.GetComponent<ElectricAdapter>().Charge();
            else if (nextAction != null)
                nextAction.Act();

            scaling = 2;
        }
    }
}
