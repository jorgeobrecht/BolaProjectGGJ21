using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip WalkSound1, WalkSound2, JumpSound, OpenFloatSound, FloatSound, AttackSound, DeathSound, VictorySound, OpenMenuSound, MenuCursorSound;
    static AudioSource audioSrc;
        
    // Start is called before the first frame update
    void Start()
    {
        WalkSound1 = Resources.Load<AudioClip>("walk 1 (placeholder)");
        WalkSound2 = Resources.Load<AudioClip>("walk 2 (placeholder)");
        JumpSound = Resources.Load<AudioClip>("jump (placeholder)");
        OpenFloatSound = Resources.Load<AudioClip>("open float (placeholder)");
        FloatSound = Resources.Load<AudioClip>("float sound (placeholder)");
        AttackSound = Resources.Load<AudioClip>("Attack (placeholder)");
        DeathSound = Resources.Load<AudioClip>("death sound (placeholder)");
        VictorySound = Resources.Load<AudioClip>("victory sound (place holder)");
        OpenMenuSound = Resources.Load<AudioClip>("Open Menu(placeholder)");
        MenuCursorSound = Resources.Load<AudioClip>("menu cursor (place holder)");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public static void PlaySound (string clip)
    {
        switch (clip){
            case "Walk1":
                audioSrc.PlayOneShot(WalkSound1);
                break;
            case "Jump":
                audioSrc.PlayOneShot(JumpSound);
                break;
            case "OpenFloat":
                audioSrc.PlayOneShot(OpenFloatSound);
                break;
            case "Float":
                audioSrc.PlayOneShot(FloatSound);
                break;
            case "Attack":
                audioSrc.PlayOneShot(AttackSound);
                break;
            case "Death":
                audioSrc.PlayOneShot(DeathSound);
                break;
            case "Victory":
                audioSrc.PlayOneShot(VictorySound);
                break;
            case "OpenMenu":
                audioSrc.PlayOneShot(OpenMenuSound);
                break;
            case "MenuCursor":
                audioSrc.PlayOneShot(MenuCursorSound);
                break;
            case "Walk2":
                audioSrc.PlayOneShot(WalkSound2);
                break;
        }

    }


}
