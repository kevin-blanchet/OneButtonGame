using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float score = 0;
    public float scoreMultiplyer = 1;
    
    [SerializeField] private Vector3 _playerSpawnPosition;
    public static GameManager GameManagerInstance;
    private GameObject _player;
    
    public List<GameObject> targets;

    [SerializeField]
    private GameObject playerController = null;

    private void Awake()
    {
        Time.timeScale = 1;
        if(GameManagerInstance != null && GameManagerInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            GameManagerInstance = this;

            SpawnPlayerController();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        targets = new List<GameObject>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
    
    void SpawnPlayerController()
    {
        if (!playerController)
        {
            Debug.LogError("no playerController found");
            return;
        }
        _player = Instantiate(playerController, _playerSpawnPosition, Quaternion.identity);
    }

    public void SpawnTarget(GameObject entity, Vector3 position)
    {
        GameObject instancedEnemy = Instantiate(entity, position, Quaternion.identity);
        targets.Add(instancedEnemy);
    }

    public GameObject GetPlayerController()
    {
        return _player;
    }
}
