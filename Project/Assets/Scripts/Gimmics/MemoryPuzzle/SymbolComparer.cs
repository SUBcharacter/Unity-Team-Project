using UnityEngine;
using UnityEngine.UI;

public class SymbolComparer : MonoBehaviour
{
    [Header("���� �⺻ ����")]
    [SerializeField] private int puzzleLength = 4;
    public SymbolData[] correctSymbol;
    public SymbolData[] inputSymbol;
    private int inputIndex = 0;

    [Header("���� ���� ������Ʈ")]
    [SerializeField] private ColorPlatform[] platforms; // ���ǵ� �ν����Ϳ� ����
    [SerializeField] private GameObject door;           // ���� Ŭ���� �� ���� ��

    [SerializeField] private Sprite[] symbolSprites; // ��������Ʈ �迭 �߰�
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
            Debug.Log("���� Ŭ����!");
            if (door != null) door.SetActive(false);
        }
        else
        {
            Debug.Log("Ʋ�� ���� ����");
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
            p.ResetPlatform(); // ���� �� ����
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

    //    Debug.Log("[���� ����]: " + string.Join(", ",
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
            Sprite sprite = GetSprite(symbols[i]); // ��������Ʈ ��������
            correctSymbol[i] = new SymbolData(symbols[i], color, sprite);
        }

        Debug.Log("[���� ����]: " + string.Join(", ",
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
