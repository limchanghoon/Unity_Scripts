using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData_MonoBehaviour : MonoBehaviour
{
    public ItemData itemData;

    private void Awake()
    {
        itemData = new ItemData();
    }
}
