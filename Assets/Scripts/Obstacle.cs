using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public float obstacleDamage;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        
    }
}
