using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;            // ���������� ���� �̻���
    [SerializeField] Transform firePoint;                // �߻� ��ġ
    [SerializeField] float fireDelay = 1.5f;             // �߻� �ֱ�
    private float fireTimer;

    [SerializeField] Scanner scanner;                    // Ÿ�� ������ ��ĳ��

    private Coroutine fireCoroutine;

    private void OnEnable()
    {
        fireCoroutine = StartCoroutine(FireCouroutine());
    }

    private void OnDisable()
    {
        if(fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
        }
    }

    //void Update()
    //{
    //    fireTimer += Time.deltaTime;

    //    if (fireTimer >= fireDelay)
    //    {
    //        Transform target = scanner.nearestTarget;

    //        if (target != null)
    //        {
    //            Debug.Log(" Ÿ�� ������: " + target.name + " / ��ġ: " + target.position);
    //            Fire(target);
    //            fireTimer = 0f;
    //        }
    //    }
    //}

    void Fire(Transform target)
    {
        Debug.Log("���� Ÿ�� �̸�: " + target.name);
        Debug.Log("Ÿ�� ��ġ: " + target.position);
        Debug.Log("�߻� ��ġ: " + firePoint.position);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.transform.position = firePoint.position;
        BulletShooter shooter = bullet.GetComponent<BulletShooter>();
        if (shooter != null)
        {
            shooter.SetTarget(target);
        }
    }

    IEnumerator FireCouroutine()
    {
        while(true)
        {
            Transform target = scanner.nearestTarget;
            if (target != null)
            {
                Debug.Log(" Ÿ�� ������: " + target.name + " / ��ġ: " + target.position);
                Fire(target);
            }
            yield return new WaitForSeconds(fireDelay);
        }
    }
}
