using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Vector3 startingForce = new Vector3(0f, 5f, 20f); 
    public Vector3 initialPosition = new Vector3(78.68f, 0f, 18.3f);
    public float bounceForce = 4f;
    private Rigidbody rb;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            
            StartGame();
        }
    }

    void StartGame() 
    {
        rb.AddForce(startingForce, ForceMode.Impulse);
    }

    void ResetBall()
    {
        float delay = 0.4f;
        Vector3 resetForce = new Vector3(0f, 0f, 0f);
        rb.AddForce(resetForce, ForceMode.Impulse);
        Invoke("StartGame", delay);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("BackWall"))
        {
            Vector3 backWallDirection = new Vector3(0f, 1f, -10f);
            rb.AddForce(backWallDirection, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            Vector3 floorBounce = new Vector3(0f, 6.5f, 0f);
            rb.AddForce(floorBounce,ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("RightWall"))
        {
            Vector3 rightWallBounce = new Vector3(-4f, 0f, 0f);
            rb.AddForce(rightWallBounce,ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            Vector3 leftWallBounce = new Vector3(4f, 0f, 0f);
            rb.AddForce(leftWallBounce,ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            float randomValue = Random.Range(0f, 1f);
            Vector3 bounceDirection = new Vector3((randomValue < 0.5f) ? -2f : 2f, 6f, 20f);

            rb.linearVelocity = bounceDirection.normalized * bounceForce;
        }

        if (collision.gameObject.CompareTag("PlayerWall"))
        {
            transform.position = initialPosition;

            ResetBall();
        }
        
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.scoreCount += 1;
        }
    }
}
