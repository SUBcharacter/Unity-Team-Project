using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPatternPuzzle : MonoBehaviour
{
    [Header("���� ����")]
    public List<Symbol> correctOrder = new List<Symbol>();

    [Header("��ϵ� Ÿ��")]
    public List<MemoryTile> memoryTiles = new List<MemoryTile>();
    PatternUIManager patternUIManager;

    int currentIndex = 0;       // Ƚ��

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
        if (!memoryTiles.Contains(tile))
        {
            memoryTiles.Add(tile);
        }
    }
    public IEnumerator PuzzleCoroutine()
    {
        // �÷��̾� �Է� ���
        isInputEnabled = false;

        yield return new WaitForSeconds(1f); // ���� ���

        foreach (var symbol in correctOrder)
        {
            var tile = memoryTiles.Find(t => t.symbolType == symbol);

            if (tile != null)
            {
                tile.HighlightTile(); // Ÿ�� ���̶���Ʈ
                yield return new WaitForSeconds(0.5f); // ������ �ð�
                tile.ResetTile();
                yield return new WaitForSeconds(0.2f); // ���� Ÿ�� �� ��� ���
            }
        }

        currentIndex = 0;
        isInputEnabled = true;
    }
}

