using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private readonly float spawnLimitXLeft = -22;
    private readonly float spawnLimitXRight = 7;
    private readonly float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnIntervalLowerBound = 3.0f;
    private float spawnIntervalHeighterBound = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        /*make the ball spawning at the value of spawnInterval and start
            at the startDelay
         */
        InvokeRepeating("SpawnRandomBall", startDelay, Random.Range(spawnIntervalLowerBound, spawnIntervalHeighterBound));
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location

        //Generate a random index of spawn ball

        Instantiate(ballPrefabs[Random.Range(0,3)], spawnPos, ballPrefabs[0].transform.rotation);
    }

}
