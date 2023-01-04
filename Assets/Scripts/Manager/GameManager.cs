using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GameManagerInstance;

    [SerializeField]
    private GameObject playerController = null;

    private void Awake()
    {
        if(!GameManagerInstance && GameManagerInstance != this)
        {
            Destroy(gameObject);
        }
        GameManagerInstance = this;

        SpawnPlayerController();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlayerController()
    {
        if (!playerController)
        {
            Debug.LogError("no playerController found");
            return;
        }
        Instantiate(playerController, transform.position, Quaternion.identity);
    }

    public GameObject GetPlayerController()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }
}
