using UnityEngine;


public class ShyEnemy : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float stopDistance = 0.1f;

    Rigidbody2D playerRb;

    private Vector2 lastPlayerPos;        //  �÷��̾ �ȿ����� ��

    private float playerLookDir;      // �÷��̾ �ٶ󺸴� ����
    private float toEnemyDir;      // �÷��̾�� ���� ����
    private bool isSameDir;       // ���� ������ ���� �ִ���

   private bool isActived = true;      // �÷��̾ ������ �Դ��� (�� Ȱ��ȭ ���� üũ)
    private void Awake()
    {
        playerRb = player.GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (!isActived) { return; }

        playerLookDir = Mathf.Sign(player.localScale.x);
        toEnemyDir = Mathf.Sign(transform.position.x - player.position.x);
        isSameDir = playerLookDir != toEnemyDir;

        // �÷��̾ �����̸� �������

        /// <summary>
        /// ����Ƽ 6�������� Velocity�� �ƴ� linearVelocity�� ����Ѵ�
        /// </summary>

        if (isSameDir)      // magnitude : ������ ũ��(����) 
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        // ���߸� ������

    }
    public void Activate()
    {
        isActived = true;
    }

    public void Deactivate()
    {
        isActived = false;
    }
}
