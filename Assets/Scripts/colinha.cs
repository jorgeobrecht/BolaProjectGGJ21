using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colinha : MonoBehaviour
{
    public Transform Colinha;
    public GameObject colaPrefab;
    public float cooldown;
    public float lastTiro=0;
   
    void Update()
    {
        if (Time.time - lastTiro > cooldown) {
            atirarCola();
            lastTiro = Time.time;
        }
        
    }
    public void atirarCola()
    {
        GameObject c = Instantiate(colaPrefab) as GameObject;
        c.transform.position = Colinha.transform.position;
        c.transform.localScale = Colinha.transform.localScale;
    }
}
