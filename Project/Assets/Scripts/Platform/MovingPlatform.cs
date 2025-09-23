using UnityEngine;

public class MovingPlatporm : MonoBehaviour
{
    // ���ǿ� ��������� ���ǰ� �Բ� �̵�
    private Vector2 lastPosition;

    private void FixedUpdate()
    {
        lastPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!collision.gameObject.activeInHierarchy) return;
            collision.transform.SetParent(null);
        }
    }
}
