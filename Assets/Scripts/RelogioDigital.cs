using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelogioDigital : MonoBehaviour
{
    public float limit;
    private bool perdeu = false;
    int segundos;
    string relogio;

    

    private void Update()
    {



        //this.transform.Rotate(0, 0, (-360 / limit) * Time.deltaTime);
        if (Time.timeSinceLevelLoad >= limit && !perdeu)
        {
            
            GameController.Instance.PlayerLost();
            perdeu = true;

        }

        segundos = (int)(limit - Time.timeSinceLevelLoad);

        relogio = (segundos / 60) + ":" + segundos % 60;

        GetComponent<Text>().text = relogio;

    }
}
