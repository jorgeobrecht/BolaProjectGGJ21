using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

 public class GameController : MonoBehaviour
{
    
    public static int winCount;
    public static bool isPlaying;
    public static bool isDead;
    public static bool isPaused;
    public GameObject pauseMenu;

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
    void Start()
    {
        isPlaying = true;
        isPaused = false;
        winCount = 0;
    }

    public void Pause()
    {
        Debug.Log("pause");
        if (isPaused) {
            Time.timeScale = 1f;
            isPaused = false;
            pauseMenu.SetActive(false);
        }
            
        else
        {
            Time.timeScale = 0f;
            isPaused = true;
            pauseMenu.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Pause();
            
        }
    }
}
    