﻿using UnityEngine;

public abstract class EnemySpawningAIObject : ScriptableObject
{
    [SerializeField]
    protected GameObject enemyTemplate;
    [SerializeField]
    protected float spawnRate = 1.0f;
    protected int layerCount;
    protected float timeSinceLastSpawn = 0.0f;
    protected GameObject gameManager;
    
    public virtual void RunOnStart(int activeLayers, GameObject gameController)
    {
        layerCount = activeLayers;
        gameManager = gameController;
    }
    public virtual void RunOnUpdate()
    {
        if (timeSinceLastSpawn > spawnRate)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0.0f;
        }
        else
        {
            timeSinceLastSpawn += Time.deltaTime;
        }
    }

    protected virtual void SpawnEnemy()
    {
        Debug.Log("Enemy spawned");
        timeSinceLastSpawn = 0.0f;
    }

    public virtual void ChangeLayerCount(int value)
    {
        layerCount = (int)Mathf.Clamp(layerCount + value, 0.0f, layerCount + value);
    }
}
