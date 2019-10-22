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
        possibleEnemy = GetComponent<Enemy>();
        possibleEnemySpawner = GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckForDot();
    }

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

    public void AddDot()
    {
        dotTimeCounter = WaterAttack.waterDotTime;
    }
}
