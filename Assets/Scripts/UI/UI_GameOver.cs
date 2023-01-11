using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameOver : MonoBehaviour
{

    private GameObject _player;
    private Canvas _canvas;

    private void Awake()
    {
        _canvas = gameObject.GetComponent<Canvas>();
        _canvas.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        _player = GameManager.GameManagerInstance.GetPlayerController();
        if (_player)
        {
            _player.GetComponent<Life>().OnDeath += GameOver;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameOver()
    {
        _canvas.enabled = true;
    }

    private void OnDisable()
    {
        if (_player)
        {
            _player.GetComponent<Life>().OnDeath -= GameOver;
        }
    }
}
