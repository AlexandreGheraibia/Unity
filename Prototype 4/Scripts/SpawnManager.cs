using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab, powerupPrefab; 
    float spawnBound = 9;
    private int enemiesByWave = 1;

    // Start is called before the first frame update
    void Start()
    {
        spawnWaves(enemiesByWave);
    }
    void spawnWaves(int enemiestoSpawn)
    {
            Enumerable.Range(0, enemiestoSpawn).ToList().ForEach(id => Instantiate(enemyPrefab, generateEnemiesSpawnPosition(), enemyPrefab.transform.rotation));
            float powerCount = GameObject.FindGameObjectsWithTag("Powerup").Length;
            if (powerCount == 0)
            {
                Instantiate(powerupPrefab, generateEnemiesSpawnPosition(), powerupPrefab.transform.rotation);
            }
    }
    // Update is called once per frame
    void Update()
    {
        float enemiesCount = FindObjectsOfType<EnemyController>().Length;
        if (enemiesCount == 0)
        {
            spawnEnemiesWaves(++enemiesByWave);
        }
       
    }

    Vector3 generateEnemiesSpawnPosition()
    {
        float spawnX = Random.Range(-spawnBound,spawnBound);
        float spawnZ = Random.Range(-spawnBound, spawnBound);
        return new Vector3(spawnX, 0, spawnZ);
    }
}
