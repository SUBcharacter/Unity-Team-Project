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
            Debug.Log("방향 벡터: " + direction);
            isFired = true;
        }
    }

    private void Start()
    {
        Destroy(gameObject, 2.0f); // 5초 후에 총알 제거
    }

    void Update()
    {
        if (isFired)
        {
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }
}

