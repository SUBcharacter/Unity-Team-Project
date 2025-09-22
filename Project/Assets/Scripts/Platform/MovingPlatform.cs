using UnityEngine;

public class MovingPlatporm : MonoBehaviour
{
    // 발판에 닿아있으면 발판과 함께 이동

    private Vector2 lastPosition;

    private void FixedUpdate()
    {
        lastPosition = transform.position;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("발판충돌");

            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 delta = (Vector2)transform.position - lastPosition;

                // 플레이어 이동
                rb.MovePosition(rb.position + delta);
            }
        }
    }
}
