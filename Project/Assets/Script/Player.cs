using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;

    public Vector2 moveVec;
    public float moveSpeed;
    public float jumpSpeed;
    public bool isGround = false;
    
    
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Terrain"))
        {
            isGround = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {

        }
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
        if(context.performed)
        {
            rigid.linearVelocityY = jumpSpeed;
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
