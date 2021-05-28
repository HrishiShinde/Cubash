using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float forwardForce = 2000f;
    public float sidewayForce = 500f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //rb.AddForce(0, 200, 500);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if ( Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) {
            rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
       } 
        
        if ( Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)){
            rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
