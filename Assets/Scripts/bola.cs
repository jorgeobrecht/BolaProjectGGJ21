using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola : MonoBehaviour
{
    private Rigidbody2D rbody;
    private float dir;
    public float acel;
    public float maxSpeed;
    private bool jump = false;
    public bool grounded = false;
    public float jumpForce ;
    public float fallWeight = 10;
    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
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
        float finalSpeed = dir * acel;

        if (dir == 0)
            rbody.velocity = new Vector2(0, rbody.velocity.y);

        if (finalSpeed >= maxSpeed) finalSpeed = maxSpeed;
       
            rbody.AddForce(new Vector2(finalSpeed, 0));
        
        if (finalSpeed == maxSpeed) Debug.Log("max");

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

    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "ground")
        {
            grounded = false;
        }
    }
}
