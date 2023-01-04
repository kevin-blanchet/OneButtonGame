using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameOver : MonoBehaviour
{

    private GameObject playerController;

    private void Awake()
    {
        GetComponent<Canvas>().enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameManager.GameManagerInstance.GetPlayerController();
        if (playerController)
        {
            playerController.GetComponent<Life>().onDeath += GameOver;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameOver()
    {
        GetComponent<Canvas>().enabled = true;
    }

    private void OnDisable()
    {
        if (playerController)
        {
            playerController.GetComponent<Life>().onDeath -= GameOver;
        }
    }
}
