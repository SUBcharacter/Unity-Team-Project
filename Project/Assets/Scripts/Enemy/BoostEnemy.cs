using NUnit.Framework.Constraints;
using UnityEngine;

public class BoostEnemy : MonoBehaviour
{
    GoombaEnemy goombaEnemy;
    [SerializeField] Rigidbody2D goombaRb;
    [SerializeField] private Transform player;

    [SerializeField] private float boostSpeed = 5.0f;
    [SerializeField] private float boostTriggerDistance = 3.0f;
    [SerializeField] private float boostReleaseDistance = 4.0f;


    private bool isBoosting = false;
    private bool IsMoveRight = true;
    private Vector3 startPos;

    private void Awake()
    {
        goombaEnemy = GetComponent<GoombaEnemy>();
        goombaRb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        //if (isBoosting)
        //{
        //    Debug.Log("급발진 시작");
        //}

        //// 플레이어 거리 체크
        //float playerDistance = Vector2.Distance(player.position, transform.position);
        //isBoosting = playerDistance < boostTriggerDistance;

        //// 속도 조절
        //float baseSpeed = isBoosting ? boostSpeed : moveSpeed;

        //float moveDir = IsMoveRight ? 1f : -1f;     // 움직이는 방향이 같으면 왼쪽으로 1, 다르면 오른쪽으로 -1
        //Vector2 velocity = new Vector2(baseSpeed, 0f) * moveDir;
        //goombaRb.linearVelocity = velocity;

        //float distanceMoved = transform.position.x - startPos.x;

        //if (Mathf.Abs(distanceMoved) >= moveDistance)
        //{
        //    IsMoveRight = !IsMoveRight;
        //    //startPos = transform.position;
        //    Flip();
        //}

        float distanceToPlayer = Vector2.Distance(player.position, transform.position);

        // 조건: 일정 거리 안으로 오면 boost
        if (!isBoosting && distanceToPlayer < boostTriggerDistance)
            isBoosting = true;
        else if (isBoosting && distanceToPlayer > boostReleaseDistance)
            isBoosting = false;

        if (isBoosting)
        {
            float moveDir = (player.position.x > transform.position.x) ? 1f : -1f;
            goombaRb.linearVelocity = new Vector2(moveDir * boostSpeed, goombaRb.linearVelocity.y);

            Debug.Log("돌진 중!");
        }
        else
        {
            // 멈춰있기 (혹은 Patrol 등 추후 확장 가능)
            goombaRb.linearVelocity = new Vector2(0f, goombaRb.linearVelocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    Debug.Log("Player Died");
        //    Destroy(gameObject);        // 테스트용 
        //}
    }

    public void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}
