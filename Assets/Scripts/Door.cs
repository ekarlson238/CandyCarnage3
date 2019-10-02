using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator doorAnimator;

    [SerializeField]
    private Enemy miniBoss;

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
        }
    }

    private void OpenDoor()
    {
        doorAnimator.SetBool("DoorOpenable", true);
    }
}
