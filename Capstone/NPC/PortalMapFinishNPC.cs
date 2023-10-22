using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PortalMapFinishNPC : MonoBehaviour,IInteract
{
    [SerializeField] GameManager GM;

    [SerializeField] TimerManager timerManager;
    [SerializeField] GameObject resultCanvas;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] TextMeshProUGUI finalTimerText;
    [SerializeField] TextMeshProUGUI myRankText;
    [SerializeField] GameObject loadingText;

    [SerializeField] ContentSizeFitter csf;
    [SerializeField] Scrollbar rankScrollbar;
    [SerializeField] Transform rankContentTr;
    [SerializeField] GameObject rankTextPrefab;

    double finalTimer = -1f;

    [ContextMenu("������~")]
    public void Interact()
    {
        GM.ui_camera.transform.parent = null;
        GM.main_camera.transform.parent = null;
        GM.myPlayer.SetActive(false);

        finalTimer = timerManager.StopTimer();

        resultCanvas.SetActive(true);

        finalTimerText.text = "���� ���� ��� : " + string.Format("{0:N3}", finalTimer) + "s";


        ETC_Memory.Instance.windowDepth++;

        StartCoroutine(FadeIn());

        StartCoroutine(GetRank());
    }

    IEnumerator FadeIn()
    {
        float t = 0f;
        while(t <= 1f)
        {
            yield return null;
            t += Time.deltaTime;
            canvasGroup.alpha = t;
        }
        canvasGroup.alpha = 1f;

        // ���� �ڿ� ��ư Ȱ��ȭ???
    }


    IEnumerator GetRank()
    {
        while (true)
        {
            // ���� ������ �� ������ ��
            if (timerManager.GetPreRecord() < 0f)
            {
                CFirebase.Instance.GetMyPrePortalRecord(timerManager);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                break;
            }
        }
        if(timerManager.GetPreRecord() > finalTimer)
            CFirebase.Instance.SetAndGetPortalRecord(this, finalTimer);
        else
            CFirebase.Instance.GetPortalRecord(this);
    }


    public void RankSet(DataSnapshot snapshot)
    {
        loadingText.SetActive(false);
        int rank = 1;
        int myRank = -1;
        foreach (DataSnapshot leader in snapshot.Children)
        {
            if (rank <= 100)
            {
                var tmp = (double)leader.Child("TimeRecord").Value;
                var rankText = Instantiate(rankTextPrefab, rankContentTr).GetComponent<TextMeshProUGUI>();
                rankText.text = (rank).ToString() + "�� " + leader.Key + " : " + string.Format("{0:N3}", tmp);

                if (leader.Key == Player_Info.Instance.nickName)
                {
                    myRank = rank;
                    rankText.color = Color.yellow;
                    myRankText.text = "���� ��ŷ :\n" + myRank.ToString() + "��";
                    Debug.Log("���� ��ŷ : " + myRank.ToString() + "��");
                }
            }
            else if (myRank == -1)
            {
                if (leader.Key == Player_Info.Instance.nickName)
                {
                    myRank = rank;
                    if (rank != 101)
                        Instantiate(rankTextPrefab, rankContentTr).GetComponent<TextMeshProUGUI>();


                    var tmp = (double)leader.Child("TimeRecord").Value;
                    var rankText = Instantiate(rankTextPrefab, rankContentTr).GetComponent<TextMeshProUGUI>();
                    rankText.text = (rank).ToString() + "�� " + leader.Key + " : " + string.Format("{0:N3}", tmp);
                    rankText.color = Color.yellow;
                    myRankText.text = "���� ��ŷ :\n" + myRank.ToString() + "��";

                    if (rank != 101)
                        ++rank;
                }
            }
            else break;

            ++rank;
        }
        Instantiate(rankTextPrefab, rankContentTr).GetComponent<TextMeshProUGUI>();
        ++rank;

        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)csf.transform);
        rankScrollbar.value = 1 - (myRank + 1) / (float)(rank - 1);
    }

    public void GoToVillage()
    {
        ETC_Memory.Instance.windowDepth--;
        LoadingSceneController.Instance.LoadScene("Village");
    }

}
