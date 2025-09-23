using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.BoolParameter;

public enum Symbol
{
    Star, Heart, Circle, Spade
}


public class PatternUIManager : MonoBehaviour
{
    public Image[] symbolimages;
    public List<Sprite> symbolSprites;

   [SerializeField] private float ShowSymbolTime = 0.5f;



    public IEnumerator ShowPatternUI(List<Symbol> symbols)
    {
        for (int i = 0; i < symbols.Count; i++)
        {
            Sprite symbolSprite = GetsymbolSprite(symbols[i]);

            if (symbolSprite != null && i < symbolimages.Length)
            {
                symbolimages[i].sprite = symbolSprite;
                symbolimages[i].color = new Color(1, 1, 1, 1); // º¸¿©ÁÜ

                yield return new WaitForSeconds(ShowSymbolTime);

                symbolimages[i].color = new Color(1, 1, 1, 0); // ¼û±è
                yield return new WaitForSeconds(0.2f);
            }
        }
    }


    private Sprite GetsymbolSprite(Symbol symbols)
    {
        switch (symbols)
        {
            case Symbol.Star: return symbolSprites[0];
            case Symbol.Heart: return symbolSprites[1];
            case Symbol.Circle: return symbolSprites[2];
            case Symbol.Spade: return symbolSprites[3];

            default: return null;
        }
    }

}
