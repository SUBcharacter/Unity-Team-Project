using UnityEngine;
using UnityEngine.UI;

public class PuzzleButton : MonoBehaviour
{
    private Image puzzleImage;
    private Color originColor;
    public Color highlightColor = Color.yellow;

    public SymbolData symbolData { get; private set; } // ���߿� � ��ư���� �񱳿�

    private void Awake()
    {
        puzzleImage = GetComponent<Image>();
    }

    // �ʱ�ȭ �Լ�: SymbolData �޾Ƽ� ����
    public void Initialize(SymbolData data)
    {
        symbolData = data;

        if (puzzleImage != null)
        {
            puzzleImage.sprite = data.sprite;
            puzzleImage.color = data.color;
            originColor = data.color;
        }
    }

    public void Highlight()
    {
        if (puzzleImage != null)
        {
            puzzleImage.color = highlightColor;
        }
    }

    public void ResetColor()
    {
        if (puzzleImage != null)
        {
            puzzleImage.color = originColor;
        }
    }
}
