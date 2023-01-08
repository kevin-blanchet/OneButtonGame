using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralSpawnerManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _spawnPoint;

    [SerializeField]
    private GameObject _neutral;

    [SerializeField]
    private float _timeSpawn = 2f;
    private float _timer = 0;

    [SerializeField]
    private int _maxNeutralSpawn;
    private List<GameObject> _neutralSpawnQueue = new List<GameObject>();

    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

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
            _timer = 0;
        }
    }

    void SpawnNeutralCharacter()
    {
        int rdn = Random.Range(0, _spawnPoint.Count);
        
        if(_neutralSpawnQueue.Count < _maxNeutralSpawn)
        {
            GameObject go = Instantiate(_neutral, _spawnPoint[rdn].position, _spawnPoint[rdn].rotation);
            _neutralSpawnQueue.Add(go);
        }
        else
        {
            GameObject go = _neutralSpawnQueue[0];
            _neutralSpawnQueue.RemoveAt(0);
            _neutralSpawnQueue.Add(go);
            go.transform.position = _spawnPoint[rdn].position;
            go.transform.rotation = _spawnPoint[rdn].rotation;
            go.GetComponent<Neutral>()?.Spawn();
        }
        
    }
}
