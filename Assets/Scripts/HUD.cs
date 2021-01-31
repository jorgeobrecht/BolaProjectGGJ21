using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public PlayerController player;
    public Text gotas;
    public Text vida;
    public int maxVida;

    public void updateGotasCounter(int n)
    {
        gotas.text = ":  " + n + "/" + GameController.Instance.maxGotas;
    }


    // Start is called before the first frame update
    void Start()
    {
        gotas.text = ":  " + GameController.Instance.playerGotas + "/" + GameController.Instance.maxGotas; 
        vida.text = ":  " + player.vida + "/" + maxVida;
        
    }

    void Update()
    {
        vida.text = ":  " + player.vida + "/" + maxVida ;
    }

}