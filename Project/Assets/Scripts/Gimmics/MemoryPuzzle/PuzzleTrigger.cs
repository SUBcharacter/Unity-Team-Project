using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    [SerializeField] PatternUIManager patternUIManager;
    public List<Symbol> symbols = new List<Symbol>();

    private bool isTriggered = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Ʈ���ſ� �� ����: " + other.name);
        if (!isTriggered && other.CompareTag("Player"))
        {
            Debug.Log("�÷��̾� ������!");
            isTriggered = true;

            //patternUIManager.ShowPatternUI(symbols);
            patternUIManager.StartPuzzle();
            gameObject.SetActive(false);
            
        }
    }
}
