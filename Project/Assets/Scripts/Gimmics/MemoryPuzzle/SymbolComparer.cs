using UnityEngine;
using UnityEngine.UI;

public class SymbolComparer : MonoBehaviour
{
    [Header("퍼즐 기본 설정")]
    [SerializeField] private int puzzleLength = 4;
    public SymbolData[] correctSymbol;
    public SymbolData[] inputSymbol;
    private int inputIndex = 0;

    [Header("퍼즐 관련 오브젝트")]
    [SerializeField] private ColorPlatform[] platforms; // 발판들 인스펙터에 연결
    [SerializeField] private GameObject door;           // 퍼즐 클리어 시 열릴 문

    [SerializeField] private Sprite[] symbolSprites; // 스프라이트 배열 추가
    private void Start()
    {
        GenerateCorrectPattern();
    }

    public void AddInput(SymbolData data)
    {
        if (inputIndex < inputSymbol.Length)
        {
            inputSymbol[inputIndex] = data;
            inputIndex++;

            if (inputIndex >= correctSymbol.Length)
            {
                CheckAnswer();
            }
        }
    }

    private void CheckAnswer()
    {
        bool isCorrect = true;

        for (int i = 0; i < correctSymbol.Length; i++)
        {
            if (inputSymbol[i] == null || inputSymbol[i].symbol != correctSymbol[i].symbol)
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            Debug.Log("퍼즐 클리어!");
            if (door != null) door.SetActive(false);
        }
        else
        {
            Debug.Log("틀림 퍼즐 리셋");
            ResetPuzzle();
        }
    }

    private void ResetPuzzle()
    {
        inputIndex = 0;
        for (int i = 0; i < inputSymbol.Length; i++)
        {
            inputSymbol[i] = null;
        }

        foreach (var p in platforms)
        {
            p.ResetPlatform(); // 발판 색 복원
        }

        GenerateCorrectPattern();
    }

    //private void GenerateCorrectPattern()
    //{
    //    Symbol[] symbols = new Symbol[] { Symbol.Magenta, Symbol.Red, Symbol.Green, Symbol.Blue };
    //    System.Array.Sort(symbols, (a, b) => Random.value.CompareTo(Random.value));

    //    correctSymbol = new SymbolData[puzzleLength];
    //    inputSymbol = new SymbolData[puzzleLength];
    //    inputIndex = 0;

    //    for (int i = 0; i < puzzleLength; i++)
    //    {
    //        correctSymbol[i] = new SymbolData(symbols[i], GetColor(symbols[i]));
    //    }

    //    Debug.Log("[정답 패턴]: " + string.Join(", ",
    //        System.Array.ConvertAll(correctSymbol, s => s.symbol.ToString())));
    //}

    private void GenerateCorrectPattern()
    {
        Symbol[] symbols = new Symbol[] { Symbol.Magenta, Symbol.Red, Symbol.Green, Symbol.Blue };
        System.Array.Sort(symbols, (a, b) => Random.value.CompareTo(Random.value));

        correctSymbol = new SymbolData[puzzleLength];
        inputSymbol = new SymbolData[puzzleLength];
        inputIndex = 0;

        for (int i = 0; i < puzzleLength; i++)
        {
            Color color = GetColor(symbols[i]);
            Sprite sprite = GetSprite(symbols[i]); // 스프라이트 가져오기
            correctSymbol[i] = new SymbolData(symbols[i], color, sprite);
        }

        Debug.Log("[정답 패턴]: " + string.Join(", ",
            System.Array.ConvertAll(correctSymbol, s => s.symbol.ToString())));
    }

    private Color GetColor(Symbol symbol)
    {
        switch (symbol)
        {
            case Symbol.Magenta: return Color.magenta;
            case Symbol.Red: return Color.red;
            case Symbol.Green: return Color.green;
            case Symbol.Blue: return Color.blue;
            default: return Color.white;
        }
    }

    private Sprite GetSprite(Symbol symbol)
    {
        switch (symbol)
        {
            case Symbol.Magenta: return symbolSprites.Length > 0 ? symbolSprites[0] : null;
            case Symbol.Red: return symbolSprites.Length > 1 ? symbolSprites[1] : null;
            case Symbol.Green: return symbolSprites.Length > 2 ? symbolSprites[2] : null;
            case Symbol.Blue: return symbolSprites.Length > 3 ? symbolSprites[3] : null;
            default: return null;
        }
    }

}
