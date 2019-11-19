using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Scott Little
/// 
/// Purpose:
///     This script's sole purpose is to test the animations for the Chocolate Double Door Object.
/// </summary>
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
        chocolateDoorAnimator.SetBool("isOpen", isOpen);
    }

    /// <summary>
    /// Used to make setting the door animator property isOpen easier to change.
    /// 
    /// **Note: Must come after Start() otherwise it will not know what animator component is being referenced.**
    /// </summary>
    public bool IsOpen
    {
        get {
                isOpen = chocolateDoorAnimator.GetBool("isOpen");
                return isOpen;
            }
        set { chocolateDoorAnimator.SetBool("isOpen", value); }
    }

    // Update is called once per frame
    void Update()
    {
        if(IsOpen == true)
            chocolateDoorAnimator.SetBool("isOpen", IsOpen);
        else if (IsOpen == false)
            chocolateDoorAnimator.SetBool("isOpen", IsOpen);
    }
}
