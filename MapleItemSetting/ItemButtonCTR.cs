using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButtonCTR : MonoBehaviour
{
    [HideInInspector] public ItemType itemType;
    [HideInInspector] public CharacterClassGroup reqClassGroup = CharacterClassGroup.Fail;
    [HideInInspector] public CharacterClass reqClass;


    [HideInInspector] public int cell = -1;

    public void TurnOnItemSelectInfo()
    {
        var _go = GameObject.Find("ItemSelectInfoCanvas").transform.GetChild(0).gameObject;
        BackStackManager.Instance.PushAndSetTrue(_go);

        int index = transform.GetSiblingIndex();
        _go.GetComponent<ItemInfo>().Init(itemType, index, false, false, cell);
    }
}
