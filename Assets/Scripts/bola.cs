﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola : MonoBehaviour
{
    private Rigidbody2D rbody;
    private SpriteRenderer srender;
    private float dir;
    public float acel;
    public float maxSpeed;
    public float speed;
    private bool jump = false;
    public bool grounded = false;
    public float jumpForce ;
    public float fallWeight = 10;
    public bool isAlive;
    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
        srender = gameObject.GetComponent<SpriteRenderer>();
        isAlive = true;
    }
    void Update()
    {
        dir = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown("space"))
        {
            jump = true;
        }

    }

    private void MovePlayer()
    {
        //lados
        
        speed = rbody.velocity.x;
        if (Mathf.Abs(speed) < maxSpeed)
            rbody.AddForce(new Vector2(dir * acel, 0));

        if (Mathf.Abs(speed) == maxSpeed) Debug.Log("max");

        //pulo
        if (jump && grounded)
        {
            rbody.AddForce(new Vector2(0, jumpForce));
            grounded = false;
            jump = false;
        }
        if (!grounded)
        {
            if(rbody.velocity.y <= 0)
            {
                rbody.AddForce(new Vector2(0,-fallWeight));
            }
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.transform.tag == "ground")
        {
            grounded = true;
        }
        if(col.transform.tag == "enemy" && isAlive)
        {
            Debug.Log("perdeu");
            acel = 0;
            srender.color = Color.black;
            isAlive = false;
        }

    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "ground")
        {
            grounded = false;
        }
        
    }
}
