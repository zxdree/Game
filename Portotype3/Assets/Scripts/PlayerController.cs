using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb; 
    public float jumpuFroce;
    public float gravitModifier; 
    public bool  isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionParticale;
    public ParticleSystem runningParticale;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    private AudioSource playerAudio;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravitModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpuFroce,ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            runningParticale.Stop();
            playerAudio.PlayOneShot(jumpSound, 1f);


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            runningParticale.Play();
        }else if(collision.gameObject.CompareTag("obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticale.Play();
            runningParticale.Stop();
            playerAudio.PlayOneShot(crashSound);
        }
        
    }
    //1064
}
