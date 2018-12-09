using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {

    [SerializeField]
    public float speed = 0.3f;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 offset = new Vector2(0f, Time.deltaTime * speed);
        Renderer render = GetComponent<Renderer>();
        render.material.mainTextureOffset += offset;
	}
}
