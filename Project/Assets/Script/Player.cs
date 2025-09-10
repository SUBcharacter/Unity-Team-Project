using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;

    public Vector2 moveVec;
    public float moveSpeed;
    public float jumpSpeed;
    bool isGround = false;
    bool canAirJump = false;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌감지");
        if(collision.gameObject.CompareTag("Terrain"))
        {
            isGround = true;
            canAirJump = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {

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
        moveVec = context.ReadValue<Vector2>();
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
    #endregion


    void Retry()
    {
        transform.gameObject.SetActive(true);
    }
}
