using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpwanManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float[] bounds= {-20,20 };
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimals", 2f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomAnimals() {
        int i = Random.Range(1, 4); ;
        animalPrefabs.Take(i).ToList().ForEach(animal => {
            var x = Random.Range(bounds[0], bounds[1]);
            Instantiate(animal, new Vector3(x, 0, 20), animal.transform.rotation);
        });
    }
}
