using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

 public class GameController : MonoBehaviour
{
    
    public static int winCount;
    public static bool isPlaying;
    public static bool isDead;

    public static void PlayerWon()
    {
        // função para quando a condição de vitória for verdadeira
        Debug.Log("Player won");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name) ;
    }

    public static void PlayerLost()
    {
        // função para quando a condição de derrota for verdadeira
        Debug.Log("Player lost");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    static void Start()
    {
        isPlaying = true;
        winCount = 0;
    }

    // Update is called once per frame
    static void Update()
    {
        
    }
}
