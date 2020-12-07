using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MoveLeft : MonoBehaviour
{
    public float speed=30.0f;
    private PlayerController pController;
    // Start is called before the first frame update
    void Start()
    {
        pController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
       if(!pController.gameOver)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
