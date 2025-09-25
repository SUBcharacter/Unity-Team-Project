using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorPlatform : MonoBehaviour
{
    public SymbolData symbolData;  // 이 발판이 가진 심볼
    [SerializeField] private SymbolComparer comparer; // 인스펙터 연결

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // 발판 초기 색/스프라이트 반영
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

            // 누르면 하이라이트 효과
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
