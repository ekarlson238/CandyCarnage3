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

    /// <summary>
    /// resets every room that's not set as cleared
    /// </summary>
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

    /// <summary>
    /// closes every door in doors (doors contains every door in the scene)
    /// </summary>
    public void CloseAllDoors()
    {
        foreach (Door d in doors)
        {
            d.CloseDoor();
        }
    }

    /// <summary>
    /// opens every door that has been opened before (if its been opened before, the door's room has been cleared)
    /// </summary>
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
