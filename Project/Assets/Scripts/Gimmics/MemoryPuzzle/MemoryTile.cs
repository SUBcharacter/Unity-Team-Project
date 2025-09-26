//using UnityEngine;

//public class MemoryTile : MonoBehaviour
//{
//    [Header("발판 기호 데이터")]
//    public SymbolData symbolData;


//    [Header("MemoryPuzzle 연결")]
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
//            Debug.LogError($"{gameObject.name}에서 PuzzleManager 연결 안 됨");
//        }

//        // sprite 초기화 (외부에서 연결 안 되어있다면)
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

//            memoryPatternPuzzle.CheckTile(symbolData.symbol); // CheckTile은 symbol만 받음
//        }

//    }

//    //private void OnTriggerEnter2D(Collider2D collision)
//    //{
//    //    if (collision.CompareTag("Player") && !isCleared)
//    //    {
//    //        isActivated = true;
//    //        HighlightTile();

//    //        memoryPatternPuzzle.CheckTile(symbolData.symbol); // CheckTile은 symbol만 받음
//    //    }
//    //}

//    public void ResetTile()
//    {
//        isCleared = false;      // 리셋할 때 초기화
//        if (symbolData != null)
//            spriteRenderer.color = symbolData.color;
//    }

//    public void HighlightTile()
//    {
//        spriteRenderer.color = Color.yellow;
//    }
//}
