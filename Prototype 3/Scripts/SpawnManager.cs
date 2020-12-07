using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Prefabs;
    private float startDelay=1;
    private float repeatRate = 2;
    private PlayerController pController;
    // Start is called before the first frame update
    void Start()
    {
        pController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnBarrel", startDelay, repeatRate);
       
    }

    private void SpawnBarrel() {
        if(!pController.gameOver)
            Instantiate(Prefabs);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
