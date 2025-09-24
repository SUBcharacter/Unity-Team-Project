using UnityEngine;
using UnityEngine.UI;

public class PuzzleButton : MonoBehaviour
{
    private Image puzzleImage;
    private Color originColor;
    public Color highlightColor = Color.yellow;

    public SymbolData symbolData { get; private set; } // 나중에 어떤 버튼인지 비교용

    private void Awake()
    {
        puzzleImage = GetComponent<Image>();
    }

    // 초기화 함수: SymbolData 받아서 세팅
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
