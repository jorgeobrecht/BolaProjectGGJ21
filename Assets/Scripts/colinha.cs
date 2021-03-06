﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colinha : MonoBehaviour
{
    public bool vivo = true;
    public GameObject colaPrefab;
    public float cooldown;
    public float lastTiro=0;
    private BoxCollider2D colid;
    private bool achei = false;
    public Transform spawnpoint;

    private void Start()
    {
        colid = gameObject.GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        /*if (Time.time - lastTiro > cooldown) {
            atirarCola();
            lastTiro = Time.time;
        }*/
        
    }
    private void Morto()
    {
        vivo = false;
        colid.enabled = false;
    }
    public void atirarCola()
    {
        if (vivo && achei)
        {
            GameObject c = Instantiate(colaPrefab) as GameObject;
            c.transform.position = spawnpoint.position;
            c.transform.localScale = transform.localScale;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("oi");
        if (collision.tag == "ataque")
        {
            Debug.Log("ai");
            Morto();
            Destroy(gameObject);
        }
        if(collision.tag == "Player")
        {
            achei = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            achei = false; ;
        }
    }
}
