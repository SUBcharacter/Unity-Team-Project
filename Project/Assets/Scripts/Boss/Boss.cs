using UnityEngine;
using UnityEngine.Rendering;

public class Boss : MonoBehaviour
{
    
    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer sprite;
    Bojo bojo;
    Vector3 originalScale;
    Vector3 farAwayScale;

    public int health;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        bojo = GetComponentInParent<Bojo>();

        health = 100;
        originalScale = transform.localScale;
        farAwayScale = transform.localScale / 30f; ;
    }

    void Update()
    {
        AnimationControl();

        Debug.Log(transform.localScale);
    }


    public void AnimationControl()
    {
        if(bojo.farAway)
        {
            transform.localScale = farAwayScale;
        }
        else
        {
            transform.localScale = originalScale;
        }

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
