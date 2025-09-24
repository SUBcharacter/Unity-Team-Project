using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    [SerializeField] PatternUIManager patternUIManager;
    public List<Symbol> symbols = new List<Symbol>();

    private bool isTriggered = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Æ®¸®°Å¿¡ ¹¹ µé¾î¿È: " + other.name);
        if (!isTriggered && other.CompareTag("Player"))
        {
            Debug.Log("ÇÃ·¹ÀÌ¾î °¨ÁöµÊ!");
            isTriggered = true;

            //patternUIManager.ShowPatternUI(symbols);
            patternUIManager.StartPuzzle();
            gameObject.SetActive(false);
            
        }
    }
}
