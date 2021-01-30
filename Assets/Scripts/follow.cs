using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    
    public Transform bola;
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
<<<<<<< HEAD
        v.y = bola.position.y+6;
        //transform.LookAt(bola);
=======
        v.y = bola.position.y;
>>>>>>> 1f7f6f415a4b37eefe661457f19c2b7ac8bac879
        transform.position = v;
    }
}
