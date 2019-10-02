using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Enemy miniBoss;

    [SerializeField]
    [Tooltip("the enemy prefab that will be spawned")]
    private GameObject enemyPrefab;

    [SerializeField]
    [Tooltip("How far in front of the spawner the prefab spawns (can't be too close")]
    private float enemySpawnDistance = 2;

    [SerializeField]
    [Tooltip("Lower = faster")]
    private float timeBetweenSpawns = 5;

    private float timeSinceSpawn;

    // Start is called before the first frame update
    private void Start()
    {
        //timeSinceSpawn = timeBetweenSpawns; //spawns an enemy right away
        timeSinceSpawn = 0; //spawns an enemy after timeBetweenSpawns has passed once
    }

    private void Update()
    {
        Spawn();
    }

    /// <summary>
    /// spawns enemies if the miniboss is still alive
    /// </summary>
    private void Spawn()
    {
        Vector3 playerPos = transform.position;
        Vector3 playerDirection = transform.forward;
        Quaternion rotation = transform.rotation;

        Vector3 spawnPos = playerPos + playerDirection * enemySpawnDistance;

        if (timeSinceSpawn <= timeBetweenSpawns)
        {
            timeSinceSpawn += Time.deltaTime;
        }

        if (!miniBoss.isDead && timeSinceSpawn >= timeBetweenSpawns)
        {
            Instantiate(enemyPrefab, spawnPos, rotation);
            timeSinceSpawn = 0;
        }
    }
}
