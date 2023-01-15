using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private bool _isTargeted = false;
    public void SetTarget()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        _isTargeted = true;
    }
    
    public void ResetTarget()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        _isTargeted = false;
    }

    public virtual bool Hit()
    {
        bool isHit = false;
        switch (tag)
        {
            case "Enemy":
                isHit = GetComponent<Enemy>().Hit();
                break;
            case "Neutral":
                GetComponent<Neutral>().Hit();
                break;
            // case "Mechanic":
            //     GetComponent<Mechanic>().Hit();
            //     break;
        }

        return isHit;
    }
}
