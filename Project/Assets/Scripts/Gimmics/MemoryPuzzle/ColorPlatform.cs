using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorPlatform : MonoBehaviour
{
    public SymbolData symbolData;  // �� ������ ���� �ɺ�
    [SerializeField] private SymbolComparer comparer; // �ν����� ����

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // ���� �ʱ� ��/��������Ʈ �ݿ�
        if (symbolData != null)
        {
            spriteRenderer.color = symbolData.color;
            if (symbolData.sprite != null)
                spriteRenderer.sprite = symbolData.sprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            comparer.AddInput(symbolData);

            // ������ ���̶���Ʈ ȿ��
            spriteRenderer.color = Color.yellow;
        }
    }

    public void ResetPlatform()
    {
        if (symbolData != null)
        {
            spriteRenderer.color = symbolData.color;
        }
    }
}
