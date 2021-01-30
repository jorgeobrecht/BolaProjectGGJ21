using System.Collections;
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

    void getInput()
    {

        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.z += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.z -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }


        transform.position = pos;

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
        //lados
        speed = rbody.velocity.x;
        if (Mathf.Abs(speed) < maxSpeed)
            rbody.AddForce(new Vector2(dir * acel, 0), ForceMode2D.Impulse);

        //if (Mathf.Abs(speed) == maxSpeed) Debug.Log("max");

        //pulo
        if (jump && grounded)
        {
            rbody.AddForce(new Vector2(0, jumpForce),ForceMode2D.Impulse);
            grounded = false;
            jump = false;
        }
        if (!grounded)
        {
            if(rbody.velocity.y <= 0)
            {
                rbody.AddForce(new Vector2(0,-fallWeight),ForceMode2D.Impulse);
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
