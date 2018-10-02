using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampPowerBar : MonoBehaviour {


    public Slider slider;
	
	void FixedUpdate () {
        Vector3 sliderPos = Camera.main.WorldToScreenPoint(this.transform.position);
        slider.transform.position = sliderPos;
    }
}
