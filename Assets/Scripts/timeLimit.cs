using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timeLimit : MonoBehaviour
{

    public float limit;


    private void Update()
    {

        this.transform.Rotate(0, 0, (-360 / limit) * Time.deltaTime);
        if (Time.timeSinceLevelLoad > limit)
        {
            GameController.PlayerLost();

        }


    }
}


