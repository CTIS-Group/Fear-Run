using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour {
    float xVector, yVector;
    [SerializeField]
    float speed = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        RespondToMovement();
	}

    private void RespondToMovement()
    {
        xVector = CrossPlatformInputManager.GetAxis("Horizontal");
        yVector = CrossPlatformInputManager.GetAxis("Vertical");
        transform.position += new Vector3(xVector, yVector, 0) * speed * Time.deltaTime;

    }
}
