using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour

    
{


    int interval = 1;
    public float nextTime = 0;

    private timeLimit timelimit;

    float timeLimit;

    // Start is called before the first frame update
    void Start()
    {
        timelimit = GameObject.Find("Ponteiro").GetComponent<timeLimit>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
             
            this.transform.Rotate(0, 0, (-360/timelimit.limit)*Time.deltaTime);
            
        
;    }
}
