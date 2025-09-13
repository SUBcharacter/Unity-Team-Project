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
        // 방향키로 플레이어 움직이는 코드
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
            // 이동 멈췄을 때 → 뒤돌았다고 가정 (원하면 방향 유지해도 됨)
            spriteRenderer.sprite = backSprite;
        }

        rigidbody2D.linearVelocity = moveDir * moveSpeed;


    }
}