using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator doorAnimator; //the animator is what will actually open the door

    [SerializeField][Tooltip("Don't need a check point for the door to work")]
    private GameObject optionalCheckPoint;

    [SerializeField]
    private Enemy miniBoss;
    
    [HideInInspector]
    public bool doorOpen = false;
    
    [HideInInspector]
    public bool doorFirstOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfMiniBossDestroyed();
    }

    private void CheckIfMiniBossDestroyed()
    {
        if (miniBoss == null && !doorOpen)
        {
            InitialOpenDoor();

            if (optionalCheckPoint != null)
            {
                PlayerRespawn.SetCheckPoint(optionalCheckPoint);
            }

            doorOpen = true; //just stops it from running OpenDoor over and over
            doorFirstOpened = true;
        }
    }

    private void InitialOpenDoor()
    {
        doorAnimator.SetBool("DoorOpenable", true);
    }

    public void OpenDoor()
    {
        doorAnimator.SetBool("DoorClosed", false);
        doorAnimator.SetBool("DoorOpen", true);
    }

    public void CloseDoor()
    {
        doorAnimator.SetBool("DoorOpen", false);
        doorAnimator.SetBool("DoorClosed", true);
    }
}
