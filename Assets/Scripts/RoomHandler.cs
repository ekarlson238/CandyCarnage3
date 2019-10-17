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

    private void Start()
    {
        enemies = roomContents.GetComponentsInChildren<Enemy>();
        spawners = roomContents.GetComponentsInChildren<EnemySpawner>();

        roomContents.SetActive(false);

        roomManager = GameObject.FindObjectOfType<RoomManager>();
    }

    private void Update()
    {
        CheckIfCleared();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
            if (cleared)
                roomManager.OpenOldDoors();
    }

    private void CheckIfCleared()
    {
        if (miniBoss == null)
        {
            cleared = true;
        }
    }

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

    public static void SetInactive()
    {
        foreach (RoomHandler rh in UnityEngine.Object.FindObjectsOfType(typeof(RoomHandler)))
        {
            rh.roomContents.SetActive(false);
        }
    }
}
