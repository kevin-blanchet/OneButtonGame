using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
    public List<GameObject> targets;
    private GameObject _target;
    private bool _canShoot = true;
    private float _shootTimer = 0;
    [SerializeField] private float shootDelay = 0.5f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        targets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindClosestEnemy(targets))
        {
            Debug.Log("newTargetSet");
        }

        _canShoot = (_shootTimer += Time.deltaTime) >= shootDelay;
        
        if (Input.anyKeyDown && _canShoot)
        {

            if (Shoot())
            {
                Debug.Log("input detected");
            }
        }
    }

    private bool FindClosestEnemy(List<GameObject> enemies)
    {
        if (enemies.Count == 0)
        {
            return false;
        }
        
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in enemies)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }

        if (_target == tMin || tMin == null)
        {
            return false;
        }

        if (_target != null)
        {
            _target.GetComponent<Target>().ResetTarget();
        }
        _target = tMin;
        _target.GetComponent<Target>().SetTarget();
        
        return true;
    }

    private bool Shoot()
    {
        _shootTimer = 0;
        
        if (_target == null)
        {
            return false;
        }
        
        bool isHit = _target.GetComponent<Target>().Hit();
        return isHit;
    }
}
