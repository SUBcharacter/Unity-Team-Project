using System.Linq;
using UnityEngine;

public class MelodyTrigger : MonoBehaviour, IResetable
{
    [SerializeField] private MelodyComparer melodyComparer;
    [SerializeField] private MelodyUI melodyUI;

    [SerializeField] BooTrigger booTrigger;

    [SerializeField] private bool isTriggered = false;

    public void Init()
    {
        isTriggered = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTriggered && other.CompareTag("Player"))
        {
            isTriggered = true;

            booTrigger.ActivateShy();

            // ���� �ʱ�ȭ
            melodyComparer.ResetMelody();

            // UI�� ���� �����ֱ�
            melodyUI.StartMelody(melodyComparer.correctMelodys.ToList());
        }
    }
}
