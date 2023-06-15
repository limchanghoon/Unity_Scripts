using System;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;

public class TetrisManager : MonoBehaviour
{
    [Serializable]
    public class _2dArray_Int
    {
        public int[] arr = new int[10];
    }

    [Serializable]
    public class _2dArray_Image
    {
        public Image[] arr = new Image[10];
    }

    [Serializable]
    public class _PositionWithGrid
    {
        public int x;
        public int y;
        public int gridX;
        public int gridY;

        public void Set(int _x, int _y, int _gridX, int _gridY)
        {
            x = _x;
            y = _y;
            gridX = _gridX;
            gridY = _gridY;
        }
    }

    [Serializable]
    public class _Position
    {
        public int x;
        public int y;

        public _Position()
        {
            x = 0;
            y = 0;
        }

        public _Position(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }


    const int FREE_SPACE_SIZE_Y = 4;            // 위에 여분 공간
    const int SIZE_X = 10;                      // 가로 사이즈
    const int SIZE_Y = 20 + FREE_SPACE_SIZE_Y;  // 세로 사이즈 + 세로 여분 공간
    const int NEED_TO_GARBAGE = 5;              // 쓰레기줄 생성을 위해 필요한 줄

    public int playerCount = 0;
    PhotonView pv;
    
    // 10 x (20 + 4)
    public _2dArray_Image[] blockImages;
    public _2dArray_Int[] blockChecks;

    public _2dArray_Image[] opponentBlockImages;
    public _2dArray_Int[] opponentBlockChecks;

    // 블럭 이미지 & 색상
    public Sprite blankSprite;
    public Sprite blockSprite;
    private Color blankColor = new Color(100f / 255f, 100f / 255f, 100f / 255f);
    private Color garbageColor = new Color(50f / 255f, 50f / 255f, 50f / 255f, 1f);
    private Color helpColor = new Color(100f / 255f, 100f / 255f, 100f / 255f, 100f / 255f);
    Dictionary<char, Color> blockColors = new Dictionary<char, Color>() {
        {'I', new Color(0f, 1f, 1f)},
        {'O', new Color(1f, 1f, 0f)},
        {'Z', new Color(1f, 0f, 0f)},
        {'S', new Color(0f, 1f, 0f)},
        {'J', new Color(0f, 0f, 1f)},
        {'L', new Color(1f, 127/255f, 0f)},
        {'T', new Color(128f/255f, 0f, 128f/255f)}
    };

    // 블럭 생성 지점
    Dictionary<char, List<_Position>> blockInitPositions = new Dictionary<char, List<_Position>>() {
        {'I', new List<_Position>(new _Position[] { new _Position(3, 18), new _Position(4, 18), new _Position(5, 18), new _Position(6, 18) } ) },
        {'O', new List<_Position>(new _Position[] { new _Position(4, 19), new _Position(5, 19), new _Position(4, 18), new _Position(5, 18) } ) },
        {'Z', new List<_Position>(new _Position[] { new _Position(3, 19), new _Position(4, 19), new _Position(4, 18), new _Position(5, 18) } ) },
        {'S', new List<_Position>(new _Position[] { new _Position(4, 19), new _Position(5, 19), new _Position(3, 18), new _Position(4, 18) } ) },
        {'J', new List<_Position>(new _Position[] { new _Position(3, 19), new _Position(3, 18), new _Position(4, 18), new _Position(5, 18) } ) },
        {'L', new List<_Position>(new _Position[] { new _Position(5, 19), new _Position(3, 18), new _Position(4, 18), new _Position(5, 18) } ) },
        {'T', new List<_Position>(new _Position[] { new _Position(4, 19), new _Position(3, 18), new _Position(4, 18), new _Position(5, 18) } ) },
    };

