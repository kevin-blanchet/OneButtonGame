using UnityEngine;

public class Neutral : MonoBehaviour
{
    private float _timer;
    [SerializeField]
    private float _maxTimer = 1.5f;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            LifeTime();
        }
    }

    public void Spawn()
    {
        _timer = 0;
        isDead = false;
    }

    public void LifeTime()
    {
        if (_timer < _maxTimer)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            transform.position = new Vector3(-500, -500, 0);
            isDead = true;
        }
    }

    public bool Hit()
    {
        GameManager.GameManagerInstance.targets.Remove(gameObject);
        Object.Destroy(gameObject);
        GameManager.GameManagerInstance.GetPlayerController().GetComponent<Life>().TakeDamage();
        return true;
    }
}
