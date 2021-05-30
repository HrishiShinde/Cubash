using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 2f;
    public float retryDelay = 3f;
    public GameObject completeLevelUi;
    public Text livesText;

    int lives = 3;

    private void Start() {
        if (PlayerPrefs.GetInt("current_lives") == 0 || PlayerPrefs.GetString("level") == "Level1" && PlayerPrefs.GetString("levStat") == "Restart")
        {
            //Debug.Log("<If>Start..."+PlayerPrefs.GetString("level", SceneManager.GetActiveScene().name));
            livesText.text = lives.ToString();
            PlayerPrefs.SetInt("current_lives", 3);
            PlayerPrefs.SetString("level", SceneManager.GetActiveScene().name);
        }
        else
        {
            //Debug.Log("<Else>Start..."+PlayerPrefs.GetString("level", SceneManager.GetActiveScene().name));
            PlayerPrefs.SetString("level", SceneManager.GetActiveScene().name);
            livesText.text = PlayerPrefs.GetInt("current_lives").ToString();
        }
        
    }

    public void CompleteLev()
    {
        PlayerPrefs.SetInt("current_lives", PlayerPrefs.GetInt("current_lives") + lives);
        completeLevelUi.SetActive(true);
    }
    public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            lives = int.Parse(livesText.text) - 1;
            PlayerPrefs.SetInt("current_lives", lives);
            livesText.text = lives.ToString();
            if (lives != 0)
            {
                PlayerPrefs.SetString("LevStat", "Restart");
                Invoke("Restart", restartDelay);
            }
            else if (lives == 0)
            {
                PlayerPrefs.SetString("LevStat", "null");
                Invoke("Retry", retryDelay);
            }
        }
    }

    void Retry()
    {
        SceneManager.LoadScene("Retry");
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
