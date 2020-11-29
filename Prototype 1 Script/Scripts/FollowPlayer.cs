using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject vehicule;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = vehicule.transform;
    }

    // Update is called once per frame
    void Update()
    {
       
    }   
}
