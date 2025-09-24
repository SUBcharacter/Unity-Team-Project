using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MemoryPatternPuzzle : MonoBehaviour
{
    [Header("사용 가능한 기호들")]
    public List<Symbol> allSymbols = new List<Symbol>();

    [Header("등록된 타일")]
    public List<MemoryTile> memoryTiles = new List<MemoryTile>();
    [SerializeField] PatternUIManager patternUIManager;

    [Header("정답 순서")]
    public List<SymbolData> correctOrder = new List<SymbolData>();

    [SerializeField] private int puzzleLength = 4;

    [SerializeField] private List<Sprite> symbolSprites;


    int currentIndex = 0;       // 횟수
    bool isInputEnabled;

    public GameObject ExitDoor;

    public void StartPuzzle()
    {
        
        if (patternUIManager != null && correctOrder != null && memoryTiles.Count > 0)
        {
            GenerateNewPattern();
            Debug.Log("[UI Pattern 순서]: " + string.Join(", ", correctOrder.Select(x => x.symbol)));
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
            var fixedColor = new Color(c.r, c.g, c.b, 1f); // 알파값 강제 설정
            correctOrder.Add(new SymbolData(symbols[i], colors[i], sprites[i]));
        }
        Debug.Log("[정답 순서 correctOrder]: " + string.Join(", ", correctOrder.Select(x => x.symbol)));
        for (int i = 0; i < memoryTiles.Count && i < correctOrder.Count; i++)
        {
            memoryTiles[i].symbolData = correctOrder[i];

            // 즉시 색깔/스프라이트 갱신
            memoryTiles[i].spriteRenderer.color = correctOrder[i].color;

            Debug.Log("[MemoryTiles] 배정된 순서: " + string.Join(", ", memoryTiles.Select(t => t.symbolData.symbol.ToString())));

        }
        //Debug.Log("[PatternUIManager] 받은 순서: " + string.Join(", ", correctOrder.Select(p => p.symbol.ToString())));


        //Debug.Log("정답 순서: " + string.Join(", ", correctOrder.Select(s => s.symbol.ToString())));

        // UI에 넘겨주는 패턴 호출
        patternUIManager.StartPuzzle(correctOrder); // StartPuzzle을 받을 수 있도록 수정 필요

        

    }

    public void CheckTile(Symbol symbol)
    {
        if (!isInputEnabled || currentIndex >= correctOrder.Count)
            return;

        Symbol expected = correctOrder[currentIndex].symbol;

        Debug.Log($"입력됨: {symbol}, 기대값: {expected}, 인덱스: {currentIndex}, 입력 가능? {isInputEnabled}");

        if (symbol == expected)
        {
            Debug.Log($"정답. ({symbol})");
            currentIndex++;

            if (currentIndex == correctOrder.Count)
            {
                PuzzleClear();
            }
        }
        else
        {
            Debug.Log($"오답. 입력: {symbol}, 정답: {expected}");
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
        GenerateNewPattern();       // 틀렸을 때 새 정답
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
        // 플레이어 입력 잠금
        yield return new WaitForSeconds(delay);
        isInputEnabled = true;
    }
}

