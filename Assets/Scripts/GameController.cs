using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

 public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }
    public static int winCount;
    public static bool isPlaying;
    public static bool isDead;
    public static bool isPaused;
    public GameObject pauseMenu;
    public GameObject gameOverScreen;
    public PlayerController player;
    private static IEnumerator coroutine;


    

    private static IEnumerator Restart()
    {
        Debug.Log("Espera 2 seg...");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("vai");
    }

    

    public void PlayerWon()
    {
        // função para quando a condição de vitória for verdadeira
        Debug.Log("Player won");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name) ;
    }

    public void PlayerLost()
    {
        // função para quando a condição de derrota for verdadeira
        Debug.Log("Player lost");
        player.isAlive = false;
        gameOverScreen.SetActive(true);
        coroutine = Restart();
        StartCoroutine(coroutine);
        
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



    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
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
    