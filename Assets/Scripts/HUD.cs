using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public PlayerController player;
    public Text gotas;
    public Text vida;

    public void updateGotasCounter(int n)
    {
        gotas.text = "gotinhass: " + n + "/" + GameController.Instance.maxGotas;
    }


    // Start is called before the first frame update
    void Start()
    {
        gotas.text = "gotinhass: " + GameController.Instance.playerGotas + "/" + GameController.Instance.maxGotas; 
        vida.text = "vidas: " + player.vida + "/ 10";
        
    }

    void Update()
    {
        vida.text = "vidas: " + player.vida + "/ 10";
    }

}