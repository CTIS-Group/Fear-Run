﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTester : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject otherGO = col.gameObject;
        print("Collided with " + otherGO.tag + ".");
    }
}
