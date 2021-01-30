using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private PlayerController player;
    void Start()
    {
        player = gameObject.GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        //groundcheck
        if (col.transform.tag == "ground")
        {
            player.anim.SetBool("air", false);
            player.grounded = true;
            player.hovering = false;
            player.hover = true;
            player.jump = false;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        //groundcheck
        if (col.transform.tag == "ground")
        {
            player.anim.SetBool("air", true);
            player.grounded = false;
        }
    }
}
