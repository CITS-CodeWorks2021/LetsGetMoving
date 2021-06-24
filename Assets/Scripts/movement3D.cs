using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement3D : MonoBehaviour
{
   
    Vector3 moveVector = Vector3.zero; // starts at (0,0,0)
    CharacterController controller;

    public float moveSpeed;
    public float jumpSpeed;
    public float gravity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //We use the GetAxis method to take in WASD and arrow key inputs
        moveVector.x = Input.GetAxis("Horizontal") * moveSpeed;
        moveVector.z = Input.GetAxis("Vertical") * moveSpeed;

       
        //if the spacebar is pressed and the player is on the ground
        if (controller.isGrounded && Input.GetButton("Jump"))
            moveVector.y = jumpSpeed;

        //smooths out the jump
        moveVector.y -= gravity * Time.deltaTime;

        //moves the player towards our newly valued vector
        controller.Move(moveVector * Time.deltaTime);

    }

}
