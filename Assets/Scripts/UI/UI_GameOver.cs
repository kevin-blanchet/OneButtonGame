using TMPro;
using UnityEngine;

public class UI_GameOver : MonoBehaviour
{

    private GameObject _player;
    private TextMeshProUGUI _txtGameOver;

    private void Awake()
    {
        _txtGameOver = GetComponentInChildren<TextMeshProUGUI>();
        _txtGameOver.enabled = false;
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
        _txtGameOver.enabled = true;
    }

    private void OnDisable()
    {
        if (_player)
        {
            _player.GetComponent<Life>().OnDeath -= GameOver;
        }
    }
}
