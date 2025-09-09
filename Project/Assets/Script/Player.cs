using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    
    public Vector2 inputVec;
    public float speed;
    
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
        rigid.linearVelocityX = inputVec.x * speed;
        if (Mathf.Abs(inputVec.x) < 1)
        {
            rigid.linearVelocityX -= rigid.linearVelocityX;
        }
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

    public void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
    

    void Retry()
    {
        transform.gameObject.SetActive(true);
    }
}
