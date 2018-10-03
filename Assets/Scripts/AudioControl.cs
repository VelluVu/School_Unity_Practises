using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour {

    public List<GameObject> soundPrefabs = new List<GameObject>();

    
    public void GetSound (string tag)
    {

        Instantiate(GameObject.FindGameObjectWithTag(tag));
                            
    }
}
