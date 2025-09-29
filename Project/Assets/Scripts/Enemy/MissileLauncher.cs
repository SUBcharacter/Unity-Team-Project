using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] Scanner scanner;                    // Ÿ�� ������ ��ĳ��
    [SerializeField] GameObject bulletPrefab;           // ���������� ���� �̻���
    [SerializeField] GameObject loadedMissile;
    [SerializeField] Transform firePoint;                // �߻� ��ġ

    [SerializeField] bool isFired = false;

    private void Awake()
    {
        scanner = GetComponent<Scanner>();
        loadedMissile = Instantiate(bulletPrefab,transform.parent);
        
    }

    void Update()
    {
        if(scanner.nearestTarget)
        {
            Vector3 targetPos = scanner.nearestTarget.position;
            Vector3 direction = targetPos - transform.position;

            transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
            Fire();
        }
    }

    private void LateUpdate()
    {
        if ((!loadedMissile.activeSelf && scanner.target))
        {
            isFired = false;
        }
    }

    void Fire()
    {
        if (isFired || GameManager.instance.player.isDead)
            return;
        isFired = true;
        loadedMissile.GetComponent<BulletShooter>().Launch(firePoint.position);
        
    }
}
