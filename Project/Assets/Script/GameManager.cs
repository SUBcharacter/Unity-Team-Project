using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public BulletManager bm;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
}
