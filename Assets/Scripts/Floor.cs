using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    public BoxCollider col;
    public GameObject player;
    public Material inActive;
    public Material active;
    
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        
    }

    private void Update()
    {
        if(gameObject.transform.position.y < player.transform.position.y)
        {
            GetComponent<Renderer>().material = active;
            this.col.isTrigger = false;
        } else
        {
            GetComponent<Renderer>().material = inActive;
            this.col.isTrigger = true;
        }
        /*if(FindObjectOfType<PlayerMovement>().isDead)
        {
            for (int i = 0; i < floors.Count; i++)
            {
                floors[i].col.isTrigger = true;
            }
        }*/
        
    }
    public void ResetColliders()
    {
        
    }
}
