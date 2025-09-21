using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] Scanner scanner;                    // Ÿ�� ������ ��ĳ��
    [SerializeField] GameObject bulletPrefab;            // ���������� ���� �̻���
    [SerializeField] Transform firePoint;                // �߻� ��ġ
    [SerializeField] float fireDelay = 1.5f;             // �߻� �ֱ�

    private Coroutine fireCoroutine;

    bool Isfiring = false;


    void Update()
    {
        Transform target = scanner.nearestTarget;
        if (target != null && !Isfiring)
        {
            fireCoroutine = StartCoroutine(FireCouroutine());
            Isfiring = true;
        }
    }

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
        while (true)
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
