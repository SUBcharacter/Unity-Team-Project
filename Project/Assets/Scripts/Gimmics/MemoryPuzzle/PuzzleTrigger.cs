//using System.Collections.Generic;
//using UnityEngine;

//public class PuzzleTrigger : MonoBehaviour
//{
//    //[SerializeField] MemoryPatternPuzzle memoryPatternPuzzle;
//    //[SerializeField] private GameObject puzzleUI;

//    //private bool isTriggered = false;
//    //private void OnTriggerEnter2D(Collider2D other)
//    //{
//    //    Debug.Log("트리거에 뭐 들어옴: " + other.name);
//    //    if (!isTriggered && other.CompareTag("Player"))
//    //    {
//    //        Debug.Log("[PuzzleTrigger] 플레이어 감지됨 퍼즐 시작");
//    //        puzzleUI.SetActive(true);

//    //        memoryPatternPuzzle.StartPuzzle();
//    //        isTriggered = true;

//    //        gameObject.SetActive(false); // 1회용 트리거
//    //    }


//    //}
//    //private void OnTriggerExit2D(Collider2D other)
//    //{
//    //    if (other.CompareTag("Player"))
//    //    {
//    //        // 구간 벗어나면 퍼즐 UI 끄기 (필요 시)
//    //        puzzleUI.SetActive(false);
//    //    }
//    //}
//}

using System.Linq;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    [SerializeField] private SymbolComparer symbolComparer;
    [SerializeField] private PatternUIManager patternUIManager;

    [SerializeField] private bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTriggered && other.CompareTag("Player"))
        {
            isTriggered = true;

            // 퍼즐 초기화
            symbolComparer.ResetPuzzle();

            // UI에 패턴 보여주기
            patternUIManager.StartPuzzle(symbolComparer.correctSymbol.ToList());
        }
    }
}
