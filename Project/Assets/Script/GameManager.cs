using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefap;
    public Player player;
    public BulletManager bulletManager;
    public Camera camera;
    public static GameManager instance;
    public SaveManager saveManager;
    public MapManager mapManager;

    private void Awake()
    {
        Debug.Log("게임 매니저 시동");

        if (camera == null)
        {
            camera = Camera.main;
        }
        instance = this;

        Instantiate(playerPrefap, gameObject.transform,true);
        player = GetComponentInChildren<Player>();
    }

    private void Start()
    {
        camera.transform.position = saveManager.currentData.cameraPos;
    }

    private void Update()
    {
        Restart();
    }

    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            player.Init(saveManager.currentData.playerPos);
            camera.transform.position = saveManager.currentData.cameraPos;
            mapManager.Init();
        }
    }
}
