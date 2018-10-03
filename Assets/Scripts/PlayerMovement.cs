﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float health;
    public float force;
    public float highPoint;
    public float damage;
    public bool launched;
    public bool goingDown;
    public bool isDead;
    public float forcePercent;
    int jumpCount;
    float incForce;
    bool maxForce;
    bool launching;
    public GameObject obstacleHit;
    public GameObject chargingControl;
    public GameObject burningEffect;
    int collisionTime;
    int lastLevel;
    static int index;
    public CameraFollow camShaking;
    public Rigidbody rb;
    Vector3 startPos;
    GameObject soundClass;
    AudioControl soundEffects;

    private void Start()
    {
        soundClass = GameObject.FindGameObjectWithTag("audioPlayer");
        soundEffects = soundClass.GetComponent<AudioControl>();
        index = SceneManager.GetActiveScene().buildIndex;
        incForce = 10f;
        maxForce = false;
        //player = findgameobjectwithtag="player"
        startPos.Set(0, 0.5f, 0);
        soundEffects.GetSound("finish");
        
    }

    private void Update()
    {
        forcePercent = force / 9;

        ChargingEffect();

        OffMap();

        ChargingForce();

        ReleasedTheForce();

        IsGoingDown();

    }

    private void IsGoingDown()
    {
        if (rb.velocity.y < 0 && goingDown == false)
        {
            goingDown = true;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
            highPoint = transform.position.y;
        }
    }

    private void ReleasedTheForce()
    {
        if (Input.GetMouseButtonUp(0))
        {
            launching = false;
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
    }

    private void ChargingForce()
    {
        if (Input.GetMouseButton(0) && jumpCount < 2)
        {
            launching = true;

            
            //Debug.Log("Hiiren vasenta nappia painettu!" + force);
            if (force >= 9)
                maxForce = true;
            if (force <= 0.1f)
                maxForce = false;
            if (!maxForce)
            {
                force += incForce * Time.deltaTime;

            }
            else
            {
                Destroy(Instantiate(burningEffect, transform.position, Quaternion.identity), 1f);
                force -= incForce * Time.deltaTime;
                TakeDamage(0.1f);
            }



            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;

        }    
    }

    private void ChargingEffect()
    {
        if (launching)
        {

            Destroy(Instantiate(chargingControl, transform.position, Quaternion.identity), 0.5f);
        }
    }

    private void OffMap()
    {
        if (transform.position.y < -20)
        {
            Death();
        }
    }

    void Launch(float launchForce, Vector3 launchDir)
    {
        soundEffects.GetSound("jump");
        launched = true;
        jumpCount++;
        rb.AddForce(launchForce * launchDir, ForceMode.Impulse);
        gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        goingDown = false;
        force = 0;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "floor")
        {
            jumpCount = 0;
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
            soundEffects.GetSound("hit");

            StartCoroutine(camShaking.Shake(0.4f, 0.4f));

            Destroy(Instantiate(obstacleHit, transform.position, Quaternion.identity), 1);
            
            
            //this.TakeDamage(FindObjectOfType<Obstacle>().obstacleDamage);
            TakeDamage(collision.gameObject.GetComponent<Obstacle>().obstacleDamage);


        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.tag == "floor")
        {
            jumpCount = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if(other.tag == "floor")
        {
            Debug.Log("Hit floor");

            if (this.transform.position.y > other.transform.position.y)
            {
                
                other.isTrigger = false;
                

            
        }
            }*/
        if(other.tag == "end")
        {
            index++;
            NextLevel(index);
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

    public void NextLevel(int index) {

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            lastLevel = i + 1;
        }
        if (lastLevel != index)
        SceneManager.LoadScene(index);    
        else
        SceneManager.LoadScene(0);
        
        
    }
    
}
