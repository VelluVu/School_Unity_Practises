using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpNeg : MonoBehaviour {

    BoxCollider2D col;

    private void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.attachedRigidbody.gravityScale *= 0.9f;
            Destroy(gameObject);
        }
    }
}
