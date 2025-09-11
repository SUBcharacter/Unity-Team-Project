using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject[] bullet;
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[bullet.Length];
        for(int i = 0; i< pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        return select;
    }
}
