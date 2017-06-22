using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAndKill : MonoBehaviour {

    public GameObject explosion;
    public GameObject player_explosion;
    private GameController go;
    public int scoreValue;

    private void Start()
    {
        go = FindObjectOfType<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            go.UpdateScore(scoreValue);
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            Instantiate(player_explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            go.GameOver();
        }
    }
}
