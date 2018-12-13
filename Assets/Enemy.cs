using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Vector3 movementFactor;
    background background;
    

    // Use this for initialization
    void Start ()
    {
        background = FindObjectOfType<background>();
        movementFactor = new Vector3(0, background.speed * -10.4f, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += movementFactor * Time.deltaTime;
	}

    void UpdateFixed()
    {

    }
}
