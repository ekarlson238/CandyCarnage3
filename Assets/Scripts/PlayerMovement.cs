using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Will be edited with the CustomEditorGUI
    [HideInInspector]
    public float speed = 500f;
    
    private Rigidbody playerBody;

    private float vertical;
    private float horizontal;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /// <summary>
    /// The player moves by setting their rigidbody's velocity rather than using transform.translate or addForce
    /// </summary>
    private void Move()
    {
        velocity = playerBody.velocity;

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        velocity.z = vertical * speed * Time.deltaTime;
        velocity.x = horizontal * speed * Time.deltaTime;

        playerBody.velocity = velocity;
    }
}
