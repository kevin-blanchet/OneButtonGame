using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
    private GameObject _target;
    private bool _canShoot = true;
    private float _shootTimer = 0;
    [SerializeField] private float shootDelay = 0.5f;
    
    private AudioSource _gunFired;
    
    // Start is called before the first frame update
    void Start()
    {
        _gunFired = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindClosestEnemy(GameManager.GameManagerInstance.targets))
        {
            Debug.Log("newTargetSet");
        }

        _canShoot = (_shootTimer += Time.deltaTime) >= shootDelay;
        
        if (Input.anyKeyDown && _canShoot)
        {
            if (Shoot())
            {
                //Debug.Log("PEW PEW");
            }
        }
    }

    private bool FindClosestEnemy(List<GameObject> targets)
    {
        if (targets.Count == 0)
        {
            return false;
        }
        
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in targets)
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
        
        _gunFired.pitch = Random.Range(1f, 1.2f);
        _gunFired.Play();
        
        if (_target == null)
        {
            return false;
        }
        
        bool isHit = _target.GetComponent<Target>().Hit();
        return isHit;
    }
}
