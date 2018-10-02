using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour {

    Slider slides;
    GameObject player;

    private void Start()
    {
        slides = gameObject.GetComponent<Slider>();
        player = GameObject.FindGameObjectWithTag("Player");     
    }

    private void FixedUpdate()
    {
        slides.value = player.GetComponent<PlayerMovement>().forcePercent;
    }
}
