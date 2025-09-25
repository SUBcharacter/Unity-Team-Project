using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    [SerializeField] MemoryPatternPuzzle memoryPatternPuzzle;
    [SerializeField] private GameObject puzzleUI;

    private bool isTriggered = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Ʈ���ſ� �� ����: " + other.name);
        if (!isTriggered && other.CompareTag("Player"))
        {
            Debug.Log("[PuzzleTrigger] �÷��̾� ������ ���� ����");
            puzzleUI.SetActive(true);

            memoryPatternPuzzle.StartPuzzle();
            isTriggered = true;

            gameObject.SetActive(false); // 1ȸ�� Ʈ����
        }

     
    }
    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        // ���� ����� ���� UI ���� (�ʿ� ��)
    //        puzzleUI.SetActive(false);
    //    }
    //}
}