    // 시계 방향 Offset
    _Position[,] clockwiseOffsets_I = new _Position[4, 5] {
        { new _Position(0, 0), new _Position(-2, 0), new _Position(1, 0), new _Position(-2, -1), new _Position(1, 2) },
        { new _Position(0, 0), new _Position(-1, 0), new _Position(2, 0), new _Position(-1, 2), new _Position(2, -1) },
        { new _Position(0, 0), new _Position(2, 0), new _Position(-1, 0), new _Position(2, 1), new _Position(-1, -2) },
        { new _Position(0, 0), new _Position(1, 0), new _Position(-2, 0), new _Position(1, -2), new _Position(-2, 1) }};
    _Position[,] clockwiseOffsets = new _Position[4, 5] {
        { new _Position(0, 0), new _Position(-1, 0), new _Position(-1, 1), new _Position(0, -2), new _Position(-1, -2) },
        { new _Position(0, 0), new _Position(1, 0), new _Position(1, -2), new _Position(0, 2), new _Position(1, 2) },
        { new _Position(0, 0), new _Position(1, 0), new _Position(1, 1), new _Position(0, -2), new _Position(1, -2) },
        { new _Position(0, 0), new _Position(-1, 0), new _Position(-1, -1), new _Position(0, 2), new _Position(-1, 2) }};

    // 반시계 방향 Offset
    _Position[,] counterClockwiseOffsets_I = new _Position[4, 5] {
        { new _Position(0, 0), new _Position(-1, 0), new _Position(2, 0), new _Position(-1, 2), new _Position(2, -1) },
        { new _Position(0, 0), new _Position(2, 0), new _Position(-1, 0), new _Position(2, 1), new _Position(-1, -2) },
        { new _Position(0, 0), new _Position(1, 0), new _Position(-2, 0), new _Position(1, -2), new _Position(-2, 1) },
        { new _Position(0, 0), new _Position(-2, 0), new _Position(1, 0), new _Position(-2, -1), new _Position(1, 2) }};
    _Position[,] counterClockwiseOffsets = new _Position[4, 5] {
        { new _Position(0, 0), new _Position(1, 0), new _Position(1, 1), new _Position(0, -2), new _Position(1, -2) },
        { new _Position(0, 0), new _Position(1, 0), new _Position(1, -1), new _Position(0, 2), new _Position(1, 2) },
        { new _Position(0, 0), new _Position(-1, 0), new _Position(-1, 1), new _Position(0, -1), new _Position(-1, -2) },
        { new _Position(0, 0), new _Position(-1, 0), new _Position(-1, -1), new _Position(0, 2), new _Position(-1, 2) }};

    /* I, O, Z, S, J, L, T */
    public GameObject[] nextBlockImage;
    Dictionary<char, GameObject> blockImageDic = new Dictionary<char, GameObject>();


    /* I, O, (Z,S), (J,L), T */
    public char currentType;
    public int currentRotation;
    char nextType = 'I';

    // 현재 블럭과 현재 고스트 블럭의 위치
    _PositionWithGrid[] currentPostitions = new _PositionWithGrid[4] { new _PositionWithGrid(), new _PositionWithGrid(), new _PositionWithGrid(), new _PositionWithGrid() };
    _Position[] helpingBlockPostitions = new _Position[4] { new _Position(), new _Position(), new _Position(), new _Position() };

    bool b_start = false;
    bool b_end = false;
    bool b_win = true;
    float timer = 0f;
    float timerFactor = 1f;
    public float totalTime = 0f;
    public float opponentTotalTime = 0f;
    public int deletedLineCount = 0;
    public int garbageLineCount = 0;
    public TextMeshProUGUI deletedLineCountText;
    public TextMeshProUGUI garbageLineCountText;
    public TextMeshProUGUI totalTimerText;
    public TextMeshProUGUI resultTotalTimerText;

    public GameObject resultPanel;
    public GameObject winText;
    public GameObject loseText;
    public GameObject drawText;

    private void Awake()
    {
        PhotonNetwork.Instantiate("TetrisPlayerPrefab", Vector3.zero, Quaternion.identity);
        pv = GetComponent<PhotonView>();
        blockImageDic.Add('I', nextBlockImage[0]);
        blockImageDic.Add('O', nextBlockImage[1]);
        blockImageDic.Add('Z', nextBlockImage[2]);
        blockImageDic.Add('S', nextBlockImage[3]);
        blockImageDic.Add('J', nextBlockImage[4]);
        blockImageDic.Add('L', nextBlockImage[5]);
        blockImageDic.Add('T', nextBlockImage[6]);

        if (PhotonNetwork.IsMasterClient)
            StartCoroutine(CheckAllPlayerLoaded());
    }

