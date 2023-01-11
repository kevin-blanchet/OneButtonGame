using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{

    delegate void DelOnTakeDamage();
    private DelOnTakeDamage _onTakeDamage;

    public delegate void DelOnDeath();
    public DelOnDeath OnDeath;

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
            life = 0;
            Time.timeScale = 0;
            OnDeath?.Invoke();
            return;
        }

        _onTakeDamage?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.GameManagerInstance.targets.Remove(other.gameObject);
            Destroy(other.gameObject);
            TakeDamage();
        }
    }
}
