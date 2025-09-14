using UnityEngine;


public class ShyEnemy : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float stopDistance = 0.1f;

    Rigidbody2D playerRb;

    private Vector2 lastPlayerPos;        //  플레이어가 안움직일 때

    private float playerLookDir;      // 플레이어가 바라보는 방향
    private float toEnemyDir;      // 플레이어와 적의 방향
    private bool isSameDir;       // 같은 방향을 보고 있는지

   private bool isActived = true;      // 플레이어가 가까이 왔는지 (적 활성화 여부 체크)
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

        // 플레이어가 움직이면 따라오기

        /// <summary>
        /// 유니티 6에서부터 Velocity가 아닌 linearVelocity로 사용한다
        /// </summary>

        if (isSameDir)      // magnitude : 벡터의 크기(길이) 
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        // 멈추면 가만히

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
