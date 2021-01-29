using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola : MonoBehaviour
{
    private Rigidbody2D rbody;
    private float dir;
    public float speed;
    private bool jump = false;
    public bool grounded = false;
    public float jumpForce = 300;
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
    private void FixedUpdate()
    {
        rbody.AddForce(new Vector2(dir * speed, 0));
        if(jump && grounded)
        {
            rbody.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }
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
