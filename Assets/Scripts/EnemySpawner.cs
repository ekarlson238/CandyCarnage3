using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    [HideInInspector]
    public float health;

    [SerializeField]
    private Enemy miniBoss;
    
    private static GameObject enemyEmptyParent;

    [SerializeField]
    [Tooltip("the enemy prefab that will be spawned")]
    private GameObject enemyPrefab;

    [SerializeField]
    [Tooltip("How far in front of the spawner the prefab spawns (can't be too close")]
    private float enemySpawnDistance = 2;

    [SerializeField]
    [Tooltip("Lower = faster")]
    private float timeBetweenSpawns = 5;

    [SerializeField]
    [Tooltip("Used for bosses")]
    private Image optionalHealthBar;

    private float timeSinceSpawn;

    private GameObject enemyAudioManager;
    private AudioSource deathSFX;

    // Start is called before the first frame update
    private void Start()
    {
        ResetHealth();

        enemyEmptyParent = GameObject.FindGameObjectWithTag("SpawnedEnemiesParent");

        timeSinceSpawn = timeBetweenSpawns; //spawns an enemy right away
        //timeSinceSpawn = 0; //spawns an enemy after timeBetweenSpawns has passed once

        enemyAudioManager = GameObject.FindGameObjectWithTag("EnemyAudioManager");
        deathSFX = enemyAudioManager.GetComponent<AudioSource>();
    }

    /// <summary>
    /// Takes damage when hit by an attack.    (WILL NEED TO EDIT THIS WHEN THERE ARE MULTIPLE ATTACK TYPES)
    /// </summary>
    /// <param name="other">The trigger that was hit</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            health -= Arrow.staticDamage;
            Debug.Log(health);
        }
    }

    /// <summary>
    /// sets the spawners health back to their max health
    /// </summary>
    public void ResetHealth()
    {
        health = maxHealth;
    }

    /// <summary>
    /// only spawn enemies if the miniboss is not dead
    /// </summary>
    private void Update()
    {
        if (!miniBoss.isDead)
            Spawn();
        else
        {
            ClearSpawnedEnemies();
            Destroy(gameObject);
        }

        UpdateHealthBar();
        CheckIfDead();
    }

    /// <summary>
    /// destroys itself if it loses all of it's health
    /// </summary>
    private void CheckIfDead()
    {
        if (health <= 0)
        {
            if (deathSFX != null)
                deathSFX.Play();

            Debug.Log(this.name + " Died");
            Destroy(gameObject);
        }
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

        if (timeSinceSpawn >= timeBetweenSpawns)
        {
            Instantiate(enemyPrefab, spawnPos, rotation, enemyEmptyParent.transform);
            timeSinceSpawn = 0; 
        }
    }

    /// <summary>
    /// destroy every enemy that have been spawned from a spawner
    /// </summary>
    public static void ClearSpawnedEnemies()
    {
        if (enemyEmptyParent != null)
            foreach (Transform child in enemyEmptyParent.transform)
                GameObject.Destroy(child.gameObject);
            
    }

    /// <summary>
    /// if the enemy spawner has a healthbar, display the spawner's current health in it
    /// </summary>
    private void UpdateHealthBar()
    {
        if (optionalHealthBar != null)
        {
            optionalHealthBar.fillAmount = health / maxHealth;
        }
    }
}
