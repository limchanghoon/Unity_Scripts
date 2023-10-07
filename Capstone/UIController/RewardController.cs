using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RewardController : MonoBehaviour
{
    public GameObject rewardBlock;
    public Transform cell_Group_Tr;

    private void Start()
    {
        GetComponent<Canvas>().sortingOrder = ETC_Memory.Instance.top_orderLayer++;
        ETC_Memory.Instance.windowDepth++;
    }

    public void Go_To_Village()
    {
        LoadingLevelController.Instance.LoadLevel("Village");
    }

    public void AddReward(string name, int count)
    {
        var obj=Instantiate(rewardBlock, cell_Group_Tr);
        string path = "Images/Items/" + name;
        obj.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
        obj.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "x " + count.ToString();
    }

    private void OnDestroy()
    {
        ETC_Memory.Instance.windowDepth--;
    }
}
