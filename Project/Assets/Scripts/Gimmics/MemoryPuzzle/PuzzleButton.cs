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
        // ���峪 ����Ʈ�� �߰� ����
    }

    public void ResetColor()
    {
        puzzleImage.color = originColor;
    }
}
