using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    private float leftBound = -15.0f;
    private PlayerController playerController;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {   //muovi verso sx
        if (playerController.isGameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        //Distruggi oggetti quando supera leftbound

        if (transform.position.x < leftBound && CompareTag("Obstacles"))
        {
            Destroy(gameObject);
        }
    }
}
