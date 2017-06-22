using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundry
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public Rigidbody player;
    public Boundry edge;
    public float tilt;

    public GameObject shot;
    public Transform shotSpwan;

    public float fireRate;
    private float nextShot;

    void Update()
    {
       if(Input.GetButton("Fire1") && Time.time > nextShot)
        {
            nextShot = Time.time + fireRate;
            Instantiate(shot, shotSpwan.position, shotSpwan.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMove, 0.0f, verticalMove);
        player.velocity = movement * speed;

        player.position = new Vector3
        (
            Mathf.Clamp(player.position.x, edge.xMin, edge.xMax),
            0.0f,
            Mathf.Clamp(player.position.z, edge.zMin, edge.zMax)
        );

        player.rotation = Quaternion.Euler(0.0f, 0.0f, player.velocity.x * -tilt);
    }
}
