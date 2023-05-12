using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardController : MonoBehaviour
{
    private static RewardController instance;
    public static RewardController Instance
    {
        get
        {
            var obj = FindObjectOfType<RewardController>();
            if (obj != null)
            {
                instance = obj;
            }
            else
            {
                instance = Create();
            }
            return instance;
        }

    }

   
    
    private static RewardController Create()
    {
        return Instantiate(Resources.Load<RewardController>("RewardUI"));
    }

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    public void LoadReward_UI()
    {
        gameObject.SetActive(true);
    }

    public void Go_To_Village()
    {
        LoadingLevelController.Instance.LoadLevel("Village");
    }

}
