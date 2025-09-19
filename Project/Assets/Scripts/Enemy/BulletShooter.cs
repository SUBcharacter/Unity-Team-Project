using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] Vector2 direction;
    private bool isFired = false;

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

