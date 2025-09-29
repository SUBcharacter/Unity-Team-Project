using UnityEngine;

public class MirrorTrigger : MonoBehaviour
{
    // Ư�� ������ ���� �� �̷� �÷��̾ Ȱ��ȭ �Ǿ��� �״ϱ� ���� Ȱ��ȭ �Ǹ� �ȵ� 
    [SerializeField] private GameObject mirrorPrefab;      // private GameObjectmirrorPrefab���� �ٲٱ� 
    [SerializeField] private float mirrorCenterX;

   public GameObject mirrorInstance;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || mirrorInstance == null)
        {
            mirrorInstance = Instantiate(mirrorPrefab);
            MirrorPlayer mp = mirrorInstance.GetComponent<MirrorPlayer>();
            mp.mirrorCenterX = mirrorCenterX;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Playter") || mirrorInstance != null)
        {
            // 1. ��Ȱ��ȭ ��Ų��.
            mirrorPrefab.SetActive(false);      // �ϴ����� ��
            // 2. Destroy�� �Ѵ�.
        }
    }
}
