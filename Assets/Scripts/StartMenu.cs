using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    
    public void LoadLevel()
    {
        SceneManager.LoadScene("SampleScene2");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
