using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    BoxCollider2D col;
    Transform player;
    Transform portalOut;
    Transform portalIn;
    

    private void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        portalOut = GameObject.FindGameObjectWithTag("portalout").GetComponent<Transform>();
        portalIn = GameObject.FindGameObjectWithTag("portal").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player.position == portalOut.position)
            {
                player.position = portalIn.position;
            }

            player.position = portalOut.position;

            
        }
    }
}
