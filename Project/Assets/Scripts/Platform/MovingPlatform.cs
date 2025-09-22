using UnityEngine;

public class MovingPlatporm : MonoBehaviour
{
    // ���ǿ� ��������� ���ǰ� �Բ� �̵�

    private Vector2 lastPosition;

    private void FixedUpdate()
    {
        lastPosition = transform.position;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("�����浹");

            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 delta = (Vector2)transform.position - lastPosition;

                // �÷��̾� �̵�
                rb.MovePosition(rb.position + delta);
            }
        }
    }
}
