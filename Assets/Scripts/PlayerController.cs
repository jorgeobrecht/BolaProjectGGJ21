using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //objetos
    private Rigidbody2D rbody;
    private SpriteRenderer srender;
    public Animator anim;
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
    private bool block = false;
    public float blockCd;
    private float lastShield;
    //info jogo
    public bool isAlive;
    private bool tictac = false;
    public int vida = 10;


    #region START, UPDATE e FIXED UPDATE
    void Start()
    {
        
        rbody = gameObject.GetComponent<Rigidbody2D>();
        srender = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        rbody.gravityScale = gScale;
        isAlive = true;
        lastShield = -2*blockCd;
    }
    void Update()
    {
        if (isAlive)
            getInput();
        AttackControl();
        BlockControl();
        AnimationControl();

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    #endregion

    #region INPUT E MOVIMENTO
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
                hovering = false;
                jumpDown = false;
                anim.SetBool("float", false );
            }
            //info ataque
            if (Input.GetKeyDown(KeyCode.Z))
            {
                attack = true;
                Debug.Log("ataquei");
            }
            if (Input.GetKeyDown(KeyCode.X) && (Time.time - lastShield) > blockCd)
            {
                block = true;
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
                anim.SetTrigger("jump");
                SoundManagerScript.PlaySound("Jump");
            }
            else if(!grounded && hover)
            {
                rbody.velocity = (new Vector2(rbody.velocity.x, jumpForce));
                hover = false;
                hovering = true;
                anim.SetBool("float", true);
                anim.SetTrigger("jump");
                SoundManagerScript.PlaySound("OpenFloat");
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
    #endregion

    #region ATAQUE e BLOCK
    private void AttackControl()
    {
        if (attack)
        {
            anim.SetTrigger("attack");
            SoundManagerScript.PlaySound("OpenFloat");
            attack = false;
        }
    }
    public void Freeze()
    {
        dir = 0;
        canMove = false;
        
    }
    private void BlockControl()
    {

        if (block && (Time.time - lastShield) > blockCd )
        {
            lastShield = Time.time;
            anim.SetTrigger("block");
            SoundManagerScript.PlaySound("Attack");
            block = false;
        }
        //mostrar cooldown
        if(lastShield + blockCd > Time.time)
        {

        }
    }
    #endregion

    #region ANIMAÇÂO E SOM
    public void Move()
    {
        canMove = true;
    }
    private void AnimationControl()
    {
        //animação de andar
        if(grounded && dir != 0)
        {
            anim.SetBool("walking", true);
            
        }
        else
        {
            anim.SetBool("walking", false);

        }
    }
    
    public void WalkSound()
    {
        if(tictac)
        {
            tictac = !tictac;
            SoundManagerScript.PlaySound("Walk1");
        }
        else
        {
            tictac = !tictac;
            SoundManagerScript.PlaySound("Walk2");
        }
    }
    #endregion

    #region COLLISIONS
    private void OnCollisionStay2D(Collision2D col)
    {        
        //check colisão com inimigo
        if(col.transform.tag == "enemy" )
        {
            vida-=1;
            if (vida == 0 && isAlive)
            {
                GameController.Instance.PlayerLost();
            }
        }


    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "enemy")
        {
            vida-=1;
            if (vida == 0 && isAlive)
            {
                GameController.Instance.PlayerLost();
            }
        }
    }
    // GANHOU
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check de vitoria
        if (collision.transform.tag == "victory" && isAlive)
        {
            GameController.Instance.PlayerWon();
        }
        if (collision.transform.tag == "enemy")
        {
            vida-=1;
            if (vida == 0 && isAlive)
            {
                GameController.Instance.PlayerLost();
            }
        }
        if (collision.transform.tag == "collectable" && isAlive)
        {
            collision.gameObject.SetActive(false);
            GameController.Instance.GetGota();
        }
    }
    #endregion
}
