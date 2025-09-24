using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MemoryPatternPuzzle : MonoBehaviour
{
    [Header("��� ������ ��ȣ��")]
    public List<Symbol> allSymbols = new List<Symbol>();

    [Header("��ϵ� Ÿ��")]
    public List<MemoryTile> memoryTiles = new List<MemoryTile>();
    [SerializeField] PatternUIManager patternUIManager;

    [Header("���� ����")]
    public List<SymbolData> correctOrder = new List<SymbolData>();

    [SerializeField] private int puzzleLength = 4;

    [SerializeField] private List<Sprite> symbolSprites;


    int currentIndex = 0;       // Ƚ��
    bool isInputEnabled;

    public GameObject ExitDoor;

    public void StartPuzzle()
    {
        
        if (patternUIManager != null && correctOrder != null && memoryTiles.Count > 0)
        {
            GenerateNewPattern();
            Debug.Log("[UI Pattern ����]: " + string.Join(", ", correctOrder.Select(x => x.symbol)));
            for (int i = 0; i < memoryTiles.Count && i < correctOrder.Count; i++)
            {
                memoryTiles[i].symbolData = correctOrder[i];
            }

            isInputEnabled = true;

        }
    }

    public void GenerateNewPattern()
    {
        correctOrder.Clear();

        List<Symbol> symbols = new List<Symbol> { Symbol.Yellow, Symbol.Red, Symbol.Green, Symbol.Blue };
        List<Color> colors = new List<Color> { Color.yellow, Color.red, Color.green, Color.blue };
        List<Sprite> sprites = new List<Sprite>(symbolSprites);

        symbols = symbols.OrderBy(x => Random.value).ToList();
        colors = colors.OrderBy(x => Random.value).ToList();
        sprites = sprites.OrderBy(x => Random.value).ToList();

        int maxLength = Mathf.Min(puzzleLength, symbols.Count, colors.Count, sprites.Count);
        for (int i = 0; i < maxLength; i++)
        {
            var c = colors[i];
            var fixedColor = new Color(c.r, c.g, c.b, 1f); // ���İ� ���� ����
            correctOrder.Add(new SymbolData(symbols[i], colors[i], sprites[i]));
        }
        Debug.Log("[���� ���� correctOrder]: " + string.Join(", ", correctOrder.Select(x => x.symbol)));
        for (int i = 0; i < memoryTiles.Count && i < correctOrder.Count; i++)
        {
            memoryTiles[i].symbolData = correctOrder[i];

            // ��� ����/��������Ʈ ����
            memoryTiles[i].spriteRenderer.color = correctOrder[i].color;

            Debug.Log("[MemoryTiles] ������ ����: " + string.Join(", ", memoryTiles.Select(t => t.symbolData.symbol.ToString())));

        }
        //Debug.Log("[PatternUIManager] ���� ����: " + string.Join(", ", correctOrder.Select(p => p.symbol.ToString())));


        //Debug.Log("���� ����: " + string.Join(", ", correctOrder.Select(s => s.symbol.ToString())));

        // UI�� �Ѱ��ִ� ���� ȣ��
        patternUIManager.StartPuzzle(correctOrder); // StartPuzzle�� ���� �� �ֵ��� ���� �ʿ�

        

    }

    public void CheckTile(Symbol symbol)
    {
        if (!isInputEnabled || currentIndex >= correctOrder.Count)
            return;

        Symbol expected = correctOrder[currentIndex].symbol;

        Debug.Log($"�Էµ�: {symbol}, ��밪: {expected}, �ε���: {currentIndex}, �Է� ����? {isInputEnabled}");

        if (symbol == expected)
        {
            Debug.Log($"����. ({symbol})");
            currentIndex++;

            if (currentIndex == correctOrder.Count)
            {
                PuzzleClear();
            }
        }
        else
        {
            Debug.Log($"����. �Է�: {symbol}, ����: {expected}");
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
        GenerateNewPattern();       // Ʋ���� �� �� ����
    }

    public void CallbackTile(MemoryTile tile)
    {
        if (!memoryTiles.Contains(tile))
        {
            memoryTiles.Add(tile);
        }
    }
    public IEnumerator PuzzleCoroutine(float delay)
    {
        // �÷��̾� �Է� ���
        yield return new WaitForSeconds(delay);
        isInputEnabled = true;
    }
}

