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
        GameManager.GameManagerInstance.targets.Remove(gameObject);
        Object.Destroy(gameObject);
        return true;
    }
}
