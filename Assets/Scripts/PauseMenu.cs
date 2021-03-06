using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
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
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetString("LevStat", "Retry");
        PlayerPrefs.SetString("level", "new");
        PlayerPrefs.SetString("isNewGame", "yes");
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        PlayerPrefs.SetString("isNewGame", "yes");
        Application.Quit();
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
