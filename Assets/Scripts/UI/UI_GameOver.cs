using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_GameOver : MonoBehaviour
{

    private GameObject _player;
    private TextMeshProUGUI _txtGameOver;
    
    private float _timeToRestart = 3f;
    private float _timer = 0f;
    
    private bool _gameOver = false;

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
        if (_gameOver)
        {
            _timer += Time.unscaledDeltaTime;
            if (_timer >= _timeToRestart)
            {
                SceneManager.LoadScene(0);
            }
        }   
    }

    void GameOver()
    {
        _txtGameOver.enabled = true;
        _gameOver = true;
    }

    private void OnDisable()
    {
        if (_player)
        {
            _player.GetComponent<Life>().OnDeath -= GameOver;
        }
    }
}
