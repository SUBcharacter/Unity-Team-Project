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

            // ���� �ʱ�ȭ
            symbolComparer.ResetPuzzle();

            // UI�� ���� �����ֱ�
            patternUIManager.StartPuzzle(symbolComparer.correctSymbol.ToList());
        }
    }
}
