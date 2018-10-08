using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour {

    Vector3 patrolMovement;
    Rigidbody2D rb;

    private void Start()
    {
        patrolMovement.Set(2f, 0, 0);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        this.transform.position += patrolMovement * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "wall" || collision.collider.tag == "Player") {

            this.patrolMovement *= -1;

        }
    }
}
