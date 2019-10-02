using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator doorAnimator; //the animator is what will actually open the door

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
        if (miniBoss.isDead)
        {
            OpenDoor();
            doorOpened = true;
        }
    }

    private void OpenDoor()
    {
        doorAnimator.SetBool("DoorOpenable", true);
    }
}
