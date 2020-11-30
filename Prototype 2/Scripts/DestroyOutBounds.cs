using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBounds : MonoBehaviour
{
    public float[] bounds= {-30,30 };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (transform.position.z > bounds[1] || transform.position.z < bounds[0])
        {
            //it's a game over, if an animal succeed to reach the bottom bound
            if (transform.position.z < bounds[0]) {
                Debug.Log("Game over");
            }
            Destroy(gameObject);
        }
    }
}
