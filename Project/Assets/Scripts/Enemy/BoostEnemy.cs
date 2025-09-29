using NUnit.Framework.Constraints;
using UnityEditor.Tilemaps;
using UnityEngine;

/// <summary>
/// 적도 동적으로 해야하나 
/// </summary>



public class BoostEnemy : MonoBehaviour,IResetable
{
    Rigidbody2D rigid;
    Scanner scanner;
    Vector2 direction;
    Vector3 initPos;
    [SerializeField] private float boostSpeed = 4f;
    [SerializeField] int health;

    

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        scanner = GetComponent<Scanner>();
        health = 5;
        initPos = transform.position;
    }

    private void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    { 
        if(scanner.nearestTarget)
        {
            direction = (scanner.nearestTarget.position - transform.position).normalized;
            rigid.linearVelocityX = direction.x * boostSpeed;
        }
        else
        {
            rigid.linearVelocityX = 0;
        }
    }

    public void Init()
    {
        health = 5;
        transform.position = initPos;
        scanner.nearestTarget = null;
        gameObject.SetActive(true);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        collision.gameObject.GetComponent<Player>().Death();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
            return;

        health -= collision.GetComponent<Bullet>().damage;
    }
}

