using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Will be edited with the CustomEditorGUI
    public float speed = 500f;
    
    private Rigidbody playerBody;

    private float vertical;
    private float horizontal;

    private Vector3 velocity;

    private bool dashing = false;

    [SerializeField][Tooltip("How long the player will dash for")]
    private float dashTime = 0.1f;
    private float dashTimeCounter;

    [SerializeField][Tooltip("What speed sould be multiplied by while dashing")]
    private float dashSpeedMultiplyer = 10;

    [Tooltip("How long before the player can dash again")]
    public float dashCooldown = 3;
    public float dashCooldownTimer = 1.5f;

    private Vector3 dashVelocity;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();

        dashTimeCounter = dashTime;
        dashCooldownTimer = dashCooldown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Dash();
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

        if (!dashing)
            playerBody.velocity = velocity;
    }

    /// <summary>
    /// if dash is off cooldown, and the player is actually moving in a direction, dash when "Fire3" is pressed
    /// the dash will last for dashTime and the cooldown time will be dashCooldown
    /// </summary>
    private void Dash()
    {
        if (Input.GetButton("Fire3"))
        {
            if ((vertical != 0 || horizontal != 0) && !dashing && dashCooldownTimer >= dashCooldown)
            {
                dashing = true;
                dashTimeCounter = 0;
                dashVelocity = velocity.normalized * speed * Time.deltaTime * dashSpeedMultiplyer;
                /*jpost audio*/
                //play the dash sound
                PlayDashSound();
            }
        }

        if (dashing)
        {
            playerBody.velocity = dashVelocity;
            dashCooldownTimer = 0;
            dashTimeCounter += Time.deltaTime;

            if (dashTimeCounter >= dashTime)
                dashing = false;
        }
        else
        {
            if (dashCooldownTimer < dashCooldown)
                dashCooldownTimer += Time.deltaTime;
        }
    }

    /*jpost audio*/
    /// <summary>
    /// simple method to trigger the FMOD audio event for the player dash sound 
    /// </summary>
    private void PlayDashSound()
    {
        //play the dash event
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Player/Movement/play_cc_sx_game_plr_dash_test_01", GetComponent<Transform>().position);
    }
}
