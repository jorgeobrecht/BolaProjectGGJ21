using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

 public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }
    public static bool isPlaying;
    public static bool isDead;
    public static bool isPaused;
    public GameObject tdsGotas;
    public GameObject pauseMenu;
    public GameObject gameOverScreen;
    public GameObject victoryScreen;
    public PlayerController player;
    private static IEnumerator coroutine;
    public string sceneName;
    public HUD hudManager;

    //collectables
    GameObject[] gotas;
    public int playerGotas;
    public int maxGotas;



    private static IEnumerator waitRestart()
    {
        Debug.Log("Espera 2 seg...");
        yield return new WaitForSeconds(2);
        
        Debug.Log("vai");
        Instance.Restart();
    }

    public void Restart()
    {
        Time.timeScale = 1f; // caso seja chamado do menu pausado
        SceneManager.LoadScene(sceneName);
    }

    public void QuitToStartMenu()
    {
        Time.timeScale = 1f; // caso seja chamado do menu pausado
        SceneManager.LoadScene("startMenu");
    }

    public void PlayerWon()
    {
        // função para quando a condição de vitória for verdadeira
        Time.timeScale = 0f;
        Debug.Log("Player won");
        victoryScreen.SetActive(true);

        if(playerGotas == maxGotas)
            tdsGotas.SetActive(true);

    }

    public void PlayerLost()
    {
        // função para quando a condição de derrota for verdadeira
        Time.timeScale = 0f;
        Debug.Log("Player lost");
        player.isAlive = false;
        gameOverScreen.SetActive(true);
        SoundManagerScript.PlaySound("Death");
    }

    // Start is called before the first frame update
    

    public void GetGota()
    {
        gotas = GameObject.FindGameObjectsWithTag("collectable");
        playerGotas = maxGotas - gotas.Length;
        hudManager.updateGotasCounter(playerGotas);
    }

    public void Pause()
    {
        Debug.Log("pause");
        if (isPaused) {
            Time.timeScale = 1f;
            isPaused = false;
            pauseMenu.SetActive(false);
            SoundManagerScript.PlaySound("OpenMenu");
        }
            
        else
        {
            Time.timeScale = 0f;
            isPaused = true;
            pauseMenu.SetActive(true);
            SoundManagerScript.PlaySound("OpenMenu");
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



    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
        isPaused = false;
        
        gotas = GameObject.FindGameObjectsWithTag("collectable");
        maxGotas = gotas.Length;
        playerGotas = maxGotas - gotas.Length;
        hudManager.updateGotasCounter(playerGotas);
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
    