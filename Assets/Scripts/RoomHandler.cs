using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    [SerializeField][Tooltip("What will be enabled when the player enters the room")]
    private GameObject RoomContents;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            RoomContents.SetActive(true);
    }

    public static void SetInactive()
    {
        foreach (RoomHandler rh in UnityEngine.Object.FindObjectsOfType(typeof(RoomHandler)))
        {
            rh.RoomContents.SetActive(false);
        }
    }
}
