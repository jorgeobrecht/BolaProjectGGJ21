using System;
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
    public float invTime;
    public float BackX;
    public float BackY;
    private float BDir;
    //info jogo
    public bool isAlive;
    private bool tictac = false;
    public int vida = 3;
    Renderer rend;
    Color c;


    #region START, UPDATE e FIXED UPDATE
    void Start()
    {
        
        rbody = gameObject.GetComponent<Rigidbody2D>();
        srender = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        rbody.gravityScale = gScale;
        isAlive = true;
        lastShield = -2*blockCd;
        rend = GetComponent<Renderer>();
        c = rend.material.color;
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
        if (canMove)
        {
            //movimento
            rbody.velocity = new Vector2(dir * speed, rbody.velocity.y);
            //FLIP
            if (dir != transform.localScale.x && dir != 0)
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
                else if (!grounded && hover)
                {
                    rbody.velocity = (new Vector2(rbody.velocity.x, jumpForce));
                    hover = false;
                    hovering = true;
                    anim.SetBool("float", true);
                    anim.SetTrigger("jump");
                    SoundManagerScript.PlaySound("OpenFloat");
                }
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
        rbody.velocity = new Vector2(0, rbody.velocity.y);
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
    /*private void OnCollisionStay2D(Collision2D col)
    {        
        //check colisão com inimigo
        if(col.transform.tag == "enemy" )
        {
           Dano();
        }


    }*/
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "enemy")
        {
            BDir = Math.Sign(transform.position.x - col.transform.position.x);
            Dano();
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
            BDir = Math.Sign(transform.position.x - collision.transform.position.x);
            Dano();
        }
        if (collision.transform.tag == "collectable" && isAlive)
        {
            collision.gameObject.SetActive(false);
            GameController.Instance.GetGota();
        }
    }
    private void Dano()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("playerShield"))
        {
            vida -= 1;
            if (vida == 0 && isAlive)
            {
                GameController.Instance.PlayerLost();
            }
            if (vida >= 1)
            {
                StartCoroutine("GetInvulnerable");
                canMove = false;
                rbody.velocity = new Vector2(BackX * BDir, BackY);
            }
        }
    }

    IEnumerator GetInvulnerable()
    {
        Physics2D.IgnoreLayerCollision(0, 8, true);
        Physics2D.IgnoreLayerCollision(0, 9, true);
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(0.5f);
        canMove = true;
        yield return new WaitForSeconds(invTime);

        Physics2D.IgnoreLayerCollision(0, 8, false);
        Physics2D.IgnoreLayerCollision(0, 9, false);
        c.a = 1f;
        rend.material.color = c;

    }
    #endregion

}
