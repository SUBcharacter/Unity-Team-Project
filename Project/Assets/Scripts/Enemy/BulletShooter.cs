using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] Vector2 direction;
    private bool isFired = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Destroy(other.gameObject);      // �÷��̾� ������Ʈ �ı�
            Destroy(gameObject);            // �̻��� ������Ʈ �ı�
        }
    }

    public void SetTarget(Transform target)
    {
        if (target != null)
        {
            direction = (target.position - transform.position).normalized;
            Debug.Log("���� ����: " + direction);
            isFired = true;
        }
    }

    private void Start()
    {
        Destroy(gameObject, 2.0f); // 5�� �Ŀ� �Ѿ� ����
    }

    void Update()
    {
        if (isFired)
        {
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }
}

