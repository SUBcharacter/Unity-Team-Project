using UnityEngine;

public class MemoryTile : MonoBehaviour
{
    [Header("발판 이름")]
    public Symbol symbolType;

    [Header("MemoryPuzzle 연결")]
    [SerializeField] MemoryPatternPuzzle memoryPatternPuzzle;

    public SpriteRenderer spriteRenderer;
    public Color symbolColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        symbolColor = spriteRenderer.color;
    }

    private void Start()
    {
        if(memoryPatternPuzzle != null)
        {
            memoryPatternPuzzle.CallbackTile(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            memoryPatternPuzzle.CheckTile(symbolType);
           
        }

    }

    public void ResetTile()
    {
        spriteRenderer.color = symbolColor;
    }

    public void HighlightTile()
    {
        spriteRenderer.color = Color.yellow;
    }
}
