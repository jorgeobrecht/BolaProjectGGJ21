using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timeLimit : MonoBehaviour
{
    
    public float limit = 5.0f;
    
    public Vector3 anglestoRotate;
    

    private void Update()
    {

        /* if (Time.time == limit)
         {
             GameOver();
         }*/

        limit -= Time.deltaTime;
        if (limit <= 0)
            GameOver();
    }

    private void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}


