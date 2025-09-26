using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public List<GameObject> prefaps;
    public List<GameObject> maps;

    private void Awake()
    {
        Debug.Log("맵 매니저 시동");
        for(int i = 0; i<prefaps.Count; i++)
        {
            maps.Add(Instantiate(prefaps[i], gameObject.transform,true));
        }
    }

    public void Init()
    {
        IResetable[] resettables = GetComponentsInChildren<IResetable>(true);
        foreach(var r in resettables)
        {
            r.Init();
        }
    }
}
