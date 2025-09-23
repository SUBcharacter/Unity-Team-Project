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
        // symbolSprites ����: [0] Star, [1] Heart, [2] Circle, [3] Spade
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

        // ���� ���� �ѱ�
        StartCoroutine(ShowPatternUI(randomized));

    }

    public IEnumerator ShowPatternUI(List<Symbol> symbols)
    {
        // ���� �� ��� �̹��� �����
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

                // ���� �̹��� �����ֱ� ������ ���
                yield return new WaitForSeconds(ShowSymbolTime);

                // ���� �̹��� ������ �غ� (���� �̹����� ����)
                symbolImages[i].gameObject.SetActive(false);
            }
        }
    }


    private Sprite GetsymbolSprite(Symbol symbols)
    {
        if (symbolSprites == null || symbolSprites.Count < 4)
        {
            Debug.LogWarning("symbolSprites�� ��������Ʈ�� ����� �������� �ʾҽ��ϴ�.");
            return null;
        }

        if (symbolDict.TryGetValue(symbols, out Sprite result))
            return result;

        Debug.LogWarning($"�ɺ� {symbols} �� �ش��ϴ� ��������Ʈ ����!");
        return null;
    }

}
