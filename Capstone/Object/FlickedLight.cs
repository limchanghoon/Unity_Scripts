using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickedLight : MonoBehaviour
{
    Light m_light;

    float m_intensity;
    [SerializeField] float mix_intensity;
    [SerializeField] float max_intensity;

    private void Start()
    {
        m_light = GetComponent<Light>();
        m_intensity = m_light.intensity;
    }
    // Update is called once per frame
    void Update()
    {
        m_light.intensity = Mathf.Lerp(mix_intensity, max_intensity, Mathf.Abs(Mathf.Sin(Time.time)));
    }
}
