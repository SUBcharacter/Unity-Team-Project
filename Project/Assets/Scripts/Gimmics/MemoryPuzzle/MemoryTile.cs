using UnityEngine;

public class MemoryTile : MonoBehaviour
{
    [Header("발판 이름")]
    public Symbol symbolType;

    [Header("MemoryPuzzle 연결")]
    [SerializeField] MemoryPatternPuzzle memoryPatternPuzzle;

    public SpriteRenderer spriteRenderer;
    public Color symbolColor;

    private bool isPuzzleActive;    
    private bool isActivated;

    public void OnEnableTile()
    {
        isActivated = true;
    }

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
        else
        {
            Debug.LogError($"{gameObject.name}에서 PuzzleManager 연결 안 됨");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log($"[{gameObject.name}] 플레이어가 밟았음! {symbolType}");

            isActivated = true;
            HighlightTile();
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
