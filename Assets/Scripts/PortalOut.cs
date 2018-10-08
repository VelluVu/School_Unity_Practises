using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalOut : MonoBehaviour {

    Transform portalOut;
    Transform portalIn;
    BoxCollider2D col;
    Transform player;
    float distance;

    void Start () {

        distance = 0.5f;
        col = gameObject.GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        portalOut = GameObject.FindGameObjectWithTag("portalout").GetComponent<Transform>();
        portalIn = GameObject.FindGameObjectWithTag("portalIn").GetComponent<Transform>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Vector2.Distance(player.position, portalOut.position) > distance)
            player.position = portalIn.position;

        }
    }

}
