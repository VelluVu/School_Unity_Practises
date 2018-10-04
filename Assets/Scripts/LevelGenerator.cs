using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public GameObject[] spawnObstacles;
    

    private void Start()
    {
        int rand1 = Random.Range(0, spawnObstacles.Length);
        

        Instantiate(spawnObstacles[rand1], transform.position, Quaternion.identity);
        
    }

}