    private void Update()
    {
        opponentBlockChecks[0].arr[0] = 1;
        if (!b_start || b_end)
        {
            return;
        }
        totalTime += Time.deltaTime;
        timer += Time.deltaTime * timerFactor;
        totalTimerText.text = (Math.Truncate(totalTime*100)/100).ToString() + "s";
        if (timer > 1f)
        {
            timer = 0f;
            DownBlock();
        }
        
    }

    IEnumerator CheckAllPlayerLoaded()
    {
        while (true)
        {
            yield return null;
            if(playerCount == PhotonNetwork.CurrentRoom.PlayerCount)
            {
                Debug.Log("모두 준비됨!");
                pv.RPC("StartAllPlayerRPC", RpcTarget.All);
                yield break;
            }
        }
    }

    /* I, O, (Z,S), (J,L), T */
    private char SelectRandomBlock()
    {
        char result = '-';
        float r = Random.Range(0f, 1f);
        if (r < 0.2f)
        {
            result = 'I';
        }
        else if (r < 0.4f)
        {
            result = 'O';
        }
        else if (r < 0.5f)
        {
            result = 'Z';
        }
        else if (r < 0.6f)
        {
            result = 'S';
        }
        else if (r < 0.7f)
        {
            result = 'J';
        }
        else if (r < 0.8f)
        {
            result = 'L';
        }
        else
        {
            result = 'T';
        }
        return result;
    }

    // 다음 블럭을 보여줌
    private void SetNextBlock(char block)
    {
        blockImageDic[nextType].SetActive(false);
        nextType = block;
        blockImageDic[nextType].SetActive(true);
    }
    
    // TODO: 수정 필요!
    private void GenerateBlock(char block)
    {
        GenerateGarbageLine();
        InnerGenerateBlock(block, 0);
    }

    private void InnerGenerateBlock(char block, int depth)
    {
        if(depth == 2)
        {
            Debug.Log("InnerGenerateBlock " + depth + " 죽었어!");
            Die();
        }

        foreach (var pos_xy in blockInitPositions[block])
        {
            if (blockChecks[pos_xy.y + depth].arr[pos_xy.x] != 0)
            {
                InnerGenerateBlock(block, depth + 1);
                return;
            }
        }

        currentType = block;
        currentRotation = 0;
        int i = 0;
        int x, y, deltaX, deltaY;
        switch (block)
        {
            case 'I':
                deltaX = 3;
                deltaY = 16;
                break;
            case 'O':
                deltaX = 4;
                deltaY = 17;
                break;
            default:
                deltaX = 3;
                deltaY = 17;
                break;
        }

        foreach (var pos_xy in blockInitPositions[block])
        {
            x = pos_xy.x;
            y = pos_xy.y + depth;
            currentPostitions[i++].Set(x, y, x - deltaX, y - deltaY);
            blockImages[y].arr[x].sprite = blockSprite;
            blockImages[y].arr[x].color = blockColors[block];
        }

        ShowHelpingBlock();
    }

    // _x, _y 좌표에 블럭 생성(이동) 가능한지 여부
    private bool CheckBlock(int _x, int _y)
    {
        if(_x < 0 || _x >= SIZE_X || _y < 0 || _y >= SIZE_Y || blockChecks[_y].arr[_x] != 0)
        {
            return false;
        }
        return true;
    }

    // SIZE_Y - FREE_SPACE_SIZE_Y 위에 블럭이 있으면 죽음!
    // blockChecks[y].arr[x] == 1 이면 죽음!
    private bool CheckDeath()
    {
        for(int i = SIZE_Y - FREE_SPACE_SIZE_Y; i < SIZE_Y; i++)
        {
            for(int j = 0; j < SIZE_X; j++)
            {
                if(blockChecks[i].arr[j] != 0)
                {
                    Debug.Log("CheckDeath : 죽었어!");
                    Die();
                    return true;
                }
            }
        }
        return false;
    }

