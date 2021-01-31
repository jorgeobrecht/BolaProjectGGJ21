using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    int n = 0;
    

    public void EnterSound()
    {
        n = (int)Random.Range(0, 3);
        if (n != 0)
            SoundManagerScript.PlaySound("MenuCursor" + n);
        else
            SoundManagerScript.PlaySound("MenuCursor");
        //SoundManagerScript.PlaySound("Attack");
        Debug.Log(n);
        
    }
}
