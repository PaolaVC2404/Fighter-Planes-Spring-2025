using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


public class LivesDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Text LivesText;
    private PlayerController playerController;
    
    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

    }


    // Update is called once per frame
    public void UpdateLivesText()
    {
        LivesText.text = "Lives: " +
      playerController.lives;
    }
}
