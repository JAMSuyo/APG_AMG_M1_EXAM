using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public bool hasDied;
    public bool health;
    void Start()
    {
        hasDied = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerWall"))
        {
           hasDied = true;
           HeartsSystem heartsSystem = FindFirstObjectByType<HeartsSystem>();
           if (heartsSystem != null)
           {
              heartsSystem.TakeDamage(1);
           }
        }
 
    }

    
}
