using UnityEngine;
using UnityEngine.SceneManagement;

public class LevComp : MonoBehaviour
{
    public void LoadNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
