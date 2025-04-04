using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameManager gameManager;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.ChangeScoreText(score);
        StartCoroutine(DestroyCoinAfterDelay(2.5f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator DestroyCoinAfterDelay(float delay)
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(delay);

        // Destroy the coin after the delay
        Destroy(gameObject);
    }

    // Player collides with the coin
    private void OnTriggerEnter(Collider whatDidIHit)
    {
        // Check if the object that collided is the player
        if (whatDidIHit.CompareTag("Player")) // Use CompareTag for better performance
        {
            // Increase the score by 1
            gameManager.AddScore(1);

            // Destroy the coin after it's collected
            Destroy(gameObject);
        }
    }
}