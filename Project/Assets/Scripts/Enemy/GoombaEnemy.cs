using NUnit.Framework.Constraints;
using UnityEngine;

public class GoombaEnemy : MonoBehaviour, IResetable
{
    Rigidbody2D rigid;
    SpriteRenderer renderer;

    [SerializeField] private float moveSpeed;
    [SerializeField] int health;
    float moveDistance = 2.0f;   // ������ �Ÿ�
   
    private bool IsMoveRight = true;
    private Vector3 startPos;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        startPos = transform.position;
        health = 2;
    }
    // ���˾Ƽ� Ư�� ���������� �������� ��

    void Update()
    {
        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {   
        float moveDir = IsMoveRight ? 1f : -1f;     // �����̴� ������ ������ �������� 1, �ٸ��� ���������� -1
        rigid.linearVelocity = new Vector2(moveDir * moveSpeed, rigid.linearVelocity.y);

        float distanceMoved = transform.position.x - startPos.x;

        if (Mathf.Abs(distanceMoved) >= moveDistance)
        {
            IsMoveRight = !IsMoveRight;
            startPos = transform.position;
            renderer.flipX = !renderer.flipX;
        }
    }

    public void Init()
    {
        gameObject.SetActive(true);
        transform.position = startPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
            return;

        health -= collision.GetComponent<Bullet>().damage;
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