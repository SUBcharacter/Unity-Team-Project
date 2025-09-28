using UnityEngine;

public class SpriteDoor : MonoBehaviour
{
    [SerializeField] private Sprite closedSprite;
    [SerializeField] private Sprite openSprite;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Close(); // 시작은 닫힌 상태
    }

    public void Open()
    {
        spriteRenderer.sprite = openSprite;
        // TODO: 애니메이션, 효과음, 충돌 끄기 등 추가 가능
        Debug.Log("[Door] 문 열림");
    }

    public void Close()
    {
        spriteRenderer.sprite = closedSprite;
        Debug.Log("[Door] 문 닫힘");
    }
}
