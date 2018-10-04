using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour {

    public List<GameObject> soundPrefabs = new List<GameObject>();

    
    public void GetSound (int index)
    {

        Instantiate(soundPrefabs[index]);

        //Instantiate(GameObject.FindGameObjectWithTag(tag));
                            
    }
}
