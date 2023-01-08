using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Char player;
    private float _timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.GameManagerInstance?.GetPlayerController()?.GetComponent<Char>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (!(_timer >= 1)) return;
        
        GameObject instancedEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        _timer -= 1;

        player.AddTarget(ref instancedEnemy);
    }
}
