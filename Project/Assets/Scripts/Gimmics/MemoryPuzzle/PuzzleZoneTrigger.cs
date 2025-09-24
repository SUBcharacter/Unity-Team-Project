using System.Collections.Generic;
using UnityEngine;

public class PuzzleZoneTrigger : MonoBehaviour
{
    [SerializeField] PatternUIManager patternUIManager;
    public MemoryPatternPuzzle puzzle;
    public GameObject wallBlocker;
    public List<Symbol> symbols = new List<Symbol>();

    private bool isTriggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!isTriggered && other.CompareTag("Player"))
        {
            Debug.Log("퍼즐 구역 진입");
            isTriggered = true;

            wallBlocker.SetActive(true);
            
            patternUIManager.StartPuzzle();     // 랜덤으로 나오는 이미지 함수
            puzzle.correctOrder = patternUIManager.currentPattern;
            puzzle.StartPuzzle();               // 순서대로 밟아야하는 버튼 함수
        }
    }

    public void SetupSymbols()
    {
        // 예: PatternUIManager에 symbol 리스트 전달
        if (patternUIManager != null)
        {
            patternUIManager.ShowPatternUI(symbols);
        }

        Debug.Log("심볼 UI 세팅 완료");
    }
}
