using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    [SerializeField] MemoryPatternPuzzle memoryPatternPuzzle;

    private bool isTriggered = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Ʈ���ſ� �� ����: " + other.name);
        if (!isTriggered && other.CompareTag("Player"))
        {
            Debug.Log("[PuzzleTrigger] �÷��̾� ������! ���� ����");

            isTriggered = true;

            memoryPatternPuzzle.StartPuzzle(); // ���⼭ ����!

            gameObject.SetActive(false); // 1ȸ�� Ʈ����
        }
    }
}
