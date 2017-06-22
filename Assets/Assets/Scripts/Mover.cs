using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;
    public Rigidbody shot;

    void Start()
    {
        shot.velocity = transform.forward*speed;
    }

}
