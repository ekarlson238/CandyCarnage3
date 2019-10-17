using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    [SerializeField][Tooltip("What will be enabled when the player enters the room")]
    private GameObject roomContents;

    [SerializeField]
    private Enemy miniBoss;

    //[HideInInspector]
    public bool cleared = false;

    private Enemy[] enemies;
    private EnemySpawner[] spawners;
    
    private void Start()
    {
        enemies = roomContents.GetComponentsInChildren<Enemy>();
        spawners = roomContents.GetComponentsInChildren<EnemySpawner>();

        roomContents.SetActive(false);
    }

    private void Update()
    {
        CheckIfCleared();
    }

    private void CheckIfCleared()
    {
        if (miniBoss.isDead)
            cleared = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            roomContents.SetActive(true);
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
