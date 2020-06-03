using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    // Variables to allow our robot to move left and right
    public float maxSpeed = 2f;                     // Maximum speed for robot
    private float move = 0f;                        // Value to hold if our robot is moving
    private bool facingLeft = true;                 // Value to represent if we are facing left or right
    private Animator anim;                          // Value to represent our Animator
    private Rigidbody2D myRigidbody;                // Value to represent our rigidbody

    // Variables to allow our robot to jump from ground layers
    public float jumpForce;                         // Jump force for robot
    public Transform groundCheckPoint;              // Part of the robot this would be grounded 
    public float groundCheckRadius;                 // Radius around the check point, to ensure it is touching the ground
    public LayerMask groundLayer;                   // To check if the player is on the 'ground'
    private bool isTouchingGround = false;          

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();              //Set to our Animator component
        myRigidbody = GetComponent<Rigidbody2D>();    //Set to our RigidBody component
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if the robot is on the ground or not
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        move = Input.GetAxis("Horizontal");         //Gives a value of (up to) 1/-1, if player is being moved left or right

        if (move > 0f) // Check if player is moving left
        {
            //move the players rigid body
            myRigidbody.velocity = new Vector2(move * maxSpeed, myRigidbody.velocity.y);
            if (!facingLeft)
            {
                Flip();         
            }
        }
        else if (move < 0f) // Or of Player is moving right
        {
            myRigidbody.velocity = new Vector2(move * maxSpeed, myRigidbody.velocity.y);
            if (facingLeft)
            {
                Flip();     
            }
        }

        // Check if Robot can jump
        if (Input.GetButtonDown("Jump") && isTouchingGround) 
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
        }

        //set parameters to animate the Robot
        anim.SetFloat("Speed", Mathf.Abs(move));                // Robot drive
        anim.SetFloat("vSpeed", myRigidbody.velocity.y);        // Robot jump
        anim.SetBool("Ground", isTouchingGround);               // Robot idle

    }

    // If we are moving right, but not facing right - flips to face moving way
    void Flip()
    {
        facingLeft = !facingLeft;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}