using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody body;
    public float jumpForce;
    public float gravityFactor;
    private bool isOnGround;
    public bool isGameOver;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Physics.gravity *= gravityFactor;
        isOnGround = true;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnGround && Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Jump_trig");
                body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }
                          
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidingObject = collision.gameObject;
        if (collidingObject.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        else if (collidingObject.gameObject.CompareTag("Obstacles"))
        {
            isGameOver = true;
            animator.SetBool("Death_b", true);
            Debug.Log("GAMEOVER");
        }
        
       
    }
   
}
