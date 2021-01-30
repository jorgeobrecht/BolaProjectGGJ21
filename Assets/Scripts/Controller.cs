using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public bola player;
    public int winCount;
    public bool isPlaying;
    public bool isDead;


    public void PlayerWon()
    {
        // função para quando a condição de vitória for verdadeira
    }

    public void PlayerLost()
    {
        // função para quando a condição de derrota for verdadeira
    }

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
        winCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
