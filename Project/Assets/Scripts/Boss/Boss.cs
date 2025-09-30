using UnityEngine;

public class Boss : MonoBehaviour
{
    
    Rigidbody2D rigid;
    Animator animatorParent;
    SpriteRenderer sprite;
    Vector3 originalScale;
    Vector3 farAwayScale;

    public int health;
    public bool farAway = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animatorParent = GetComponentInParent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        health = 100;
        originalScale = transform.localScale;
        farAwayScale = transform.localScale / 30f; ;
    }

    void Update()
    {
        AnimationControl();

        if (farAway)
        {
            transform.localScale =farAwayScale;
        }
        else
            transform.localScale = originalScale;


        Debug.Log(transform.localScale);
    }


    public void AnimationControl()
    {
        AnimatorStateInfo stateInfo = animatorParent.GetCurrentAnimatorStateInfo(0);

        if(stateInfo.IsName("Wait"))
        {
            Debug.Log("축소");
            farAway = true;
        }
        if(stateInfo.IsName("Wait 0"))
        {
            Debug.Log("확대");
            farAway = false;
        }

        Debug.Log(farAway); 

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
            return;
        animatorParent.SetTrigger("Hit");
        collision.gameObject.SetActive(false);
        GameManager.instance.bulletManager.activeBullet--;
        health -= collision.GetComponent<Bullet>().damage;

    }
}
