using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.BoolParameter;


public class PatternUIManager : MonoBehaviour
{
    public Image[] symbolImages;

    [SerializeField] private float ShowSymbolTime = 10f; // 화면에 보여주는 시간

    public void StartPuzzle(List<SymbolData> pattern)
    {
        StartCoroutine(ShowPatternUI(pattern));
    }

    public IEnumerator ShowPatternUI(List<SymbolData> pattern)
    {
        // 시작 시 모든 이미지 숨기기
        for (int i = 0; i < symbolImages.Length; i++)
        {
            symbolImages[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < pattern.Count && i < symbolImages.Length; i++)
        {
            var data = pattern[i];

            if (data.sprite != null)
            {
                symbolImages[i].sprite = data.sprite;
                symbolImages[i].color = data.color;
                symbolImages[i].gameObject.SetActive(true);

                yield return new WaitForSeconds(ShowSymbolTime);

                symbolImages[i].gameObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning($"[PatternUIManager] SymbolData {i}에 스프라이트가 없음!");
            }
        }
    }

}
