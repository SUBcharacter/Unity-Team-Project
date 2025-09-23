using UnityEngine;
using UnityEngine.UI;

public class PuzzleButton : MonoBehaviour
{
    private Image puzzleImage;
    private Color originColor;
    public Color highlightColor = Color.yellow;

    private void Awake()
    {
        puzzleImage = GetComponent<Image>();
        originColor = puzzleImage.color;
    }

    public void Highlight()
    {
        puzzleImage.color = highlightColor;
        // 사운드나 이펙트도 추가 가능
    }

    public void ResetColor()
    {
        puzzleImage.color = originColor;
    }
}
