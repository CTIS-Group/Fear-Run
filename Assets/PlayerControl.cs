#define DEBUG_MODE
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
    public float protectionTime = 1.5f;
    [SerializeField]
    public int playerLives = 3;

    [Header("Degrees to turn to animate walking effect")]
    public float animationDegree = 30f;
    [Header("Speed of walking animation")]
    public float animationSpeed = 1f;

    private bool _isCollided = false;

    // Use this for initialization
    void Awake () {
		
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
            DecreasePlayerLives();
            setCollisionDeactive();
        }
        Invoke("setCollisionActive", protectionTime);
    }

    void DecreasePlayerLives()
    {
        playerLives = playerLives - 1;
        GameManager.CheckGameState(this);

#if DEBUG_MODE
        print("Player lives: " + playerLives);
#endif
    }

    void setCollisionActive()
    {
        _isCollided = false;
        GetComponent<CircleCollider2D>().enabled = true;
    }

    void setCollisionDeactive()
    {
        _isCollided = true;
        GetComponent<CircleCollider2D>().enabled = false;
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
