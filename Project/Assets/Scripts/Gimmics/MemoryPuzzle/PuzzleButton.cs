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
        // 사운드나 이펙트도 추가 가능
    }

    public void ResetColor()
    {
        sr.color = originColor;
    }
}
