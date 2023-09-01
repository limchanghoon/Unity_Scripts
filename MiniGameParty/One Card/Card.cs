using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] OneCardManager oneCardGM = null;
    public enum CardType
    {
        Spade,
        Heart,
        Diamond,
        Club,
        Joker
    }
    public CardType originalType;
    public CardType cardType;
    public int cardNum;
    public Image image;

    public bool isMine = false;
    public void ShowCardInfo()
    {
        if (oneCardGM == null)
            oneCardGM = GameObject.Find("GM").GetComponent<OneCardManager>();
        oneCardGM.ShowCardInfo(this);
    }
}
