using UnityEngine;

public class MemoryTile : MonoBehaviour
{
    [Header("���� ��ȣ ������")]
    public SymbolData symbolData;


    [Header("MemoryPuzzle ����")]
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
        Debug.Log($"[{gameObject.name}] Start���� sprite: {spriteRenderer.sprite?.name}, active? {gameObject.activeSelf}, position: {transform.position}");
        if (memoryPatternPuzzle != null)
        {
            memoryPatternPuzzle.CallbackTile(this);
        }
        else
        {
            Debug.LogError($"{gameObject.name}���� PuzzleManager ���� �� ��");
        }

        // sprite �ʱ�ȭ (�ܺο��� ���� �� ��������)
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
            //Debug.Log($"[{gameObject.name}] ���ǹ��� {symbolData.symbol}");

            isActivated = true;
            HighlightTile();

            memoryPatternPuzzle.CheckTile(symbolData.symbol); // CheckTile�� symbol�� ����
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
