using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class credits : MonoBehaviour
{
    public RectTransform parentCanvas;
    public GameObject creditos;
    public int altura;
    string textao;

    Vector3 rollSpeed = new Vector3(0, 1f, 0);
    // Start is called before the first frame update
    void Start()
    {
        //parentCanvas = 
        //    GetComponentInParent<RectTransform>();


        creditos.transform.position = new Vector3(0, -parentCanvas.rect.height, 0);
        
        textao =
            "fez o jogo\t\t\t\t\t\tBRUMACH\n\n" +
            "tunez\t\t\t\t\t\t\t\tneg\n\n" +
            "twitch prime\t\t\t\t\t\tProliel\n\n" +
            "ceo bola\t\t\t\t\t\t\t\t\tCyberTwilight\n\n" +
            "tava na cara\t\t\t\t\tJorgeObrete\n\n" +
            "perae,repete\t\t\t\t\tleo\n\n" +
            "best chefe\t\t\t\tlukeLionRoze\n\n" +
            "\n\n\n\n\n\n\n\n\n\n\nPress any key" ;

        creditos.GetComponent<Text>().text = textao;
    }

    // Update is called once per frame
    void Update()
    {
        creditos.transform.position += rollSpeed;
        if(Input.anyKey)
            SceneManager.LoadScene("StartMenu");
        //if (creditos.transform.position.y >= altura)
        //SceneManager.LoadScene("StartMenu");
    }
}
