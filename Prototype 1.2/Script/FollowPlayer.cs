using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject vehicule;
    // Start is called before the first frame update
    //Awake method run when the object is create. Whereas 
    //start method run when the scene is create.
    void Start()
    {
        transform.parent = vehicule.transform;
    }

    // Update is called once per frame
    void Update()
    {
       
    }   
}
