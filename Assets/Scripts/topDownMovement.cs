using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topDownMovement : MonoBehaviour
{

    Rigidbody2D body;

    private float horizontal;
    private float vertical;

    public float speed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //We use the GetAxis method to take in WASD and arrow key inputs
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    //Good practice to have any physics related operations in fixedUpdate,
    //as physics are updated immediately after this method (not the case with Update)
    private void FixedUpdate()
    {
        //add velocity in the direction of the movement keys being pressed
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }



}
