using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[System.Serializable]
public class Enemy : MonoBehaviour
{
    //Damage is the same for all enemies; different enemy types will need to be children of this class
    private static int damage = 20;

    public static int enemyDamage
    {
        get { return damage; }
    }

    [SerializeField]
    private bool enemyCanMove = true;

    [HideInInspector]
    public float maxHealth = 100;
    [HideInInspector]
    public float health;

    [HideInInspector]
    public float knockbackForce = 20;
    private Rigidbody myRigidbody;

    private NavMeshAgent myNavMeshAgent;
    private GameObject[] players;
    private GameObject closestPlayer;
    private float distance;

    private GameObject enemyAudioManager;
    private AudioSource deathSFX;

    [SerializeField][Tooltip("Used for bosses")]
    private Image optionalHealthBar;
    
    [HideInInspector]
    public bool isDead = false; //even though the enemy is destoryed on death, this is needed to stop AttackPlayer()
    //and it is used by Door.cs

    private Vector3 startingPosition;

    //scale
    [SerializeField]
    private float minimunScale;
    private float scale = 1;
    private float xScale;
    private float yScale;
    private float zScale;
    
    // Start is called before the first frame update
    public void Awake()
    {
        ResetHealth();

        startingPosition = transform.position;

        enemyAudioManager = GameObject.FindGameObjectWithTag("EnemyAudioManager");
        deathSFX = enemyAudioManager.GetComponent<AudioSource>();

        myNavMeshAgent = GetComponent<NavMeshAgent>();
        players = GameObject.FindGameObjectsWithTag("Player");
        myRigidbody = GetComponent<Rigidbody>();

        xScale = transform.localScale.x;
        yScale = transform.localScale.y;
        zScale = transform.localScale.z;
    }

    /// <summary>
    /// Sets the enemy's postition to where they spawned
    /// </summary>
    public void ResetPosition()
    {
        transform.position = startingPosition;
    }

    /// <summary>
    /// Sets the enemy's health back to thier max health
    /// </summary>
    public void ResetHealth()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void Update()
    {
        CheckIfDead();

        UpdateHealthBar();
        UpdateScale();

        if (enemyCanMove)
        {
            FindClosestPlayer();
            AttackPlayer();
        }

        foreach(GameObject player in players)
            Debug.Log(player);
    }


    /// <summary>
    /// Destroys itself if it doesn't have any health left
    /// </summary>
    private void CheckIfDead()
    {
        if (health <= 0)
        {
            if (deathSFX != null)
                deathSFX.Play();

            Debug.Log(this.name + " Died");
            isDead = true;
            Destroy(gameObject);
        }
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
    /// Pushes the enemy away from the player
    /// adapted from this post https://answers.unity.com/questions/1100879/push-object-in-opposite-direction-of-collision.html
    /// </summary>
    /// <param name="collision">Whatever the enemy collides with</param>
    private void OnCollisionStay(Collision collision)
    {
        // If the object we hit is the enemy
        if (collision.gameObject.tag == "Player" && enemyCanMove)
        {
            Debug.Log("player hit");
            // Calculate Angle Between the collision point and the player
            Vector3 direction = collision.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            direction = -direction.normalized;
            // And finally we set velocity in the direction of dir and multiply it by the knockback force. 
            // This will push back the player
            myRigidbody.velocity = direction * knockbackForce;
        }

        if (collision.gameObject.tag == "Death") //if they fall off the map, kill them
        {
            health = 0;
        }
    }

    /// <summary>
    /// Uses the enemy's navMesh to move to the closest player's position
    /// </summary>
    private void AttackPlayer()
    {
        if (!isDead) //stops it from trying to move the same frame as death
            myNavMeshAgent.SetDestination(closestPlayer.transform.position);
    }

    /// <summary>
    /// Returns the player that is closest
    /// adapted from https://answers.unity.com/questions/264568/find-objects-and-go-there-with-nav-mesh-agent.html
    /// </summary>
    /// <returns></returns>
    private void FindClosestPlayer()
    {
        GameObject closest = null;
        distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject player in players)
        {
            Vector3 difference = player.transform.position - position;
            float targetDistance = difference.sqrMagnitude;
            if (targetDistance < distance) //distance starts at infinity so this will always work at least once
            {
                closest = player;
                distance = targetDistance;
            }
        }
        closestPlayer = closest;
    }
    
    /// <summary>
    /// Updates the health bar UI to display health (as a bar)
    /// </summary>
    private void UpdateHealthBar()
    {
        if (optionalHealthBar != null)
        {
            optionalHealthBar.fillAmount = health / maxHealth;
        }
    }

    /// <summary>
    /// changes the enemies scale based on their health
    /// </summary>
    private void UpdateScale()
    {
        if (scale > minimunScale)
            scale = health / maxHealth + minimunScale;
        else
            scale = minimunScale;

        //never let the scale be greater than 1
        if (scale > 1)
            scale = 1;
        
        transform.localScale = new Vector3(xScale * scale, yScale * scale, zScale * scale);
    }
}
