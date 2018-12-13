﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour {

    [SerializeField]
    float rotateSpeed = 10f;
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
	}
}
