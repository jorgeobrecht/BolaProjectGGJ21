using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    int n = 0;
    

    public void EnterSound()
    {
        
        SoundManagerScript.PlaySound("MenuCursor" + ((n+1)%3+1));
        Debug.Log("aasdfas");
        
    }
}
