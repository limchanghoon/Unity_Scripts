using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float m_force;
    [SerializeField] Vector3 m_offset;
    public Quaternion m_Rot = Quaternion.identity;

    [ContextMenu("카메라 흔들기")]
    public void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        for(int i = 0; i < 15; i++)
        {
            float t_rotX = Random.Range(-m_offset.x, m_offset.x);
            float t_rotY = Random.Range(-m_offset.y, m_offset.y);
            float t_rotZ = Random.Range(-m_offset.z, m_offset.z);

            Quaternion t_rot = Quaternion.Euler(t_rotX, t_rotY, t_rotZ);

            while (Quaternion.Angle(m_Rot, t_rot) > 0.1f)
            {
                m_Rot = Quaternion.RotateTowards(m_Rot, t_rot, m_force * Time.deltaTime);
                yield return null;
            }
            yield return null;
        }
        StartCoroutine(ResetCoroutine());
    }

    IEnumerator ResetCoroutine()
    {
        while (Quaternion.Angle(m_Rot, Quaternion.identity) > 0f)
        {
            m_Rot = Quaternion.RotateTowards(m_Rot, Quaternion.identity, m_force * Time.deltaTime);
            yield return null;
        }
    }
}
