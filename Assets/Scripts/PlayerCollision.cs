using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    void OnCollisionEnter (Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
        if(collision.gameObject.name == "Ground")
        {
            movement.isGrounded = true;
            Debug.Log("Ground...."+movement.isGrounded);
        }
    }
}