    // 시각 보조 블럭(예측블럭)
    private void ShowHelpingBlock()
    {
        for(int i = 0; i < 4; i++)
        {
            int helpX = helpingBlockPostitions[i].x;
            int helpY = helpingBlockPostitions[i].y;
            if(blockChecks[helpY].arr[helpX] == 0)
            {
                int j = 0;
                for (; j < 4; j++)
                {
                    if (currentPostitions[j].x == helpX && currentPostitions[j].y == helpY)
                        break;
                }
                // 현재 블럭과 전 예측블럭이 겹치지 않음 => 빈블럭으로 바꿔주기
                if (j == 4)
                {
                    blockImages[helpY].arr[helpX].sprite = blankSprite;
                    blockImages[helpY].arr[helpX].color = blankColor;
                }
            }

            helpingBlockPostitions[i].x = currentPostitions[i].x;
            helpingBlockPostitions[i].y = currentPostitions[i].y;
        }

        while (true)
        {
            foreach (var pos in helpingBlockPostitions)
            {
                int nextPosX = pos.x;
                int nextPosY = pos.y - 1;

                if (!CheckBlock(nextPosX, nextPosY))
                {
                    foreach (var helpPos in helpingBlockPostitions)
                    {
                        int helpX = helpPos.x;
                        int helpY = helpPos.y;
                        if (blockChecks[helpY].arr[helpX] == 0)
                        {
                            int j = 0;
                            for (; j < 4; j++)
                            {
                                if (currentPostitions[j].x == helpX && currentPostitions[j].y == helpY)
                                    break;
                            }
                            // 현재 블럭과 지금 예측블럭이 겹치지 않음 => 빈블럭으로 바꿔주기
                            if (j == 4)
                            {
                                blockImages[helpY].arr[helpX].sprite = blockSprite;
                                blockImages[helpY].arr[helpX].color = helpColor;
                            }
                        }
                    }
                    return;
                }
            }
            foreach (var pos in helpingBlockPostitions)
            {
                pos.y--;
            }
        }
    }

    private void BlockToBlank()
    {
        foreach (var pos in currentPostitions)
        {
            blockImages[pos.y].arr[pos.x].sprite = blankSprite;
            blockImages[pos.y].arr[pos.x].color = blankColor;
        }
    }

    private void BlankToBlock()
    {
        foreach (var pos in currentPostitions)
        {
            blockImages[pos.y].arr[pos.x].sprite = blockSprite;
            blockImages[pos.y].arr[pos.x].color = blockColors[currentType];
        }
    }

    private void BlockToFix()
    {
        foreach (var pos in currentPostitions)
        {
            blockChecks[pos.y].arr[pos.x] = 1;
            pv.RPC("FixBlockRPC", RpcTarget.Others, pos.x, pos.y, (byte)currentType);
        }
    }

    private void DeleteLine()
    {
        for(int i = SIZE_Y - 1; i >= 0; i--)
        {
            int j = 0;
            for (; j < SIZE_X; j++)
            {
                if (blockChecks[i].arr[j] != 1)
                    break;
            }
            if(j == SIZE_X)
            {
                // i번째 줄 삭제!
                deletedLineCountText.text = "삭제한 라인수 : " + (++deletedLineCount).ToString();
                if (deletedLineCount % NEED_TO_GARBAGE == 0)
                    pv.RPC("SendGarbageLine", RpcTarget.Others);
                LineToBlank(i);
                pv.RPC("DeleteLineRPC", RpcTarget.Others, i);
            }
        }
    }

    private void LineToBlank(int idx)
    {
        for (int i = 0; i < SIZE_X; i++)
        {
            blockImages[idx].arr[i].sprite = blankSprite;
            blockImages[idx].arr[i].color = blankColor;
            blockChecks[idx].arr[i] = 0;
        }
        idx++;
        for (; idx < SIZE_Y; idx++)
        {
            for (int i = 0; i < SIZE_X; i++)
            {
                if(blockChecks[idx].arr[i] == 1)
                {
                    blockImages[idx - 1].arr[i].sprite = blockSprite;
                    blockImages[idx - 1].arr[i].color = blockImages[idx].arr[i].color;
                    blockChecks[idx - 1].arr[i] = 1;

                    blockImages[idx].arr[i].sprite = blankSprite;
                    blockImages[idx].arr[i].color = blankColor;
                    blockChecks[idx].arr[i] = 0;
                }
            }
        }
    }

