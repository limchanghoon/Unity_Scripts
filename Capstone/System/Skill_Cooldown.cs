using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill_Cooldown : MonoBehaviour
{
    public Slider cooldownSlider;
    public float maxCooldownTime = 0.0f;
    public float currentCooldownTime = 0.0f;
    public Image icon;
    Color c0 = new Color(1, 1, 0, 1f/51f);
    Color c1 = new Color(1, 1, 0, 1);

    public IEnumerator CooldownCoroutine(float newCooldownTime)
    {
        icon.color = c0;
        maxCooldownTime = newCooldownTime;
        currentCooldownTime = newCooldownTime;
        cooldownSlider.value = 1f;
        while (true)
        {
            yield return null;
            currentCooldownTime -= Time.deltaTime;
            if (currentCooldownTime < 0f)
                currentCooldownTime = 0f;
            cooldownSlider.value = currentCooldownTime / maxCooldownTime;
            if (currentCooldownTime <= 0f)
            {
                icon.color = c1;
                yield break;
            }
        }
    }
}
