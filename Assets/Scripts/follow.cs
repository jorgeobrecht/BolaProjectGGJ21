using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    
    public Transform bola;
    public float altura;
    public float xOffset;
    private float xBarreira;
    public Vector3 v;
    public Transform barreira;

    // Start is called before the first frame update
    void Start()
    {
        xBarreira = barreira.position.x;
        altura = bola.position.y;
        v = new Vector3(xBarreira + xOffset, altura, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(bola.position.x > xBarreira + xOffset)
            v.x = bola.position.x;
        if(bola.position.y > 12)
            v.y = altura + (bola.position.y - 12);

        transform.position = v;
    }
}
