using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPortal : MonoBehaviour
{
    public Transform opponentPortalTr;
    public Transform targetTr;
    [SerializeField] Transform m_target;
    Transform parentTr;

    [SerializeField] bool isA;

    [SerializeField] bool isActive = false;

    PortalMapManager portalMapManager;

    private void Awake()
    {
        portalMapManager = GameObject.Find("PortalManager").GetComponent<PortalMapManager>();
    }


    public void FadeIn(Transform _tr)
    {
        parentTr = _tr;
        isActive = false;
        if(opponentPortalTr == null)
        {
            GameObject _portal = isA ? portalMapManager.Portal_B : portalMapManager.Portal_A;
            if(_portal != null)
            {
                opponentPortalTr = _portal.transform;
                targetTr = _portal.transform.GetChild(1).GetChild(0);

                var _MP = _portal.GetComponentInChildren<MirrorPortal>();
                if (_MP.opponentPortalTr == null)
                {
                    _MP.opponentPortalTr = transform.parent;
                    _MP.targetTr = m_target;
                }
            }
        }

        StartCoroutine(FadeInCoroutine());
    }

    IEnumerator FadeInCoroutine()
    {
        transform.parent.parent.parent = null;
        transform.parent.parent.localScale = 0.3f * Vector3.one;
        transform.parent.parent.parent = parentTr;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 3.5f;
            transform.parent.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            yield return null;
        }

        isActive = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (isActive)
        {
            if(other.tag == "Player")
                DoTrigger_Player(other);
            if (other.tag == "CanPortal")
                DoTrigger_Other(other);
        }
    }

    public void DoTrigger_Player(Collider other)
    {
        if (isActive && other.tag == "Player")
        {
            if (targetTr == null || opponentPortalTr == null)
                return;

            m_target.position = other.transform.position;

            if (0 <= opponentPortalTr.rotation.eulerAngles.x && opponentPortalTr.rotation.eulerAngles.x <= 90)
                targetTr.localPosition = new Vector3(m_target.localPosition.x, -m_target.localPosition.y, 10f);
            else
                targetTr.localPosition = new Vector3(m_target.localPosition.x, -m_target.localPosition.y, 3.5f);

            other.GetComponent<Player_Move>().SetPortalVelocity(opponentPortalTr.forward);

            other.transform.position = targetTr.position;
            other.transform.Rotate(0f, opponentPortalTr.eulerAngles.y - transform.eulerAngles.y - 90f, 0f);
        }
    }


    public void DoTrigger_Other(Collider other)
    {
        if (targetTr == null || opponentPortalTr == null)
            return;

        m_target.position = other.transform.position;

        targetTr.localPosition = new Vector3(m_target.localPosition.x, -m_target.localPosition.y, 3.5f);

        other.transform.position = targetTr.position;
        other.transform.Rotate(
            opponentPortalTr.eulerAngles.x - transform.eulerAngles.x
            , opponentPortalTr.eulerAngles.y - transform.eulerAngles.y - 90f
            , 0f);
    }


}
