using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPatternPuzzle : MonoBehaviour
{
    [Header("��� ������ ��ȣ��")]
    public List<Symbol> allSymbols = new List<Symbol>();

    [Header("���� ����")]
    public List<Symbol> correctOrder = new List<Symbol>();
    [SerializeField] private int puzzleLength = 4; // ������ �ɺ� ��

    [Header("��ϵ� Ÿ��")]
    public List<MemoryTile> memoryTiles = new List<MemoryTile>();
    [SerializeField] PatternUIManager patternUIManager;

    int currentIndex = 0;       // Ƚ��
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

        // Fisher-Yates ����
        for (int i = 0; i < tempList.Count; i++)
        {
            int rand = Random.Range(i, tempList.Count);
            Symbol temp = tempList[i];
            tempList[i] = tempList[rand];
            tempList[rand] = temp;
        }

        // ���� ����Ʈ�� �տ������� puzzleLength�� �߰�
        for (int i = 0; i < puzzleLength; i++)
        {
            correctOrder.Add(tempList[i]);
        }

        Debug.Log("���� ����: " + string.Join(", ", correctOrder));

    }

    public void CheckTile(Symbol symbol)
    {
        Debug.Log($"�Էµ�: {symbol}, ��밪: {correctOrder[currentIndex]}, �ε���: {currentIndex}, �Է� ����? {isInputEnabled}");

        if (!isInputEnabled) { return; }
        if (currentIndex >= correctOrder.Count) { return; }

        if (symbol == correctOrder[currentIndex])
        {
            Debug.Log($"���� : {correctOrder}");
            currentIndex++;

            if (currentIndex == correctOrder.Count)
            {
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
        ExitDoor.SetActive(false); // �� ���� (�� ������Ʈ ��Ȱ��ȭ or �ִϸ��̼� ���)
    }

    public void ResetPuzzle()
    {
        currentIndex = 0;
        Debug.Log("Ʋ����");

        foreach (var tile in memoryTiles)
        {
            tile.ResetTile();
        }

        StartCoroutine(PuzzleCoroutine());  // �ٽ� ���� ���� �����ֱ�
        GenerateNewPattern();       // Ʋ���� �� �� ����
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
        isInputEnabled = true;
        yield break;
        //isInputEnabled = false;

        //yield return new WaitForSeconds(1f); // ���� ���

        //foreach (var symbol in correctOrder)
        //{
        //    var tile = memoryTiles.Find(t => t.symbolType == symbol);

        //    if (tile != null)
        //    {
        //        tile.HighlightTile(); // Ÿ�� ���̶���Ʈ
        //        yield return new WaitForSeconds(0.5f); // ������ �ð�
        //        tile.ResetTile();
        //        yield return new WaitForSeconds(0.2f); // ���� Ÿ�� �� ��� ���
        //    }
        //}

        //currentIndex = 0;
        //isInputEnabled = true;
    }
}

