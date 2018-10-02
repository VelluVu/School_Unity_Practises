using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    GameObject player;
    Slider slider;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        slider = gameObject.GetComponent<Slider>();
    }

    private void Update()
    {
        slider.value = player.GetComponent<PlayerMovement>().health / 100;
    }
}
