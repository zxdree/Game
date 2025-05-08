using UnityEngine;

public class MoveLeft : MonoBehaviour
{
   public float speed = 30;
   private PlayerController playerControllerScript;
   private float leftBound = -15f;


    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("obstacle"))
        {
            Destroy(gameObject);
        }
        
    }
}
