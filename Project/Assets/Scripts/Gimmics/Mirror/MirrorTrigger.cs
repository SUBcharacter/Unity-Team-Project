using UnityEngine;

public class MirrorTrigger : MonoBehaviour, IResetable
{
    [Header("�̷� �÷��̾� ������ �� ���ؼ�")]
    [SerializeField] private GameObject mirrorPrefab;
    [SerializeField] private float mirrorCenterX = 0f;

    private GameObject mirrorInstance;
    private bool isTriggered = false;

    public void Init()
    {
        // �̹� ������� �̷� �÷��̾� ����
        if (mirrorInstance != null)
        {
            mirrorInstance.SetActive(false);
            Debug.Log("[MirrorTrigger] �̷� �÷��̾� ���ŵ�!");
        }

        // Ʈ���� �ʱ�ȭ
        isTriggered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTriggered && collision.CompareTag("Player"))
        {
            isTriggered = true;

            // �̷� �÷��̾� ��ġ ���
            Vector3 realPos = collision.transform.position;
            float mirroredX = mirrorCenterX - (realPos.x - mirrorCenterX);
            Vector3 mirrorPos = new Vector3(mirroredX, realPos.y, realPos.z);

            Debug.Log($"[MirrorTrigger] �÷��̾� X: {realPos.x}, �̷� X: {mirroredX}");
            // ��ġ �־ Instantiate
            mirrorInstance = Instantiate(mirrorPrefab, mirrorPos, Quaternion.identity);


            // ������ ����
            MirrorPlayer mp = mirrorInstance.GetComponent<MirrorPlayer>();
            if (mp != null)
            {
                mp.mirrorCenterX = mirrorCenterX;
                mp.realPlayer = collision.transform;
                mp.realSprite = collision.GetComponent<SpriteRenderer>();
                mp.mirrorSprite = mirrorInstance.GetComponent<SpriteRenderer>();
            }


            Debug.Log("[MirrorTrigger] �̷� �÷��̾� ������!");
        }
    }

  
}
