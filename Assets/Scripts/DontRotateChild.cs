using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontRotateChild : MonoBehaviour
{
    //https://answers.unity.com/questions/423031/how-do-i-set-a-child-object-to-not-rotate-if-the-p.html

    private Quaternion rotation;
    
    /// <summary>
    /// sets the initial rotation to (0,0,0) so we dont need to worry about roation issues
    /// </summary>
    void Awake()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        rotation = transform.rotation;
    }

    /// <summary>
    /// sets the rotation equal to the set rotation at the end of every frame
    /// </summary>
    void LateUpdate()
    {
        transform.rotation = rotation;
    }
}
