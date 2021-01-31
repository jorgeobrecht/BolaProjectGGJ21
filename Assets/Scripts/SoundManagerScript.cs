using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip WalkSound1, WalkSound2, JumpSound, KillSound, OpenFloatSound, DamageSound, DefenseSound, CollectableSound, FloatSound1, FloatSound2, AttackSound, DeathSound, VictorySound, OpenMenuSound, MenuCursorSound1, MenuCursorSound2, MenuCursorSound3;
    static AudioSource audioSrc;
        
    // Start is called before the first frame update
    void Start()
    {
        WalkSound1 = Resources.Load<AudioClip>("walk 1 (new)");
        WalkSound2 = Resources.Load<AudioClip>("walk 2 (new)");
        JumpSound = Resources.Load<AudioClip>("jump (new)");
        OpenFloatSound = Resources.Load<AudioClip>("open float (new)");
        FloatSound1 = Resources.Load<AudioClip>("floating 1 (new)");
        FloatSound2 = Resources.Load<AudioClip>("floating 2 (new)");
        AttackSound = Resources.Load<AudioClip>("Schlap novo");
        DeathSound = Resources.Load<AudioClip>("death sound (new)");
        VictorySound = Resources.Load<AudioClip>("victory jingle (new)");
        OpenMenuSound = Resources.Load<AudioClip>("start (new)");
        DamageSound = Resources.Load<AudioClip>("damage");
        DefenseSound = Resources.Load<AudioClip>("defense");
        CollectableSound = Resources.Load<AudioClip>("collectable");
        MenuCursorSound1 = Resources.Load<AudioClip>("menu cursor 1 (new)");
        MenuCursorSound2 = Resources.Load<AudioClip>("menu cursor 2 (new)");
        MenuCursorSound3 = Resources.Load<AudioClip>("menu cursor 3 (new)");
        KillSound = Resources.Load<AudioClip>("kill");

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
            case "kill":
                audioSrc.PlayOneShot(KillSound);
                break;
            case "Jump":
                audioSrc.PlayOneShot(JumpSound);
                break;
            case "damage":
                audioSrc.PlayOneShot(DamageSound);
                break;
            case "defense":
                audioSrc.PlayOneShot(DefenseSound);
                break;
            case "collectable":
                audioSrc.PlayOneShot(CollectableSound);
                break;
            case "OpenFloat":
                audioSrc.PlayOneShot(OpenFloatSound);
                break;
            case "Float":
                audioSrc.PlayOneShot(FloatSound1);
                break;
            case "Float1":
                audioSrc.PlayOneShot(FloatSound2);
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
                audioSrc.PlayOneShot(MenuCursorSound1);
                break;
            case "MenuCursor1":
                audioSrc.PlayOneShot(MenuCursorSound2);
                break;
            case "MenuCursor2":
                audioSrc.PlayOneShot(MenuCursorSound3);
                break;
            case "Walk2":
                audioSrc.PlayOneShot(WalkSound2);
                break;
        }

    }


}
