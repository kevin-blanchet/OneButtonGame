using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralSpawnerManager : MonoBehaviour
{
    [SerializeField]
    private List<Vector3> _spawnPoints;

    [SerializeField]
    private GameObject _neutral;

    [SerializeField]
    private float _timeSpawn = 2f;
    private float _timer = 0;

    [SerializeField]
    private int _maxNeutralSpawn;
    private List<GameObject> _neutralSpawnQueue = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if(_timer < _timeSpawn)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            SpawnNeutralCharacter();
            _timer -= _timeSpawn;
        }
    }

    void SpawnNeutralCharacter()
    {
        int rdn = Random.Range(0, _spawnPoints.Count);
            
        GameManager.GameManagerInstance.SpawnTarget(_neutral, _spawnPoints[rdn]);
    }
}
