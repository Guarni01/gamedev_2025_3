using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //body + animation
    private Rigidbody body;
    public float jumpForce;
    public float gravityFactor;
    private bool isOnGround;
    private Animator animator;

    //gamewise concepts
    public bool isGameOver;

    //suoni
    public AudioClip crashSound;
    public AudioClip jumpSound;
    private AudioSource audioSource;

    //FX
    public ParticleSystem explosionParticles;
    public ParticleSystem dirtParticles;
    public AudioSource musicAudioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Physics.gravity *= gravityFactor;
        isOnGround = true;
        isGameOver = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver && isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump_trig");
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            dirtParticles.Stop();
            audioSource.PlayOneShot(jumpSound, 1.0f);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidingObject = collision.gameObject;
        if (collidingObject.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticles.Play();
        }

        else if (collidingObject.gameObject.CompareTag("Obstacles"))
        {
            isGameOver = true;
            animator.SetBool("Death_b", true);
            int deathType = Random.Range(1, 3);
            animator.SetInteger("DeathType_int", deathType);
            Debug.Log("GAMEOVER");
            explosionParticles.Play();
            dirtParticles.Stop();
            audioSource.PlayOneShot(crashSound, 1.0f);
            musicAudioSource.Stop();
        }


    }

}
