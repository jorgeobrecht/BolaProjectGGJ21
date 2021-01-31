using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    
    public Transform bola;
    public float altura;
    public Vector3 v;

    // Start is called before the first frame update
    void Start()
    {
        altura = bola.position.y;
        v = new Vector3(bola.position.x, altura, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        v.x = bola.position.x;
        if(bola.position.y > 12)
            v.y = altura + (bola.position.y - 12);

        transform.position = v;
    }
}
