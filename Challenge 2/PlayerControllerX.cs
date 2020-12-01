using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    float spendTime=0;
    // Update is called once per frame
    void Update()
    {
         spendTime+=Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space)&& spendTime > 1.0f)
        {
            spendTime = 0;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
