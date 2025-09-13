using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    PlayerAction playerAction;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;



    [SerializeField] private float moveSpeed = 5.0f;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        playerAction = new PlayerAction();
        playerAction.Player.Enable();
    }

    private void Update()
    {
        // ����Ű�� �÷��̾� �����̴� �ڵ�
        Vector2 moveDir = playerAction.Player.Move.ReadValue<Vector2>();

        if (moveDir.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            spriteRenderer.sprite = frontSprite;
        }
        else if (moveDir.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            spriteRenderer.sprite = frontSprite;
        }
        else
        {
            // �̵� ������ �� �� �ڵ��Ҵٰ� ���� (���ϸ� ���� �����ص� ��)
            spriteRenderer.sprite = backSprite;
        }

        rigidbody2D.linearVelocity = moveDir * moveSpeed;


    }
}