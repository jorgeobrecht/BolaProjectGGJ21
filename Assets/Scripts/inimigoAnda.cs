using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoAnda : MonoBehaviour
{
    public float speed;
    public float deathForce;
    public bool vivo = true;
    private Rigidbody2D rbody;
    private BoxCollider2D colid;
    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
        colid = gameObject.GetComponent<BoxCollider2D>();

    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        rbody.velocity = new Vector2(transform.localScale.x * speed, rbody.velocity.y);
    }
    public void Flip()
    {
        if (vivo)
        {
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "wall" || col.transform.tag == "enemy")
        {
            Flip();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "victory")
        {
            Flip();
        }
        if (collision.tag == "ataque")
        {
            
            Morto();
        }
    }
    private void Morto()
    {
        Debug.Log("boy");
        vivo = false;
        speed = 0;
        transform.localScale = new Vector3(1, -1, 1);
        rbody.AddForce(Vector2.up * deathForce);
        colid.enabled = false;
    }
    private void OnBecameInvisible()
    {
        if(!vivo)
        {
            Destroy(gameObject);
        }
    }
}
