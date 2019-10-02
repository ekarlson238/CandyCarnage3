using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector]
    public float maxHealth = 200;

    private float health;
    
    [HideInInspector]
    public float invincibilityTime = 1;

    private float timeSinceDamaged;
    private bool isInvincible;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        timeSinceDamaged = invincibilityTime;
        isInvincible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        InvinciblityTimer();
    }

    /// <summary>
    /// Checks to see if the player has been damaged and, if they have, makes the invincible for the invincibility time
    /// </summary>
    private void InvinciblityTimer()
    {
        if (timeSinceDamaged <= invincibilityTime)
        {
            timeSinceDamaged += Time.deltaTime;
            isInvincible = true;
        }
        else
        {
            isInvincible = false;
        }
    }

    /// <summary>
    /// Damages the player if hit by an enemy
    /// </summary>
    /// <param name="collision">what the player collided with</param>
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && !isInvincible)
        {
            health -= Enemy.enemyDamage;
            timeSinceDamaged = 0;
            Debug.Log("Player has been hit!  Health:" + health);
        }
    }
}
