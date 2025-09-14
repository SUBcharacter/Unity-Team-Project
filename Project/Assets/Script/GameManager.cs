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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            player.Init(new Vector2(-1.0f, 1.0f));
        }
    }
}
