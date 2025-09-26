//using UnityEngine;

//public class MemoryTile : MonoBehaviour
//{
//    [Header("���� ��ȣ ������")]
//    public SymbolData symbolData;


//    [Header("MemoryPuzzle ����")]
//    [SerializeField] MemoryPatternPuzzle memoryPatternPuzzle;

//    public SpriteRenderer spriteRenderer;
//    public Color symbolColor;

//    private bool isCleared;    
//    private bool isActivated;

//    public void OnEnableTile()
//    {
//        isActivated = true;
//    }

//    private void Awake()
//    {
//        spriteRenderer = GetComponent<SpriteRenderer>();
//        symbolColor = spriteRenderer.color;
//    }

//    private void Start()
//    {
//        if (memoryPatternPuzzle != null)
//        {
//            memoryPatternPuzzle.CallbackTile(this);
//        }
//        else
//        {
//            Debug.LogError($"{gameObject.name}���� PuzzleManager ���� �� ��");
//        }

//        // sprite �ʱ�ȭ (�ܺο��� ���� �� �Ǿ��ִٸ�)
//        if (spriteRenderer == null)
//        { 
//            spriteRenderer = GetComponent<SpriteRenderer>();
//        }

//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player") && !isCleared)
//        {
//            isActivated = true;
//            HighlightTile();

//            memoryPatternPuzzle.CheckTile(symbolData.symbol); // CheckTile�� symbol�� ����
//        }

//    }

//    //private void OnTriggerEnter2D(Collider2D collision)
//    //{
//    //    if (collision.CompareTag("Player") && !isCleared)
//    //    {
//    //        isActivated = true;
//    //        HighlightTile();

//    //        memoryPatternPuzzle.CheckTile(symbolData.symbol); // CheckTile�� symbol�� ����
//    //    }
//    //}

//    public void ResetTile()
//    {
//        isCleared = false;      // ������ �� �ʱ�ȭ
//        if (symbolData != null)
//            spriteRenderer.color = symbolData.color;
//    }

//    public void HighlightTile()
//    {
//        spriteRenderer.color = Color.yellow;
//    }
//}
