using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //objetos
    private Rigidbody2D rbody;
    private SpriteRenderer srender;
    private Animator anim;
    //movimento
    private float dir;
    public float speed;
    //pulo
    private bool jumpDown = false;
    public bool jump = false;
    public bool grounded = false;
    public bool hovering = false;
    public bool hover = false;
    public float jumpForce;
    public float fallWeight = 10;
    public float gScale;
    public float hoverGrav;
    //combate
    private bool attack = false;
    private bool canMove = true;
    private bool Block = false;
    //info jogo
    public bool isAlive;



    void Start()
    {
        
        rbody = gameObject.GetComponent<Rigidbody2D>();
        srender = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        rbody.gravityScale = gScale;
        isAlive = true;
    }
    void Update()
    {
        if (isAlive)
            getInput();
        AttackControl();
        BlockControl();

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    //receber informação do teclado
    void getInput()
    {
        if (canMove)
        {
            //info movimento
            dir = (Input.GetAxisRaw("Horizontal"));
            if (Input.GetKeyDown("space"))
            {
                jump = true;
            }
            if (Input.GetKey("space"))
            {
                jumpDown = true;
            }
            else
            {
                jumpDown = false;
            }
            //info ataque
            if (Input.GetKeyDown(KeyCode.Z))
            {
                attack = true;
                Debug.Log("ataquei");
            }
        }
    }
    private void MovePlayer()
    {

        //movimento
        rbody.velocity = new Vector2(dir * speed, rbody.velocity.y);
        //FLIP
        if(dir != transform.localScale.x && dir != 0)
        {
            transform.localScale = new Vector2(dir, 1);
        }
        //pulo
        if (jump)
        {
            if (grounded)
            {
                rbody.velocity = (new Vector2(rbody.velocity.x, jumpForce));
                grounded = false;
                jump = false;
            }
            else if(!grounded && hover)
            {
                rbody.velocity = (new Vector2(rbody.velocity.x, jumpForce));
                hover = false;
                hovering = true;
            }
        }
        if(hovering && jumpDown && rbody.velocity.y < 0)
        {
            rbody.gravityScale = hoverGrav;
        }
        else
        {
            rbody.gravityScale = gScale; 
        }
    }

    private void AttackControl()
    {
        if (attack)
        {

        }
    }
    private void BlockControl()
    {

    }
    private void OnCollisionStay2D(Collision2D col)
    {
        
        //check colisão com inimigo
        if(col.transform.tag == "enemy" && isAlive)
        {
            Debug.Log("perdeu");
            srender.color = Color.black;
            isAlive = false;
        }


    }
    // GANHOU
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        //check de vitoria
        if (collision.transform.tag == "victory")
        {
            GameController.PlayerWon();  
        }
    }

}
