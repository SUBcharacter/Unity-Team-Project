using System.Collections.Generic;
using UnityEngine;

public class GhostTrail : MonoBehaviour
{
    SpriteRenderer sprite;
    public GhostPool pool;
    public float spawnInterval = 0.05f;
    float timer;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        timer += Time.deltaTime;
        if(timer >= spawnInterval)
        {
            pool.SpawnGhost(sprite.sprite, sprite.bounds.center, sprite.transform.lossyScale, 0.3f);
            timer = 0f;
        }
    }

    
}
