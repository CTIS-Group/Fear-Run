using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashingObstacle : MonoBehaviour {

    [SerializeField]
    float smashDelay = 2f;
    [SerializeField]
    float gapDistance = 2f;
    [SerializeField]
    float smashTime = 0.4f;
    enum AnimateState { BackOff, Smash};
    AnimateState animateState = AnimateState.BackOff;
    float backOffSpeed,
        smashSpeed;
    float lastSmashTime;
	// Use this for initialization
	void Start ()
    {
        int index = 0;
        foreach (Transform child in transform)
        {
            child.localPosition = new Vector3(-2 + index * 4, 0);
            index++;
        }
        // /2.0f is there because of 2 objects are moving to each other and they should move only gapDistance / 2 size
        backOffSpeed = gapDistance / smashDelay / 2.0f;
        smashSpeed = gapDistance / smashTime / 2.0f;
        lastSmashTime = Time.time;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(animateState == AnimateState.BackOff)
        {
            int direction = -1;
            foreach (Transform child in transform)
            {
                child.localPosition = child.localPosition + new Vector3(direction * backOffSpeed * Time.deltaTime, 0);
                direction = 1;
            }
            if (lastSmashTime + smashDelay < Time.time)
                animateState = AnimateState.Smash;
        }
        else
        {
            int direction = 1;
            foreach (Transform child in transform)
            {
                child.localPosition = child.localPosition + new Vector3(direction * smashSpeed * Time.deltaTime, 0);
                direction = -1;
            }
            if(lastSmashTime + smashDelay + smashTime <= Time.time)
            {
                lastSmashTime = Time.time;
                animateState = AnimateState.BackOff;
            }
        }
	}
}
