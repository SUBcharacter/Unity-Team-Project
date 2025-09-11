using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigid;
    Player player;

    public int damage;
    public float speed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            gameObject.SetActive(false);
            rigid.MovePosition(player.transform.position);
        }
    }
        
}
