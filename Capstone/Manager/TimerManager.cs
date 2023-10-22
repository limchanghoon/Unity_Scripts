using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] double preRecord = -1f;

    double timer = 0f;
    bool isFinished = false;

    private void Start()
    {
        CFirebase.Instance.GetMyPrePortalRecord(this);
    }

    private void Update()
    {
        if (isFinished)
            return;

        timer += Time.deltaTime;
        timerText.text = string.Format("{0:N3}", timer);
    }

    public double StopTimer()
    {
        isFinished = true;
        return timer;
    }

    public double GetPreRecord()
    {
        return preRecord;
    }

    public void SetPreRecord(double _preRecord)
    {
        preRecord = _preRecord;
    }

}
