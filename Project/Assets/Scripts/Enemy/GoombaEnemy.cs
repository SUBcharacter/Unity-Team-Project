using NUnit.Framework.Constraints;
using UnityEngine;

public class GoombaEnemy : MonoBehaviour, IResetable
{
    Rigidbody2D rigid;
    SpriteRenderer renderer;

    [SerializeField] private float moveSpeed;
     float moveDistance = 2.0f;   // ������ �Ÿ�
   
    private bool IsMoveRight = true;
    private Vector3 startPos;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        startPos = transform.position;
    }
    // ���˾Ƽ� Ư�� ���������� �������� ��
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

}

/// <summary>
/// ���� Ư¡
/// Ư����ġ������ ������
/// ���˾Ƽ� ������ (���� AI)
/// �¿�θ� ������
/// �׷���? ��ĭ ������ ����
/// 
/// </summary>