using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.BoolParameter;

public enum Symbol
{
    Yellow, Red, Green, Blue
}


public class PatternUIManager : MonoBehaviour
{
    public Image[] symbolImages;
    public List<Sprite> symbolSprites;

    [SerializeField] private float ShowSymbolTime = 5f;

    private Dictionary<Symbol, Sprite> symbolDict;

    public List<Color> symbolColors;

    public List<Symbol> currentPattern { get; private set; }

    private void Awake()
    {
        // symbolSprites ����: [0] Yellow, [1] Red, [2] Green, [3] Blue
        symbolDict = new Dictionary<Symbol, Sprite>
    {
        { Symbol.Yellow, symbolSprites[0] },
        { Symbol.Red, symbolSprites[1] },
        { Symbol.Green, symbolSprites[2] },
        { Symbol.Blue, symbolSprites[3] }
    };
    }

    public void StartPuzzle()
    {
        Debug.Log($"[DEBUG] symbolSprites.Count = {symbolSprites.Count}");

        List<Symbol> allSymbols = new List<Symbol> { Symbol.Yellow, Symbol.Red, Symbol.Green, Symbol.Blue };
        List<Symbol> randomized = new List<Symbol>();

        List<Color> allColors = new List<Color> { Color.yellow, Color.red, Color.green, Color.blue };
        List<Color> mixColor = new List<Color>();
    

        while (allSymbols.Count > 0)
        {
            int randIndex = Random.Range(0, allSymbols.Count);
            int randColorIndex = Random.Range(0, allColors.Count);

            Debug.Log($"���� �ɺ� : {allSymbols[randIndex]}, �ε��� : {randIndex}");
            randomized.Add(allSymbols[randIndex]);
            mixColor.Add(allColors[randColorIndex]);
            allSymbols.RemoveAt(randIndex);
            allColors.RemoveAt(randColorIndex);
        }

        currentPattern = randomized;
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
                //symbolImages[i].color = 
               
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
