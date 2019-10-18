using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    [SerializeField][Tooltip("What will be enabled when the player enters the room")]
    private GameObject roomContents;

    [SerializeField]
    private Enemy miniBoss;

    [HideInInspector]
    public bool cleared = false;

    [HideInInspector]
    public bool entered = false;

    private Enemy[] enemies;
    private EnemySpawner[] spawners;

    private RoomManager roomManager;

    //start
    private void Start()
    {
        enemies = roomContents.GetComponentsInChildren<Enemy>();
        spawners = roomContents.GetComponentsInChildren<EnemySpawner>();

        roomContents.SetActive(false);

        roomManager = GameObject.FindObjectOfType<RoomManager>();
    }

    //update
    private void Update()
    {
        CheckIfCleared();
    }

    /// <summary>
    /// if the player is in a handler where the miniboss is dead, open all previously opened doors
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
            if (cleared)
                roomManager.OpenOldDoors();
    }

    /// <summary>
    /// sets the room as cleared when the m
    /// </summary>
    private void CheckIfCleared()
    {
        if (miniBoss == null)
        {
            cleared = true;
        }
    }

    /// <summary>
    /// activates the room's enemies when the player enters the room
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!entered)
            {
                roomContents.SetActive(true);
                roomManager.CloseAllDoors();
                entered = true;
            }
        }
    }

    /// <summary>
    /// resets every enemy and spawner in the room
    /// </summary>
    public void ResetRoom()
    {
        foreach (Enemy e in enemies)
        {
            if (e != null)
            {
                e.ResetHealth();
                e.ResetPosition();
            }
        }
        foreach (EnemySpawner s in spawners)
        {
            if (s != null)
                s.ResetHealth();
        }
    }

    /// <summary>
    /// deactivates every room's enemies (public static because it's called by the respawn script)
    /// </summary>
    public static void SetInactive()
    {
        foreach (RoomHandler rh in UnityEngine.Object.FindObjectsOfType(typeof(RoomHandler)))
        {
            rh.roomContents.SetActive(false);
        }
    }
}
