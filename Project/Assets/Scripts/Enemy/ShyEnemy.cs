using UnityEngine;


public class ShyEnemy : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float stopDistance = 0.1f;

    Rigidbody2D playerRb;

   private bool isActived = true;      // 플레이어가 가까이 왔는지 (적 활성화 여부 체크)
    private void Awake()
    {
        // Player가 인스펙터에 연결 안되어있을 경우 자동 연결
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
                Debug.Log("플레이어 자동 연결 완료: " + player.name);
            }
            else
            {
                Debug.LogWarning("Player 오브젝트를 찾을 수 없습니다. 태그 확인 필요!");
            }
        }

        // Rigidbody 연결
        if (player != null)
        {
            playerRb = player.GetComponent<Rigidbody2D>();
        }

    }

    private void Update()
    {
        Debug.Log("Player 위치: " + player.position + " / Player 이름: " + player.name);

        if (!isActived) { return; }

        float playerLookDir = Mathf.Sign(player.localScale.x);
        float toEnemyDir = Mathf.Sign(transform.position.x - player.position.x);
        bool isPlayerLookingAtEnemy = playerLookDir != toEnemyDir;

        if (isPlayerLookingAtEnemy)      // magnitude : 벡터의 크기(길이) 
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
