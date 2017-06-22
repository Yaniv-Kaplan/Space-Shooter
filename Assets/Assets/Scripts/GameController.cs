using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float wait_before_spawn;
    public float wait_between;

    public GUIText gameLost;
    public GUIText gameReset;
    public GUIText gameScore;

    private bool reset;
    private bool over;
    private int currentScore;

    void Start()
    {
        reset = false;
        over = false;

        currentScore = 0;
        gameScore.text = "";
        gameLost.text = "";
        gameReset.text = "";
        StartCoroutine(SpawnWaves());    
    }

    void Update()
    {
        if (reset)
        {
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("Main");
            }
        }    
    }


    IEnumerator SpawnWaves()
    {
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                if (over)
                {
                    reset = true;
                    gameReset.text = "To reset game press 'R'";
                    break;
                }
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(wait_before_spawn);
            }
            yield return new WaitForSeconds(wait_between);
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        gameLost.text = "Game Over!";
        over = true;
    }

    public void UpdateScore(int pointsToAdd)
    {
        currentScore = currentScore+pointsToAdd;
        gameScore.text = "Score: " +currentScore;
    }
}
