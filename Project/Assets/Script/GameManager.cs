using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public BulletManager bulletManager;
    public Camera camera;
    public static GameManager instance;
    public SaveManager saveManager;

    private void Awake()
    {
        if(camera == null)
        {
            camera = Camera.main;
        }
        instance = this;
    }

    private void Start()
    {
        camera.transform.position = saveManager.currentData.cameraPos;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            player.Init(saveManager.currentData.playerPos);
            camera.transform.position = saveManager.currentData.cameraPos;
        }
    }
}
