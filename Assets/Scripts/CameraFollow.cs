using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    bool isShaking;

    private Vector3 offset;        

    
    void Start()
    {
        
        offset = transform.position - player.transform.position;
    }

    
    void LateUpdate()
    {
        if(!isShaking)
        transform.position = player.transform.position + offset;
    }
    
    public IEnumerator Shake (float duration, float magnitude)
    {
        
        float elapsed = 0.0f;
        while(elapsed < duration)
        {
            isShaking = true;
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        isShaking = false;

        
     
    }
}
