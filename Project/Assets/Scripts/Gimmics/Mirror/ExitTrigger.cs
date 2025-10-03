using UnityEngine;
using UnityEngine.SceneManagement;

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

                SceneManager.LoadScene(exitDoor.bossSceneName);
            }
            else
            {
                Debug.Log("[MirrorExitTrigger] ���� ���� ��������");
            }
        }
    }
}