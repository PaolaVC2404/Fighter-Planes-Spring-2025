using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private GameManager gameManager;
    public int score = 0;
    public float speed = 0.5f;
    public float amplitude = 8.0f;

    private float initialX;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.ChangeScoreText(score);
        StartCoroutine(DestroyHealthAfterDelay(2.5f));
        initialX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DestroyHealthAfterDelay(float delay)
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(delay);

        // Destroy the Health after the delay
        Destroy(this.gameObject);
    }

    // Player collides with the Health
    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Player")
        {
            whatDidIHit.GetComponent<PlayerController>();
            Destroy(this.gameObject);
        }
    }
}