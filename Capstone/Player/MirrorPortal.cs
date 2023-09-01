using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPortal : MonoBehaviour
{
    public Transform opponentPortalTr;
    public Transform targetTr;
    [SerializeField] Transform m_target;

    [SerializeField] bool isA;

    [SerializeField] bool isActive = false;


    public void FadeIn()
    {
        isActive = false;
        if(opponentPortalTr == null)
        {
            GameObject _portal = isA ? GameObject.Find("어디로든 문B(Clone)") : GameObject.Find("어디로든 문A(Clone)");
            if(_portal != null)
            {
                opponentPortalTr = _portal.transform;
                targetTr = _portal.transform.GetChild(5).GetChild(0);

                var _MP = _portal.GetComponentInChildren<MirrorPortal>();
                if (_MP.opponentPortalTr == null)
                {
                    _MP.opponentPortalTr = transform.root;
                    _MP.targetTr = m_target;
                }
            }
        }

        StartCoroutine(FadeInCoroutine());
    }

    IEnumerator FadeInCoroutine()
    {
        Vector3 halfVector = Vector3.one * 0.5f;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 2f;
            transform.root.localScale = Vector3.Lerp(Vector3.zero, halfVector, t);
            yield return null;
        }

        isActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isActive && other.tag == "Player")
        {
            if (targetTr == null || opponentPortalTr == null)
                return;

            m_target.position = other.transform.position;

            if (opponentPortalTr.rotation.eulerAngles.x == 90)
                targetTr.localPosition = new Vector3(m_target.localPosition.x, -m_target.localPosition.y, 8.5f);
            else
                targetTr.localPosition = new Vector3(m_target.localPosition.x, -m_target.localPosition.y, 3.5f);

            other.transform.position = targetTr.position;
            other.transform.Rotate(0f, opponentPortalTr.eulerAngles.y - transform.eulerAngles.y - 90f, 0f);
        }
    }
}
