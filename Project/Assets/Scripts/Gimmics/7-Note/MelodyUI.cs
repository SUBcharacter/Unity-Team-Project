using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class MelodyUI : MonoBehaviour
{
    public Image[] melodySymbols;
    bool reset = false;

    [SerializeField] private float ShowSymbolTime = 3f; // ȭ�鿡 �����ִ� �ð�

    public void StartMelody(List<MelodyData> pattern)
    {
        Debug.Log("[MelodyUI] StartMelody ȣ���, md.Count=" + pattern.Count);
        Init();
        StartCoroutine(ShowMelodyUI(pattern));
    }

    public void Init()
    {
        reset = true;
        for (int x = 0; x < melodySymbols.Length; x++)
        {
            melodySymbols[x].gameObject.SetActive(false);
        }
    }


    public IEnumerator ShowMelodyUI(List<MelodyData> md)
    {
        Debug.Log("[MelodyUI] ShowMelodyUI ���۵�!");

        // 1. ��ü ���ֱ�
        for (int i = 0; i < melodySymbols.Length; i++)
            melodySymbols[i].gameObject.SetActive(false);

        // 2. 0~6 �� �������� 3�� �ε��� �̱�
        List<int> selectedIndices = Enumerable.Range(0, melodySymbols.Length)
                                              .OrderBy(_ => Random.value)
                                              .Take(md.Count)
                                              .ToList();

        for (int i = 0; i < md.Count; i++)
        {
            var data = md[i];
            int slotIndex = selectedIndices[i];

            if (data.sprite != null)
            {
                melodySymbols[slotIndex].sprite = data.sprite;
                melodySymbols[slotIndex].color = data.color;
                melodySymbols[slotIndex].gameObject.SetActive(true);
                melodySymbols[slotIndex].transform.SetAsFirstSibling();

                yield return new WaitForSeconds(ShowSymbolTime);

                melodySymbols[slotIndex].gameObject.SetActive(false);
            }
        }

        // ������ Ȥ�� �𸣴� �� ��������
        for (int i = 0; i < melodySymbols.Length; i++)
            melodySymbols[i].gameObject.SetActive(false);
    }
}
