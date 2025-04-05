using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject cloudPrefab;
    public GameObject coinPrefab;
    public GameObject healthPrefab;

    public PlayerController playerController;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    public float horizontalScreenSize;
    public float verticalScreenSize;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("CreateEnemy", 1, 3);
        InvokeRepeating("CreateCoin", 1, 5);
        InvokeRepeating("CreateHealth", 1, 7);
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeScoreText(score);
    }

    void CreateCoin()
    {
        Vector3 coinPosition = new Vector3(UnityEngine.Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0);
        Instantiate(coinPrefab, coinPosition, Quaternion.Euler(0, 0, 0));
    }

    void CreateEnemy()
    {
        Instantiate(enemyOnePrefab, new Vector3(UnityEngine.Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0), Quaternion.Euler(180, 0, 0));
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(UnityEngine.Random.Range(-horizontalScreenSize, horizontalScreenSize), UnityEngine.Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }
 
    }

    void CreateHealth()
    {
        Vector3 healthPosition = new Vector3(UnityEngine.Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0);
        Instantiate(healthPrefab, healthPosition, Quaternion.Euler(0, 0, 0));
    }

    public void AddScore(int earnedScore)
    {
        score = score + earnedScore;
        ChangeScoreText(score);
    }

    public void ChangeScoreText(int currentScore)
    {
        scoreText.text = "Score: " + currentScore;
    }

    public void ChangeLivesText (int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }
}
