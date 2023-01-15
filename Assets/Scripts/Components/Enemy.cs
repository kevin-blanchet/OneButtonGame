using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));
    }

    public bool Hit()
    {
        GameManager.GameManagerInstance.score += 100 * GameManager.GameManagerInstance.scoreMultiplyer;
        GameManager.GameManagerInstance.scoreMultiplyer *= 1.1f;
        
        GameManager.GameManagerInstance.targets.Remove(gameObject);
        Object.Destroy(gameObject);
        return true;
    }
}
