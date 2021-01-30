using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timeLimit : MonoBehaviour
{

    public float limit = 5.0f;


    private void Update()
    {
        if (Time.timeSinceLevelLoad > limit)
        {
            GameController.PlayerLost();

        }


    }
}


