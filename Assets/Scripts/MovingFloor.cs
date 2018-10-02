using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour {

    Vector3 moveFloor;
    bool upWards;

    private void Start()
    {       
        moveFloor.Set(0f, 2f, 0f);
    }

    private void Update()
    {
        transform.position += moveFloor * Time.deltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!(collision.collider.tag == "Player")) {
            moveFloor = -moveFloor;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!(other.tag == "Player")) {
            moveFloor = -moveFloor;
        }
    }
}
