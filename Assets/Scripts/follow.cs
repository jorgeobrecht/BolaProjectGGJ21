﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    
    public Transform bola;
    public int altura = 9;
    public Vector3 v;

    // Start is called before the first frame update
    void Start()
    {
        v = new Vector3(bola.position.x, bola.position.y, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        v.x = bola.position.x;
        if(bola.position.y > 20)
            v.y = altura + bola.position.y/2;

        transform.position = v;
    }
}
