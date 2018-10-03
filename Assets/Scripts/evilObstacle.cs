using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evilObstacle : MonoBehaviour {

    Vector3 move1;
    Vector3 move2;
    Vector3 burst1;
    Vector3 burst2;
    Vector3 burst3;
    Vector3 burst4;
    Vector3 rotateBurst;
    Vector3 startPos;
    Rigidbody evilRB;

    private void Start()
    {
        evilRB = gameObject.GetComponent<Rigidbody>();
        move1.Set(Random.Range(-5 , 5), 0, 0);
        move2.Set(0, Random.Range(-5, 5), 0);
        burst1.Set(Random.Range(1, 4), 0, 0);
        burst2.Set(Random.Range(-1, -4), 0, 0);
        burst3.Set(Random.Range(-1, -4), Random.Range(-1, -4), 0);
        burst4.Set(Random.Range(1, 4), Random.Range(1, 4), 0);
        rotateBurst.Set(0, 0, 50 * Time.deltaTime);
        startPos.Set(transform.position.x, transform.position.y, 0);
    }

    void FixedUpdate () {

        if (transform.position.y > 15 || transform.position.x > 5 && transform.position.x < -5)
        {
            transform.position = startPos;
        }
        transform.Rotate(rotateBurst);

        switch (Random.Range(0,9))
        {
            case 0:
               
                transform.position += move1 * Time.deltaTime;
                break;

            case 1:
                
                transform.position += move2 * Time.deltaTime;
                break;

            case 2:
                
                transform.position -= move1 * Time.deltaTime;
                break;

            case 3:
                
                transform.position -= move2 * Time.deltaTime;
                break;

            case 4:
              
                transform.position -= burst3 * Time.deltaTime;
                break;

            case 5:
             
                evilRB.AddForce(burst1);
                break;

            case 6:
               
                evilRB.AddForce(burst2);
                break;

            case 7:
               
                evilRB.AddForce(burst4);
                break;

            case 8:
              
                evilRB.AddForce(burst2);
                break;

            default:
               
                break;
        }
        
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "wall" && collision.collider.tag == "Player")
        evilRB.AddExplosionForce(100, collision.transform.position, 5);
    }
}
