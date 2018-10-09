using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilObstacle : MonoBehaviour  {

    Transform player;
    Vector3 move1; 
    Vector3 burst1; 
    Vector3 burst2;
    Vector3 rotateBurst;  
    Vector3 startPos;
    Rigidbody2D evilRB;
    float chaseSpeed;
    float minR;
    float maxR;
    float evilObstacleDamage;

    private void Start()
    {
        evilObstacleDamage = 40f;
        chaseSpeed = 1f;
        minR = -5f;
        maxR = 5f;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        evilRB = gameObject.GetComponent<Rigidbody2D>();
        move1.Set(Random.Range(minR, maxR), 0, 0);      
        burst1.Set(Random.Range(minR, maxR), 0, 0);           
        burst2.Set(Random.Range(minR, maxR), Random.Range(minR, maxR), 0);
        rotateBurst.Set(0, 0, 50 * Time.deltaTime);
        startPos.Set(transform.position.x, transform.position.y, 0);
    }

    public float GetEvilObsDmg()
    {
        return this.evilObstacleDamage;
    }

    void FixedUpdate () {

        if (Vector2.Distance(player.position, transform.position) < 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed *  Time.deltaTime);
                }

        if (transform.position.y > 15 || transform.position.x > 5 && transform.position.x < -5)
        {
            transform.position = startPos;
        }
        switch (Random.Range(0, 2))
        {
            case 0:

                transform.Rotate(rotateBurst);
                break;

            case 1:

                transform.Rotate(-rotateBurst);
                break;

            default:
                break;
        }
        

        switch (Random.Range(0,8))
        {
            case 0:
               
                evilRB.AddForce(move1);
                break;

            case 1:

                evilRB.AddForce(-move1);
                break;

            case 2:

                evilRB.AddForce(move1);
                break;

            case 3:

                evilRB.AddForce(-move1);
                 break;

            case 4:

                evilRB.AddForce(burst1);
                break;

            case 5:
             
                evilRB.AddForce(-burst1);
                break;

            case 6:
               
                evilRB.AddForce(burst2);
                break;

            case 7:
               
                evilRB.AddForce(-burst2);
                break;

           
            default:
               
                break;
        }
        
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "floor") {

            
        }
        
    }
}
