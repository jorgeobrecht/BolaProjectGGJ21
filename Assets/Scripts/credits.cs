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
    public Text textao;

    Vector3 rollSpeed = new Vector3(0, 1f, 0);
    // Start is called before the first frame update
    void Start()
    {
        transform.position -= new Vector3(0, 400, 0);
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