    // 하나씩 떨어뜨림, 바닥에 걸리면 false 리턴함
    private bool DownBlock()
    {
        foreach (var pos in currentPostitions)
        {
            int nextPosX = pos.x;
            int nextPosY = pos.y - 1;

            if (!CheckBlock(nextPosX, nextPosY))
            {
                BlockToFix();
                DeleteLine();
                if (CheckDeath())
                    return false;
                GenerateBlock(nextType);
                SetNextBlock(SelectRandomBlock());
                return false;
            }
        }

        BlockToBlank();

        foreach (var pos in currentPostitions)
        {
            pos.y--;
        }

        BlankToBlock();

        return true;
    }

    // 시계 방향 회전
    public void RotateClockwise()
    {
        InnerRotateClockwise(0);
    }

    private void InnerRotateClockwise(int depth)
    {
        if (currentType == 'O' || !b_start || b_end)
            return;
        int deltaX = currentPostitions[0].x - currentPostitions[0].gridX;
        int deltaY = currentPostitions[0].y - currentPostitions[0].gridY;
        int NxN = currentType == 'I' ? 3 : 2;

        _Position depthOffset = new _Position();
        foreach (var pos in currentPostitions)
        {
            if(currentType == 'I')
            {
                depthOffset.x = clockwiseOffsets_I[currentRotation, depth].x;
                depthOffset.y = clockwiseOffsets_I[currentRotation, depth].y;
            }
            else
            {
                depthOffset.x = clockwiseOffsets[currentRotation, depth].x;
                depthOffset.y = clockwiseOffsets[currentRotation, depth].y;
            }
            int nextPosX = pos.gridY + deltaX + depthOffset.x;
            int nextPosY = NxN - pos.gridX + deltaY + depthOffset.y;


            if (!CheckBlock(nextPosX, nextPosY))
            {
                if (depth < 4)
                    InnerRotateClockwise(depth + 1);
                return;
            }
        }

        BlockToBlank();

        foreach (var pos in currentPostitions)
        {
            if (currentType == 'I')
            {
                depthOffset.x = clockwiseOffsets_I[currentRotation, depth].x;
                depthOffset.y = clockwiseOffsets_I[currentRotation, depth].y;
            }
            else
            {
                depthOffset.x = clockwiseOffsets[currentRotation, depth].x;
                depthOffset.y = clockwiseOffsets[currentRotation, depth].y;
            }
            int tmp = pos.gridX;
            pos.gridX = pos.gridY;
            pos.gridY = NxN - tmp;

            pos.x = pos.gridX + deltaX + depthOffset.x;
            pos.y = pos.gridY + deltaY + depthOffset.y;
        }
        BlankToBlock();

        currentRotation = (++currentRotation) % 4;

        ShowHelpingBlock();
    }

    // 반시계 방향 회전
    public void RotateCounterclockwise()
    {
        InnerRotateCounterclockwise(0);
    }

    private void InnerRotateCounterclockwise(int depth)
    {
        if (currentType == 'O' || !b_start || b_end)
            return;
        int deltaX = currentPostitions[0].x - currentPostitions[0].gridX;
        int deltaY = currentPostitions[0].y - currentPostitions[0].gridY;
        int NxN = currentType == 'I' ? 3 : 2;

        _Position depthOffset = new _Position();
        foreach (var pos in currentPostitions)
        {
            if (currentType == 'I')
            {
                depthOffset.x = counterClockwiseOffsets_I[currentRotation, depth].x;
                depthOffset.y = counterClockwiseOffsets_I[currentRotation, depth].y;
            }
            else
            {
                depthOffset.x = counterClockwiseOffsets[currentRotation, depth].x;
                depthOffset.y = counterClockwiseOffsets[currentRotation, depth].y;
            }
            int nextPosX = NxN - pos.gridY + deltaX + depthOffset.x;
            int nextPosY = pos.gridX + deltaY + depthOffset.y;

            if (!CheckBlock(nextPosX, nextPosY))
            {
                if (depth < 4)
                    InnerRotateCounterclockwise(depth + 1);
                return;
            }
        }

        BlockToBlank();

        foreach (var pos in currentPostitions)
        {

            if (currentType == 'I')
            {
                depthOffset.x = counterClockwiseOffsets_I[currentRotation, depth].x;
                depthOffset.y = counterClockwiseOffsets_I[currentRotation, depth].y;
            }
            else
            {
                depthOffset.x = counterClockwiseOffsets[currentRotation, depth].x;
                depthOffset.y = counterClockwiseOffsets[currentRotation, depth].y;
            }

            int tmp = pos.gridX;
            pos.gridX = NxN - pos.gridY;
            pos.gridY = tmp;

            pos.x = pos.gridX + deltaX + depthOffset.x;
            pos.y = pos.gridY + deltaY + depthOffset.y;
        }

        BlankToBlock();

        if (currentRotation == 0)
            currentRotation = 3;
        else
            currentRotation--;

        ShowHelpingBlock();
    }

