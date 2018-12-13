using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacles : MonoBehaviour {

    [SerializeField]
    float movementSpeed = 10f;
    [SerializeField]
    float gapBetweenObstacles = 1f;
    Vector3 startPoint;
	// Use this for initialization
	void Start () {
        int index = 0;
        foreach (Transform child in transform)
        {
            child.localPosition = new Vector3(-5 + index * gapBetweenObstacles + index * 2f, 0);
            index++;
        }
        startPoint = new Vector3(-5 + +index * gapBetweenObstacles + index * 2f, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        foreach (Transform child in transform)
        {
            child.localPosition = child.localPosition + new Vector3(-movementSpeed * Time.deltaTime, 0);
            if (child.localPosition.x <= -5)
            {
                child.localPosition = startPoint;
            }
        }
    }
}
