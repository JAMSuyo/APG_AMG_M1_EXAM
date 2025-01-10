using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 4f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput,0f).normalized;

        MovePlayer(movement);
    }

    void MovePlayer(Vector3 movement) 
    {
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            ScoreManager.scoreCount += 1;
        }
    }
}
