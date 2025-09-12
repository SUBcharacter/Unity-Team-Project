using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigid;

    public int damage;
    public float speed;
    public Vector2 direction;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Init(Vector2 dir)
    {
        dir = dir.normalized;
        rigid.linearVelocityX = dir.x * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            gameObject.SetActive(false);
        }
        else if(collision.gameObject.CompareTag("Terrain"))
        {
            gameObject.SetActive(false);
        }
    }
        
}
