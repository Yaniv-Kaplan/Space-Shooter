using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public float tumble;
    public Rigidbody astroid;

    void Start()
    {
        astroid.angularVelocity = Random.insideUnitSphere * tumble;    
    }
}
