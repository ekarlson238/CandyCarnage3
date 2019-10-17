using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField]
    private GameObject firstRoomContents;

    private RoomHandler[] rooms;

    private Door[] doors;

    //private Door[] compareDoors;

    private Door lastDoor;

    // Start is called before the first frame update
    void Start()
    {
        rooms = GameObject.FindObjectsOfType<RoomHandler>();

        doors = GameObject.FindObjectsOfType<Door>();

        //compareDoors = doors;

        firstRoomContents.SetActive(true);
    }

    public void ResetUnclearedRooms()
    {
        foreach (RoomHandler r in rooms)
        {
            if (!r.cleared)
            {
                r.ResetRoom();
                r.entered = false;
            }
        }
    }

    public void CloseAllDoors()
    {
        foreach (Door d in doors)
        {
            d.CloseDoor();
        }
    }

    public void OpenOldDoors()
    {
        foreach (Door d in doors)
        {
            if (d.doorOpen)
            {
                d.OpenDoor();
            }
        }
    }
}
