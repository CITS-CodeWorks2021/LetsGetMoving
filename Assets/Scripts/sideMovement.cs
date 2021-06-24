using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideMovement : MonoBehaviour
{
    Rigidbody2D body;

    private float horizontal;
    private bool jumpCheck;
    private bool isGrounded;

    public float moveSpeed;
    public float jumpSpeed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        jumpCheck = false;
    }

    void Update()
    {
        //Here we only want to take in input from the AD keys or left right arrows
        horizontal = Input.GetAxisRaw("Horizontal");    
        
        //Check for W or Up arrow
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            jumpCheck = true;
        
    }

    void FixedUpdate()
    {
        //regular movement
        body.velocity = new Vector2(horizontal * moveSpeed, body.velocity.y);

        //If the player has activated a jump, and they are on the ground
        if (jumpCheck && isGrounded)
        {
            Vector2 movement = new Vector2(body.velocity.x, jumpSpeed);
            body.velocity = movement;
            jumpCheck = false;
        }
    }

    //This method is triggered when the player collides with another collider
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
            isGrounded = true;
    }

    //This method is triggered when the player leaves a collison with another collider
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
            isGrounded = false;
    }

}
