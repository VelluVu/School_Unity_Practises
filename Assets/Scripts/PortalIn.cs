using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalIn : MonoBehaviour {

    BoxCollider2D col;
    Transform player;
    Transform portalIn;
    Transform portalOut;
    float distance;

    private void Start()
    {
        distance = 0.5f;
        col = gameObject.GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();    
        portalIn = GameObject.FindGameObjectWithTag("portalIn").GetComponent<Transform>();
        portalOut = GameObject.FindGameObjectWithTag("portalout").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
                   
            if (Vector2.Distance(player.position, portalIn.position) > distance)
            player.position = portalOut.position;
           
           
        }
    }
    
}
