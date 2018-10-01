using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRotate : MonoBehaviour {

    private void Update()
    {
        transform.Rotate(Vector3.up);
    }
}
