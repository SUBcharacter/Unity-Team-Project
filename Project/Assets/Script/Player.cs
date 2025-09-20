using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Animator animator;
    Gun gun;

    public Vector2 moveVec;
    public float moveSpeed;
    float coyoteTimeCounter = 0;
    float coyoteTime = 0.15f;
    float distance = 0.05f;
    [SerializeField] private float[] jumpSpeeds;
    

    bool shotDir = true; // true : 오른쪽, false : 왼쪽
    [SerializeField] bool isGround = false;
    [SerializeField] bool canAirJump = false;

    void Awake()
    {
        gameObject.SetActive(true);
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        gun = GetComponentInChildren<Gun>();

        jumpSpeeds = new float[] { 10.0f, 7.0f };
        
    }

    void Start()
    {
        Init(GameManager.instance.saveManager.currentData.playerPos);
    }

    void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        Move();
        if (isGround)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }
    public void Init(Vector3 initPos)
    {
        transform.position = initPos;
        rigid.linearVelocityY = 0f;
        gameObject.SetActive(true);
    }

    void Control()
    {

    }

    void Move()
    {
        rigid.linearVelocityX = moveVec.x * moveSpeed;
    }

    #region EventFunc
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌감지");
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Terrain"))
            return;

        isGround = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Obstacle"))
            return;
        gameObject.SetActive(false);
    }

    #region UNITY_EVENTS

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        Vector3 gunPostion = gun.transform.position;
        if ( input.x < 0)
        {
            sprite.flipX = true;
            gun.transform.position = new Vector3(-gunPostion.x, gunPostion.y, gunPostion.z);
            gun.facingRight = false;
        }
        else if(input.x > 0)
        {
            sprite.flipX = false;
            gun.transform.position = new Vector3(gunPostion.x, gunPostion.y, gunPostion.z);
            gun.facingRight = true;
        }
        moveVec = input;

        if(moveVec.x != 0)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
        

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!(isGround || canAirJump))
            return;

        if(context.performed)
        {
            if(isGround && coyoteTimeCounter>0)
            {
                isGround = false;
                rigid.linearVelocityY = jumpSpeeds[0];
            }
            else if(canAirJump) 
            {
                canAirJump = false;
                rigid.linearVelocityY = jumpSpeeds[1];
            }
        }
        if(context.canceled)
        {
            if(rigid.linearVelocityY > 0)
            {
                rigid.linearVelocityY *= 0.5f;
            }
            
        }

    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        gun.Fire();
    }
    #endregion
    #endregion
}
