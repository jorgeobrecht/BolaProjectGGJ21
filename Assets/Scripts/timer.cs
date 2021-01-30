using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour

    
{

    public float limit=5f;
    public Vector3 anglestoRotate;
    int interval = 1;
    float nextTime = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextTime) {
            
            this.transform.Rotate(0, 0, 360/limit);

            nextTime += interval;

        }
        
;    }
}
