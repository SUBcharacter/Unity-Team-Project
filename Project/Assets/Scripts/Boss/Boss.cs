using UnityEngine;

public class Boss : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator animator;

    public int health;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        health = 100;
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
            return;
        animator.SetTrigger("Hit");
        collision.gameObject.SetActive(false);
        GameManager.instance.bulletManager.activeBullet--;
        health -= collision.GetComponent<Bullet>().damage;

    }
}
