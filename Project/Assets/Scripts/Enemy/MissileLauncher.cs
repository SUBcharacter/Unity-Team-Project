using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;            // 프리팹으로 만든 미사일
    [SerializeField] Transform firePoint;                // 발사 위치
    [SerializeField] float fireDelay = 1.5f;             // 발사 주기
    private float fireTimer;

    [SerializeField] Scanner scanner;                    // 타겟 감지용 스캐너

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
    //            Debug.Log(" 타겟 감지됨: " + target.name + " / 위치: " + target.position);
    //            Fire(target);
    //            fireTimer = 0f;
    //        }
    //    }
    //}

    void Fire(Transform target)
    {
        Debug.Log("현재 타겟 이름: " + target.name);
        Debug.Log("타겟 위치: " + target.position);
        Debug.Log("발사 위치: " + firePoint.position);

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
                Debug.Log(" 타겟 감지됨: " + target.name + " / 위치: " + target.position);
                Fire(target);
            }
            yield return new WaitForSeconds(fireDelay);
        }
    }
}
