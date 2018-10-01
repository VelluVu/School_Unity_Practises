using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float health;
    public float force;
    public float highPoint;
    public float damage;
    public bool launched;
    public bool goingDown;
    public bool isDead;
    public GameObject obstacleHit;
    int collisionTime;

    public Rigidbody rb;
    Vector3 startPos;

    private void Start()
    {
        //player = findgameobjectwithtag="player"
        startPos.Set(0, 0.5f, 0);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("Hiiren vasenta nappia painettu!" + force);
            force += 20 * Time.deltaTime;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        } 

        if (Input.GetMouseButtonUp(0))
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            
            Vector3 dir = (mousePos - transform.position).normalized;

            if (dir.y < 0)
            {
                dir *= -1;
            }

            Launch(force, dir);
        }
        if(rb.velocity.y < 0 && goingDown == false)
        {
            goingDown = true;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
            highPoint = transform.position.y;
        }
        
    }

    void Launch(float launchForce, Vector3 launchDir)
    {
        launched = true;
        rb.AddForce(launchForce * launchDir, ForceMode.Impulse);
        gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        goingDown = false;
        force = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "floor")
        {
            Debug.Log("collides with floor");

            if (goingDown && highPoint - gameObject.transform.position.y > 0.1)
            {
           
                //damage = collision.transform.position.y + highPoint;
                damage = Mathf.Sqrt(2f * Mathf.Abs(Physics.gravity.y) * highPoint - transform.position.y);
                TakeDamage(damage);
            }
            launched = false;
            goingDown = false;
        }  
        if (collision.collider.tag == "obstacle")
        {
            Destroy(Instantiate(obstacleHit, transform.position, Quaternion.identity), 1);
            
            //this.TakeDamage(FindObjectOfType<Obstacle>().obstacleDamage);
            TakeDamage(collision.gameObject.GetComponent<Obstacle>().obstacleDamage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "floor")
        {
            Debug.Log("Hit floor");

            if (this.transform.position.y > other.transform.position.y)
            {
                
                other.isTrigger = false;
                
            }

            
        }
        if(other.tag == "end")
        {
            this.gameObject.SetActive(false);
        }
    }

    void TakeDamage(float dmg)
    {
        this.health -= dmg;
        if (health <= 0)
        {
            Death();
        }
        isDead = false;
        
    }
    void Death()
    {
        this.transform.position = startPos;
        health = 100;
        isDead = true;

        foreach (var item in FindObjectsOfType<Floor>())
        {
            item.col.isTrigger = true;
        }
         
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 50, 200, 20), "Jump force " + force);
        GUI.Label(new Rect(10, 40, 200, 20), "High Point " + highPoint);
        GUI.Label(new Rect(10, 30, 200, 20), "Damage " + damage);
        GUI.Label(new Rect(10, 20, 200, 20), "Health " + health);
        GUI.Label(new Rect(10, 10, 200, 20), "Launched " + launched);
        GUI.Label(new Rect(10, 0, 200, 20), "Going Down " + goingDown);
    }

}
