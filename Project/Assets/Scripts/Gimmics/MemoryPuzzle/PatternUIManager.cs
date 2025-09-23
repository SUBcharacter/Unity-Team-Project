using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.BoolParameter;

public enum Symbol
{
    Star, Heart, Circle, Spade
}


public class PatternUIManager : MonoBehaviour
{
    public Image[] symbolImages;
    public List<Sprite> symbolSprites;

    [SerializeField] private float ShowSymbolTime = 0.5f;

    private Dictionary<Symbol, Sprite> symbolDict;

    private void Awake()
    {
        // symbolSprites 순서: [0] Star, [1] Heart, [2] Circle, [3] Spade
        symbolDict = new Dictionary<Symbol, Sprite>
    {
        { Symbol.Star, symbolSprites[0] },
        { Symbol.Heart, symbolSprites[1] },
        { Symbol.Circle, symbolSprites[2] },
        { Symbol.Spade, symbolSprites[3] }
    };
    }


    private void Start()
    {
        Debug.Log($"[DEBUG] symbolSprites.Count = {symbolSprites.Count}");

        List<Symbol> allSymbols = new List<Symbol> { Symbol.Star, Symbol.Heart, Symbol.Circle, Symbol.Spade };
        List<Symbol> randomized = new List<Symbol>();

        while (allSymbols.Count > 0)
        {
            int randIndex = Random.Range(0, allSymbols.Count);
            randomized.Add(allSymbols[randIndex]);
            allSymbols.RemoveAt(randIndex);
        }

        // 랜덤 패턴 넘김
        StartCoroutine(ShowPatternUI(randomized));

    }

    public IEnumerator ShowPatternUI(List<Symbol> symbols)
    {
        // 시작 시 모든 이미지 숨기기
        for (int i = 0; i < symbolImages.Length; i++)
        {
            symbolImages[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < symbols.Count; i++)
        {
            Sprite symbolSprite = GetsymbolSprite(symbols[i]);

            if (symbolSprite != null && i < symbolImages.Length)
            {
                symbolImages[i].sprite = symbolSprite;
                symbolImages[i].gameObject.SetActive(true);

                // 다음 이미지 보여주기 전까지 대기
                yield return new WaitForSeconds(ShowSymbolTime);

                // 다음 이미지 보여줄 준비 (지금 이미지는 숨김)
                symbolImages[i].gameObject.SetActive(false);
            }
        }
    }


    private Sprite GetsymbolSprite(Symbol symbols)
    {
        if (symbolSprites == null || symbolSprites.Count < 4)
        {
            Debug.LogWarning("symbolSprites에 스프라이트가 충분히 설정되지 않았습니다.");
            return null;
        }

        if (symbolDict.TryGetValue(symbols, out Sprite result))
            return result;

        Debug.LogWarning($"심볼 {symbols} 에 해당하는 스프라이트 없음!");
        return null;
    }

}
