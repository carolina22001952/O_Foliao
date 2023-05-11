using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private static bool GameIsPaused = false;

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject confirmationMenu, confirmationQuit;
    [SerializeField] private GameObject game;
    [SerializeField] private Button resumeButton, menuButton, quitButton;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        confirmationMenu.SetActive(false);
        confirmationQuit.SetActive(false);

        game.GetComponent<Game>().enabled = true;
        game.GetComponent<Movement>().enabled = true;

        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);

        game.GetComponent<Game>().enabled = false;
        game.GetComponent<Movement>().enabled = false;

        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        SceneManager.LoadScene("Start Menu");
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
