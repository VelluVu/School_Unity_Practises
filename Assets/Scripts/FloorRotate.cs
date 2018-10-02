using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRotate : MonoBehaviour {

    Vector3 minScale;
    Vector3 maxScale;
    Vector3 scaleRate;
    float speed;
    bool maxS;

    void Start()
    {
        maxS = true;
        speed = 1f;
        scaleRate.Set(speed * Time.deltaTime, 0, 0);
        maxScale.Set(7,0,0);
        minScale.Set(speed,0,0);
    }
    private void Update()
    {
        if (maxScale.x <= transform.localScale.x)
        {
            maxS = true;
            
            
        }
        if (minScale.x >= transform.localScale.x)
        {
            maxS = false;
            
        }
        
        if (maxS)
        {
            transform.localScale -= scaleRate;
        }
        else
        {
            transform.localScale += scaleRate;
        }
            
        
            
        
    }
}
