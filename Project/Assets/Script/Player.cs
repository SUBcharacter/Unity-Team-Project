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
    public float jumpSpeed;
    bool shotDir = true; // true : 오른쪽, false : 왼쪽
    bool isGround = false;
    bool canAirJump = false;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        gun = GetComponentInChildren<Gun>();
    }

    void Start()
    {
        Init(new Vector2(-1.0f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();

    }
    public void Init(Vector2 initPos)
    {
        transform.position = new Vector3(initPos.x,initPos.y,0);
        gameObject.SetActive(true);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌감지");
        if(collision.gameObject.CompareTag("Terrain"))
        {
            foreach(ContactPoint2D c in collision.contacts)
            {
                if(c.normal.y > 0.9f)
                {
                    isGround = true;
                    canAirJump = true;
                }
            }
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
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

    void Control()
    {
        
    }

    void Move()
    {
        rigid.linearVelocityX = moveVec.x * moveSpeed;
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
            if(isGround)
            {
                Debug.Log("jumped");
                rigid.linearVelocityY = jumpSpeed;
                isGround = false;
            }
            else if(canAirJump)
            {
                rigid.linearVelocityY = jumpSpeed;
                canAirJump = false;
            }
                
        }
        else if(context.canceled)
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


    void Retry()
    {
        transform.gameObject.SetActive(true);
    }
}
