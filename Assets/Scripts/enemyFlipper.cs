using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFlipper : MonoBehaviour
{
    private inimigoAnda inimigo;
    void Start()
    {
        inimigo = gameObject.GetComponentInParent<inimigoAnda>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag =="ground")
        {
            inimigo.Flip();
        }
    }
}
