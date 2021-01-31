using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{

    public Text gotas;
    public Text vida;

    public void updateGotasCounter(int n)
    {
        gotas.text = "gotinhass: " + n;
    }

    // Start is called before the first frame update
    void Start()
    {
        gotas.text = "gotinhass: " + GameController.Instance.playerGotas;
        vida.text = "vida: tua vida é uma merda";
    }



}