using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ������ ���� �ڵ�� �ϴ� �ּ�ó�� �߽��ϴ�
/// </summary>

public class MirrorExitDoor : MonoBehaviour, IResetable
{
    [Header("�� ���� ��������Ʈ")]
    [SerializeField] private Sprite closedSprite;
    [SerializeField] private Sprite openSprite;

    [Header("������ �� �̸�")]
    [SerializeField] public string bossSceneName = "Boss";

    [Header("�ſ�� ���� ����")]
    public MirrorTrigger mirrorTrigger;

    private SpriteRenderer sr;
    private Collider2D doorCollider;

    private bool isOpen = false;

    public bool IsOpen => isOpen;

    public void Init()
    {
        CloseDoor();
    }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        doorCollider = GetComponent<Collider2D>();

        // ������ �� ������ ���� ����
        sr.sprite = closedSprite;
        if (doorCollider != null) doorCollider.enabled = true;
    }

    public void OpenDoor()
    {
        if (isOpen) return;

        isOpen = true;
        sr.sprite = openSprite;
        if (doorCollider != null) doorCollider.enabled = false;

        Debug.Log("[MirrorExitDoor] �� ����!");
    }

    public void CloseDoor() // �ʿ� ������ �����ص� ��
    {
        isOpen = false;
        sr.sprite = closedSprite;
        if (doorCollider != null) doorCollider.enabled = true;

        Debug.Log("[MirrorExitDoor] �� ����!");
    }
}
