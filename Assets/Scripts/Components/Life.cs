using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{

    delegate void OnTakeDamage();
    OnTakeDamage onTakeDamage;

    delegate void OnDeath();
    OnDeath onDeath;

    [SerializeField]
    private int maxLife = 3;
    [SerializeField]
    private int life = 0;

    private void Awake()
    {
        life = maxLife;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage()
    {
        life--;

        if(life <= 0)
        {
            onDeath?.Invoke();
            return;
        }

        onTakeDamage?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }
}
