using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SymbolComparer : MonoBehaviour, IResetable
{
    [Header("���� �⺻ ����")]
    [SerializeField] private int puzzleLength = 4;
    public SymbolData[] correctSymbol;
    public SymbolData[] inputSymbol;
    private int inputIndex = 0;

    [Header("���� ���� ������Ʈ")]
    [SerializeField] private ColorPlatform[] platforms; // ���ǵ� �ν����Ϳ� ����
    [SerializeField] private GameObject door;           // ���� Ŭ���� �� ���� ��
    Animator animator;

    [SerializeField] private Sprite[] symbolSprites; // ��������Ʈ �迭 �߰�

    private PatternUIManager patternUIManager;

    private float resetTime = 1f;       // Ʋ���� �� 1-2�� ī��Ʈ

    public void Init()
    {
        ResetPuzzle();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        patternUIManager = GetComponent<PatternUIManager>();
        GenerateCorrectPattern();
    }

    public void AddInput(SymbolData data)
    {
        if (inputIndex < inputSymbol.Length)
        {
            // ���İ� 1�� ����
            Color fixedColor = data.color;
            fixedColor.a = 1f;

            inputSymbol[inputIndex] = new SymbolData(data.symbol, fixedColor, data.sprite);
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
            animator.SetTrigger("IsOpen");

        }
        else
        {
            Debug.Log("Ʋ�� ���� ����");
            
            StartCoroutine(ColorResetCoroutine());

        }
    }

    public void ResetPuzzle()
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

    IEnumerator ColorResetCoroutine()
    {
        foreach (var plat in platforms)
        {
            Debug.Log($"{plat.gameObject.name} -> Red");
            plat.ResetColor(Color.red);
        }
        yield return new WaitForSeconds(resetTime);

        foreach (var plat in platforms)
        {
            plat.ResetPlatform(); // ���� ���� ����
        }

        GenerateCorrectPattern();

        if(patternUIManager != null)
        {
            patternUIManager.StartPuzzle(correctSymbol.ToList());
            Debug.Log("[SymbolComparer] ���� ���µ� �� UI �����");
        }
    }

 


}
