using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoAnda : MonoBehaviour
{
    public float dir;
    public float speed;
    private Rigidbody2D rbody;
    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();

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
        rbody.velocity = new Vector2(dir * speed, rbody.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "wall" || col.transform.tag == "enemy")
        {
            dir = -dir;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "victory")
        {
            dir = -dir;
        }
    }
}
