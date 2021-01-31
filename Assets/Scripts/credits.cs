using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class credits : MonoBehaviour
{
    public GameObject creditos;
    public int altura;
    string textoCreditos;

    Vector3 rollSpeed = new Vector3(0, 2f, 0);
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

        if (creditos.transform.position.y >= altura)
            SceneManager.LoadScene("StartMenu");
    }
}
