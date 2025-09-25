using UnityEngine;

public class WindSpace : MonoBehaviour
{
    [SerializeField] private Vector2 windDirection = Vector2.left; // �ٶ� ���� ����
    [SerializeField] private float windForce = 130f; // �ٶ� ���� (�ʿ��� ��ŭ ����)

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rbPlayer = collision.attachedRigidbody;
            if (rbPlayer != null)
            {
                rbPlayer.AddForce(windDirection.normalized * windForce, ForceMode2D.Force);
            }
        }
    }
}
