using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    [Header("�ⱸ �� ����")]
    [SerializeField] private MirrorExitDoor exitDoor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (exitDoor != null && exitDoor.IsOpen)
            {
                Debug.Log("[MirrorExitTrigger] �ⱸ ���� ���� - �̷� ���� �� ������ �̵� �غ�");

                // �̷� ����
                if (exitDoor.mirrorTrigger != null)
                {
                    exitDoor.mirrorTrigger.Init();
                    Debug.Log("[MirrorExitTrigger] �̷��÷��̾� ���� �Ϸ�");
                }

                // ������ �̵��� ���⿡ �־ �ǰ� exitDoor���� �ص� ��
                // SceneManager.LoadScene("BossScene");
            }
            else
            {
                Debug.Log("[MirrorExitTrigger] ���� ���� ��������");
            }
        }
    }
}