using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFloors : MonoBehaviour {

    public GameObject[] spawnFloors;
    
    void Start () {

        int rand2 = Random.Range(0, spawnFloors.Length);

        Instantiate(spawnFloors[rand2], transform.position, Quaternion.identity);
    }
	
}
