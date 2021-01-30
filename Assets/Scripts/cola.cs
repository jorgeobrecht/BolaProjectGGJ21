using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cola : MonoBehaviour
{
    public float speed = 50.0f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed*transform.localScale.x, 0);
    }

  
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D col)
    {
            Destroy(this.gameObject);

    }

}
