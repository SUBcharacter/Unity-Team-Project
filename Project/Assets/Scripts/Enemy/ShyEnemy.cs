using UnityEngine;


public class ShyEnemy : MonoBehaviour,IResetable
{

    [SerializeField] Sprite[] sprites;
    SpriteRenderer sprite;
    Scanner scanner;
    Rigidbody2D rigid;
    [SerializeField] Vector3 initPos;
    Vector2 direction;

    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float stopDistance = 0.1f;

   private bool isActived = true;      // 플레이어가 가까이 왔는지 (적 활성화 여부 체크)
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        scanner = GetComponent<Scanner>();
        rigid = GetComponent<Rigidbody2D>();

        sprite.sprite = sprites[0];
        // transform.position = initPos;
    }

    private void Update()
    {
        bool playerFacingRight = GameManager.instance.player.gun.facingRight;

        if (scanner.nearestTarget)
        {
            direction = (scanner.nearestTarget.position - transform.position).normalized;
            if(playerFacingRight)
            {
                if(direction.x >0)
                {
                    sprite.sprite = sprites[0];
                    sprite.flipX = false;
                    rigid.linearVelocity = direction * moveSpeed;
                }
                else
                {
                    sprite.sprite = sprites[1];
                    rigid.linearVelocity = Vector2.zero;
                }
            }
            else
            {
                if(direction.x < 0)
                {
                    sprite.sprite = sprites[0];
                    sprite.flipX = true;
                    rigid.linearVelocity = direction * moveSpeed;
                }
                else
                {
                    sprite.sprite = sprites[1];
                    rigid.linearVelocity = Vector2.zero;
                }

            }
        }
        else
        {
            rigid.linearVelocity = Vector2.zero;
        }
    }

    public void Init()
    {
        // 컴포넌트가 없으면 확보
        if (sprite == null) sprite = GetComponent<SpriteRenderer>();
        if (rigid == null) rigid = GetComponent<Rigidbody2D>();
        if (scanner == null) scanner = GetComponent<Scanner>();

        sprite.sprite = sprites[0];
        transform.position = initPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        collision.GetComponent<Player>().Death();
    }
}
