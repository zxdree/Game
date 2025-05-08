using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2f;
    private float repeatRate = 2f;
   private PlayerController playerControllerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       InvokeRepeating("SpawnObstacle", startDelay, repeatRate); 
       playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()   
    {
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab,spawnPos,obstaclePrefab.transform.rotation);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
