using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour {

    Vector3 patrolMovement;

    private void Start()
    {
        patrolMovement.Set(2f, 0, 0);
    }

    private void Update()
    {
        this.transform.position += patrolMovement * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "wall" || collision.collider.tag == "Player") {

            patrolMovement = -patrolMovement;

        }
    }
}
