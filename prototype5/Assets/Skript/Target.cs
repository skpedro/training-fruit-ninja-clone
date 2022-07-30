
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Vector3 randomPos;
    private GameManager gameManager;
    private Rigidbody rb;

    public ParticleSystem explosionParticle;
    public int pointValue;

    private float maxSpeed=18;
    private float minSpeed=10;
    private float torqye=10;
    private float ySpawnPosition=-2;
    private float xRange = 4;
  
    void Start()
    {
        
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(),ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(),ForceMode.Impulse);
        transform.position = RandomSpawnPoint();
    }
  
    float RandomTorque(){
        return Random.Range(-torqye,torqye);
    }

    Vector3 RandomForce(){
        return Vector3.up * Random.Range(minSpeed,maxSpeed);
    }

    Vector3 RandomSpawnPoint(){
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPosition);
    }

    private void OnMouseDown()
    {
        if (!gameManager.isGameOver)
        {
            Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        if (gameObject.CompareTag("Good"))
        {
            gameManager.SubtractingLives();
        }
        
        Destroy(gameObject);
    }

}
