using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour {

    Vector3 moveFloor;
    bool upWards;

    private void Start()
    {       
        moveFloor.Set(0f, 2f, 0);
    }

    private void Update()
    {
        transform.position += moveFloor * Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "wall" || collision.collider.tag == "floor" || collision.collider.tag == "obstacle") {
            moveFloor *= -1;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.tag == "wall" || other.tag == "floor" || other.tag == "obstacle")
        {
            moveFloor *= -1;
        }
    }
}
