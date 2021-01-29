using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola : MonoBehaviour
{
    private Rigidbody2D rbody;
    private float dir;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        rbody.AddForce(new Vector2(dir * speed, 0));

    }
}
