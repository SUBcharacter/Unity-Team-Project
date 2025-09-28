using UnityEngine;

public class SpriteDoor : MonoBehaviour
{
    [SerializeField] private Sprite closedSprite;
    [SerializeField] private Sprite openSprite;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Close(); // ������ ���� ����
    }

    public void Open()
    {
        spriteRenderer.sprite = openSprite;
        // TODO: �ִϸ��̼�, ȿ����, �浹 ���� �� �߰� ����
        Debug.Log("[Door] �� ����");
    }

    public void Close()
    {
        spriteRenderer.sprite = closedSprite;
        Debug.Log("[Door] �� ����");
    }
}
