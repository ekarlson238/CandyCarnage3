using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField]
    private GameObject firstRoomContents;

    private RoomHandler[] rooms;

    // Start is called before the first frame update
    void Start()
    {
        rooms = GameObject.FindObjectsOfType<RoomHandler>();

        firstRoomContents.SetActive(true);
    }

    public void ResetUnclearedRooms()
    {
        foreach (RoomHandler r in rooms)
        {
            if (!r.cleared)
                r.ResetRoom();
        }
    }
}
