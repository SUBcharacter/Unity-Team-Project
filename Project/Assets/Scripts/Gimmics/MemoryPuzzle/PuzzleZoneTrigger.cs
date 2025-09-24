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
            Debug.Log("���� ���� ����");
            isTriggered = true;

            wallBlocker.SetActive(true);
            
            patternUIManager.StartPuzzle();     // �������� ������ �̹��� �Լ�
            puzzle.correctOrder = patternUIManager.currentPattern;
            puzzle.StartPuzzle();               // ������� ��ƾ��ϴ� ��ư �Լ�
        }
    }

    public void SetupSymbols()
    {
        // ��: PatternUIManager�� symbol ����Ʈ ����
        if (patternUIManager != null)
        {
            patternUIManager.ShowPatternUI(symbols);
        }

        Debug.Log("�ɺ� UI ���� �Ϸ�");
    }
}
