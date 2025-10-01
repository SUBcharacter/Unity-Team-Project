using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject prefap;
    List<GameObject> pools;

    int bulletIndex = 0;
    int bulletCount = 5;
    int maxActiveBullet = 5;
    public int activeBullet;

    private void Awake()
    {

        pools = new List<GameObject>();
        for(int i = 0; i< bulletCount; i++)
        {
            GameObject bullet = Instantiate(prefap,gameObject.transform);
            bullet.SetActive(false);
            pools.Add(bullet);
        }
    }

    public void GetBullet(Vector2 pos, Vector2 dir)
    {
        if (activeBullet >= maxActiveBullet)
            return;

        GameObject bullet = pools[bulletIndex];
        bullet.SetActive(true);
        activeBullet++;
        bullet.transform.position = pos;
        bullet.GetComponent<Bullet>().Init(dir);

        bulletIndex = (bulletIndex + 1) % bulletCount;
    }
}
