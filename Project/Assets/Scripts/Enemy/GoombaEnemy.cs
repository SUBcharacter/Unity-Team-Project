using NUnit.Framework.Constraints;
using UnityEngine;

public class GoombaEnemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D goombaRb;
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private float moveDistance = 2.0f;   // ������ �Ÿ�
   
    private bool IsMoveRight = true;
    private Vector3 startPos;

    private void Awake()
    {
        goombaRb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    // ���˾Ƽ� Ư�� ���������� �������� ��
    private void FixedUpdate()
    {   
        float moveDir = IsMoveRight ? 1f : -1f;     // �����̴� ������ ������ �������� 1, �ٸ��� ���������� -1
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
            Destroy(gameObject);        // �׽�Ʈ�� 
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
/// ���� Ư¡
/// Ư����ġ������ ������
/// ���˾Ƽ� ������ (���� AI)
/// �¿�θ� ������
/// �׷���? ��ĭ ������ ����
/// 
/// </summary>