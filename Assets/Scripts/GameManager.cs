using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 2f;
    public float retryDelay = 3f;
    public GameObject completeLevelUi;
    public GameObject InstrucMenuUi;
    public Text livesText;

    int lives = 3;

    private void Start() {
        if (PlayerPrefs.GetString("isNewGame") == "yes"){
            InstrucMenuUi.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("<Start> panel visible");
        }
        if (PlayerPrefs.GetInt("current_lives") == 0 || SceneManager.GetActiveScene().name == "Level1" && PlayerPrefs.GetString("LevStat") != "Restart")
        {
            Debug.Log("<If>Start..."+PlayerPrefs.GetString("level")+"--"+PlayerPrefs.GetString("current_lives")+"--"+PlayerPrefs.GetString("LevStat"));
            livesText.text = lives.ToString();
            PlayerPrefs.SetInt("current_lives", 3);
            PlayerPrefs.SetString("level", SceneManager.GetActiveScene().name);
        } 
        else
        {
            Debug.Log("<Else>Start..."+PlayerPrefs.GetString("level")+"--"+PlayerPrefs.GetInt("current_lives")+"--"+PlayerPrefs.GetString("LevStat"));
            PlayerPrefs.SetString("level", SceneManager.GetActiveScene().name);
            livesText.text = PlayerPrefs.GetInt("current_lives").ToString();
        }
        
    }

    private void Update() {
        // if (PlayerPrefs.GetString("isNewGame") == "yes"){
        //     Debug.Log("isNewGame"+PlayerPrefs.GetString("isNewGame"));
            
        // }
        if (Input.anyKey && SceneManager.GetActiveScene().name == "Level1")
        {
            Debug.Log("Key is pressed.");
            Time.timeScale = 1f;
            PlayerPrefs.SetString("isNewGame", "no");
            Debug.Log("<Update>Set to no!");
            InstrucMenuUi.SetActive(false);
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
                PlayerPrefs.SetString("LevStat", "Retry");
                PlayerPrefs.SetString("isNewGame", "yes");
                Debug.Log("Set to yes!");
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
