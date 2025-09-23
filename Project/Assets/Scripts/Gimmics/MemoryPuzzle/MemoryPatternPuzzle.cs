using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPatternPuzzle : MonoBehaviour
{
    [Header("정답 순서")]
    public List<Symbol> correctOrder = new List<Symbol>();

    [Header("등록된 타일")]
    public List<MemoryTile> memoryTiles = new List<MemoryTile>();
    PatternUIManager patternUIManager;

    int currentIndex = 0;       // 횟수

    bool isInputEnabled;

    private void Start()
    {
        if (patternUIManager != null && correctOrder != null && memoryTiles.Count > 0)
        {
            StartCoroutine(PuzzleCoroutine());
            patternUIManager.StartCoroutine(patternUIManager.ShowPatternUI(correctOrder));
        }
    }

    public void CheckTile(Symbol symbol)
    {
        if (currentIndex >= correctOrder.Count)
        {
            return;
        }

        if (symbol == correctOrder[currentIndex])
        {
            Debug.Log($"정답 : {correctOrder}");
            currentIndex++;

            if (currentIndex == correctOrder.Count)
            {
                Debug.Log("퍼즐 클리어");
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

    }

    public void ResetPuzzle()
    {
        currentIndex = 0;
        Debug.Log("퍼즐 리셋");

        foreach (var tile in memoryTiles)
        {
            tile.ResetTile();
        }


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
        isInputEnabled = false;

        yield return new WaitForSeconds(1f); // 시작 대기

        foreach (var symbol in correctOrder)
        {
            var tile = memoryTiles.Find(t => t.symbolType == symbol);

            if (tile != null)
            {
                tile.HighlightTile(); // 타일 하이라이트
                yield return new WaitForSeconds(0.5f); // 깜빡임 시간
                tile.ResetTile();
                yield return new WaitForSeconds(0.2f); // 다음 타일 전 잠깐 대기
            }
        }

        currentIndex = 0;
        isInputEnabled = true;
    }
}

