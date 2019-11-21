using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Scott Little
/// 
/// Purpose:
///     This script's sole purpose is to test the animations for the Chocolate Double Door Object.
/// </summary>
[RequireComponent(typeof(Animator))]
public class ChocolateDoorTestingScript : MonoBehaviour
{
    private Animator chocolateDoorAnimator;

    [SerializeField]
    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        chocolateDoorAnimator = GetComponent<Animator>();

        // Set the animator's isOpen property to be equal to the default isOpen value. 
        // This must use isOpen and NOT IsOpen since IsOpen isn't declared til after this function
        chocolateDoorAnimator.SetBool("IsOpen", isOpen);
    }

    /// <summary>
    /// Used to make setting the door animator property isOpen easier to change.
    /// 
    /// **Note: Must come after Start() otherwise it will not know what animator component is being referenced.**
    /// </summary>
    public bool IsOpen
    {
        get {
                return isOpen;
            }
        set {
                isOpen = value;
                chocolateDoorAnimator.SetBool("IsOpen", isOpen);
            }
    }

    // Update is called once per frame
    void Update()
    {
        chocolateDoorAnimator.SetBool("IsOpen", IsOpen);
    }
}
