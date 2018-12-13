using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Collider2D))]
public class PlayerControl : MonoBehaviour {
    float xVector, yVector;
    [SerializeField]
    float speed = 10f;

    [Header("Amount of time to be invincible after losing a life.")]
    [SerializeField]
    public float protectionTime = 3f;
    [SerializeField]
    public int playerLives = 3;

    [Header("Degrees to turn to animate walking effect")]
    public float animationDegree = 30f;
    [Header("Speed of walking animation")]
    public float animationSpeed = 1f;

    private bool _isCollided = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        RespondToMovement();
        AnimatePlayer();
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!_isCollided)
        {
            playerLives -= 1;
            GameManager.CheckGameState(this);
            print("Player lives: " + playerLives);
            _isCollided = true;
        }
        Invoke("setCollusionActive", protectionTime);
    }

    void setCollusionActive()
    {
        _isCollided = false;
    }

    void AnimatePlayer()
    {
        //TODO
    }

    private void RespondToMovement()
    {
        xVector = CrossPlatformInputManager.GetAxis("Horizontal");
        yVector = CrossPlatformInputManager.GetAxis("Vertical");
        transform.position += new Vector3(xVector, yVector, 0) * speed * Time.deltaTime;

    }
}
