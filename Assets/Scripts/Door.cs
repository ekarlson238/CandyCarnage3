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
    public bool doorOpened = false;

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
        if (miniBoss.isDead && !doorOpened)
        {
            OpenDoor();

            if (optionalCheckPoint != null)
            {
                PlayerRespawn.SetCheckPoint(optionalCheckPoint);
            }

            doorOpened = true; //just stops it from running OpenDoor over and over
        }
    }

    private void OpenDoor()
    {
        doorAnimator.SetBool("DoorOpenable", true);
    }
}
