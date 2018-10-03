using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour {

    public AudioSource themeMusic;
    float delay;

    private void Start()
    {
        delay = 2f;
        themeMusic.PlayDelayed(delay);
    }
}
