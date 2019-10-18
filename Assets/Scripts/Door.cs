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

    /// <summary>
    /// opens the door for the first time if the set miniboss (enemy) is destroyed
    /// if a checkpoint is attatched, set it as the new checkpoint when the miniboss (enemy) dies
    /// </summary>
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
        }
    }

    /// <summary>
    /// opens the door for the first time via the animator
    /// </summary>
    private void InitialOpenDoor()
    {
        doorAnimator.SetBool("DoorOpenable", true);
    }

    /// <summary>
    /// opens the door via the animator
    /// sets DoorClosed to false before setting DoorOpen to prevent the animation from looping
    /// </summary>
    public void OpenDoor()
    {
        doorAnimator.SetBool("DoorClosed", false);
        doorAnimator.SetBool("DoorOpen", true);
    }

    /// <summary>
    /// closes the door via the animator
    /// sets DoorOpen to false before setting DoorClosed to prevent the animation from looping
    /// </summary>
    public void CloseDoor()
    {
        doorAnimator.SetBool("DoorOpen", false);
        doorAnimator.SetBool("DoorClosed", true);
    }
}
