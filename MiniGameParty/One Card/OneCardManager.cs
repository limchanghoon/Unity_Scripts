using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OneCardManager : TurnBasedManager
{
    const int FIRST_CARD_COUNT = 7;
    int DEATH_COUNT = 20;
    public Transform myTurnTextTr;
    public TextMeshProUGUI myTurnText;
    public GameObject cardInfoObj;
    public Image cardInfoImage;
    public TextMeshProUGUI cardInfoText;
    public Button drawBtn;
    public Button handInBtn;
    public GameObject resultPanel;
    public TextMeshProUGUI resultText;
    public GameObject sevenPanel;
    public GameObject[] attackedObjs;
    public TextMeshProUGUI[] attackedTexts;
    public TextMeshProUGUI[] countOfCardTexts;
    public Image[] borderOfSevens;
    public Sprite[] spitesOfSeven;

    public GameObject[] p1BacksOfCard;
    public GameObject[] p2BacksOfCard;
    public GameObject[] p3BacksOfCard;
    public GameObject[] p4BacksOfCard;
    public GameObject[][] backsOfCard;

    [SerializeField] string[] cardEffectsStr;

    public Transform trOfField;
    public Card cardOfField;
    Card selectedCard = null;
    public int attackPoint = 0;

    [SerializeField] Transform cardsOfFieldTr;
    [SerializeField] Transform deckTr;
    [SerializeField] List<int> cardsOfField = new List<int>();
    [SerializeField] List<int> cardsOfDeck = new List<int>();
    [SerializeField] List<Transform> indexToTr = new List<Transform>();

    [SerializeField] List<Transform> playerHands = new List<Transform>();

    public GameObject myPanel;
    string[] cardTypes = { "스페이드", "하트", "다이아몬드", "클로버", "조커"};

    int rating = -1;
    int numDeaths = 0;
    int numWin = 0;

    protected override void Awake()
    {
        totalPlayer = PhotonNetwork.CurrentRoom.PlayerCount;
        switch (PhotonNetwork.CurrentRoom.PlayerCount)
        {
            case 2:
                DEATH_COUNT = 20;
                break;
            case 3:
                DEATH_COUNT = 17;
                break;
            case 4:
                DEATH_COUNT = 12;
                break;
        }
        backsOfCard = new GameObject[][] { p1BacksOfCard, p2BacksOfCard, p3BacksOfCard, p4BacksOfCard };
        PhotonNetwork.Instantiate("OneCardPlayer", Vector3.zero, Quaternion.identity);
        base.Awake();
    }

    public override void SetInitialOfAllClient()
    {
        int k = -1;
        for (int i = 0; i < playerList.Count; i++)
        {
            if (playerList[i] == PhotonNetwork.LocalPlayer.ActorNumber)
            {
                k = i;
                break;
            }
        }
        GameObject[] tmpObj = new GameObject[4];
        TextMeshProUGUI[] tmpAtkText = new TextMeshProUGUI[4];
        TextMeshProUGUI[] tmpCntText = new TextMeshProUGUI[4];
        GameObject[][] tmpArray = new GameObject[4][];
        for (int i = 0; i < 4; i++)
        {
            Debug.Log("k : " + k.ToString());
            tmpObj[k] = attackedObjs[i];
            tmpAtkText[k] = attackedTexts[i];
            tmpCntText[k] = countOfCardTexts[i];
            tmpArray[k] = backsOfCard[i];
            k = (k + 1) % 4;
        }
        attackedObjs = tmpObj;
        attackedTexts = tmpAtkText;
        countOfCardTexts = tmpCntText;
        backsOfCard = tmpArray;
    }

    public override void SetInitialOfMasterClient()
    {
        Shuffle();
        DivideCard();
        pv.RPC("ShowBackOfCard", RpcTarget.All);
    }

    private void Shuffle()
    {
        for (int i = cardsOfDeck.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            var tr = cardsOfDeck[i];
            cardsOfDeck[i] = cardsOfDeck[j];
            cardsOfDeck[j] = tr;
        }
        pv.RPC("SetCardsOfDeck", RpcTarget.Others, cardsOfDeck.ToArray());
    }

    [PunRPC]
    void SetCardsOfDeck(int[] array)
    {
        cardsOfDeck.Clear();
        for (int i = 0; i < array.Length; i++)
        {
            cardsOfDeck.Add(array[i]);
        }
    }

    private void DivideCard()
    {
        for(int i = 0; i < playerCount; i++)
        {
            for (int k = 0; k < FIRST_CARD_COUNT; k++)
            {
                pv.RPC("GetCard", RpcTarget.All, i, cardsOfDeck.Count - 1);
            }
        }
        pv.RPC("AddToField", RpcTarget.All, cardsOfDeck.Count - 1);
    }

    [PunRPC]
    void ShowBackOfCard()
    {
        for (int i = 0; i < playerCount; i++)
        {
            if (playerList[i] != PhotonNetwork.LocalPlayer.ActorNumber)
            {
                int k = 0;
                for (; k < FIRST_CARD_COUNT; k++)
                {
                    backsOfCard[i][k].SetActive(true);
                }
                for (; k < DEATH_COUNT; k++)
                {
                    backsOfCard[i][k].SetActive(false);
                }
            }
        }
    }

    void IfZeroMakeDeckAndGetCard()
    {
        if (cardsOfDeck.Count == 0)
        {
            cardsOfDeck = cardsOfField.ToList();
            Shuffle();
            pv.RPC("ClearFieldAndMoveToDeckRPC", RpcTarget.All);
        }
        if (cardsOfDeck.Count - 1 >= 0)
            pv.RPC("GetCard", RpcTarget.All, whoseTurn, cardsOfDeck.Count - 1);
    }

    [PunRPC]
    void GetCard(int player_index, int cardOfDeckIndex)
    {
        int card = cardsOfDeck[cardOfDeckIndex];
        Debug.Log(card.ToString());
        Debug.Log(player_index.ToString());
        if (PhotonNetwork.LocalPlayer.ActorNumber == playerList[player_index])
        {
            indexToTr[card].SetParent(myPanel.transform);
            indexToTr[card].GetComponent<Card>().isMine = true;
        }
        else
        {
            indexToTr[card].SetParent(playerHands[player_index]);
        }
        cardsOfDeck.RemoveAt(cardOfDeckIndex);
    }

    [PunRPC]
    void ClearFieldAndMoveToDeckRPC()
    {
        cardsOfField.Clear();
        for (int i = (cardsOfFieldTr.childCount - 1); i >= 0; i--)
        {
            Debug.Log("iii : "+i.ToString());
            Card _card = cardsOfFieldTr.GetChild(i).GetComponent<Card>();
            cardsOfFieldTr.GetChild(i).SetParent(deckTr);
        }
    }

    void EndOfTurn()
    {
        playerDic[playerList[whoseTurn]].pv.RPC("ChangeIsMyTurn", RpcTarget.All, false);
        ChangeCardToBlack();
        Hit();
    }

    void ChangeCardToBlack()
    {
        for (int i = myPanel.transform.childCount - 1; i >= 0; i--)
        {
            Transform _t = myPanel.transform.GetChild(i);
            _t.GetChild(0).GetComponent<Image>().color = Color.black;
        }
    }

    void Hit()
    {
        if(selectedCard == null)
        {
            for (int i = 0; i < attackPoint; i++)
            {
                IfZeroMakeDeckAndGetCard();
            }
            attackPoint = 0;
            pv.RPC("SetAttackPoint", RpcTarget.All, attackPoint);
            return;
        }

        int hitPoint = attackPoint;
        switch (cardOfField.cardNum)
        {
            case 1:
                if (selectedCard.cardNum == 1)
                {
                    if (cardOfField.cardType == Card.CardType.Spade)
                    {
                        attackPoint = 3;
                    }
                    else
                    {
                        hitPoint = 0;
                        if (selectedCard.cardType == Card.CardType.Spade)
                            attackPoint += 5;
                        else
                            attackPoint += 3;
                    }
                }
                else if (selectedCard.cardNum == 2)
                {
                    attackPoint = 2;
                }
                else if (selectedCard.cardNum == 14)
                {
                    hitPoint = 0;
                    attackPoint += 5;
                }
                else if (selectedCard.cardNum == 15)
                {
                    hitPoint = 0;
                    attackPoint += 7;
                }
                else
                    attackPoint = 0;
                break;
            case 2:
                if (selectedCard.cardNum == 1)
                {
                    hitPoint = 0;
                    if (selectedCard.cardType == Card.CardType.Spade)
                        attackPoint += 5;
                    else
                        attackPoint += 3;
                }
                else if (selectedCard.cardNum == 2)
                {
                    hitPoint = 0;
                    attackPoint += 2;
                }
                else if (selectedCard.cardNum == 3)
                {
                    hitPoint = 0;
                    attackPoint = 0;
                }
                else if (selectedCard.cardNum == 14)
                {
                    hitPoint = 0;
                    attackPoint += 5;
                }
                else if (selectedCard.cardNum == 15)
                {
                    hitPoint = 0;
                    attackPoint += 7;
                }
                else
                    attackPoint = 0;
                break;
            case 14:    // 흑백 조커
                if (selectedCard.cardNum == 1)
                {
                    if (selectedCard.cardType == Card.CardType.Spade)
                    {
                        hitPoint = 0;
                        attackPoint += 5;
                    }
                    else
                        attackPoint = 3;
                }
                else if (selectedCard.cardNum == 2)
                    attackPoint = 2;
                else if (selectedCard.cardNum == 15)
                {
                    hitPoint = 0;
                    attackPoint += 7;
                }
                else
                    attackPoint = 0;
                break;
            case 15:    // 컬러 조커
                if (selectedCard.cardNum == 1)
                {
                    if (selectedCard.cardType == Card.CardType.Spade)
                        attackPoint = 5;
                    else
                        attackPoint = 3;
                }
                else if (selectedCard.cardNum == 2)
                    attackPoint = 2;
                else if (selectedCard.cardNum == 14)
                    attackPoint = 5;
                else
                    attackPoint = 0;
                break;
            default:
                if (selectedCard.cardNum == 1)
                {
                    if (selectedCard.cardType == Card.CardType.Spade)
                        attackPoint = 5;
                    else
                        attackPoint = 3;
                }
                else if (selectedCard.cardNum == 2)
                    attackPoint = 2;
                else if (selectedCard.cardNum == 14)
                    attackPoint = 5;
                else if (selectedCard.cardNum == 15)
                    attackPoint = 7;
                break;
        }
        for (int i = 0; i < hitPoint; i++)
        {
            IfZeroMakeDeckAndGetCard();
        }
        pv.RPC("SetAttackPoint", RpcTarget.All, attackPoint);
    }

    [PunRPC]
    void SetAttackPoint(int _attackPoint)
    {
        attackPoint = _attackPoint;
    }

    [PunRPC]
    void AddToField(int cardOfDeckIndex)
    {
        int card = cardsOfDeck[cardsOfDeck.Count - 1];
        indexToTr[card].SetParent(trOfField);
        cardOfField = indexToTr[card].GetComponent<Card>();
        cardsOfDeck.RemoveAt(cardOfDeckIndex);
    }

    // 여기 수정
    [PunRPC]
    public void TurnToNext(int preTurn)
    {
        if (!PhotonNetwork.IsMasterClient)
            return;

        Debug.Log("TurnToNext");
        if (CheckEnd())
            return;
        pv.RPC("SetTurn", RpcTarget.All, GetNextTurn(), preTurn);
    }

    // 여기 수정
    [PunRPC]
    public override void TurnToNext()
    {
        if (!PhotonNetwork.IsMasterClient)
            return;

        Debug.Log("TurnToNext");
        if (CheckEnd())
            return;
        pv.RPC("SetTurn", RpcTarget.All, GetNextTurn(), whoseTurn);
    }

    bool CheckEnd()
    {
        int count = 0;
        for (int i = 0; i < playerList.Count; i++)
        {
            if (playerList[i] != -1 && !playerDic[playerList[i]].isDied)
                count++;
        }
        
        if (count <= 1)
        {
            gameEnd = true;
            pv.RPC("ShowResult", RpcTarget.All);
            return true;
        }
        
        return false;
    }

    int GetNextTurn()
    {
        Debug.Log("GetNextTurn");
        int tmp = whoseTurn;
        do
        {
            tmp = (tmp + 1) % playerList.Count;
            Debug.Log(tmp);
            if (tmp == whoseTurn)
            {
                Debug.Log("Can not turn to next!");
                break;
            }
        } while (playerList[tmp] == -1 || playerDic[playerList[tmp]].isDied);
        return tmp;
    }

    int GetPreTurn()
    {
        Debug.Log("GetPreTurn");
        int tmp = whoseTurn;
        do
        {
            if (--tmp < 0)
                tmp = playerList.Count - 1;
            Debug.Log(tmp);
            if (tmp == whoseTurn)
            {
                Debug.Log("Can not turn to pre!");
                break;
            }
        } while (playerList[tmp] == -1 || playerDic[playerList[tmp]].isDied);
        return tmp;
    }

    [PunRPC]
    void SetTurn(int _idx, int preTurn)
    {
        Debug.Log("SetTurn");
        // 죽은 것 체크
        if (preTurn >= 0)
        {
            attackedObjs[preTurn].SetActive(false);

            if (playerList[preTurn] != PhotonNetwork.LocalPlayer.ActorNumber) {   // 내턴아님!(whoseTurn 바뀌기 전)
                int cnt = playerHands[preTurn].childCount;
                if (cnt > DEATH_COUNT)
                {
                    if(playerList[preTurn]!= -1)
                        playerDic[playerList[preTurn]].isDied = true;
                    numDeaths++;
                    int i = cnt - 1;
                    for (; i >= DEATH_COUNT; i--)
                    {
                        Card _card = playerHands[preTurn].GetChild(i).GetComponent<Card>();
                        _card.transform.SetParent(cardsOfFieldTr);
                        if (_card.cardType == Card.CardType.Joker)
                        {
                            // 53 54
                            cardsOfField.Add(39 + _card.cardNum);
                        }
                        else
                        {
                            cardsOfField.Add(((int)(_card.cardType)) * 13 + _card.cardNum);
                        }
                    }
                    for (; i >= 0; i--)
                    {
                        Card _card = playerHands[preTurn].GetChild(i).GetComponent<Card>();
                        _card.transform.SetParent(cardsOfFieldTr);
                        if (_card.cardType == Card.CardType.Joker)
                        {
                            // 53 54
                            cardsOfField.Add(39 + _card.cardNum);
                        }
                        else
                        {
                            cardsOfField.Add(((int)(_card.cardType)) * 13 + _card.cardNum);
                        }
                        backsOfCard[preTurn][i].SetActive(false);
                    }
                }
                else if (cnt == 0)
                {
                    for (int i = 0; i < DEATH_COUNT; i++)
                    {
                        backsOfCard[preTurn][i].SetActive(false);
                    }
                    if (playerList[preTurn] != -1)
                        playerDic[playerList[preTurn]].isDied = true;
                    numWin++;
                }
                else
                {
                    int i = 0;
                    for (; i < cnt; i++)
                    {
                        backsOfCard[preTurn][i].SetActive(true);
                    }
                    for (; i < DEATH_COUNT; i++)
                    {
                        backsOfCard[preTurn][i].SetActive(false);
                    }
                }
            }
            else   // 내턴!(whoseTurn 바뀌기 전)
            {
                int cnt = myPanel.transform.childCount;
                if (cnt > DEATH_COUNT)
                {
                    if (playerList[preTurn] != -1)
                        playerDic[playerList[preTurn]].isDied = true;
                    for (int i = myPanel.transform.childCount - 1; i >= 0; i--)
                    {
                        Card _card = myPanel.transform.GetChild(i).GetComponent<Card>();
                        _card.transform.SetParent(cardsOfFieldTr);
                        if (_card.cardType == Card.CardType.Joker)
                        {
                            // 53 54
                            cardsOfField.Add(39 + _card.cardNum);
                        }
                        else
                        {
                            cardsOfField.Add(((int)(_card.cardType)) * 13 + _card.cardNum);
                        }
                    }
                    rating = playerCount - numDeaths;
                    numDeaths++;
                } 
                else if(cnt == 0)
                {
                    if (playerList[preTurn] != -1)
                        playerDic[playerList[preTurn]].isDied = true;
                    rating = 1 + numWin;
                    numWin++;
                }
            }
        }
        //
        for(int i = 0; i < playerList.Count; i++)
        {
            int _cnt = -1;
            if (playerList[i] == PhotonNetwork.LocalPlayer.ActorNumber)
                _cnt = myPanel.transform.childCount;
            else
                _cnt = playerHands[i].childCount;

            countOfCardTexts[i].text = _cnt == 0 ? "" : _cnt.ToString() + "/" + DEATH_COUNT.ToString() + "장";
        }

        whoseTurn = _idx;
        if (attackPoint >= 0)
        {
            attackedTexts[whoseTurn].text = "X " + attackPoint.ToString();
            attackedObjs[whoseTurn].SetActive(true);
        }
        if (playerDic[playerList[whoseTurn]].pv.IsMine)
        {
            StartCoroutine(StartMyTurnCoroutine());
        }
        if (PhotonNetwork.IsMasterClient)
            CheckEnd();
    }

    IEnumerator StartMyTurnCoroutine()
    {
        Debug.Log("StartMyTurnCoroutine");
        myTurnTextTr.gameObject.SetActive(true);
        myTurnTextTr.localScale = Vector3.zero;
        float c = 0f;
        while (c < 1f)
        {
            c = c + Time.deltaTime > 1f ? 1f : c + Time.deltaTime;
            myTurnTextTr.localScale = new Vector3(c, c, c);
            myTurnText.alpha = 1f - c;
            yield return null;
        }
        myTurnTextTr.gameObject.SetActive(false);
        playerDic[playerList[whoseTurn]].StartMyTurn();

        MarkAvailableCards();
        drawBtn.interactable = true;
        if (selectedCard != null && CheckHandIn(selectedCard, attackPoint))
            handInBtn.interactable = true;
    }

    void MarkAvailableCards()
    {
        for (int i = myPanel.transform.childCount - 1; i >= 0; i--)
        {
            Transform _t = myPanel.transform.GetChild(i);
            if (CheckHandIn(_t.GetComponent<Card>(), attackPoint))
                _t.GetChild(0).GetComponent<Image>().color = Color.yellow;
            else
                _t.GetChild(0).GetComponent<Image>().color = Color.black;
        }
    }

    public void ShowCardInfo(Card card)
    {
        if (!card.isMine)
            return;
        selectedCard = card;

        bool bbb = CheckHandIn(selectedCard, attackPoint);
        if (playerList[whoseTurn] != PhotonNetwork.LocalPlayer.ActorNumber || !bbb)
            handInBtn.interactable = false;
        else if(bbb && drawBtn.interactable)
            handInBtn.interactable = true;

        cardInfoObj.SetActive(true);
        cardInfoImage.sprite = selectedCard.image.sprite;
        cardInfoText.text = "카드 이름 : ";
        string num = "";
        int n = selectedCard.cardNum;
        if (n == 1)
            num = "A";
        else if (n <= 10)
            num = n.ToString();
        else if (n == 11)
            num = "J";
        else if (n == 12)
            num = "Q";
        else if (n == 13)
            num = "K";
        else if (n == 14)
            cardInfoText.text += "흑백";
        else if (n == 15)
            cardInfoText.text += "컬러";
        cardInfoText.text += cardTypes[(int)selectedCard.cardType] + " " + num + "\n";
        int idx;
        if (selectedCard.cardType == Card.CardType.Joker)
        {
            idx = 39 + selectedCard.cardNum;
        }
        else
        {
            idx = ((int)(selectedCard.cardType)) * 13 + selectedCard.cardNum;
        }
        cardInfoText.text += "카드 효과 : " + cardEffectsStr[idx] + "!";
    }

    public void HandIn()
    {
        cardInfoObj.SetActive(false);
        if (!CheckHandIn(selectedCard, attackPoint))
            return;


        if (playerList[whoseTurn] == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            drawBtn.interactable = false;
            handInBtn.interactable = false;
            if(selectedCard.cardNum == 7)
            {
                ChangeCardToBlack();
                SelectTypeOfSeven((int)selectedCard.cardType);
                sevenPanel.SetActive(true);
            }
            else
            {
                EndOfTurn();
            }
            Debug.Log("HandIn");
            pv.RPC("HandInRPC", RpcTarget.All, selectedCard.cardType, selectedCard.cardNum);
            selectedCard = null;
        }
    }

    [PunRPC]
    void HandInRPC(Card.CardType _cardType, int _cardNum)
    {
        Debug.Log(((int)(_cardType)) * 12 + _cardNum);
        cardOfField.transform.SetParent(cardsOfFieldTr);
        if (cardOfField.cardType == Card.CardType.Joker)
        {
            // 53 54
            cardsOfField.Add(39 + cardOfField.cardNum);
        }
        else
        {
            if (cardOfField.cardNum == 7)
            {
                cardOfField.cardType = cardOfField.originalType;
                cardOfField.transform.GetChild(1).GetComponent<Image>().sprite = spitesOfSeven[(int)cardOfField.cardType];
            }
            cardsOfField.Add(((int)(cardOfField.cardType)) * 13 + cardOfField.cardNum);
        }
        Transform _cardTr = _cardType == Card.CardType.Joker ?
            indexToTr[39 + _cardNum] : indexToTr[((int)(_cardType)) * 13 + _cardNum];
        cardOfField = _cardTr.GetComponent<Card>();
        cardOfField.isMine = false;
        cardOfField.transform.SetParent(trOfField);
        if (cardOfField.cardNum == 7)
            return;
        if (PhotonNetwork.IsMasterClient)
        {
            int preTurn = whoseTurn;
            if (_cardNum == 11)
            {
                whoseTurn = GetNextTurn();
                pv.RPC("TurnToNext", RpcTarget.All, preTurn);
            }
            else if (_cardNum == 12)
            {
                whoseTurn = GetPreTurn();
                whoseTurn = GetPreTurn();
                pv.RPC("TurnToNext", RpcTarget.All, preTurn);
            }
            else if (_cardNum == 13)
            {
                whoseTurn = GetPreTurn();
                pv.RPC("TurnToNext", RpcTarget.All, preTurn);
            }
            else
            {
                pv.RPC("TurnToNext", RpcTarget.All);
            }
        }
    }

    bool CheckHandIn(Card _card, int ap)
    {
        if (ap > 0)
        {
            if (!CheckHandIn(_card, 0))
                return false;
            // 공격 : 컬러 조커, 흑백 조커, 스페이드 에이스, 에이스 3장, 2숫자 4장
            // 비공격 : 3숫자 4장
            if (_card.cardNum == 15)
                return true;
            if (_card.cardNum == 14 && cardOfField.cardNum != 15)
                return true;
            if (_card.cardNum == 1)
            {
                if (_card.cardType == Card.CardType.Spade)
                {
                    if (cardOfField.cardNum != 15)
                        return true;
                }
                else
                {
                    if (!(cardOfField.cardNum == 1 && cardOfField.cardType == Card.CardType.Spade) 
                        && cardOfField.cardNum != 14 && cardOfField.cardNum != 15)
                        return true;
                }
            }
            if (_card.cardNum == 2 && cardOfField.cardNum == 2)
                return true;
            if (_card.cardNum == 3 && cardOfField.cardNum == 2)
                return true;
            return false;
        }
        else
        {
            if (_card.cardNum == cardOfField.cardNum)
                return true;
            if (_card.cardType == cardOfField.cardType)
                return true;
            if (_card.cardType == Card.CardType.Joker)
                return true;
            if (cardOfField.cardType == Card.CardType.Joker)
                return true;
            return false;
        }
    }

    public void CancelHandIn()
    {
        Debug.Log("CancelHandIn");
        cardInfoObj.SetActive(false);
        selectedCard = null;
    }

    public void SelectTypeOfSeven(int n)
    {
        for(int i = 0; i < 4; i++)
        {
            if (i == n)
                borderOfSevens[i].color = Color.magenta;
            else
                borderOfSevens[i].color = Color.black;
        }
    }

    public void ConfirmTypeOfSeven()
    {
        for (int i = 0; i < 4; i++)
        {
            if (borderOfSevens[i].color == Color.magenta)
            {
                sevenPanel.SetActive(false);
                EndOfTurn();
                pv.RPC("ChangeTypeOfSeven", RpcTarget.All, i);
                pv.RPC("TurnToNext", RpcTarget.All);
                return;
            }
        }
    }

    [PunRPC]
    void ChangeTypeOfSeven(int idx)
    {
        cardOfField.cardType = (Card.CardType)idx;
        cardOfField.transform.GetChild(1).GetComponent<Image>().sprite = spitesOfSeven[(int)cardOfField.cardType];
    }

    public void DrawCard()
    {
        if (playerList[whoseTurn] == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            drawBtn.interactable = false;
            handInBtn.interactable = false;
            if (attackPoint == 0)
                IfZeroMakeDeckAndGetCard();
            EndOfTurn();
            pv.RPC("TurnToNext", RpcTarget.All);
        }
    }

    [PunRPC]
    protected override void ShowResult()
    {
        gameEnd = true;
        resultPanel.SetActive(true);
        if (rating == -1)
            rating = totalPlayer - numDeaths;
        resultText.text = rating.ToString() + "등!";
    }

    public void GoToMenu()
    {
        PhotonNetwork.LeaveRoom();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        numDeaths++;

        for (int i = 0; i < playerList.Count; i++)
        {
            if (playerList[i] == otherPlayer.ActorNumber)
            {
                for (int k = 0; k < DEATH_COUNT; k++)
                {
                    backsOfCard[i][k].SetActive(false);
                }
                attackedObjs[i].SetActive(false);
                countOfCardTexts[i].text = "";
                for(int k = playerHands[i].childCount - 1; k >=0; k--)
                {
                    Card _card = playerHands[i].GetChild(k).GetComponent<Card>();
                    _card.transform.SetParent(cardsOfFieldTr);
                    if (_card.cardType == Card.CardType.Joker)
                    {
                        // 53 54
                        cardsOfField.Add(39 + _card.cardNum);
                    }
                    else
                    {
                        cardsOfField.Add(((int)(_card.cardType)) * 13 + _card.cardNum);
                    }
                }
                break;
            }

        }


        base.OnPlayerLeftRoom(otherPlayer);
    }
}
