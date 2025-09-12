using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigid;

    public int damage;
    public float speed = 10.0f;
    

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector2 dir)
    {
        dir = dir.normalized;
        rigid.linearVelocity = dir * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool border = collision.gameObject.CompareTag("Border");
        bool terrain = collision.gameObject.CompareTag("Terrain");

        if (!(border || terrain))
            return;

        gameObject.SetActive(false);
        GameManager.instance.bm.activeBullet--;
    }
        
}
