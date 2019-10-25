using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamageOverTime : MonoBehaviour
{
    private float dotTimeCounter = 0;

    //can attach to either an enemy or a spawner
    private Enemy possibleEnemy;
    private EnemySpawner possibleEnemySpawner;
    
    private void Start()
    {
        AddDot();

        possibleEnemy = GetComponent<Enemy>();
        possibleEnemySpawner = GetComponent<EnemySpawner>();
    }

    //using fixed update so frame rate doesnt effect dps (it could happen with update on some rare cases)
    // Update is called once per frame
    void FixedUpdate()
    {
        CheckForDot();
    }

    /// <summary>
    /// if the DOT has time left, deal damage each tick (normalized by Time.deltaTime) and count down the time left
    /// </summary>
    private void CheckForDot()
    {
        if (dotTimeCounter > 0)
        {
            if (possibleEnemy != null)
                possibleEnemy.health -= WaterAttack.waterDamagePerSecond * Time.deltaTime;

            if (possibleEnemySpawner != null)
                possibleEnemySpawner.health -= WaterAttack.waterDamagePerSecond * Time.deltaTime;

            dotTimeCounter -= Time.deltaTime;
        }
    }

    /// <summary>
    /// resets the dot time left to max time
    /// </summary>
    public void AddDot()
    {
        dotTimeCounter = WaterAttack.waterDotTime;
    }
}
