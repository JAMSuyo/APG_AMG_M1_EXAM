using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartsSystem : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    private bool dead;
    private ScoreManager scoreManager;

    private void Start()
    {
        life = hearts.Length;
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }
    void Update()
    {
        if (dead)
        {
            Debug.Log("Game Over");
            StartCoroutine(GameOverCoroutine());
        }
    }

    IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("MainMenu");
        ScoreManager.scoreCount = 0;
    }

    public void TakeDamage(int damage) 
    {
        if (!dead)
        {
            life -= damage;
            life = Mathf.Clamp(life, 0, hearts.Length);
            Destroy(hearts[life].gameObject);

            if (life <= 0)
            {
                dead = true;
            }
        }
    }


}