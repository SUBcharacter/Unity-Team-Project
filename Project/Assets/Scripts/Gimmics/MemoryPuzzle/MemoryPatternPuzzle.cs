using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPatternPuzzle : MonoBehaviour
{
    [Header("���� ����")]
    public List<string> correctOrder = new List<string>();

    [Header("��ϵ� Ÿ��")]
    public List<MemoryTile> memoryTiles = new List<MemoryTile>();

    int currentIndex = 0;       // Ƚ��

    public void CheckTile(string symbol)
    {
        if (symbol == correctOrder[currentIndex])
        {
            Debug.Log($"���� : {correctOrder}");
            currentIndex++;

            if (currentIndex == correctOrder.Count)
            {
                Debug.Log("���� Ŭ����");
                // ���� Ŭ���� ó��
                PuzzleClear();
            }
        }
        else
        {
            Debug.Log($"���� : {correctOrder}");
            // ���� ó��
            ResetPuzzle();
        }
    }

    public void PuzzleClear()
    {
        Debug.Log("���� Ŭ����");

    }

    public void ResetPuzzle()
    {
        currentIndex = 0;
        Debug.Log("���� ����");

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
