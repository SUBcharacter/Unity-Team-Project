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

    [SerializeField] private float ShowSymbolTime = 3f; // ȭ�鿡 �����ִ� �ð�

    public void StartPuzzle(List<SymbolData> pattern)
    {
        Debug.Log("[PatternUIManager] StartPuzzle ȣ���, pattern.Count=" + pattern.Count);
        StartCoroutine(ShowPatternUI(pattern));
    }

    public IEnumerator ShowPatternUI(List<SymbolData> pattern)
    {
        Debug.Log("[PatternUIManager] ShowPatternUI ���۵�!");
        // ���� �� ��� �̹��� �����
        for (int i = 0; i < symbolImages.Length; i++)
        {
            symbolImages[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < pattern.Count && i < symbolImages.Length; i++)
        {
            var data = pattern[i];
         
            if (data.sprite != null)
            {
                var fixedColor = data.color;
                fixedColor.a = 1f;
                symbolImages[i].sprite = data.sprite;
                symbolImages[i].color = fixedColor;
                symbolImages[i].gameObject.SetActive(true);
                symbolImages[i].transform.SetAsFirstSibling();      // ui����� �׽�Ʈ �ڵ�
               

                yield return new WaitForSeconds(ShowSymbolTime);

                symbolImages[i].gameObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning($"[PatternUIManager] SymbolData {i}�� ��������Ʈ�� ����!");
            }
        }
    }

}
