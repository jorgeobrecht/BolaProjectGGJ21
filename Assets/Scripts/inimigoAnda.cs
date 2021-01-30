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
        dir = Random.Range(-1, 1);
    }
    void Update()
    {
        if (dir == 0) dir = 1;
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
        if(col.transform.tag == "wall")
        {
            dir = -dir;
        }
    }
}
