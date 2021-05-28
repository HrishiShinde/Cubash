using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public GameManager mangager;
    void OnTriggerEnter ()
    {
        Debug.Log("From EndTrigger");
        FindObjectOfType<GameManager>().CompleteLev();
    }
}