    // 오른쪽으로 이동
    public void MoveRight()
    {
        if (!b_start || b_end)
            return;
        foreach (var pos in currentPostitions)
        {
            int nextPosX = pos.x + 1;
            int nextPosY = pos.y;

            if (!CheckBlock(nextPosX, nextPosY))
            {
                return;
            }
        }

        BlockToBlank();

        foreach (var pos in currentPostitions)
        {
            pos.x++;
        }

        BlankToBlock();

        ShowHelpingBlock();
    }

    // 왼쪽으로 이동
    public void MoveLeft()
    {
        if (!b_start || b_end)
            return;
        foreach (var pos in currentPostitions)
        {
            int nextPosX = pos.x - 1;
            int nextPosY = pos.y;

            if (!CheckBlock(nextPosX, nextPosY))
            {
                return;
            }
        }

        BlockToBlank();

        foreach (var pos in currentPostitions)
        {
            pos.x--;
        }

        BlankToBlock();

        ShowHelpingBlock();
    }

    // 한번에 끝까지 떨어뜨리기
    public void HardDrop()
    {
        if (!b_start || b_end)
            return;
        while (true)
        {
            if (!DownBlock())
                break;
        }
        timer = 0f;
    }

    // 빠르게 떨어뜨리기 시작(롱클릭 시작)
    public void SoftDropStart()
    {
        if (!b_start || b_end)
            return;
        timerFactor = 15f;
    }

    // 빠르게 떨어뜨리기 종료(롱클릭 종료)
    public void SoftDropEnd()
    {
        if (!b_start || b_end)
            return;
        timerFactor = 1f;
    }

    public void GoToMenu()
    {
        PhotonNetwork.LeaveRoom();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
    }

    /*
     * 네트워크 관련 함수
     */

    [PunRPC]
    public void StartAllPlayerRPC()
    {
        b_start = true;
        GenerateBlock(SelectRandomBlock());
        SetNextBlock(SelectRandomBlock());
    }

    [PunRPC]
    public void SendGarbageLine()
    {
        garbageLineCountText.text = "<color=yellow>" + (++garbageLineCount).ToString() + "</color>줄 공격받음!";
    }

    private void GenerateGarbageLine()
    {
        if (garbageLineCount == 0)
            return;
        pv.RPC("GenGarbageRPC", RpcTarget.Others, garbageLineCount);
        int y;
        for(y = SIZE_Y - 1; y >= garbageLineCount; y--)
        {
            for(int x = 0; x < SIZE_X; x++)
            {
                blockImages[y].arr[x].sprite = blockImages[y - garbageLineCount].arr[x].sprite;
                blockImages[y].arr[x].color = blockImages[y - garbageLineCount].arr[x].color;
                blockChecks[y].arr[x] = blockChecks[y - garbageLineCount].arr[x];
            }
        }
        for(; y >= 0; y--)
        {
            for (int x = 0; x < SIZE_X; x++)
            {
                blockImages[y].arr[x].sprite = blockSprite;
                blockImages[y].arr[x].color = garbageColor;
                blockChecks[y].arr[x] = 2;
            }
        }
        garbageLineCount = 0;
        garbageLineCountText.text = "<color=yellow>" + garbageLineCount.ToString() + "</color>줄 공격받음!";
        CheckDeath();
    }

