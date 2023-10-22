using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathCam : MonoBehaviour
{
    [SerializeField] GameObject youDiedCanvasPrefab;
    public GameObject youDiedCanvas;

    public Camera theCam;
    public Camera uiCam;

    public Transform target;


    [SerializeField] Color startColor;
    [SerializeField] Color endColor;

    public void SetYouDied(PhotonView pv)
    {
        if (pv == null || pv.IsMine || PhotonNetwork.InLobby)
        {
            youDiedCanvas = Instantiate(youDiedCanvasPrefab);
            youDiedCanvas.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if(theCam != null)
        {
            theCam.transform.RotateAround(target.position, Vector3.up, Time.deltaTime * 20f);
            uiCam.transform.position = theCam.transform.position;

            theCam.transform.LookAt(target);
            uiCam.transform.LookAt(target);
        }
    }


    public void FarAway()
    {
        StartCoroutine(FarAwayCoroutine());
    }


    public IEnumerator FarAwayCoroutine()
    {
        float t = 0f;

        while(t < 3f)
        {
            yield return null;
            t += Time.deltaTime;
            theCam.transform.position += (theCam.transform.position - target.position).normalized * Time.deltaTime * 2f;
            uiCam.transform.position = theCam.transform.position;
        }


        Image youDiedPanel = youDiedCanvas.transform.GetChild(0).GetComponent<Image>();
        TextMeshProUGUI youDiedText = youDiedCanvas.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        t = 0f;
        while(t < 3f)
        {
            yield return null;
            t += Time.deltaTime;
            float dividedT = t / 3f;
            youDiedText.alpha = dividedT;
            youDiedText.fontSize = Mathf.Lerp(80f, 100f, dividedT);
            youDiedPanel.color = Color.Lerp(startColor, endColor, dividedT);
        }

        ETC_Memory.Instance.windowDepth++;
        youDiedCanvas.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
    }
}
