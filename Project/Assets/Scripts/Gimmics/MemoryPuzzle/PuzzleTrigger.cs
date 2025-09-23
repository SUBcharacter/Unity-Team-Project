using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    [SerializeField] PatternUIManager patternUIManager;
    public List<Symbol> symbols = new List<Symbol>();

    private bool isTriggered = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTriggered && collision.CompareTag("Player"))
        {
            isTriggered = true;

            //List<Symbol> allSymbols = new List<Symbol> { Symbol.Star, Symbol.Heart, Symbol.Circle, Symbol.Spade };
            //List<Symbol> randomized = new List<Symbol>();

            //while (allSymbols.Count > 0)
            //{
            //    int randIndex = Random.Range(0, allSymbols.Count);
            //    randomized.Add(allSymbols[randIndex]);
            //    allSymbols.RemoveAt(randIndex);
            //}

            //// ·£´ý ÆÐÅÏ ³Ñ±è
            //StartCoroutine(patternUIManager.ShowPatternUI(randomized));

            
        }
    }
}
