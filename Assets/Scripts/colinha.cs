using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colinha : MonoBehaviour
{
    public bool vivo = true;
    public GameObject colaPrefab;
    public float cooldown;
    public float lastTiro=0;
    private BoxCollider2D colid;

    private void Start()
    {
        colid = gameObject.GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (Time.time - lastTiro > cooldown) {
            atirarCola();
            lastTiro = Time.time;
        }
        
    }
    private void Morto()
    {
        vivo = false;
        colid.enabled = false;
    }
    public void atirarCola()
    {
        if (vivo)
        {
            GameObject c = Instantiate(colaPrefab) as GameObject;
            c.transform.position = transform.position;
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
    }
}
