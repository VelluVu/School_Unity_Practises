using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleChase : MonoBehaviour
{

    Transform player;
    Rigidbody2D chaserRB;
    float chaseSpeed;
    float ChaseObstacleDamage;

    private void Start()
    {
        ChaseObstacleDamage = 10f;
        chaseSpeed = 1f;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        chaserRB = gameObject.GetComponent<Rigidbody2D>();

    }

    public float GetChaseObstacleDamage()
    {
        return this.ChaseObstacleDamage;
    }

    void FixedUpdate()
    {

        if (Vector2.Distance(player.position, transform.position) < 5)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Player")
       {

            collision.rigidbody.
               AddForce(player.position * -1 *1000);
       }
    }


}
