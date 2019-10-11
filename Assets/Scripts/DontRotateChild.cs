using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontRotateChild : MonoBehaviour
{
    //https://answers.unity.com/questions/423031/how-do-i-set-a-child-object-to-not-rotate-if-the-p.html

    private Quaternion rotation;

    void Awake()
    {
        rotation = transform.rotation;
    }
    void LateUpdate()
    {
        transform.rotation = rotation;
    }
}
