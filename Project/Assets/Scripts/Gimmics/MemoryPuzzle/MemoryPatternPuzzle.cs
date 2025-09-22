using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPatternPuzzle : MonoBehaviour
{
    [Header("정답 순서")]
    public List<string> correctOrder = new List<string>();

    [Header("등록된 타일")]
    public List<MemoryTile> memoryTiles = new List<MemoryTile>();

    int currentIndex = 0;       // 횟수

    public void CheckTile(string symbol)
    {
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
        if(!memoryTiles.Contains(tile))
        {
            memoryTiles.Add(tile);
        }
    }
}
