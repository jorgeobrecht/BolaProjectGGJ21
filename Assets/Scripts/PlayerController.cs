using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rbody;
    private SpriteRenderer srender;
    private float dir;
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

    void getInput()
    {
        dir = (Input.GetAxisRaw("Horizontal"));
        if (Input.GetKeyDown("space"))
        {
            jump = true;
        }
            
    }

    void Update()
    {
        if(isAlive)
            getInput();

    }

    private void MovePlayer()
    {
        rbody.velocity = new Vector2(dir * speed, rbody.velocity.y);    

        //pulo
        if (jump && grounded)
        {
            rbody.AddForce(new Vector2(0, jumpForce));
            grounded = false;
            jump = false;
        }
    /*   if (!grounded)
        {
            if(rbody.velocity.y <= 0)
            {
                rbody.AddForce(new Vector2(0,-fallWeight));
            }
        }*/
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
            srender.color = Color.black;
            isAlive = false;
            GameController.PlayerLost();
        }


    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "ground")
        {
            grounded = false;
        }
        
    }

    // GANHOU
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.transform.tag == "victory")
        {
            GameController.PlayerWon();
                       
        }
    }

}
