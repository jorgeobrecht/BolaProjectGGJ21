using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola : MonoBehaviour
{
    private Rigidbody2D rbody;
    private float dir;
    public float speed;
    public bool jump = false;
    public bool grounded = false;
    public float jumpForce;
    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        groundcheck();
        dir = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown("space")&& grounded)
        {
            jump = true;
        }
    }
    private void FixedUpdate()
    {
        rbody.AddForce(new Vector2(dir * speed, 0));
        if(jump)
        {
            rbody.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }
    }
    private void groundcheck()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity);
        Debug.DrawRay(transform.position, (Vector3.down)*6, Color.red);
        if (hit.distance < 6)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
}
