using UnityEngine;

public class MemoryTile : MonoBehaviour
{
    [Header("발판 기호 데이터")]
    public SymbolData symbolData;


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
        Debug.Log($"[{gameObject.name}] Start에서 sprite: {spriteRenderer.sprite?.name}, active? {gameObject.activeSelf}, position: {transform.position}");
        if (memoryPatternPuzzle != null)
        {
            memoryPatternPuzzle.CallbackTile(this);
        }
        else
        {
            Debug.LogError($"{gameObject.name}에서 PuzzleManager 연결 안 됨");
        }

        // sprite 초기화 (외부에서 연결 안 돼있으면)
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        //if (symbolData != null)
        //{
        //    spriteRenderer.sprite = symbolData.sprite;
        //    spriteRenderer.color = symbolData.color;
        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log($"[{gameObject.name}] 발판밟음 {symbolData.symbol}");

            isActivated = true;
            HighlightTile();

            memoryPatternPuzzle.CheckTile(symbolData.symbol); // CheckTile은 symbol만 받음
        }

    }

    public void ResetTile()
    {
        if (symbolData != null)
            spriteRenderer.color = symbolData.color;
    }

    public void HighlightTile()
    {
        spriteRenderer.color = Color.yellow;
    }
}
