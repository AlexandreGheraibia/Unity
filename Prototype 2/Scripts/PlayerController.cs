using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float xInput;
    public float speed;
    public float[] Bounds = { -20.0f, 20.0f };
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //retrieves player input
        xInput = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        //keep the player in bounds
        if (transform.position.x + xInput >= Bounds[0] && transform.position.x + xInput <= Bounds[1])
        {

            transform.Translate(xInput, 0, 0);
        }
        //launch a projectilPrefabs from the player
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab,transform.position,transform.rotation);
        }
    }
}
