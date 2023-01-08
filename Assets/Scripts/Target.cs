using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void SetTarget()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    
    public void ResetTarget()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public virtual bool Hit()
    {
        bool isHit = false;
        switch (tag)
        {
            case "enemy":
                isHit = GetComponent<Enemy>().Hit();
                break;
            // case "neutral":
            //     GetComponent<Neutral>().Hit();
            //     break;
            // case "mechanic":
            //     GetComponent<Mechanic>().Hit();
            //     break;
        }

        return isHit;
    }
}
