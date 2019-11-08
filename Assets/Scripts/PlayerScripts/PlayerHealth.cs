using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 200;

    [HideInInspector]
    public float health;
    
    public float invincibilityTime = 1;

    private float timeSinceDamaged;
    private bool isInvincible;

    [HideInInspector]
    public bool isDead = false;

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
        CheckIfDead();
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

        if (collision.gameObject.tag == "Death") //if they fall off the map, kill them
        {
            health = 0;
        }
    }


    /// <summary>
    /// Destroys itself if it doesn't have any health left
    /// </summary>
    private void CheckIfDead()
    {
        if (health <= 0)
        {
            Debug.Log(this.name + " Died");
            isDead = true;
        }
    }
}
