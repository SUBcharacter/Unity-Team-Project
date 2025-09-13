using UnityEngine;


public class ShyEnemy : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float stopDistance = 0.1f;

    Rigidbody2D playerRb;

    private Vector2 lastPlayerPos;        //  �÷��̾ �ȿ����� ��

    private float playerLookDir ;      // �÷��̾ �ٶ󺸴� ����
    private float toEnemyDir;      // �÷��̾�� ���� ����
    private bool isSameDir;       // ���� ������ ���� �ִ���
    private void Awake()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
       
    }

    private void Update()
    {
        playerLookDir = Mathf.Sign(player.localScale.x);
        toEnemyDir = Mathf.Sign(transform.position.x - player.position.x);
        isSameDir = playerLookDir != toEnemyDir;
        //float PlayerMoveDis = Vector3.Distance(transform.position, player.position);
        //Vector3 targetPos = player.position;
        //if(PlayerMoveDis > stopDistance)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        //}

        //lastPlayerPos = player.position;



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
}
