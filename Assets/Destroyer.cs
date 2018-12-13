using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject.transform.parent.gameObject);
    }
    void OnTriggerEnter2d(Collision2D col)
    {
    }
}
