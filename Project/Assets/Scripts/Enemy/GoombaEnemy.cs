using NUnit.Framework.Constraints;
using UnityEngine;

public class GoombaEnemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D goombaRb;
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private float moveDistance = 2.0f;   // 움직일 거리
   
    private bool IsMoveRight = true;
    private Vector3 startPos;

    private void Awake()
    {
        goombaRb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    // 지알아서 특정 범위에서만 움직여야 함
    private void FixedUpdate()
    {   
        float moveDir = IsMoveRight ? 1f : -1f;     // 움직이는 방향이 같으면 왼쪽으로 1, 다르면 오른쪽으로 -1
        goombaRb.linearVelocity = new Vector2(moveDir * moveSpeed, goombaRb.linearVelocity.y);

        float distanceMoved = transform.position.x - startPos.x;

        if (Mathf.Abs(distanceMoved) >= moveDistance)
        {
            IsMoveRight = !IsMoveRight;
            startPos = transform.position;
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Died");
            Destroy(gameObject);        // 테스트용 
        }
    }

    public void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}

/// <summary>
/// 굼바 특징
/// 특정위치에서만 움직임
/// 지알아서 움직임 (ㄹㅇ AI)
/// 좌우로만 움직임
/// 그러면? 몇칸 범위를 하지
/// 
/// </summary>