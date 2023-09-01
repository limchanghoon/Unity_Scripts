using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField] Transform canvasTf;
    Transform theCam;
    public TextMeshProUGUI text;
    float animTime = 0;
    bool startAnim = true;
    float time_limit = 3f;

    private void Start()
    {
        theCam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        canvasTf.LookAt(theCam.transform);

        if (startAnim)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
            startAnim = false;
        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - Time.deltaTime/ time_limit);
        animTime += Time.deltaTime;
        if(animTime > time_limit)
        {
            animTime = 0;
            startAnim = true;
            gameObject.SetActive(false);
        }
    }
}
