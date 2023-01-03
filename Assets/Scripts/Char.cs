using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
    private List<GameObject> _targets;
    private GameObject _target;
    // Start is called before the first frame update
    void Start()
    {
        _targets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindClosestEnemy(_targets))
        {
            _target.GetComponent<Target>().SetTarget();
        }
    }
    
    public void AddTarget(ref GameObject target)
    {
        _targets.Add(target);
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

        _target = tMin;
        return true;
    }
}
