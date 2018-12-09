using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Tooltip("1 for right, -1 for left, 0 for none")][SerializeField] int isX = 0;
    [Tooltip("1 for top, -1 for bottom, 0 for none")][SerializeField] int isY = -1;
    [SerializeField] float speedX = 10f, speedY = 10f;
    private new Vector3 movementFactor;
    background bckground;
    // Use this for initialization
    void Start ()
    {
        bckground = FindObjectOfType<background>();
        movementFactor = new Vector3(isX * speedX, isY * speedY + bckground.speed * -10.4f, 0);
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
