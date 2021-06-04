using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{

    public GameManager mangager;
    void OnTriggerEnter ()
    {
        if (SceneManager.GetActiveScene().name == "Level3"){
            PlayerPrefs.SetString("LevStat", "GameEnd");
        }
        Debug.Log("From EndTrigger");
        FindObjectOfType<GameManager>().CompleteLev();
    }
}
