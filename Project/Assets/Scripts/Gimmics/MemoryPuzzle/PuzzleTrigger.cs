using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    [SerializeField] MemoryPatternPuzzle memoryPatternPuzzle;

    private bool isTriggered = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("트리거에 뭐 들어옴: " + other.name);
        if (!isTriggered && other.CompareTag("Player"))
        {
            Debug.Log("[PuzzleTrigger] 플레이어 감지됨! 퍼즐 시작");

            isTriggered = true;

            memoryPatternPuzzle.StartPuzzle(); // 여기서 시작!

            gameObject.SetActive(false); // 1회용 트리거
        }
    }
}
