using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Life : MonoBehaviour
{

    public delegate void DelOnTakeDamage(int lives);

    public DelOnTakeDamage _onTakeDamage;

    public delegate void DelOnDeath();

    public DelOnDeath OnDeath;

    [SerializeField] private int maxLife = 3;
    [SerializeField] private int life = 0;

    private void Awake()
    {
        life = maxLife;
    }

    public void TakeDamage()
    {
        life--;

        _onTakeDamage?.Invoke(life);

        if (life <= 0)
        {
            life = 0;
            Time.timeScale = 0;
            OnDeath?.Invoke();
            return;
        }
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

    public int GetMaxLife()
    {
        return maxLife;
    }
}