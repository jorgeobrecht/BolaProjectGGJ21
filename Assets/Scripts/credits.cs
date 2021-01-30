using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class credits : MonoBehaviour
{
    public GameObject creditos;
    string textoCreditos;
    Vector3 rollSpeed = new Vector3(0, 1f, 0);
    // Start is called before the first frame update
    void Start()
    {
        textoCreditos = "comi teu cu";
        creditos.GetComponent<Text>().text = textoCreditos;
    }

    // Update is called once per frame
    void Update()
    {
        creditos.transform.position += rollSpeed;

        if (creditos.transform.position.y >= 350)
            SceneManager.LoadScene("StartMenu");
    }
}
