using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color originColor;
    public Color highlightColor = Color.yellow;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originColor = sr.color;
    }

    public void Highlight()
    {
        sr.color = highlightColor;
        // ���峪 ����Ʈ�� �߰� ����
    }

    public void ResetColor()
    {
        sr.color = originColor;
    }
}
