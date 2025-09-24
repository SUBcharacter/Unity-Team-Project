using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPatternPuzzle : MonoBehaviour
{
    [Header("사용 가능한 기호들")]
    public List<Symbol> allSymbols = new List<Symbol>();

    [Header("정답 순서")]
    public List<Symbol> correctOrder = new List<Symbol>();
    [SerializeField] private int puzzleLength = 4; // 보여줄 심볼 수

    [Header("등록된 타일")]
    public List<MemoryTile> memoryTiles = new List<MemoryTile>();
    [SerializeField] PatternUIManager patternUIManager;

    int currentIndex = 0;       // 횟수
    bool isInputEnabled;

    public GameObject ExitDoor;

    public void StartPuzzle()
    {
        if (patternUIManager != null && correctOrder != null && memoryTiles.Count > 0)
        {
            GenerateNewPattern();
            isInputEnabled = true;
            //StartCoroutine(PuzzleCoroutine());

        }
    }

    private void GenerateNewPattern()
    {
        correctOrder.Clear();

        List<Symbol> tempList = new List<Symbol>(allSymbols);

        // Fisher-Yates 셔플
        for (int i = 0; i < tempList.Count; i++)
        {
            int rand = Random.Range(i, tempList.Count);
            Symbol temp = tempList[i];
            tempList[i] = tempList[rand];
            tempList[rand] = temp;
        }

        // 정답 리스트에 앞에서부터 puzzleLength개 추가
        for (int i = 0; i < puzzleLength; i++)
        {
            correctOrder.Add(tempList[i]);
        }

        Debug.Log("정답 순서: " + string.Join(", ", correctOrder));

    }

    public void CheckTile(Symbol symbol)
    {
        Debug.Log($"입력됨: {symbol}, 기대값: {correctOrder[currentIndex]}, 인덱스: {currentIndex}, 입력 가능? {isInputEnabled}");

        if (!isInputEnabled) { return; }
        if (currentIndex >= correctOrder.Count) { return; }

        if (symbol == correctOrder[currentIndex])
        {
            Debug.Log($"정답 : {correctOrder}");
            currentIndex++;

            if (currentIndex == correctOrder.Count)
            {
                // 퍼즐 클리어 처리
                PuzzleClear();
            }
        }
        else
        {
            Debug.Log($"오답 : {correctOrder}");
            // 오답 처리
            ResetPuzzle();
        }
    }

    public void PuzzleClear()
    {
        Debug.Log("퍼즐 클리어");
        ExitDoor.SetActive(false); // 문 열림 (문 오브젝트 비활성화 or 애니메이션 재생)
    }

    public void ResetPuzzle()
    {
        currentIndex = 0;
        Debug.Log("틀렸음");

        foreach (var tile in memoryTiles)
        {
            tile.ResetTile();
        }

        StartCoroutine(PuzzleCoroutine());  // 다시 퍼즐 랜덤 보여주기
        GenerateNewPattern();       // 틀렸을 때 새 정답
    }

    public void CallbackTile(MemoryTile tile)
    {
        if (!memoryTiles.Contains(tile))
        {
            memoryTiles.Add(tile);
        }
    }
    public IEnumerator PuzzleCoroutine()
    {
        // 플레이어 입력 잠금
        isInputEnabled = true;
        yield break;
        //isInputEnabled = false;

        //yield return new WaitForSeconds(1f); // 시작 대기

        //foreach (var symbol in correctOrder)
        //{
        //    var tile = memoryTiles.Find(t => t.symbolType == symbol);

        //    if (tile != null)
        //    {
        //        tile.HighlightTile(); // 타일 하이라이트
        //        yield return new WaitForSeconds(0.5f); // 깜빡임 시간
        //        tile.ResetTile();
        //        yield return new WaitForSeconds(0.2f); // 다음 타일 전 잠깐 대기
        //    }
        //}

        //currentIndex = 0;
        //isInputEnabled = true;
    }
}