    [PunRPC]
    public void FixBlockRPC(int _x, int _y, byte _type)
    {
        opponentBlockChecks[_y].arr[_x] = 1;
        opponentBlockImages[_y].arr[_x].sprite = blockSprite;
        opponentBlockImages[_y].arr[_x].color = blockColors[Convert.ToChar(_type)];
    }

    [PunRPC]
    public void GenGarbageRPC(int garbageCount)
    {
        int y;
        for (y = SIZE_Y - 1; y >= garbageCount; y--)
        {
            for (int x = 0; x < SIZE_X; x++)
            {
                opponentBlockImages[y].arr[x].sprite = opponentBlockImages[y - garbageCount].arr[x].sprite;
                opponentBlockImages[y].arr[x].color = opponentBlockImages[y - garbageCount].arr[x].color;
                opponentBlockChecks[y].arr[x] = opponentBlockChecks[y - garbageCount].arr[x];
            }
        }
        for (; y >= 0; y--)
        {
            for (int x = 0; x < SIZE_X; x++)
            {
                opponentBlockImages[y].arr[x].sprite = blockSprite;
                opponentBlockImages[y].arr[x].color = garbageColor;
                opponentBlockChecks[y].arr[x] = 2;
            }
        }
    }

    [PunRPC]
    public void DeleteLineRPC(int idx)
    {
        for (int i = 0; i < SIZE_X; i++)
        {
            opponentBlockImages[idx].arr[i].sprite = blankSprite;
            opponentBlockImages[idx].arr[i].color = blankColor;
            opponentBlockChecks[idx].arr[i] = 0;
        }
        idx++;
        for (; idx < SIZE_Y; idx++)
        {
            for (int i = 0; i < SIZE_X; i++)
            {
                if (opponentBlockChecks[idx].arr[i] == 1)
                {
                    opponentBlockImages[idx - 1].arr[i].sprite = blockSprite;
                    opponentBlockImages[idx - 1].arr[i].color = opponentBlockImages[idx].arr[i].color;
                    opponentBlockChecks[idx - 1].arr[i] = 1;

                    opponentBlockImages[idx].arr[i].sprite = blankSprite;
                    opponentBlockImages[idx].arr[i].color = blankColor;
                    opponentBlockChecks[idx].arr[i] = 0;
                }
            }
        }
    }

    public void Die()
    {
        Debug.Log("Die");
        b_end = true;
        b_win = false;
        pv.RPC("SendTotalTime1", RpcTarget.Others, totalTime);
    }

    [PunRPC]
    public void SendTotalTime1(float _time)
    {
        Debug.Log("SendTotalTime1");
        b_end = true;
        opponentTotalTime = _time;
        bool needToCheckTimer;
        if (b_win)
            needToCheckTimer = false;
        else
            needToCheckTimer = true;

        pv.RPC("SendTotalTime2", RpcTarget.Others, totalTime, needToCheckTimer);
        ShowResult(needToCheckTimer);
    }

    [PunRPC]
    public void SendTotalTime2(float _time, bool needToCheckTimer)
    {
        Debug.Log("SendTotalTime2");
        opponentTotalTime = _time;
        b_end = true;
        ShowResult(needToCheckTimer);
    }

    private void ShowResult(bool needToCheckTimer)
    {
        resultPanel.SetActive(true);
        if (needToCheckTimer)
        {
            Debug.Log("needToCheckTimer : TURE");
            resultTotalTimerText.text = "<color=white>나의 생존시간 : " + totalTime.ToString() + "</color>\n<color=black>상대 생존시간 : " + opponentTotalTime.ToString() + " </color>";
            if (totalTime > opponentTotalTime)
            {
                winText.SetActive(true);
            }
            else if (totalTime < opponentTotalTime)
            {
                loseText.SetActive(true);
            }
            else
            {
                drawText.SetActive(true);
            }
        }
        else
        {
            Debug.Log("needToCheckTimer : FALSE");
            if (b_win)
                winText.SetActive(true);
            else
                loseText.SetActive(true);
        }
    }


}
