using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    BoxCollider2D col;

    private void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Physics2D.gravity.Set(0, -9.81f);
            Physics2D.gravity *= 0.25f;
            Destroy(gameObject);
        }
    }
}
