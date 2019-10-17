using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Rigidbody playerBody;

    private PlayerHealth myHealth;

    private static GameObject checkPoint; //everyone respawns in the same place

    [SerializeField]
    private GameObject firstCheckPoint;
    
    [SerializeField]
    private RoomManager roomManager;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        myHealth = GetComponent<PlayerHealth>();
        checkPoint = firstCheckPoint;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfDead();
    }

    //respawns the player at their last checkpoint if they die
    private void CheckIfDead()
    {
        if (myHealth.isDead)
        {
            //might want to make a lives system later
            playerBody.position = checkPoint.transform.position;
            myHealth.health = myHealth.maxHealth;
            EnemySpawner.ClearSpawnedEnemies();
            roomManager.ResetUnclearedRooms();
            RoomHandler.SetInactive();
            myHealth.isDead = false;
        }
    }

    public static void SetCheckPoint(GameObject newCheckPoint)
    {
        checkPoint = newCheckPoint;
    }
}
