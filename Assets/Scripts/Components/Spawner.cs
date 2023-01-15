using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    private float _timer = 0;
    [SerializeField] private float _spawnTime = 1;

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (!(_timer >= _spawnTime)) return;
        
        GameManager.GameManagerInstance.SpawnTarget(enemy, transform.position);
        _timer -= _spawnTime;
    }
}
